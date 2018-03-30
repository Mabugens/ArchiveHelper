using ClosedXML.Excel;
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
    public partial class NoReturnForm : Form
    {
        public NoReturnForm()
        {
            InitializeComponent();
        }

        private void btnRefreshArchive_Click(object sender, EventArgs e)
        {
            StatGrid.PrimaryGrid.Rows.Clear();
            string sql = @"select p.projectName, t.archiveName, t.copies-t.Remaining as Copies, b.Borrower, b.Phone, b.lendUnit, b.lendReason, b.NeedReturn from ArchiveInfo t 
                            join lendArchive b on t.id = b.ArchId
                            join ProjectInfo p on p.id = t.projectId
                            Left join ReturnArchive c on t.id = c.ArchId
                            where t.Remaining < t.Copies order by p.projectName";
            using (SQLiteConnection conn = new SQLiteConnection(DataSourceManager.DataSource))
            {
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = sql;
                SQLiteDataReader reader = sql_cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GridRow gr = StatGrid.PrimaryGrid.NewRow();
                        gr[0].Value = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        gr[1].Value = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        gr[2].Value = reader.GetInt16(2);
                        gr[3].Value = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        gr[4].Value = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        gr[5].Value = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        gr[6].Value = reader.IsDBNull(6) ? "" : reader.GetString(6);
                        gr[7].Value = reader.IsDBNull(7) ? "" : reader.GetString(7);
                        StatGrid.PrimaryGrid.Rows.Add(gr);
                    }
                }
                reader.Close();
                conn.Close();
            }
        }

        private void NoReturnForm_Shown(object sender, EventArgs e)
        {
            this.StatGrid.PrimaryGrid.EnableCellMerging = true;
            this.StatGrid.PrimaryGrid.Columns[2].CellMergeMode = CellMergeMode.None;
            btnRefreshArchive_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void GetWorkBook(string strFile)
        {
           // string[,] data = new string[,] { { "年级", "班级", "姓名", "学号" }, { "八年级", "一班", "LiuHui", "080831" }, { "八年级", "二班", "LIYang", "080832" }, { "九年级", "一班", "WangHui", "080833" }, { "八年级", "三班", "LiMing", "080834" } };

            XLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("未归还统计清单_"+DateTime.Now.ToString("yyyyMMdd"));
            IXLStyle style = workSheet.Style;

            style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            style.Alignment.Vertical = XLAlignmentVerticalValues.Bottom;

            //设置底部边框及颜色  
            style.Border.BottomBorder = XLBorderStyleValues.MediumDashDot;
            style.Border.BottomBorderColor = XLColor.BlueGray;

            //设置顶部边框及颜色  
            style.Border.TopBorder = XLBorderStyleValues.SlantDashDot;
            style.Border.TopBorderColor = XLColor.BlueGray;

            //设置左部边框及颜色  
            style.Border.LeftBorder = XLBorderStyleValues.MediumDashDotDot;
            style.Border.LeftBorderColor = XLColor.BlueGray;

            //设置右部边框及颜色  
            style.Border.RightBorder = XLBorderStyleValues.Hair;
            style.Border.RightBorderColor = XLColor.BlueGray;

            style.Font.Bold = true;
            style.Font.FontColor = XLColor.Black;
            style.Font.FontName = "微软雅黑";
            style.Font.FontSize = 12;
            style.Font.Italic = false;
            style.Font.Shadow = false;
           // style.Font.Underline = XLFontUnderlineValues.Double;

            //设置A1，B1的字体颜色为灰色  
            //workSheet.Range("A1", "B1").Style.Font.FontColor = XLColor.BlizzardBlue;
            //把第5行第1列和第2列合并单元格  
           // workSheet.Range(5, 1, 5, 2).Merge();
            //设置第5行第1列和第2列内容左对齐  
            //workSheet.Range(5, 1, 5, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            //设置列的宽度  
            workSheet.Column(1).Width = 60;
            workSheet.Column(2).Width = 60;
            workSheet.Columns(3, 7).Width = 45;
            //设置第4到7列的宽度  
           // workSheet.Columns(4, 7).Width = 40;
            int iCol = 1;
            foreach(GridColumn gc in StatGrid.PrimaryGrid.Columns){
                workSheet.Cell(1, iCol++).Value = gc.HeaderText;
            }
            for (int i = 0; i < StatGrid.PrimaryGrid.Columns.Count; i++)
            {
                int j = 0;
                foreach (GridRow gr in StatGrid.PrimaryGrid.Rows)
                {
                    j++;
                    workSheet.Cell(j + 1, i + 1).Value = gr[i].Value;
                }
            }

            workBook.SaveAs(strFile);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //StatGrid.PrimaryGrid.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel File|*.xlsx";
            if (sfd.ShowDialog().Equals(DialogResult.OK))
            {
                GetWorkBook(sfd.FileName);
            }
        }  
    }
}
