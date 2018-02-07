using DevComponents.DotNetBar.SuperGrid;
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
    public partial class ReturnForm : Form
    {
        private ArchiveInfo CurrentArchiveInfo;
        private string[] MissingDamageItems = { "无损坏", "有损坏" };
        private bool CtrlPressed = false;

        public ReturnForm()
        {
            InitializeComponent();
        }

        public ReturnForm(ArchiveInfo ai)
        {
            InitializeComponent();
            btnDelete.Visible = Authority.AllowDelete;
            this.CurrentArchiveInfo = ai;
            ReturnGrid.MouseWheel += new System.Windows.Forms.MouseEventHandler(mouseWheel);
        }

        private void InitReturnArhiveGrid()
        {
            GridPanel panel = ReturnGrid.PrimaryGrid;
            panel.Rows.Clear();
            panel.EnableColumnFiltering = true;
            panel.ShowCheckBox = !Authority.AllowDelete;
            panel.CheckBoxes = Authority.AllowDelete;
            panel.FilterLevel = FilterLevel.AllConditional;
            panel.FilterMatchType = FilterMatchType.RegularExpressions;
            panel.DefaultVisualStyles.CellStyles.Default.Font = new Font("宋体", 11f);

            panel.Columns["gcArchName"].EditorType = typeof(ArchiveDropDownEditControl);
            List<string> Archives = GetArchiveList();
            panel.Columns["gcArchName"].EditorParams = new object[] { Archives };
            
            GridColumn gcReturnDate = panel.Columns[2];
            gcReturnDate.EditorType = typeof(GridDateTimePickerEditControl);
            gcReturnDate.RenderType = typeof(GridDateTimePickerEditControl);
            gcReturnDate.DefaultNewRowCellValue = DateTime.Now;

            GridColumn gcCopies = panel.Columns[3];
            gcCopies.EditorType = typeof(GridDoubleIntInputEditControl);
            GridDoubleIntInputEditControl de = (GridDoubleIntInputEditControl)gcCopies.EditControl;
            gcCopies.DataType = typeof(int);
            de.MinValue = 0;

            GridColumn gcDamageOrLost = panel.Columns["gcMissingDamage"];
            gcDamageOrLost.EditorType = typeof(GridCellDropDownEditControl);
            gcDamageOrLost.EditorParams = new object[] { MissingDamageItems };
        }

        private List<string> GetArchiveList()
        {
            return new List<string>() { CurrentArchiveInfo.ArchiveName };
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            GridRow gr = ReturnGrid.PrimaryGrid.NewRow();
            gr.Cells["gcArchName"].Value = CurrentArchiveInfo.ArchiveName;
            gr.Cells["gcMissingDamage"].Value = MissingDamageItems[0];
            gr.Cells["gcArchId"].Value = CurrentArchiveInfo.Id;
            ReturnGrid.PrimaryGrid.Rows.Add(gr);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ReturnGrid.PrimaryGrid.Rows.Clear();
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
                    string strsql = string.Format("select * from ReturnArchive where ArchId = {0} order by ReturnDate desc", CurrentArchiveInfo.Id);
                    cmd.CommandText = strsql;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GridRow gr = ReturnGrid.PrimaryGrid.NewRow();
                            gr["gcId"].Value = reader.GetInt16(0);
                            gr["gcArchName"].Value = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                gr[2].Value = Convert.ToDateTime(reader.GetString(2));
                            }
                            gr[3].Value = reader.GetInt16(3);
                            gr["gcReturnCount"].AllowEdit = false;
                            gr["gcHandler"].Value = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            gr["gcMissingDamage"].Value = reader.GetInt16(5) == 0 ? MissingDamageItems[0] : MissingDamageItems[1];
                            gr["gcRemark"].Value = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            gr["gcReturner"].Value = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            gr["gcArchId"].Value = CurrentArchiveInfo.Id;
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
        private void btnSaveReturn_Click(object sender, EventArgs e)
        {
            btnSaveReturn.Focus();
            ReturnGrid.PrimaryGrid.FlushSelected();
            List<GridRow> list = new List<GridRow>();
            foreach (GridRow gr in ReturnGrid.PrimaryGrid.Rows)
            {
                if (gr.RowDirty && !gr.IsDeleted)
                {
                    list.Add(gr);
                }
            }
            if (list.Count == 0)
            {
                ToastMessage.Show(this, "没有可保存的内容。");
                return;
            }
            SaveReturnArchiveInfo(list);
            UpdateArchiveList();
            ToastMessage.Show(this, "已保存。");
        }

        private void UpdateArchiveList()
        {
            //throw new NotImplementedException();
        }

        private void SaveReturnArchiveInfo(List<GridRow> list)
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
                        ReturnArchive ai = GridCellMapToReturnArchive(gr);
                        cmd.CommandText = GenReturnSQL(ai);
                        cmd.ExecuteNonQuery();
                        if (ai.Id == 0)
                        {
                            cmd.CommandText = NotifyArchiveRemaining(ai);
                            cmd.ExecuteNonQuery();
                            ReturnArchiveRetreeIdFixRowCellReadonly(gr, ai);
                            gr["gcReturnCount"].AllowEdit = false;
                        }
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

        private ReturnArchive GridCellMapToReturnArchive(GridRow gr)
        {
            return new ReturnArchive()
            {
                Id = gr["gcId"].IsValueNull ? 0 : Convert.ToInt16(gr["gcId"].Value),
                ArchiveName = (string)gr["gcArchName"].Value,
                ReturnDate = Convert.ToDateTime(gr[2].Value),
                Copies = (null != gr[3].Value) ? int.Parse(gr[3].Value.ToString()) : 0,
                Handler = (string)gr["gcHandler"].Value,
                DamageOrLost = (string)gr["gcMissingDamage"].Value == MissingDamageItems[0] ? 0 : 1,
                Remark = (string)gr["gcRemark"].Value,
                Returner = (string)gr["gcReturner"].Value,
                ArchId = CurrentArchiveInfo.Id
            };
        }

        private string GenReturnSQL(ReturnArchive ai)
        {
            if (ai.Id == 0)
            {
                return "insert into ReturnArchive(archiveName, ReturnDate, Copies, Handler, DamageOrLost, Remark, Returner, ArchId) values ('"
                            + ai.ArchiveName + "','" + ai.ReturnDate + "'," + ai.Copies + ",'" + ai.Handler + "'," + ai.DamageOrLost
                            + ",'" + ai.Remark + "','" + ai.Returner +"'," + CurrentArchiveInfo.Id +")";
            }
            return "update ReturnArchive set archiveName='" + ai.ArchiveName + "', ReturnDate='" + ai.ReturnDate + "', Copies=" + ai.Copies +
                ", Handler='" + ai.Handler + "', DamageOrLost=" + ai.DamageOrLost + ", Remark='" + ai.Remark + "', Returner='" + ai.Returner +
                "' where id =" + ai.Id;
        }


        private string NotifyArchiveRemaining(ReturnArchive ai)
        {
            return "update ArchiveInfo set Remaining=Remaining+" + ai.Copies + " where Id='" + CurrentArchiveInfo.Id + "'";
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
                    ai.Id = Convert.ToInt32(sql_cmd.ExecuteScalar());
                    gr["gcId"].Value = ai.Id;
                    conn.Close();
                }
            }
        }

        private void ReturnForm_Shown(object sender, EventArgs e)
        {
            InitReturnArhiveGrid();
            ReturnGrid.PrimaryGrid.Rows.Clear();
            LoadReturnArchiveList();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            btnSaveReturn_Click(sender, e);
            this.Close();
        }

        private void ReturnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnSaveReturn_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool IsWarninged = false;
            GridPanel panel = ReturnGrid.PrimaryGrid;
            int DeleteCount = 0;
            foreach (GridRow row in panel.Rows)
            {
                if (row.Checked && !row.Cells["gcId"].IsValueNull)
                {
                    if (!IsWarninged)
                    {
                        bool IsCancel = MessageBox.Show("若删除记录，资料的剩余份数会被减去当前归还记录的份数。确定要删除吗？ ", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2).Equals(DialogResult.No);
                        if (IsCancel)
                        {
                            return;
                        }
                        IsWarninged = true;
                    }
                    try
                    {
                        int id = int.Parse(row.Cells["gcId"].Value.ToString());
                        int copies = int.Parse(row.Cells["gcReturnCount"].Value.ToString());
                        int archId = int.Parse(row.Cells["gcArchId"].Value.ToString());
                        DeleteReturnArchive(id, copies, archId);
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

        private void DeleteReturnArchive(int id, int copies, int archId)
        {
            string sql = string.Format("Delete from ReturnArchive where Id = {0}", id);
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                sql = string.Format("Update ArchiveInfo set Remaining = Remaining - {1} where id = {0}", archId, copies);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private void mouseWheel(object sender, MouseEventArgs e)
        {
            if (CtrlPressed)
            {
                GridPanel panel = ReturnGrid.PrimaryGrid;
                CellVisualStyles cs = panel.DefaultVisualStyles.CellStyles;
                if (e.Delta > 0)
                {
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

        private void ReturnGrid_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlPressed = e.KeyValue.Equals(17);
        }

        private void ReturnGrid_KeyUp(object sender, KeyEventArgs e)
        {
            CtrlPressed = !e.KeyValue.Equals(17);
        }
    }
}
