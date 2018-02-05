using DevComponents.DotNetBar.SuperGrid;
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
    public partial class LendForm : Form
    {
        private ArchiveInfo CurrentArchiveInfo;
        private string[] NeedReturnArgs = { "需归还", "不归还" };

        public LendForm()
        {
            InitializeComponent();
        }

        public LendForm(ArchiveInfo ai)
        {
            InitializeComponent();
            this.CurrentArchiveInfo = ai;
        }

        private void InitLendArchiveGrid()
        {
            GridPanel panel = LendGrid.PrimaryGrid;
            panel.Rows.Clear();
            panel.EnableColumnFiltering = true;
            panel.ShowCheckBox = !Authority.AllowDelete;
            panel.CheckBoxes = Authority.AllowDelete;
            panel.ShowTreeButtons = true;
            panel.ShowTreeLines = true;
            panel.ShowRowGridIndex = true;
            panel.EnableColumnFiltering = true;

            panel.FilterLevel = FilterLevel.AllConditional;
            panel.FilterMatchType = FilterMatchType.RegularExpressions;

            //panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            //List<string> Archives = GetArchiveList();
            //panel.Columns[1].EditorParams = new object[] { Archives };

            panel.Columns[2].EditorType = typeof(GridDateTimePickerEditControl);
            panel.Columns[2].RenderType = typeof(GridDateTimePickerEditControl);
            panel.Columns[2].DefaultNewRowCellValue = DateTime.Now;

            panel.Columns[3].EditorType = typeof(GridDoubleIntInputEditControl);
            GridDoubleIntInputEditControl de = (GridDoubleIntInputEditControl)panel.Columns[3].EditControl;
            panel.Columns[3].DataType = typeof(int);
            panel.Columns[3].CellStyles.Default.Background.BackColorBlend.Colors = new Color[1] { Color.LightGray };
            de.MinValue = 0;

            GridColumn gc = panel.Columns["gcRebackDate"];
            gc.EditorType = typeof(GridDateTimePickerEditControl);
            gc.RenderType = typeof(GridDateTimePickerEditControl);
            gc.DefaultNewRowCellValue = DateTime.Now;

            GridColumn nr = panel.Columns["gcNeedReturn"];
            nr.EditorType = typeof(ArchiveDropDownEditControl);
            nr.EditorParams = new object[] { NeedReturnArgs };
            nr.DefaultNewRowCellValue = NeedReturnArgs[0];
        }

        private void btnLend_Click(object sender, EventArgs e)
        {
            GridPanel panel = LendGrid.PrimaryGrid;
            panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            List<string> Archives = GetArchiveList();
            panel.Columns[1].EditorParams = new object[] { Archives };

            GridRow gr = LendGrid.PrimaryGrid.NewRow();
            gr.Cells["gcArchName"].Value = CurrentArchiveInfo.ArchiveName;
            gr.Cells["gcArchId"].Value = CurrentArchiveInfo.Id;
            LendGrid.PrimaryGrid.Rows.Add(gr);
        }

        private List<string> GetArchiveList()
        {
            return new List<string>() { CurrentArchiveInfo.ArchiveName };
        }

        private void btnLendRefresh_Click(object sender, EventArgs e)
        {
            LendGrid.PrimaryGrid.Rows.Clear();
            LoadLendArchiveList();
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
                    string strsql = string.Format("select * from LendArchive where ArchId = {0} order by LendDate desc", CurrentArchiveInfo.Id);
                    cmd.CommandText = strsql;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GridRow gr = LendGrid.PrimaryGrid.NewRow();
                            gr["gcId"].Value = reader.GetInt16(0);
                            gr["gcArchName"].Value = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                gr["gcLendDate"].Value = Convert.ToDateTime(reader.GetString(2));
                            }
                            gr["gcCount"].Value = reader.GetInt16(3);
                            //gr["gcCount"].AllowEdit = false;
                            gr["gcReason"].Value = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            gr["gcLendUnit"].Value = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            gr["gcHandler"].Value = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            gr["gcPhone"].Value = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            if (!reader.IsDBNull(8))
                            {
                                gr["gcRebackDate"].Value = Convert.ToDateTime(reader.GetString(8));
                            }
                            gr["gcBorrower"].Value = reader.IsDBNull(9) ? "" : reader.GetString(9);
                            gr["gcApprovedBy"].Value = reader.IsDBNull(10) ? "" : reader.GetString(10);
                            gr["gcNeedReturn"].Value = reader.IsDBNull(11) ? "" : reader.GetString(11);
                            gr["gcArchId"].Value = reader.GetInt16(12);
                            //gr["gcCount"].ReadOnly = true;
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

        private void btnSaveSend_Click(object sender, EventArgs e)
        {
            btnSaveSend.Focus();
            List<GridRow> list = new List<GridRow>();
            foreach (GridRow gr in LendGrid.PrimaryGrid.Rows)
            {
                if (gr.RowDirty)
                {
                    list.Add(gr);
                }
            }
            if (list.Count == 0)
            {
                ToastMessage.Show(this, "没有可保存的内容。");
                return;
            }
            if (SaveLendArchiveInfo(list) > 0)
            {
                ToastMessage.Show(this, "已保存。"); 
            }
        }
        
        private int SaveLendArchiveInfo(List<GridRow> list)
        {
            int changeCount = 0;
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                try
                {
                    foreach (GridRow gr in list)
                    {
                        LendArchive ai = GridCellMapToLendArchive(gr);
                        if (!CheckLendable(ai))
                        {
                            gr["gcCount"].CellStyles.Default.TextColor = Color.Red;
                            ToastMessage.Show(this, ai.ArchiveName + " 剩余数量不足，请重新修改借出数量");
                            continue;
                        }
                        cmd.CommandText = GenLendArchiveSQL(ai);
                        cmd.ExecuteNonQuery();
                        gr["gcCount"].CellStyles.Default.TextColor = Color.Black;
                        cmd.CommandText = NotifyLendArchiveRemaining(ai);
                        cmd.ExecuteNonQuery();
                        LendArchiveRetreeIdFixRowCellReadonly(gr, ai);
                        changeCount++;
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
            return changeCount;
        }

        private bool CheckLendable(LendArchive ai)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = string.Format("select (copies - ifnull((select sum(copies) from lendArchive where archId={0} and id <> {4}),0) - {1}) as copies from archiveInfo where archiveName='{2}' And ProjectId={3}", ai.ArchId, ai.Copies, ai.ArchiveName, CurrentArchiveInfo.ProjectId, ai.Id);
                int value = Convert.ToInt32(sql_cmd.ExecuteScalar());
                conn.Close();
                return value >= 0;
            }
        }

        private LendArchive GridCellMapToLendArchive(GridRow gr)
        {
            return new LendArchive()
            {
                Id = gr["gcId"].IsValueNull ? 0 : Convert.ToInt16(gr["gcId"].Value),
                ArchiveName = (string)gr["gcArchName"].Value,
                LendDate = Convert.ToDateTime(gr["gcLendDate"].Value),
                Copies = (null != gr["gcCount"].Value) ? int.Parse(gr["gcCount"].Value.ToString()) : 0,
                LendReason = (string)gr["gcReason"].Value,
                LendUnit = (string)gr["gcLendUnit"].Value,
                Handler = (string)gr["gcHandler"].Value,
                Phone = (string)gr["gcPhone"].Value,
                ExpectedReturnDate = Convert.ToDateTime(gr["gcRebackDate"].Value),
                Borrower = (string)gr["gcBorrower"].Value,
                ApprovedBy = (string)gr["gcApprovedBy"].Value,
                NeedReturn = (string)gr["gcNeedReturn"].Value,
                ArchId = (null != gr["gcArchId"].Value) ? int.Parse(gr["gcArchId"].Value.ToString()) : 0
            };
        }

        private string GenLendArchiveSQL(LendArchive ai)
        {
            if (ai.Id == 0)
            {
                return "insert into LendArchive(archiveName, LendDate, Copies, LendReason, LendUnit, Handler, Phone, ExpectedReturnDate,Borrower, ApprovedBy, NeedReturn, ArchId)"
                    + " values ('" + ai.ArchiveName + "','" + ai.LendDate + "'," + ai.Copies + ",'" + ai.LendReason + "','"
                    + ai.LendUnit + "','" + ai.Handler + "','" + ai.Phone + "','" + ai.ExpectedReturnDate + "','" + ai.Borrower + "','"
                    + ai.ApprovedBy + "','" + ai.NeedReturn + "'," + ai.ArchId + ")";
            }
            return "update LendArchive set archiveName='" + ai.ArchiveName + "', LendDate='" + ai.LendDate
                + "', Copies=" + ai.Copies + ", LendReason='" + ai.LendReason + "', LendUnit='" + ai.LendUnit
                + "', Handler='" + ai.Handler + "', Phone='" + ai.Phone + "', ExpectedReturnDate='" + ai.ExpectedReturnDate
                + "', Borrower='" + ai.Borrower + "', ApprovedBy='" + ai.ApprovedBy + "', NeedReturn='" + ai.NeedReturn + "' where id =" + ai.Id;
        }

        private void LendArchiveRetreeIdFixRowCellReadonly(GridRow gr, LendArchive ai)
        {
            gr.RowDirty = false;
            if (ai.Id == 0)
            {
                using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
                {
                    conn.Open();
                    SQLiteCommand sql_cmd = conn.CreateCommand();
                    sql_cmd.CommandText = "select seq from sqlite_sequence where name='LendArchive'";
                    ai.Id = Convert.ToInt32(sql_cmd.ExecuteScalar());
                    gr["gcId"].Value = ai.Id;
                    conn.Close();
                }
            }
        }

        private string NotifyLendArchiveRemaining(LendArchive ai)
        {
            return string.Format("update archiveInfo set remaining = copies - (select sum(copies) from lendArchive b where b.ArchId = {0}) where id = {0}", ai.ArchId);
        }

        private void LendForm_Shown(object sender, EventArgs e)
        {
            InitLendArchiveGrid();
            LendGrid.PrimaryGrid.Rows.Clear();
            LoadLendArchiveList();
        }

        private void btnSaveAndReturn_Click(object sender, EventArgs e)
        {
            btnSaveSend_Click(sender, e);
            this.Close();
        }

        private void LendForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnSaveSend_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GridPanel panel = LendGrid.PrimaryGrid;
            foreach (GridRow row in panel.Rows)
            {
                if (row.Checked && !row.Cells["gcId"].IsValueNull)
                {
                    try
                    {
                        int id = int.Parse(row.Cells["gcId"].Value.ToString());
                        int copies = int.Parse(row.Cells["gcCount"].Value.ToString());
                        DeleteLeadArchive(id, copies);
                        row.IsDeleted = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void DeleteLeadArchive(int id, int copies)
        {
            string sql = string.Format("Delete from LendArchive where archId = {0}", id);
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                sql = string.Format("Update ArchiveInfo set Remaining = Remaining + {1} where id = {0}", id, copies);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

    }
}
