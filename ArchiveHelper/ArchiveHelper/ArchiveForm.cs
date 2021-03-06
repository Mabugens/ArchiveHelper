﻿using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArchiveHelper
{
    public partial class ArchiveForm : Form
    {
        private List<ArchiveInfo> ArchiveInfoList = new List<ArchiveInfo>();
        private string[] ArchTypes = { "证件", "红头", "文本", "图纸", "合同", "其他" };
        private ProjectInfo Project;
        private bool CtrlPressed = false;

        public ArchiveForm()
        {
            InitializeComponent();
        }

        public ArchiveForm(ProjectInfo pi)
        {
            InitializeComponent();
            this.Project = pi;
            btnDelete.Visible = Authority.AllowDelete;
            ArchiveGrid.MouseWheel += new System.Windows.Forms.MouseEventHandler(mouseWheel);
        }

        private void InitArchiveGrid()
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            panel.ShowCheckBox = !Authority.AllowDelete;
            panel.CheckBoxes = Authority.AllowDelete;
            panel.ShowTreeButtons = true;
            panel.ShowTreeLines = true;
            panel.ShowRowGridIndex = true;
            panel.EnableColumnFiltering = true;
            panel.FilterLevel = FilterLevel.AllConditional;
            panel.FilterMatchType = FilterMatchType.RegularExpressions;
            panel.RowDragBehavior = RowDragBehavior.GroupMove;
            panel.DefaultVisualStyles.CellStyles.Default.Font = new Font("宋体", 11f);
            panel.Caption.Text = Project.ProjectName;
            panel.ReadOnly = Project.IsFreeze == 1;

            panel.Rows.Clear();
            panel.Columns[2].EditorType = typeof(ArchiveTypeComboBox);
            panel.Columns[2].EditorParams = new object[] { ArchTypes };

            panel.Columns[3].EditorType = typeof(GridDateTimePickerEditControl);
            panel.Columns[3].RenderType = typeof(GridDateTimePickerEditControl);
            panel.Columns[3].DefaultNewRowCellValue = DateTime.Now;

            panel.Columns[5].EditorType = typeof(GridDoubleIntInputEditControl);
            GridDoubleIntInputEditControl de = (GridDoubleIntInputEditControl)panel.Columns[5].EditControl;
            panel.Columns[5].DataType = typeof(int);
            de.MinValue = 0;

            panel.Columns[6].EditorType = typeof(GridDoubleIntInputEditControl);
            GridDoubleIntInputEditControl de5 = (GridDoubleIntInputEditControl)panel.Columns[6].EditControl;
            panel.Columns[6].DataType = typeof(int);
            de5.MinValue = 0;

            GridColumn gcRegisterDate = panel.Columns["gcRegisteDate"];
            gcRegisterDate.EditorType = typeof(GridDateTimePickerEditControl);
            gcRegisterDate.RenderType = typeof(GridDateTimePickerEditControl);
            gcRegisterDate.DefaultNewRowCellValue = DateTime.Now;

            GridButtonXEditControl ddcLend = panel.Columns["gcLend"].EditControl as GridButtonXEditControl;
            if (ddcLend != null)
            {
                ddcLend.Visible = true;
                ddcLend.Text = "借出";
                ddcLend.UseCellValueAsButtonText = false;
                ddcLend.Click += ToLendClick;
            }

            GridButtonXEditControl ddcReturn = panel.Columns["gcReturn"].EditControl as GridButtonXEditControl;
            if (ddcReturn != null)
            {
                ddcReturn.Visible = true;
                ddcReturn.Text = "归还";
                ddcReturn.UseCellValueAsButtonText = false;
                ddcReturn.Click += ToReturnClick;
            }
        }

        private void ToReturnClick(object sender, EventArgs e)
        {
            GridButtonXEditControl ddc = sender as GridButtonXEditControl;
            GridRow row = ddc.EditorCell.GridRow;
            if (row.Cells["gcArchName"].Value == null)
            {
                MessageBox.Show("请先保存资料，然后再归还资料");
                return;
            }
            ArchiveInfo ai = (ArchiveInfo)row.Cells["gcId"].Tag;
            ReturnForm form = new ReturnForm(ai);
            form.ShowDialog();
            btnRefreshArchive_Click(sender, e);
            NavigateTo(ai.ArchiveName);
        }

        private void ToLendClick(object sender, EventArgs e)
        {
            GridButtonXEditControl ddc = sender as GridButtonXEditControl;
            GridRow row = ddc.EditorCell.GridRow;
            if (row.Cells["gcArchName"].Value == null)
            {
                MessageBox.Show("请先保存资料，然后再借出资料");
                return;
            }
            ArchiveInfo ai = (ArchiveInfo)row.Cells["gcId"].Tag;
            LendForm form = new LendForm(ai);
            form.ShowDialog();
            btnRefreshArchive_Click(sender, e);
            NavigateTo(ai.ArchiveName);
        }

        private void NavigateTo(string archiveName)
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            foreach(GridRow row in panel.Rows){
                if (row.Cells["gcArchName"].Value.ToString().Equals(archiveName))
                {
                    row.SetActive(true);
                    row.IsSelected = true;
                    break;
                }
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            GridRow gr = ArchiveGrid.PrimaryGrid.NewRow();
            ArchiveGrid.PrimaryGrid.Rows.Add(gr);
        }

        private void btnRefreshArchive_Click(object sender, EventArgs e)
        {
            ArchiveGrid.PrimaryGrid.Rows.Clear();
            ArchiveInfoList.Clear();
            GetArchivesList();
            LoadArchiveList();
        }

        private void GetArchivesList()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = string.Format("select a.Id,a.ArchiveName,ArchType,ArchDate,DispatchNum,a.Copies,Remaining,StorageLocation,a.Handler,ProjectId, RegisterDate, Remark"
                    + ", count(b.Id) bcount from ArchiveInfo a left join lendArchive b on a.ArchiveName = b.ArchiveName where ProjectId = {0} "
                    + " group by a.Id,a.ArchiveName,ArchType,ArchDate,DispatchNum,a.Copies,Remaining,StorageLocation,a.Handler,ProjectId, RegisterDate, Remark "
                    + " order by ArchDate desc ", Project.Id);
                SQLiteDataReader reader = sql_cmd.ExecuteReader();
                if (reader.HasRows)
                {
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
                        ai.ProjectId = reader.GetInt16(9);
                        ai.RegisterDate = reader.IsDBNull(10) ? DateTime.Now : Convert.ToDateTime(reader.GetString(10));
                        ai.Remark = reader.IsDBNull(11) ? "" : reader.GetString(11);
                        ai.HasLend = reader.GetInt16(12) > 0;
                        ai.Project = Project;
                        ArchiveInfoList.Add(ai);
                    }
                }
                reader.Close();
                conn.Close();
            }
        }

        private void LoadArchiveList()
        {
            ArchiveGrid.PrimaryGrid.Rows.Clear();
            foreach (ArchiveInfo ai in ArchiveInfoList)
            {
                GridRow gr = ArchiveGrid.PrimaryGrid.NewRow();
                gr[1].Value = ai.Id;
                gr[0].Value = ai.ArchiveName;
                gr[2].Value = ai.ArchType;
                if (ai.ArchDate != null)
                {
                    gr[3].Value = ai.ArchDate.ToString();//"yyyy-MM-dd"
                }
                gr[4].Value = ai.DispatchNum;
                gr[5].Value = ai.Copies;
                gr[6].Value = ai.Remaining;
                if (ai.Copies > ai.Remaining)
                {
                    gr[6].CellStyles.Default.Background.Color1 = Color.RoyalBlue;
                    if (ai.Remaining == 0)
                    {
                        gr[6].CellStyles.Default.Background.Color1 = Color.DarkGray;
                    }
                }
                gr[7].Value = ai.StorageLocation;
                gr[8].Value = ai.Handler;
                gr[9].Value = ai.ProjectId;
                gr[6].ReadOnly = ai.HasLend;
                gr[10].Value = ai.RegisterDate != null ? ai.RegisterDate.ToString() : "";
                gr[11].Value = ai.Remark;
                gr[1].Tag = ai;
                ArchiveGrid.PrimaryGrid.Rows.Add(gr);
            }
        }
        
        private void btnSaveRegister_Click(object sender, EventArgs e)
        {
            btnRegistration.Focus();
            List<GridRow> list = GetUnSavedList();
            if (list.Count == 0)
            {
                ToastMessage.Show(this, "没有可保存的内容。");
                return;
            }
            SaveArchiveInfo(list);
            ToastMessage.Show(this, "已保存。"); 
        }

        private List<GridRow> GetUnSavedList()
        {
            List<GridRow> list = new List<GridRow>();
            foreach (GridRow gr in ArchiveGrid.PrimaryGrid.Rows)
            {
                if (gr.RowDirty && !gr.IsDeleted)
                {
                    list.Add(gr);
                }
            }
            return list;
        }

        private void SaveArchiveInfo(List<GridRow> list)
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
                        ArchiveInfo ai = GridCellMapToArchiveInfo(gr);
                        string strsql = GenSQL(ai);
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                        ArchiveInfoRetreeIdFixRowCellReadonly(gr, ai);
                        UpdateCascadeArchiveName(ai);
                        ArchiveInfoList.Add(ai);
                    }
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    string msg = "保存失败。原因：" + E.Message;
                    if (E.Message.Contains("UNIQUE constraint failed"))
                    {
                        msg = "保存失败。原因：资料名称重复。";
                    }
                    MessageBox.Show(msg);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void UpdateCascadeArchiveName(ArchiveInfo ai)
        {
            if (ai.Id < 1)
            {
                return;
            }
            string sql = string.Format("update LendArchive set ArchiveName = '{1}' where ArchId = {0}", ai.Id, ai.ArchiveName);
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                sql = string.Format("update ReturnArchive set ArchiveName = '{1}' where ArchId = {0}", ai.Id, ai.ArchiveName);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private string GenSQL(ArchiveInfo ai)
        {
            if (ai.Id == 0)
            {
                return "insert into ArchiveInfo(archiveName, ArchType, ArchDate, DispatchNum, Copies, Remaining, StorageLocation, Handler, ProjectId, RegisterDate, Remark) values ('"
                    + ai.ArchiveName + "','" + ai.ArchType + "','" + ai.ArchDate + "','" + ai.DispatchNum + "'," + ai.Copies + "," + ai.Remaining 
                    + ",'" + ai.StorageLocation + "','" + ai.Handler + "', " + ai.ProjectId + ", '" + ai.RegisterDate + "','" + ai.Remark + "')";
            }
            return "update ArchiveInfo set archiveName='" + ai.ArchiveName + "', ArchType='" + ai.ArchType + "', ArchDate='" + ai.ArchDate +
                "', DispatchNum='" + ai.DispatchNum + "', Copies=" + ai.Copies + ", Remaining=" + ai.Remaining + ", StorageLocation='" + ai.StorageLocation
                + "', Handler='" + ai.Handler + "', ProjectId=" + ai.ProjectId + ",RegisterDate='" + ai.RegisterDate + "', Remark='" + ai.Remark + "' where id =" + ai.Id;
        }

        private ArchiveInfo GridCellMapToArchiveInfo(GridRow gr)
        {
            return new ArchiveInfo()
            {
                Id = string.IsNullOrEmpty(gr[1].Value.ToString()) ? 0 : Convert.ToInt16(gr[1].Value),
                ArchiveName = gr[0].Value.ToString(),
                ArchType = (string)gr[2].Value,
                ArchDate = Convert.ToDateTime(gr[3].Value),
                DispatchNum = (string)gr[4].Value,
                Copies = (null != gr[5].Value) ? int.Parse(gr[5].Value.ToString()) : 0,
                Remaining = (null != gr[6].Value) ? int.Parse(gr[6].Value.ToString()) : 0,
                StorageLocation = (string)gr[7].Value,
                Handler = (string)gr[8].Value,
                ProjectId = this.Project.Id,
                RegisterDate = Convert.ToDateTime(gr[10].Value),
                Remark = (string)gr[11].Value,
                HasLend = gr[6].ReadOnly,
                Project = this.Project
            };
        }
        private void ArchiveInfoRetreeIdFixRowCellReadonly(GridRow gr, ArchiveInfo ai)
        {
            gr.RowDirty = false;
            if (ai.Id == 0)
            {
                gr[6].ReadOnly = ai.HasLend;
                using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
                {
                    conn.Open();
                    SQLiteCommand sql_cmd = conn.CreateCommand();
                    sql_cmd.CommandText = "select seq from sqlite_sequence where name='ArchiveInfo'; ";
                    ai.Id = Convert.ToInt32(sql_cmd.ExecuteScalar());
                    gr["gcId"].Value = ai.Id;
                    ai.HasLend = false;
                    gr["gcId"].Tag = ai;
                    conn.Close();
                }
            }

        }
        private void ArchiveGrid_RowHeaderDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridRowHeaderDoubleClickEventArgs e)
        {
            e.GridRow.Rows.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                CreateReturnPanel(e, conn);
                CreateLendPanel(e, conn);
            }
        }

        private void CreateReturnPanel(GridRowHeaderDoubleClickEventArgs e, SQLiteConnection conn)
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            GridRow row = (GridRow)panel.Rows[e.GridRow.RowIndex];
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            try
            {
                int archId = int.Parse(row.Cells[1].Value.ToString());
                string strsql = string.Format("select * from ReturnArchive where ArchId={0} order by ReturnDate desc", archId);
                cmd.CommandText = strsql;
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    GridPanel subPanel = new GridPanel();
                    SetReturnPanelColumn(subPanel);
                    while (reader.Read())
                    {
                        GridRow gr = new GridRow();
                        gr.Cells.Add(new GridCell(reader.GetInt16(0)));
                        gr.Cells.Add(new GridCell(reader.GetString(1)));
                        if (!reader.IsDBNull(2))
                        {
                            gr.Cells.Add(new GridCell(Convert.ToDateTime(reader.GetString(2))));
                        }
                        gr.Cells.Add(new GridCell(reader.GetInt16(3)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(7) ? "" : reader.GetString(7)));
                        gr.Cells.Add(new GridCell(reader.GetInt16(5)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(6) ? "" : reader.GetString(6)));
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

        private void SetReturnPanelColumn(GridPanel subPanel)
        {
            subPanel.Caption.Visible = true;
            subPanel.Caption.RowHeight = 40;
            subPanel.Caption.Text = "归还记录";
            GridColumnCollection sourceColumns = GetReturnColumns();
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

        private GridColumnCollection GetReturnColumns()
        {
            ReturnGridPanelProvider provider = new ReturnGridPanelProvider();
            return provider.GetColumns();
        }

        private void CreateLendPanel(GridRowHeaderDoubleClickEventArgs e, SQLiteConnection conn)
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            GridRow row = (GridRow)panel.Rows[e.GridRow.RowIndex];
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            try
            {
                int archId = int.Parse(row.Cells[1].Value.ToString());
                string strsql = string.Format("select * from LendArchive where ArchId ={0} order by LendDate desc", archId);
                cmd.CommandText = strsql;
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    GridPanel subPanel = new GridPanel();
                    SetLendPanelColumn(subPanel);
                    while (reader.Read())
                    {
                        GridRow gr = new GridRow();
                        gr.Cells.Add(new GridCell(reader.GetInt16(0)));
                        gr.Cells.Add(new GridCell(reader.GetString(1)));
                        if (!reader.IsDBNull(2))
                        {
                            gr.Cells.Add(new GridCell(Convert.ToDateTime(reader.GetString(2))));
                        }
                        gr.Cells.Add(new GridCell(reader.GetInt16(3)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(4) ? "" : reader.GetString(4)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(5) ? "" : reader.GetString(5)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(9) ? "" : reader.GetString(9)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(7) ? "" : reader.GetString(7)));
                        if (!reader.IsDBNull(8))
                        {
                            gr.Cells.Add(new GridCell(Convert.ToDateTime(reader.GetString(8))));
                        }
                        gr.Cells.Add(new GridCell(reader.IsDBNull(6) ? "" : reader.GetString(6)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(10) ? "" : reader.GetString(10)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(11) ? "" : reader.GetString(11)));
                        subPanel.Rows.Add(gr);
                    }
                    e.GridRow.Rows.Add(subPanel);
                    e.GridRow.Expanded = true;
                }
            }
            catch (System.Data.SQLite.SQLiteException E)
            {
                throw new Exception(E.Message);
            }
        }

        private void SetLendPanelColumn(GridPanel subPanel)
        {
            subPanel.Caption.Visible = true;
            subPanel.Caption.RowHeight = 40;
            subPanel.Caption.Text = "借出记录";
            GridColumnCollection sourceColumns = GetLendColumns();
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

        private GridColumnCollection GetLendColumns()
        {
            GridPanelProvider provider = new LendGridPanelProvider();
            return provider.GetColumns();
        }

        private void ArchiveForm_Shown(object sender, EventArgs e)
        {
            InitArchiveGrid();
            ArchiveGrid.PrimaryGrid.Rows.Clear();
            GetArchivesList();
            LoadArchiveList();
        }

        private void ArchiveGrid_EndEdit(object sender, GridEditEventArgs e)
        {
            if (!e.GridCell.GridColumn.Name.Equals("gcAllCount")){
                return ;
            }
            object o = e.GridCell.GridRow.Cells["gcId"].Tag;
            ArchiveInfo ai = o as ArchiveInfo;
            if (ai == null || !ai.HasLend)
            {
                e.GridCell.GridRow.Cells["gcRemaining"].Value = e.GridCell.Value;
            }
            else
            {
                int newCount = Convert.ToInt32(e.GridCell.GridRow.Cells["gcAllCount"].Value);
                e.GridCell.GridRow.Cells["gcRemaining"].Value = CalcRemaining(newCount, ai);
            }
        }

        private int CalcRemaining(int newCount, ArchiveInfo ai)
        {
            string sql = string.Format("SELECT {1} - ifnull((SELECT sum(copies) FROM lendArchive WHERE archid = {0}),0) "
                       + " + ifnull(( SELECT sum( copies ) FROM ReturnArchive WHERE archid = {0}),0) as Remaining "
                       + " FROM ArchiveInfo WHERE id = {0}", ai.Id, newCount);
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
               // SQLiteDataReader reader = cmd.ExecuteReader();
                return Convert.ToInt32(cmd.ExecuteScalar()); //reader.GetInt16(0);
            }
        }

        private void ArchiveGrid_AfterExpand(object sender, GridAfterExpandEventArgs e)
        {
            GridRow row = (GridRow)ArchiveGrid.PrimaryGrid.Rows[e.GridContainer.RowIndex];
            row.CellStyles.Default.Background.BackColorBlend.Colors = new Color[1] { Color.CornflowerBlue };
        }

        private void ArchiveGrid_AfterCollapse(object sender, GridAfterCollapseEventArgs e)
        {
            GridRow row = (GridRow)ArchiveGrid.PrimaryGrid.Rows[e.GridContainer.RowIndex];
            row.CellStyles.Default.Background.BackColorBlend.Colors = new Color[0];
        }

        private void ArchiveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<GridRow> list = GetUnSavedList();
            if (list.Count > 0)
            {
                ToastMessage.Show(this, "尚有未保存的内容，请保存后再退出。");
                e.Cancel = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (ArchiveGrid.PrimaryGrid.Rows.Count == 0)
            {
                MessageBox.Show("没有导出数据");
                return;
            }
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitializeLifetimeService();
                sfd.Filter = "Excel Files | *.xls";
                sfd.DefaultExt = "xls";
                DialogResult ret = STAShowDialog(sfd);
                if (!ret.Equals(DialogResult.OK))
                {
                    return;
                }
                string path = sfd.FileName;
                MessageBox.Show("文件导出成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DialogResult STAShowDialog(FileDialog dialog)
        {
            DialogState state = new DialogState();
            state.dialog = dialog;
            System.Threading.Thread t = new System.Threading.Thread(state.ThreadProcShowDialog);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            return state.result;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool IsWarninged = false;
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            int DeleteCount = 0;
            foreach (GridRow row in panel.Rows)
            {
                if (row.Checked && !row.Cells["gcId"].IsValueNull)
                {
                    int id = int.Parse(row.Cells["gcId"].Value.ToString());
                    if(!CheckDelete(id)){
                        string name = row.Cells["gcArchName"].Value.ToString();
                        MessageBox.Show(string.Format("“{0}”有借出或归还记录，无法删除。若要删除，请先删除该资料的借出或归还信息。 ", name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;
                    }
                    if (!IsWarninged)
                    {
                        bool IsCancel = MessageBox.Show("确定要删除吗？ ", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2).Equals(DialogResult.No);
                        if (IsCancel)
                        {
                            return;
                        }
                        IsWarninged = true;
                    }
                    try
                    {                        
                        DeleteArchiveInfo(id);
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

        private bool CheckDelete(int id)
        {
            string sql = string.Format("select id from LendArchive where ArchId = {0} union select id from ReturnArchive where ArchId = {0}", id);
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

        private void DeleteArchiveInfo(int id)
        {
            string sql = string.Format("Delete from ArchiveInfo where Id = {0}", id);
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private void mouseWheel(object sender, MouseEventArgs e)
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            CellVisualStyles cs = panel.DefaultVisualStyles.CellStyles;
            if (!CtrlPressed || (cs.Default.Font.Size <= 8 && e.Delta < 0))
            {
                return;
            }
            int step = e.Delta > 0 ? 1 : -1;
            Font f = new Font(cs.Default.Font.FontFamily, cs.Default.Font.Size + step);
            cs.Default.Font = f;
            panel.DefaultRowHeight += step;
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = f;
            foreach (GridColumn gc in panel.Columns)
            {
                gc.Width += step * 4;
            }
        }

        private void ArchiveGrid_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlPressed = e.KeyValue.Equals(17);
        }

        private void ArchiveGrid_KeyUp(object sender, KeyEventArgs e)
        {
            CtrlPressed = !e.KeyValue.Equals(17);
        }
    }

    public class DialogState
    {
        public DialogResult result;
        public FileDialog dialog;

        public void ThreadProcShowDialog()
        {
            result = dialog.ShowDialog();
        }
    }
}
