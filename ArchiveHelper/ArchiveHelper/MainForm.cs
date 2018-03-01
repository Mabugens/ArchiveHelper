using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveHelper
{
    public partial class MainForm : Form
    {
        private List<ProjectInfo> ProjectList = new List<ProjectInfo>();
        private List<GridRow> EditList = new List<GridRow>();
        private object preEditValue = null;
        private bool CtrlPressed = false;

        public MainForm()
        {
            InitializeComponent();
            ProjectGrid.MouseWheel += new System.Windows.Forms.MouseEventHandler(mouseWheel);
            btnRegisterProject.Visible = Authority.AllowDelete;
        }

        private void InitProjectGrid()
        {
            GridPanel panel = ProjectGrid.PrimaryGrid;
            panel.CheckBoxes = true;
            panel.ShowCheckBox = false;
            panel.ShowTreeButtons = true;
            panel.ShowTreeLines = true;
            panel.ShowRowGridIndex = true;
            panel.EnableColumnFiltering = true;
            panel.FilterLevel = FilterLevel.AllConditional;
            panel.FilterMatchType = FilterMatchType.RegularExpressions;
            panel.RowDragBehavior = RowDragBehavior.GroupMove;
            panel.DefaultVisualStyles.CellStyles.Default.Font = new Font("宋体", 12f);

            //panel.Columns["gcFreeze"].AllowEdit = Authority.AllowDelete;
            panel.Columns["gcFreeze"].EditorType = typeof(ArchiveDropDownEditControl);
            //GridTextBoxDropDownEditControl gbc = panel.Columns["gcFreeze"].RenderControl as GridTextBoxDropDownEditControl;
            //gbc.OnText = "激活";
            //gbc.OffText = "冻结";
            //gbc.OnValue = 0;
            //gbc.OffValue = 1;
            string[] objs = new string[2] { "激活", "冻结" };
            panel.Columns["gcFreeze"].EditorParams = new object[] { objs };
            panel.Columns["gcProjectName"].AllowEdit = Authority.AllowDelete;
            GridButtonXEditControl ddc =
                panel.Columns["gcToRegister"].EditControl as GridButtonXEditControl;
            if (ddc != null)
            {
                ddc.Visible = true;
                ddc.Text = "查看资料";
                ddc.UseCellValueAsButtonText = false;
                ddc.Click += ToRegisterClick;
            }
        }

        private void mouseWheel(object sender, MouseEventArgs e)
        {
            if (CtrlPressed)
            {
                GridPanel panel = ProjectGrid.PrimaryGrid;
                CellVisualStyles cs = panel.DefaultVisualStyles.CellStyles;
                if (e.Delta > 0){
                    Font f = new Font(cs.Default.Font.FontFamily, cs.Default.Font.Size + 1);
                    cs.Default.Font = f;
                    panel.DefaultRowHeight++;
                    panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = f;
                }
                else
                {
                    if (cs.Default.Font.Size <= 8)
                    {
                        return;
                    }
                    Font f = new Font(cs.Default.Font.FontFamily, cs.Default.Font.Size - 1);
                    cs.Default.Font = f;
                    panel.DefaultRowHeight--;
                    panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = f;
                }
            }
        }

        private void ToRegisterClick(object sender, EventArgs e)
        {
            GridButtonXEditControl ddc = sender as GridButtonXEditControl;
            GridRow row = ddc.EditorCell.GridRow;
            if ("".Equals(row.Cells["gcId"].Value))
            {
                MessageBox.Show("请先保存项目，然后收存资料");
                return;
            }
            ProjectInfo pi = (ProjectInfo)row.Cells["gcId"].Tag;
            row.Cells[3].EditorDirty = false;
            ArchiveForm archiveFrom = new ArchiveForm(pi);
            this.Hide();
            archiveFrom.ShowDialog();
            this.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"backup"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"backup");
            }
            string sourceFile = AppDomain.CurrentDomain.BaseDirectory + @"archiveinfo.s3db";
            string destinationFile = AppDomain.CurrentDomain.BaseDirectory + @"backup\archiveinfo_"+DateTime.Now.ToString("yyMMdd_Hmmss") + ".s3db";
            bool isrewrite = true;
            System.IO.File.Copy(sourceFile, destinationFile, isrewrite); 
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitProjectGrid();
            LoadProjectInfoList();
            btnDelete.Visible = Authority.AllowDelete;
        }
            
        private void btnRefreshProject_Click(object sender, EventArgs e)
        {
            LoadProjectInfoList();
        }

        private void LoadProjectInfoList()
        {
            ProjectList.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = "select * from ProjectInfo order by Id desc ";
                SQLiteDataReader reader = sql_cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProjectInfo ai = new ProjectInfo();
                        ai.Id = reader.GetInt16(0);
                        ai.ProjectName = reader.GetString(1);
                        ai.IsFreeze = reader.GetInt16(2);
                        ProjectList.Add(ai);
                    }
                }
                reader.Close();
                conn.Close();
            }

            ProjectGrid.PrimaryGrid.Rows.Clear();
            foreach (ProjectInfo ai in ProjectList)
            {
                GridRow gr = ProjectGrid.PrimaryGrid.NewRow();
                gr[1].Value = ai.Id;
                gr[1].Tag = ai;
                gr[0].Value = ai.ProjectName;
                gr[0].AllowEdit = ai.IsFreeze == 0;
                gr["gcFreeze"].Value = ai.IsFreeze == 0 ? "激活" : "冻结";
                gr["gcFreeze"].AllowEdit = ai.IsFreeze == 0;
                ProjectGrid.PrimaryGrid.Rows.Add(gr);
            }
        }

        private void ProjectGrid_RowHeaderDoubleClick(object sender, GridRowHeaderDoubleClickEventArgs e)
        {
            GridPanel panel = ProjectGrid.PrimaryGrid;
            GridRow row = (GridRow)panel.Rows[e.GridRow.RowIndex];
            row.Rows.Clear();
            int id = (int)row.Cells["gcId"].Value;
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                try
                {
                    string Id = row.Cells[0].Value.ToString();
                    string strsql = string.Format("select * from ArchiveInfo where ProjectId={0} order by ArchDate desc", id);
                    cmd.CommandText = strsql;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        GridPanel subPanel = new GridPanel();
                        SetArchivePanelColumn(subPanel);
                        while (reader.Read())
                        {
                            ArchiveInfo ai = new ArchiveInfo();
                            ai.Id = reader.GetInt16(0);
                            ai.ArchiveName = reader.GetString(1);
                            ai.ArchType = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                ai.ArchDate = Convert.ToDateTime(reader.GetString(3));
                            }
                            ai.DispatchNum = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            ai.Copies = reader.GetInt16(5);
                            ai.Remaining = reader.GetInt16(6);
                            ai.StorageLocation = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            ai.Handler = reader.IsDBNull(8) ? "" : reader.GetString(8);

                            GridRow gr = new GridRow();
                            gr.Cells.Add(new GridCell(ai.ArchiveName));
                            gr.Cells.Add(new GridCell(ai.Id));
                            gr.Cells.Add(new GridCell(ai.ArchType));
                            if (ai.ArchDate != null)
                            {
                                gr.Cells.Add(new GridCell(ai.ArchDate.ToString()));//"yyyy-MM-dd"
                            }
                            gr.Cells.Add(new GridCell(ai.DispatchNum));
                            gr.Cells.Add(new GridCell(ai.Copies));
                            gr.Cells.Add(new GridCell(ai.Remaining));
                            gr.Cells.Add(new GridCell(ai.StorageLocation));
                            gr.Cells.Add(new GridCell(ai.Handler));

                            subPanel.Rows.Add(gr);
                        }
                        e.GridRow.Rows.Add(subPanel);
                    }
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    throw new Exception(E.Message);
                }
            }
        }

        private void SetArchivePanelColumn(GridPanel subPanel)
        {
            subPanel.Caption.Visible = true;
            subPanel.Caption.RowHeight = 40;
            subPanel.Caption.Text = "资料记录";
            GridColumnCollection sourceColumns = GetArchiveColumns();
            foreach (GridColumn gc in sourceColumns)
            {
                GridColumn col = new GridColumn()
                {
                    HeaderText = gc.HeaderText,
                    Width = gc.Width,
                    Visible = gc.Visible,
                    ReadOnly = true
                };
                subPanel.Columns.Add(col);
            }
        }

        private GridColumnCollection GetArchiveColumns()
        {
            GridPanelProvider provider = new ArchiveGridPanelProvider();
            return provider.GetColumns();
        }

        private void btnRegisterProject_Click(object sender, EventArgs e)
        {
            GridRow gr = ProjectGrid.PrimaryGrid.NewRow();
            ProjectGrid.PrimaryGrid.Rows.Add(gr);
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            btnSaveProject.Focus();
            ProjectGrid.EndUpdate();
            if (EditList.Count == 0)
            {
                ToastMessage.Show(this, "没有可保存的内容。");
                return;
            }
            SaveProjectInfo(EditList);
            EditList.Clear();
            ToastMessage.Show(this, "已保存。");    
        }

        private void SaveProjectInfo(List<GridRow> list)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                try
                {
                    foreach (GridRow gr in list)
                    {
                        ProjectInfo ai = GridCellMapToProjectInfo(gr);

                        string strsql = GenProjectSQL(ai);
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                        ProjectInfoRetreeIdFixRowCellReadonly(gr, ai);
                        ProjectList.Add(ai);
                    }
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    MessageBox.Show(cmd.CommandText + Environment.NewLine + E.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ProjectInfoRetreeIdFixRowCellReadonly(GridRow gr, ProjectInfo ai)
        {
            gr.RowDirty = false;
            gr[0].AllowEdit = ai.IsFreeze == 0;
            gr[2].AllowEdit = ai.IsFreeze == 0;
            if (ai.Id == 0)
            {
                using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
                {
                    conn.Open();
                    SQLiteCommand sql_cmd = conn.CreateCommand();
                    sql_cmd.CommandText = "select seq from sqlite_sequence where name='ProjectInfo'";
                    int newId = Convert.ToInt32(sql_cmd.ExecuteScalar());
                    gr["gcId"].Value = newId;
                    conn.Close();
                }
            }
        }

        private string GenProjectSQL(ProjectInfo ai)
        {
            if (ai.Id == 0)
            {
                return "insert into ProjectInfo(ProjectName) values ('" + ai.ProjectName + "')";
            }
            return "update ProjectInfo set ProjectName='" + ai.ProjectName + "', IsFreeze=" + ai.IsFreeze + " where id =" + ai.Id;
        }

        private ProjectInfo GridCellMapToProjectInfo(GridRow gr)
        {
            ProjectInfo pi = new ProjectInfo();
            pi.Id =  string.IsNullOrEmpty(gr[1].Value.ToString()) ? 0 : Convert.ToInt16(gr[1].Value);
            pi.ProjectName = (string)gr[0].Value;
            pi.IsFreeze = gr[2].Value.ToString().Equals("激活") ? 0 : 1;
            return pi;
        }

        private void ProjectGrid_RowMarkedDirty(object sender, GridEditEventArgs e)
        {
            
        }

        private void ProjectGrid_EndEdit(object sender, GridEditEventArgs e)
        {
            if ((e.GridCell.ColumnIndex == 0 && !preEditValue.Equals(e.GridCell.Value))|| e.GridCell.ColumnIndex == 2)
            {
                EditList.Add(e.GridCell.GridRow);
            }
        }
        
        private void ProjectGrid_BeginEdit(object sender, GridEditEventArgs e)
        {            
            preEditValue = (null == e.GridCell.Value) ? "" : e.GridCell.Value;
        }

        private void BtnChangeMyPsd_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditList.Count > 0)
            {
                e.Cancel = true;
                ToastMessage.Show(this, "有未保存的项目，请保存完之后再退出。");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool IsWarninged = false;
            GridPanel panel = ProjectGrid.PrimaryGrid;
            int DeleteCount = 0;
            foreach (GridRow row in panel.Rows)
            {
                if (row.Checked && !row.Cells["gcId"].IsValueNull)
                {
                    int id = int.Parse(row.Cells["gcId"].Value.ToString());
                    string name = row.Cells["gcProjectName"].Value.ToString();
                    if (!CheckDelete(id))
                    {
                        MessageBox.Show(string.Format("项目“{0}”已收存资料，无法删除。若要删除，请先删除该项目下所有资料。 ", name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;
                    }
                    if (!IsWarninged)
                    {
                        bool IsCancel = MessageBox.Show("确定要删除项目吗？ ", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2).Equals(DialogResult.No);
                        if (IsCancel)
                        {
                            return;
                        }
                        IsWarninged = true;
                    }
                    try
                    {
                        DeleteProjectInfo(id);
                        row.IsDeleted = true;
                        DeleteCount++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (DeleteCount > 0)
            {
                ToastMessage.Show(this, "已删除 " + DeleteCount.ToString() + " 条记录");
            }
        }

        private void DeleteProjectInfo(int id)
        {
            string sql = string.Format("Delete from ProjectInfo where Id = {0}", id);
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private bool CheckDelete(int id)
        {
            string sql = string.Format("select id from ArchiveInfo where ProjectId = {0}", id);
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                SQLiteDataReader reader = cmd.ExecuteReader();
                return !reader.HasRows;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlPressed = e.KeyValue.Equals(17);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            CtrlPressed = !e.KeyValue.Equals(17);
        }

        private void ProjectGrid_EditorValueChanged(object sender, GridEditEventArgs e)
        {
            
        }

        private void ProjectGrid_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            if (e.GridCell.GridColumn.EditControl is ArchiveDropDownEditControl)
            {
                //ArchiveDropDownEditControl gbc = e.GridCell.EditControl as ArchiveDropDownEditControl;
                if (e.OldValue.Equals("激活") && e.NewValue.Equals("冻结"))
                {
                    DialogResult dr = MessageBox.Show("确实要冻结该项目吗？ 冻结项目以后，该项目的所有资料将无法借出/归还，也不能进行任何维护操作。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dr.Equals(DialogResult.No))
                    {
                        e.GridCell.Value = "激活";
                        return;
                    }
                    ProjectInfo pi = (ProjectInfo)e.GridCell.GridRow[1].Tag;
                    pi.IsFreeze = 1;
                    EditList.Add(e.GridCell.GridRow);
                }
            }
        }
        
    }

    internal class ArchiveTypeComboBox : GridComboBoxExEditControl
    {
        public ArchiveTypeComboBox(IEnumerable orderArray)
        {
            DataSource = orderArray;
        }
    }
    
}
