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
    public partial class ReturnForm : Form
    {
        private string archiveName;
        private string[] MissingDamageItems = { "无损坏", "有损坏" };

        public ReturnForm()
        {
            InitializeComponent();
        }

        public ReturnForm(string name)
        {
            InitializeComponent();
            this.archiveName = name;
        }

        private void InitReturnArhiveGrid()
        {
            GridPanel panel = ReturnGrid.PrimaryGrid;
            panel.Rows.Clear();
            panel.EnableColumnFiltering = true;
            panel.FilterLevel = FilterLevel.AllConditional;
            panel.FilterMatchType = FilterMatchType.RegularExpressions;

            panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            List<string> Archives = GetArchiveList();
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

            GridColumn gcDamageOrLost = panel.Columns["gcMissingDamage"];
            gcDamageOrLost.EditorType = typeof(GridCellDropDownEditControl);
            gcDamageOrLost.EditorParams = new object[] { MissingDamageItems };
        }

        private List<string> GetArchiveList()
        {
            return new List<string>() { archiveName };
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            GridRow gr = ReturnGrid.PrimaryGrid.NewRow();
            gr.Cells["gcArchName"].Value = archiveName;
            gr.Cells["gcMissingDamage"].Value = MissingDamageItems[0];
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
                    string strsql = string.Format("select * from ReturnArchive where ArchiveName = '{0}' order by ReturnDate desc", archiveName);
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
                            gr["gcReturnCount"].AllowEdit = false;
                            gr["gcHandler"].Value = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            gr["gcMissingDamage"].Value = reader.GetInt16(5) == 0 ? MissingDamageItems[0] : MissingDamageItems[1];
                            gr["gcRemark"].Value = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            gr["gcReturner"].Value = reader.IsDBNull(7) ? "" : reader.GetString(7);
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
            List<GridRow> list = new List<GridRow>();
            foreach (GridRow gr in ReturnGrid.PrimaryGrid.Rows)
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
                //SQLiteTransaction tx = conn.BeginTransaction();
                //cmd.Transaction = tx;
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

        private ReturnArchive GridCellMapToReturnArchive(GridRow gr)
        {
            return new ReturnArchive()
            {
                Id = gr[0].IsValueNull ? 0 : Convert.ToInt16(gr[0].Value),
                ArchiveName = (string)gr[1].Value,
                ReturnDate = Convert.ToDateTime(gr[2].Value),
                Copies = (null != gr[3].Value) ? int.Parse(gr[3].Value.ToString()) : 0,
                Handler = (string)gr["gcHandler"].Value,
                DamageOrLost = (string)gr["gcMissingDamage"].Value == MissingDamageItems[0] ? 0 : 1,
                Remark = (string)gr["gcRemark"].Value,
                Returner = (string)gr["gcReturner"].Value
            };
        }

        private string GenReturnSQL(ReturnArchive ai)
        {
            if (ai.Id == 0)
            {
                return "insert into ReturnArchive(archiveName, ReturnDate, Copies, Handler, DamageOrLost, Remark, Returner) values ('"
                            + ai.ArchiveName + "','" + ai.ReturnDate + "'," + ai.Copies + ",'" + ai.Handler + "'," + ai.DamageOrLost
                            + ",'" + ai.Remark + "','" + ai.Returner +"')";
            }
            return "update ReturnArchive set archiveName='" + ai.ArchiveName + "', ReturnDate='" + ai.ReturnDate + "', Copies=" + ai.Copies +
                ", Handler='" + ai.Handler + "', DamageOrLost=" + ai.DamageOrLost + ", Remark='" + ai.Remark + "', Returner='" + ai.Returner +
                "' where id =" + ai.Id;
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
    }
}
