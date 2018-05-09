namespace ArchiveHelper
{
    partial class ReturnGridCtrl
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
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell5 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell6 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.ReturnGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.SuspendLayout();
            // 
            // ReturnGrid
            // 
            this.ReturnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReturnGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.ReturnGrid.Location = new System.Drawing.Point(0, 0);
            this.ReturnGrid.Name = "ReturnGrid";
            this.ReturnGrid.PrimaryGrid.Caption.RowHeight = 40;
            this.ReturnGrid.PrimaryGrid.Caption.Text = "资料总目";
            gridColumn1.Name = "gcId";
            gridColumn1.Visible = false;
            gridColumn2.HeaderText = "资料名称";
            gridColumn2.Name = "gcArchName";
            gridColumn2.Width = 360;
            gridColumn3.HeaderText = "归还日期";
            gridColumn3.Name = "gcReturnDate";
            gridColumn4.HeaderText = "份数";
            gridColumn4.Name = "gcReturnCount";
            gridColumn5.HeaderText = "归还人";
            gridColumn5.Name = "gcReturnPerson";
            gridColumn5.Width = 70;
            gridColumn6.HeaderText = "有无缺失损坏";
            gridColumn6.Name = "gcMissingDamage";
            gridColumn6.Width = 90;
            gridColumn7.HeaderText = "备注";
            gridColumn7.Name = "gcRemark";
            gridColumn7.Width = 80;
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn1);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn2);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn3);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn4);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn5);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn6);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn7);
            this.ReturnGrid.PrimaryGrid.EnableFiltering = true;
            this.ReturnGrid.PrimaryGrid.Filter.RowHeight = 25;
            this.ReturnGrid.PrimaryGrid.Filter.Visible = true;
            this.ReturnGrid.PrimaryGrid.RowHeaderIndexOffset = 1;
            gridRow1.Cells.Add(gridCell1);
            gridRow1.Cells.Add(gridCell2);
            gridRow1.Cells.Add(gridCell3);
            gridRow1.Cells.Add(gridCell4);
            gridRow1.Cells.Add(gridCell5);
            gridRow1.Cells.Add(gridCell6);
            gridRow1.InfoText = "";
            this.ReturnGrid.PrimaryGrid.Rows.Add(gridRow1);
            this.ReturnGrid.PrimaryGrid.Rows.Add(gridRow2);
            this.ReturnGrid.PrimaryGrid.ShowRowGridIndex = true;
            this.ReturnGrid.Size = new System.Drawing.Size(847, 431);
            this.ReturnGrid.TabIndex = 6;
            this.ReturnGrid.Text = "superGridControl3";
            // 
            // ReturnGridCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReturnGrid);
            this.Name = "ReturnGridCtrl";
            this.Size = new System.Drawing.Size(847, 431);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl ReturnGrid;
    }
}
