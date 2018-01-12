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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn29 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn30 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn31 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn32 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn33 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn34 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn35 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow9 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell25 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell26 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell27 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell28 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell29 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell30 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow10 = new DevComponents.DotNetBar.SuperGrid.GridRow();
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
            gridColumn29.Name = "gcId";
            gridColumn29.Visible = false;
            gridColumn30.HeaderText = "资料名称";
            gridColumn30.Name = "gcArchName";
            gridColumn30.Width = 360;
            gridColumn31.HeaderText = "归还日期";
            gridColumn31.Name = "gcReturnDate";
            gridColumn32.HeaderText = "份数";
            gridColumn32.Name = "gcReturnCount";
            gridColumn33.HeaderText = "归还人";
            gridColumn33.Name = "gcReturnPerson";
            gridColumn33.Width = 70;
            gridColumn34.HeaderText = "有无缺失损坏";
            gridColumn34.Name = "gcMissingDamage";
            gridColumn34.Width = 90;
            gridColumn35.HeaderText = "备注";
            gridColumn35.Name = "gcRemark";
            gridColumn35.Width = 80;
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn29);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn30);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn31);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn32);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn33);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn34);
            this.ReturnGrid.PrimaryGrid.Columns.Add(gridColumn35);
            this.ReturnGrid.PrimaryGrid.EnableFiltering = true;
            this.ReturnGrid.PrimaryGrid.Filter.RowHeight = 25;
            this.ReturnGrid.PrimaryGrid.Filter.Visible = true;
            this.ReturnGrid.PrimaryGrid.RowHeaderIndexOffset = 1;
            gridRow9.Cells.Add(gridCell25);
            gridRow9.Cells.Add(gridCell26);
            gridRow9.Cells.Add(gridCell27);
            gridRow9.Cells.Add(gridCell28);
            gridRow9.Cells.Add(gridCell29);
            gridRow9.Cells.Add(gridCell30);
            gridRow9.InfoText = "";
            this.ReturnGrid.PrimaryGrid.Rows.Add(gridRow9);
            this.ReturnGrid.PrimaryGrid.Rows.Add(gridRow10);
            this.ReturnGrid.PrimaryGrid.ShowRowGridIndex = true;
            this.ReturnGrid.Size = new System.Drawing.Size(1048, 466);
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
            this.panel4.Size = new System.Drawing.Size(1048, 51);
            this.panel4.TabIndex = 6;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnSaveReturn.Location = new System.Drawing.Point(882, 15);
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
            this.ClientSize = new System.Drawing.Size(1048, 517);
            this.Controls.Add(this.ReturnGrid);
            this.Controls.Add(this.panel4);
            this.Name = "ReturnForm";
            this.Text = "ReturnForm";
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