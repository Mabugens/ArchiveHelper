namespace ArchiveHelper
{
    partial class ArchiveGridCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell5 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell6 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BackColorBlend backColorBlend1 = new DevComponents.DotNetBar.SuperGrid.Style.BackColorBlend();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell7 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell8 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell9 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.ArchiveGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.SuspendLayout();
            // 
            // ArchiveGrid
            // 
            this.ArchiveGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.ArchiveGrid.Location = new System.Drawing.Point(0, 0);
            this.ArchiveGrid.Name = "ArchiveGrid";
            this.ArchiveGrid.PrimaryGrid.Caption.RowHeight = 40;
            this.ArchiveGrid.PrimaryGrid.Caption.Text = "资料总目";
            gridColumn1.HeaderText = "资料名称";
            gridColumn1.Name = "gcArchName";
            gridColumn1.Width = 360;
            gridColumn2.DefaultNewRowCellValue = "";
            gridColumn2.Name = "gcId";
            gridColumn2.Visible = false;
            gridColumn3.DefaultNewRowCellValue = "";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl);
            gridColumn3.FilterPopupMaxItems = 75;
            gridColumn3.HeaderText = "资料分类";
            gridColumn3.Name = "gcType";
            gridColumn3.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            gridColumn3.Width = 75;
            gridColumn4.HeaderText = "资料日期";
            gridColumn4.Name = "gcArchDate";
            gridColumn4.Width = 80;
            gridColumn5.HeaderText = "文号";
            gridColumn5.Name = "gcDispatchNum";
            gridColumn5.Width = 160;
            gridColumn6.HeaderText = "总份数";
            gridColumn6.Name = "gcAllCount";
            gridColumn6.Width = 58;
            gridColumn7.HeaderText = "剩余份数";
            gridColumn7.Name = "gcRemaining";
            gridColumn7.Width = 58;
            gridColumn8.HeaderText = "存放位置";
            gridColumn8.Name = "gcLocation";
            gridColumn9.HeaderText = "经办人";
            gridColumn9.Name = "gcHandler";
            gridColumn9.Width = 70;
            gridColumn10.Name = "gcProjectId";
            gridColumn10.Visible = false;
            gridColumn11.HeaderText = "收存日期";
            gridColumn11.Name = "gcRegisteDate";
            gridColumn11.Width = 80;
            gridColumn12.HeaderText = "备注";
            gridColumn12.Name = "gcRemark";
            gridColumn13.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn13.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            gridColumn13.HeaderText = "借出";
            gridColumn13.Name = "gcLend";
            gridColumn13.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            gridColumn13.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn13.Width = 80;
            gridColumn14.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            gridColumn14.HeaderText = "归还";
            gridColumn14.Name = "gcReturn";
            gridColumn14.Width = 80;
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn1);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn2);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn3);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn4);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn5);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn6);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn7);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn8);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn9);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn10);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn11);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn12);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn13);
            this.ArchiveGrid.PrimaryGrid.Columns.Add(gridColumn14);
            this.ArchiveGrid.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ArchiveGrid.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.Black;
            this.ArchiveGrid.PrimaryGrid.EnableFiltering = true;
            this.ArchiveGrid.PrimaryGrid.Filter.RowHeight = 25;
            this.ArchiveGrid.PrimaryGrid.Filter.Visible = true;
            this.ArchiveGrid.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.ArchiveGrid.PrimaryGrid.RowHeaderWidth = 65;
            gridCell1.Value = "1";
            gridCell2.Value = "2";
            gridRow1.Cells.Add(gridCell1);
            gridRow1.Cells.Add(gridCell2);
            gridRow1.Cells.Add(gridCell3);
            gridRow1.Cells.Add(gridCell4);
            gridRow1.Cells.Add(gridCell5);
            gridRow1.Cells.Add(gridCell6);
            backColorBlend1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.CornflowerBlue};
            background1.BackColorBlend = backColorBlend1;
            background1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            gridRow1.CellStyles.Default.Background = background1;
            gridRow1.Expanded = true;
            gridRow1.InfoText = "";
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.Goldenrod;
            gridRow1.RowStyles.Default.Background = background2;
            gridCell7.Value = "2";
            gridCell8.Value = "2";
            gridRow2.Cells.Add(gridCell7);
            gridRow2.Cells.Add(gridCell8);
            gridRow2.Cells.Add(gridCell9);
            this.ArchiveGrid.PrimaryGrid.Rows.Add(gridRow1);
            this.ArchiveGrid.PrimaryGrid.Rows.Add(gridRow2);
            this.ArchiveGrid.PrimaryGrid.ShowRowGridIndex = true;
            this.ArchiveGrid.Size = new System.Drawing.Size(1140, 587);
            this.ArchiveGrid.TabIndex = 4;
            this.ArchiveGrid.Text = "superGridControl3";
            // 
            // ArchiveGridCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ArchiveGrid);
            this.Name = "ArchiveGridCtrl";
            this.Size = new System.Drawing.Size(1140, 587);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl ArchiveGrid;

    }
}
