namespace ArchiveHelper
{
    partial class LendGridCtrl
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
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell5 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell6 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.LendGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.SuspendLayout();
            // 
            // LendGrid
            // 
            this.LendGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LendGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.LendGrid.Location = new System.Drawing.Point(0, 0);
            this.LendGrid.Name = "LendGrid";
            this.LendGrid.PrimaryGrid.Caption.RowHeight = 40;
            this.LendGrid.PrimaryGrid.Caption.Text = "资料总目";
            gridColumn1.Name = "gcId";
            gridColumn1.Visible = false;
            gridColumn2.HeaderText = "资料名称";
            gridColumn2.Name = "gcArchName";
            gridColumn2.Width = 360;
            gridColumn3.HeaderText = "借出日期";
            gridColumn3.Name = "gcLendDate";
            gridColumn4.HeaderText = "份数";
            gridColumn4.Name = "gcCount";
            gridColumn5.HeaderText = "借出事由";
            gridColumn5.Name = "gcReason";
            gridColumn5.Width = 70;
            gridColumn6.HeaderText = "借出单位";
            gridColumn6.Name = "gcLendUnit";
            gridColumn6.Width = 60;
            gridColumn7.HeaderText = "借出人";
            gridColumn7.Name = "gcLender";
            gridColumn8.HeaderText = "电话";
            gridColumn8.Name = "gcPhone";
            gridColumn8.Width = 80;
            gridColumn9.HeaderText = "预计归还时间";
            gridColumn9.Name = "gcRebackDate";
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn1);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn2);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn3);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn4);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn5);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn6);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn7);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn8);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn9);
            this.LendGrid.PrimaryGrid.EnableFiltering = true;
            this.LendGrid.PrimaryGrid.Filter.RowHeight = 25;
            this.LendGrid.PrimaryGrid.Filter.Visible = true;
            this.LendGrid.PrimaryGrid.RowHeaderIndexOffset = 1;
            gridRow1.Cells.Add(gridCell1);
            gridRow1.Cells.Add(gridCell2);
            gridRow1.Cells.Add(gridCell3);
            gridRow1.Cells.Add(gridCell4);
            gridRow1.Cells.Add(gridCell5);
            gridRow1.Cells.Add(gridCell6);
            gridRow1.InfoText = "";
            this.LendGrid.PrimaryGrid.Rows.Add(gridRow1);
            this.LendGrid.PrimaryGrid.Rows.Add(gridRow2);
            this.LendGrid.PrimaryGrid.ShowRowGridIndex = true;
            this.LendGrid.Size = new System.Drawing.Size(976, 585);
            this.LendGrid.TabIndex = 6;
            this.LendGrid.Text = "superGridControl3";
            // 
            // LendGridCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LendGrid);
            this.Name = "LendGridCtrl";
            this.Size = new System.Drawing.Size(976, 585);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl LendGrid;
    }
}
