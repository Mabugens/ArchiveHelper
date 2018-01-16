namespace ArchiveHelper
{
    partial class ReturnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveReturn = new DevComponents.DotNetBar.ButtonX();
            this.btnReturn = new DevComponents.DotNetBar.ButtonX();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReturnGrid
            // 
            this.ReturnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReturnGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.ReturnGrid.Location = new System.Drawing.Point(0, 51);
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
            this.ReturnGrid.Size = new System.Drawing.Size(1056, 517);
            this.ReturnGrid.TabIndex = 7;
            this.ReturnGrid.Text = "superGridControl3";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonX1);
            this.panel4.Controls.Add(this.btnSaveReturn);
            this.panel4.Controls.Add(this.btnReturn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1056, 51);
            this.panel4.TabIndex = 6;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(124, 15);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 26);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "刷新";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnSaveReturn
            // 
            this.btnSaveReturn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveReturn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveReturn.Location = new System.Drawing.Point(890, 15);
            this.btnSaveReturn.Name = "btnSaveReturn";
            this.btnSaveReturn.Size = new System.Drawing.Size(75, 26);
            this.btnSaveReturn.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSaveReturn.TabIndex = 2;
            this.btnSaveReturn.Text = "保存";
            this.btnSaveReturn.Click += new System.EventHandler(this.btnSaveReturn_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReturn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReturn.Location = new System.Drawing.Point(27, 15);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 26);
            this.btnReturn.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "登记归还";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 568);
            this.Controls.Add(this.ReturnGrid);
            this.Controls.Add(this.panel4);
            this.Name = "ReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "归还资料";
            this.Shown += new System.EventHandler(this.ReturnForm_Shown);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl ReturnGrid;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnSaveReturn;
        private DevComponents.DotNetBar.ButtonX btnReturn;
    }
}