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
        private string archiveName;

        public LendForm()
        {
            InitializeComponent();
        }

        public LendForm(string name)
        {
            InitializeComponent();
            this.archiveName = name;
        }

        private void InitLendArchiveGrid()
        {
            GridPanel panel = LendGrid.PrimaryGrid;
            panel.Rows.Clear();

            panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            List<string> Archives = GetArchiveList();
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

        private void btnLend_Click(object sender, EventArgs e)
        {
            GridPanel panel = LendGrid.PrimaryGrid;
            panel.Columns[1].EditorType = typeof(ArchiveDropDownEditControl);
            List<string> Archives = GetArchiveList();
            panel.Columns[1].EditorParams = new object[] { Archives };

            GridRow gr = LendGrid.PrimaryGrid.NewRow();
            gr.Cells["gcArchName"].Value = archiveName;
            LendGrid.PrimaryGrid.Rows.Add(gr);
        }

        private List<string> GetArchiveList()
        {
            //ArchiveInfoList.Select(i => i.ArchiveName).ToList();//.Where(a => a.project.IsFreeze == 0)
            return new List<string>() { archiveName};
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
                    string strsql = string.Format("select * from LendArchive where ArchiveName = '{0}' order by LendDate desc", archiveName);
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
            if (list.Count > 0)
            {
                SaveLendArchiveInfo(list);
                //LoadArchiveList();
            }
        }

        private void LoadArchiveList()
        {
            throw new NotImplementedException();
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

        private string GenLendArchiveSQL(LendArchive ai)
        {
            if (ai.Id == 0)
            {
                return "insert into LendArchive(archiveName, LendDate, Copies, LendReason, LendUnit, Handler, Phone, ExpectedReturnDate) values ('"
                            + ai.ArchiveName + "','" + ai.LendDate + "'," + ai.Copies
                            + ",'" + ai.LendReason + "','" + ai.LendUnit + "','" + ai.Handler + "','" + ai.Phone + "','" + ai.ExpectedReturnDate + "')";
            }
            return "update LendArchive set archiveName='" + ai.ArchiveName + "', LendDate='" + ai.LendDate +
                "', Copies=" + ai.Copies + ", LendReason=" + ai.LendReason + ", LendUnit='" + ai.LendUnit
                + "', Handler='" + ai.Handler + "', Phone='" + ai.Phone + "', ExpectedReturnDate='" + ai.ExpectedReturnDate + "' where id =" + ai.Id;
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
                    gr["gcId"].Value = newId;
                    conn.Close();
                }
            }
        }

        private string NotifyLendArchiveRemaining(LendArchive ai)
        {
            return "update ArchiveInfo set Remaining=Remaining-" + ai.Copies + " where ArchiveName='" + ai.ArchiveName + "'";
        }

        private void LendForm_Shown(object sender, EventArgs e)
        {
            InitLendArchiveGrid();
        }

    }
}
