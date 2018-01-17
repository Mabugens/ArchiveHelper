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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn21 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow5 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell13 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell14 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell15 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell16 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell17 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell18 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow6 = new DevComponents.DotNetBar.SuperGrid.GridRow();
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
            gridColumn15.Name = "gcId";
            gridColumn15.Visible = false;
            gridColumn16.HeaderText = "资料名称";
            gridColumn16.Name = "gcArchName";
            gridColumn16.Width = 360;
            gridColumn17.HeaderText = "归还日期";
            gridColumn17.Name = "gcReturnDate";
            gridColumn18.HeaderText = "份数";
            gridColumn18.Name = "gcReturnCount";
            gridColumn19.HeaderText = "归还人";
            gridColumn19.Name = "gcReturnPerson";
            gridColumn19.Width = 70;
            gridColumn20.HeaderText = "有无缺失损坏";
            gridColumn20.Name = "gcMissingDamage";
            gridColumn20.Width = 90;
            gridColumn21.HeaderText = "备注";
            gridColumn21.Name = "gcRemark";
            gridColumn21.Width = 80;
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn15);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn16);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn17);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn18);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn19);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn20);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn21);
            this.ReturnGrid.PrimaryGrid.EnableFiltering = true;
            this.ReturnGrid.PrimaryGrid.Filter.RowHeight = 25;
            this.ReturnGrid.PrimaryGrid.Filter.Visible = true;
            this.ReturnGrid.PrimaryGrid.RowHeaderIndexOffset = 1;
            gridRow5.Cells.Add(gridCell13);
            gridRow5.Cells.Add(gridCell14);
            gridRow5.Cells.Add(gridCell15);
            gridRow5.Cells.Add(gridCell16);
            gridRow5.Cells.Add(gridCell17);
            gridRow5.Cells.Add(gridCell18);
            gridRow5.InfoText = "";
            this.ReturnGrid.PrimaryGrid.Rows.Add(gridRow5);
            this.ReturnGrid.PrimaryGrid.Rows.Add(gridRow6);
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
            this.buttonX1.Location = new System.Drawing.Point(131, 15);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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