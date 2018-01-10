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
        private string[] ArchTypes = { "证件", "红头", "文本", "图纸", "合同", "其他" };
        
        private List<string> Archives;
        private List<ArchiveInfo> ArchiveInfoList;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitArchiveGrid()
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            panel.CheckBoxes = true;
            panel.ShowCheckBox = false;
            panel.ShowTreeButtons = true;
            panel.ShowTreeLines = true;
            panel.ShowRowGridIndex = true;
            panel.RowDragBehavior = RowDragBehavior.GroupMove;

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
            panel.Columns[6].CellStyles.Default.Background.Color1 = Color.BurlyWood;
            de5.MinValue = 0;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            GridRow gr = ArchiveGrid.PrimaryGrid.NewRow();
            ArchiveGrid.PrimaryGrid.Rows.Add(gr);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            GetArchivesList();
            InitArchiveGrid();
            InitLendArchiveGrid();
            InitReturnArhiveGrid();

            LoadArchiveList();
            LoadLendArchiveList();
            LoadReturnArchiveList();
        }

        private void LoadReturnArchiveList()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                try
                {
                    string strsql = "select * from LendArchive order by LendDate desc";
                    cmd.CommandText = strsql;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GridRow gr = LendGrid.PrimaryGrid.NewRow();
                            gr[0].Value = reader.GetInt16(0);
                            gr[1].Value = reader.GetString(1);                            
                            if (!reader.IsDBNull(2))
                            {
                                gr[2].Value = Convert.ToDateTime(reader.GetString(2));
                            }
                            gr[3].Value = reader.GetInt16(3);
                            gr[4].Value = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            gr[5].Value = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            gr[6].Value = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            gr[7].Value = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            if (!reader.IsDBNull(8))
                            {
                                gr[8].Value = Convert.ToDateTime(reader.GetString(8));
                            }
                            //gr[6].ReadOnly = true;

                            LendGrid.PrimaryGrid.Rows.Add(gr);
                        }

                    }
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    throw new Exception(E.Message);
                }
            }
        }

        private void LoadLendArchiveList()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                try
                {
                    string strsql = "select * from ReturnArchive order by ReturnDate desc";
                    cmd.CommandText = strsql;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GridRow gr = ReturnGrid.PrimaryGrid.NewRow();
                            gr[0].Value = reader.GetInt16(0);
                            gr[1].Value = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                gr[2].Value = Convert.ToDateTime(reader.GetString(2));
                            }                            
                            gr[3].Value = reader.GetInt16(3);
                            gr[4].Value = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            gr[5].Value = reader.GetInt16(5); 
                            gr[6].Value = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            
                            ReturnGrid.PrimaryGrid.Rows.Add(gr);
                        }

                    }
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    throw new Exception(E.Message);
                }
            }
        }

        private void RegisterDataSavingTask()
        {
            ArchiveInfoTimer.Start();
        }

        private void LoadArchiveList()
        {
            ArchiveGrid.PrimaryGrid.Rows.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                try
                {
                    string strsql = "select * from archiveInfo order by archDate desc";
                    cmd.CommandText = strsql;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GridRow gr = ArchiveGrid.PrimaryGrid.NewRow();
                            gr[1].Value = reader.GetInt16(0);
                            gr[0].Value = reader.GetString(1);
                            gr[2].Value = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                gr[3].Value = Convert.ToDateTime(reader.GetString(3));
                            }
                            gr[4].Value = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            gr[5].Value = reader.GetInt16(5);
                            gr[6].Value = reader.GetInt16(6);
                            gr[7].Value = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            gr[8].Value = reader.IsDBNull(8) ? "" : reader.GetString(8);
                            gr[9].Value = reader.GetInt16(9) == 0 ? false : true;
                            gr[6].ReadOnly = true;
                            ArchiveGrid.PrimaryGrid.Rows.Add(gr);
                        }
                    } 
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    throw new Exception(E.Message);
                }
            }
        }

        private void SaveArchiveInfo(List<GridRow> list)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                SQLiteTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
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
                        Archives.Add(ai.ArchiveName);
                    }
                    tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    //throw new Exception(E.Message);
                    MessageBox.Show(cmd.CommandText + Environment.NewLine + E.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private string GenReturnArchiveSQL(ReturnArchive ai)
        {
            if (ai.Id == 0)
            {
                return "insert into ReturnArchive(archiveName, ReturnDate, Copies, Handler, DamageOrLost, Remark) values ('"
                            + ai.ArchiveName + "','" + ai.ReturnDate + "'," + ai.Copies + ",'" + ai.Handler + "'," + ai.DamageOrLost
                            + ",'" + ai.Remark + "')";
            }
            return "update ReturnArchive set archiveName='" + ai.ArchiveName + "', ReturnDate='" + ai.ReturnDate + "', Copies=" + ai.Copies +
                ", Handler='" + ai.Handler + "', DamageOrLost=" + ai.DamageOrLost + ", Remark=" + ai.Remark + "' where id =" + ai.Id;
        }

        private void ArchiveInfoRetreeIdFixRowCellReadonly(GridRow gr, ArchiveInfo ai)
        {
            gr.RowDirty = false;
            if (ai.Id == 0)
            {
                gr[6].ReadOnly = true;
                using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
                {
                    conn.Open();
                    SQLiteCommand sql_cmd = conn.CreateCommand();
                    sql_cmd.CommandText = "select seq from sqlite_sequence where name='ArchiveInfo'; ";
                    int newId = Convert.ToInt32(sql_cmd.ExecuteScalar());
                    gr[0].Value = newId;
                    conn.Close();
                }
            }
        }

        private string GenSQL(ArchiveInfo ai)
        {
            if(ai.Id == 0){
                return "insert into ArchiveInfo(archiveName, ArchType, ArchDate, DispatchNum, Copies, Remaining, StorageLocation, Handler, IsFreeze) values ('"
                            + ai.ArchiveName + "','" + ai.ArchType + "','" + ai.ArchDate + "','" + ai.DispatchNum + "'," + ai.Copies
                            + "," + ai.Remaining + ",'" + ai.StorageLocation + "','" + ai.Handler + "', " + ai.IsFreeze + ")";
            }
            return "update ArchiveInfo set archiveName='" + ai.ArchiveName + "', ArchType='" + ai.ArchType + "', ArchDate='" + ai.ArchDate +
                "', DispatchNum='" + ai.DispatchNum + "', Copies=" + ai.Copies + ", Remaining=" + ai.Remaining + ", StorageLocation='" + ai.StorageLocation
                + "', Handler='" + ai.Handler + "', IsFreeze=" + ai.IsFreeze +" where id =" + ai.Id;
        }

        private ArchiveInfo GridCellMapToArchiveInfo(GridRow gr)
        {
            return new ArchiveInfo()
            {
                Id = string.IsNullOrEmpty(gr[1].Value.ToString()) ? 0 : Convert.ToInt16(gr[1].Value),
                ArchiveName = (string)gr[0].Value,
                ArchType = (string)gr[2].Value,
                ArchDate = Convert.ToDateTime(gr[3].Value),
                DispatchNum = (string)gr[4].Value,
                Copies = (null != gr[5].Value) ? int.Parse(gr[5].Value.ToString()) : 0,
                Remaining = (null != gr[6].Value) ? int.Parse(gr[6].Value.ToString()) : 0,
                StorageLocation = (string)gr[7].Value,
                Handler = (string)gr[8].Value,
                IsFreeze = Convert.ToInt16(gr[9].Value)
            };
        }

        private LendArchive GridCellMapToLendArchive(GridRow gr)
        {
            return new LendArchive()
            {
                Id = gr[0].IsValueNull ? 0 : Convert.ToInt16(gr[0].Value),
                ArchiveName = (string)gr[1].Value,
                LendDate = Convert.ToDateTime(gr[2].Value),
                Copies = (null != gr[3].Value) ? int.Parse(gr[3].Value.ToString()) : 0,
                LendReason = (string)gr[4].Value,
                LendUnit = (string)gr[5].Value,
                Handler = (string)gr[6].Value,
                Phone = (string)gr[7].Value,
                ExpectedReturnDate = Convert.ToDateTime(gr[8].Value)
            };
        }

        private ReturnArchive GridCellMapToReturnArchive(GridRow gr)
        {
            return new ReturnArchive()
            {
                Id = gr[0].IsValueNull ? 0 : Convert.ToInt16(gr[0].Value),
                ArchiveName = (string)gr[1].Value,
                ReturnDate = Convert.ToDateTime(gr[2].Value),
                Copies = (null != gr[3].Value) ? int.Parse(gr[3].Value.ToString()) : 0,
                Handler = (string)gr[4].Value,
                DamageOrLost = gr[5].IsValueNull ? 0 : Convert.ToInt16(gr[5].Value),
                Remark = (string)gr[6].Value
            };
        }

        private void ArchiveInfoTimer_Tick(object sender, EventArgs e)
        {
            List<GridRow> list = new List<GridRow>();
            foreach(GridRow gr in ArchiveGrid.PrimaryGrid.Rows){
                if(gr.RowDirty){
                    list.Add(gr);
                }
            }
            if (list.Count > 0){
                SaveArchiveInfo(list);
            }
        }

        private void btnSaveRegister_Click(object sender, EventArgs e)
        {
            List<GridRow> list = new List<GridRow>();
            foreach (GridRow gr in ArchiveGrid.PrimaryGrid.Rows)
            {
                if (gr.RowDirty)
                {
                    list.Add(gr);
                }
            }
            if (list.Count > 0)
            {
                SaveArchiveInfo(list);
            }
        }

        private void btnLend_Click(object sender, EventArgs e)
        {
            GridPanel panel = LendGrid.PrimaryGrid;
            panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            panel.Columns[1].EditorParams = new object[] { Archives };

            GridRow gr = LendGrid.PrimaryGrid.NewRow();
            LendGrid.PrimaryGrid.Rows.Add(gr);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            GridRow gr = ReturnGrid.PrimaryGrid.NewRow();
            ReturnGrid.PrimaryGrid.Rows.Add(gr);
        }

        private void btnSaveSend_Click(object sender, EventArgs e)
        {
            List<GridRow> list = new List<GridRow>();
            foreach (GridRow gr in LendGrid.PrimaryGrid.Rows)
            {
                if (gr.RowDirty)
                {
                    list.Add(gr);
                }
            }
            if (list.Count > 0)
            {
                SaveLendArchiveInfo(list);
                LoadArchiveList();
            }
        }

        private void SaveLendArchiveInfo(List<GridRow> list)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                SQLiteTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    foreach (GridRow gr in list)
                    {
                        LendArchive ai = GridCellMapToLendArchive(gr);

                        cmd.CommandText = GenLendArchiveSQL(ai);
                        cmd.ExecuteNonQuery();
                        LendArchiveRetreeIdFixRowCellReadonly(gr, ai);
                        cmd.CommandText = NotifyLendArchiveRemaining(ai);
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    MessageBox.Show(cmd.CommandText + Environment.NewLine + E.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private string NotifyLendArchiveRemaining(LendArchive ai)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            //{
            //    conn.Open();
            //    SQLiteCommand sql_cmd = conn.CreateCommand();
                return "update ArchiveInfo set Remaining=Remaining-" + ai.Copies + " where ArchiveName='" + ai.ArchiveName + "'";
            //    sql_cmd.ExecuteNonQuery();
            //    conn.Close();
            //}
        }

        private void LendArchiveRetreeIdFixRowCellReadonly(GridRow gr, LendArchive ai)
        {
            gr.RowDirty = false;
            if (ai.Id == 0)
            {
                //gr[6].ReadOnly = true;
                using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
                {
                    conn.Open();
                    SQLiteCommand sql_cmd = conn.CreateCommand();
                    sql_cmd.CommandText = "select seq from sqlite_sequence where name='LendArchive'; ";
                    int newId = Convert.ToInt32(sql_cmd.ExecuteScalar());
                    gr[0].Value = newId;
                    conn.Close();
                }
            }
        }

        private string GenLendArchiveSQL(LendArchive ai)
        {
            if (ai.Id == 0)
            {
                return "insert into LendArchive(archiveName, LendDate, Copies, LendReason, LendUnit, Handler, Phone, ExpectedReturnDate) values ('"
                            + ai.ArchiveName + "','" + ai.LendDate + "'," + ai.Copies
                            + ",'" + ai.LendReason + "','" + ai.LendUnit + "','" + ai.Handler + "','" + ai.Phone + "','"+ ai.ExpectedReturnDate + "')";
            }
            return "update LendArchive set archiveName='" + ai.ArchiveName + "', LendDate='" + ai.LendDate +
                "', Copies=" + ai.Copies + ", LendReason=" + ai.LendReason + ", LendUnit='" + ai.LendUnit
                + "', Handler='" + ai.Handler + "', Phone='" + ai.Phone + "', ExpectedReturnDate='" + ai.ExpectedReturnDate + "' where id =" + ai.Id;
        }

        private void btnSaveReturn_Click(object sender, EventArgs e)
        {
            List<GridRow> list = new List<GridRow>();
            foreach (GridRow gr in ReturnGrid.PrimaryGrid.Rows)
            {
                if (gr.RowDirty)
                {
                    list.Add(gr);
                }
            }
            if (list.Count > 0)
            {
                SaveReturnArchiveInfo(list);
                LoadArchiveList();
            }
        }

        private void SaveReturnArchiveInfo(List<GridRow> list)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                SQLiteTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    foreach (GridRow gr in list)
                    {
                        ReturnArchive ai = GridCellMapToReturnArchive(gr);
                        cmd.CommandText = GenReturnSQL(ai);
                        cmd.ExecuteNonQuery();
                        ReturnArchiveRetreeIdFixRowCellReadonly(gr, ai);
                        cmd.CommandText = NotifyArchiveRemaining(ai);
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    MessageBox.Show(cmd.CommandText + Environment.NewLine + E.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private string NotifyArchiveRemaining(ReturnArchive ai)
        {
            return "update ArchiveInfo set Remaining=Remaining+" + ai.Copies + " where ArchiveName='" + ai.ArchiveName + "'";
        }

        private void ReturnArchiveRetreeIdFixRowCellReadonly(GridRow gr, ReturnArchive ai)
        {
            gr.RowDirty = false;
            if (ai.Id == 0)
            {
                using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
                {
                    conn.Open();
                    SQLiteCommand sql_cmd = conn.CreateCommand();
                    sql_cmd.CommandText = "select seq from sqlite_sequence where name='ReturnArchive'; ";
                    int newId = Convert.ToInt32(sql_cmd.ExecuteScalar());
                    gr[0].Value = newId;
                    conn.Close();
                }
            }
        }

        private string GenReturnSQL(ReturnArchive ai)
        {
            if (ai.Id == 0)
            {
                return "insert into ReturnArchive(archiveName, ReturnDate, Copies, Handler, DamageOrLost, Remark) values ('"
                            + ai.ArchiveName + "','" + ai.ReturnDate + "'," + ai.Copies + ",'" + ai.Handler + "'," + ai.DamageOrLost
                            + ",'" + ai.Remark + "')";
            }
            return "update ReturnArchive set archiveName='" + ai.ArchiveName + "', ReturnDate='" + ai.ReturnDate + "', Copies=" + ai.Copies +
                ", Handler='" + ai.Handler + "', DamageOrLost=" + ai.DamageOrLost + ", Remark='" + ai.Remark + "' where id =" + ai.Id;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void InitReturnArhiveGrid()
        {
            GridPanel panel = ReturnGrid.PrimaryGrid;
            panel.Rows.Clear();

            panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            panel.Columns[1].EditorParams = new object[] { Archives };

            GridColumn gcReturnDate = panel.Columns[2];
            gcReturnDate.EditorType = typeof(GridDateTimePickerEditControl);
            gcReturnDate.RenderType = typeof(GridDateTimePickerEditControl);
            gcReturnDate.DefaultNewRowCellValue = DateTime.Now;

            GridColumn gcCopies = panel.Columns[3];
            gcCopies.EditorType = typeof(GridDoubleIntInputEditControl);
            GridDoubleIntInputEditControl de = (GridDoubleIntInputEditControl)gcCopies.EditControl;
            gcCopies.DataType = typeof(int);
            de.MinValue = 0;
        }

        private void InitLendArchiveGrid()
        {
            GridPanel panel = LendGrid.PrimaryGrid;
            panel.Rows.Clear();

            panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            panel.Columns[1].EditorParams = new object[] { Archives };

            panel.Columns[2].EditorType = typeof(GridDateTimePickerEditControl);
            panel.Columns[2].RenderType = typeof(GridDateTimePickerEditControl);
            panel.Columns[2].DefaultNewRowCellValue = DateTime.Now;

            panel.Columns[3].EditorType = typeof(GridDoubleIntInputEditControl);
            GridDoubleIntInputEditControl de = (GridDoubleIntInputEditControl)panel.Columns[3].EditControl;
            panel.Columns[3].DataType = typeof(int);
            de.MinValue = 0;

            GridColumn gc = panel.Columns[8];
            gc.EditorType = typeof(GridDateTimePickerEditControl);
            gc.RenderType = typeof(GridDateTimePickerEditControl);
            gc.DefaultNewRowCellValue = DateTime.Now;
        }

        private void GetArchivesList()
        {
            Archives = new List<string>();
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = "select ArchiveName from ArchiveInfo order by ArchDate desc ";
                SQLiteDataReader reader = sql_cmd.ExecuteReader();
                //while(dr.Read()){
                //    Archives.Add(dr.GetString(0));
                //}
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
                        ai.IsFreeze = reader.GetInt16(9);
                        ArchiveInfoList.Add(ai);
                    }
                }
                reader.Close();
                conn.Close();
            }
        }

        private void btnRefreshArchive_Click(object sender, EventArgs e)
        {
            ArchiveGrid.PrimaryGrid.Rows.Clear();
            LoadArchiveList();
        }

        private void btnLendRefresh_Click(object sender, EventArgs e)
        {
            LendGrid.PrimaryGrid.Rows.Clear();
            LoadLendArchiveList();
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            ReturnGrid.PrimaryGrid.Rows.Clear();
            LoadReturnArchiveList();
        }

        private void ArchiveGrid_RowHeaderDoubleClick(object sender, GridRowHeaderDoubleClickEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();                
                CreateReturnPanel(e, conn);
                CreateLendPanel(e, conn);
            }
        }

        private void CreateLendPanel(GridRowHeaderDoubleClickEventArgs e, SQLiteConnection conn)
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            GridRow row = (GridRow)panel.Rows[e.GridRow.RowIndex];
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            try
            {
                string name = row.Cells[0].Value.ToString();
                string strsql = string.Format("select * from LendArchive where ArchiveName='{0}' order by LendDate desc", name);
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
                        gr.Cells.Add(new GridCell(reader.IsDBNull(6) ? "" : reader.GetString(6)));
                        gr.Cells.Add(new GridCell(reader.IsDBNull(7) ? "" : reader.GetString(7)));
                        if (!reader.IsDBNull(8))
                        {
                            gr.Cells.Add(new GridCell(Convert.ToDateTime(reader.GetString(8))));
                        }
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

        private void SetLendPanelColumn(GridPanel subPanel)
        {
            subPanel.Caption.Visible = true;
            subPanel.Caption.RowHeight = 40;
            subPanel.Caption.Text = "借出记录";

            foreach (GridColumn gc in LendGrid.PrimaryGrid.Columns)
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

        private void CreateReturnPanel(GridRowHeaderDoubleClickEventArgs e, SQLiteConnection conn)
        {
            GridPanel panel = ArchiveGrid.PrimaryGrid;
            GridRow row = (GridRow)panel.Rows[e.GridRow.RowIndex];
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            try
            {
                string name = row.Cells[0].Value.ToString();
                string strsql = string.Format("select * from ReturnArchive where ArchiveName='{0}' order by ReturnDate desc", name);
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
                        gr.Cells.Add(new GridCell(reader.IsDBNull(4) ? "" : reader.GetString(4)));
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

            foreach (GridColumn gc in ReturnGrid.PrimaryGrid.Columns)
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
