using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitProjectGrid()
        {
            GridPanel panel = ProjectGrid.PrimaryGrid;
            panel.CheckBoxes = true;
            panel.ShowCheckBox = false;
            panel.ShowTreeButtons = true;
            panel.ShowTreeLines = true;
            panel.ShowRowGridIndex = true;
            panel.RowDragBehavior = RowDragBehavior.GroupMove;

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

        private void ToRegisterClick(object sender, EventArgs e)
        {
            GridButtonXEditControl ddc = sender as GridButtonXEditControl;
            GridRow row = ddc.EditorCell.GridRow;
            if ("".Equals(row.Cells["gcId"].Value))
            {
                MessageBox.Show("请先保存项目，然后收存资料");
                return;
            }
            int id = (int)row.Cells["gcId"].Value;
            row.Cells[3].EditorDirty = false;
            ArchiveForm archiveFrom = new ArchiveForm(id);
            this.Hide();
            archiveFrom.ShowDialog();
            this.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitProjectGrid();
            LoadProjectInfoList();
        }

        private void RegisterDataSavingTask()
        {
            ArchiveInfoTimer.Start();
        }

         
        private void ArchiveInfoTimer_Tick(object sender, EventArgs e)
        {
            
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
                gr[0].Value = ai.ProjectName;
                gr[2].Value = ai.IsFreeze;
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

            foreach (GridColumn gc in ArchiveGrid.PrimaryGrid.Columns)
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

        private void btnRegisterProject_Click(object sender, EventArgs e)
        {
            GridRow gr = ProjectGrid.PrimaryGrid.NewRow();
            ProjectGrid.PrimaryGrid.Rows.Add(gr);
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            btnSaveProject.Focus();
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
                //SQLiteTransaction tx = conn.BeginTransaction();
                //cmd.Transaction = tx;
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
                    //tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    //tx.Rollback();
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
            gr[2].ReadOnly = ai.IsFreeze == 1; // AllowEdit
            if (ai.Id == 0)
            {
                using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
                {
                    conn.Open();
                    SQLiteCommand sql_cmd = conn.CreateCommand();
                    sql_cmd.CommandText = "select seq from sqlite_sequence where name='ProjectInfo'"; //"select Id from ProjectInfo where ProjectName='{0}'"; // 
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
            pi.IsFreeze = gr[2].Value == null ? 0 : Convert.ToInt16(gr[2].Value);
            return pi;
        }

        private void ProjectGrid_RowMarkedDirty(object sender, GridEditEventArgs e)
        {
            
        }

        private void ProjectGrid_EndEdit(object sender, GridEditEventArgs e)
        {
            if (e.GridCell.ColumnIndex == 0 && !preEditValue.Equals(e.GridCell.Value))
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

    internal class ArchiveDropDownEditControl : GridComboTreeEditControl
    {
        public ArchiveDropDownEditControl(IEnumerable orderArray)
        {
            DataSource = orderArray;
        }
    }
}
