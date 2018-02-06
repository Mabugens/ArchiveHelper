namespace ArchiveHelper
{
    partial class LendForm
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BackColorBlend backColorBlend1 = new DevComponents.DotNetBar.SuperGrid.Style.BackColorBlend();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell5 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridCell gridCell6 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LendForm));
            this.LendGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveAndReturn = new DevComponents.DotNetBar.ButtonX();
            this.btnLendRefresh = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveSend = new DevComponents.DotNetBar.ButtonX();
            this.btnLend = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LendGrid
            // 
            this.LendGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LendGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.LendGrid.Location = new System.Drawing.Point(0, 51);
            this.LendGrid.Name = "LendGrid";
            this.LendGrid.PrimaryGrid.Caption.RowHeight = 40;
            this.LendGrid.PrimaryGrid.Caption.Text = "资料借出登记表";
            gridColumn1.HeaderText = "资料名称";
            gridColumn1.Name = "gcArchName";
            gridColumn1.Width = 360;
            gridColumn2.Name = "gcId";
            gridColumn2.Visible = false;
            gridColumn3.HeaderText = "借出日期";
            gridColumn3.Name = "gcLendDate";
            backColorBlend1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.LightGray};
            background1.BackColorBlend = backColorBlend1;
            gridColumn4.CellStyles.Default.Background = background1;
            gridColumn4.HeaderText = "份数";
            gridColumn4.Name = "gcCount";
            gridColumn5.HeaderText = "借出事由";
            gridColumn5.Name = "gcReason";
            gridColumn5.Width = 70;
            gridColumn6.HeaderText = "借出单位";
            gridColumn6.Name = "gcLendUnit";
            gridColumn6.Width = 60;
            gridColumn7.HeaderText = "借出人";
            gridColumn7.Name = "gcBorrower";
            gridColumn8.HeaderText = "电话";
            gridColumn8.Name = "gcPhone";
            gridColumn8.Width = 80;
            gridColumn9.HeaderText = "预计归还时间";
            gridColumn9.Name = "gcRebackDate";
            gridColumn10.HeaderText = "经办人";
            gridColumn10.Name = "gcHandler";
            gridColumn11.HeaderText = "核准人";
            gridColumn11.Name = "gcApprovedBy";
            gridColumn12.HeaderText = "是否需要归还";
            gridColumn12.Name = "gcNeedReturn";
            gridColumn13.Name = "gcArchId";
            gridColumn13.Visible = false;
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn1);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn2);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn3);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn4);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn5);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn6);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn7);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn8);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn9);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn10);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn11);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn12);
            this.LendGrid.PrimaryGrid.Columns.Add(gridColumn13);
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
            this.LendGrid.Size = new System.Drawing.Size(1283, 543);
            this.LendGrid.TabIndex = 7;
            this.LendGrid.Text = "superGridControl3";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnSaveAndReturn);
            this.panel3.Controls.Add(this.btnLendRefresh);
            this.panel3.Controls.Add(this.btnSaveSend);
            this.panel3.Controls.Add(this.btnLend);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1283, 51);
            this.panel3.TabIndex = 6;
            // 
            // btnSaveAndReturn
            // 
            this.btnSaveAndReturn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveAndReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndReturn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveAndReturn.Location = new System.Drawing.Point(1131, 15);
            this.btnSaveAndReturn.Name = "btnSaveAndReturn";
            this.btnSaveAndReturn.Size = new System.Drawing.Size(140, 26);
            this.btnSaveAndReturn.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSaveAndReturn.TabIndex = 4;
            this.btnSaveAndReturn.Text = "保存并返回登记收存";
            this.btnSaveAndReturn.Click += new System.EventHandler(this.btnSaveAndReturn_Click);
            // 
            // btnLendRefresh
            // 
            this.btnLendRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLendRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLendRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLendRefresh.Location = new System.Drawing.Point(130, 15);
            this.btnLendRefresh.Name = "btnLendRefresh";
            this.btnLendRefresh.Size = new System.Drawing.Size(75, 26);
            this.btnLendRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnLendRefresh.TabIndex = 3;
            this.btnLendRefresh.Text = "刷新";
            this.btnLendRefresh.Click += new System.EventHandler(this.btnLendRefresh_Click);
            // 
            // btnSaveSend
            // 
            this.btnSaveSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveSend.Location = new System.Drawing.Point(1025, 15);
            this.btnSaveSend.Name = "btnSaveSend";
            this.btnSaveSend.Size = new System.Drawing.Size(75, 26);
            this.btnSaveSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSaveSend.TabIndex = 2;
            this.btnSaveSend.Text = "保存";
            this.btnSaveSend.Click += new System.EventHandler(this.btnSaveSend_Click);
            // 
            // btnLend
            // 
            this.btnLend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLend.Location = new System.Drawing.Point(27, 15);
            this.btnLend.Name = "btnLend";
            this.btnLend.Size = new System.Drawing.Size(75, 26);
            this.btnLend.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnLend.TabIndex = 0;
            this.btnLend.Text = "登记借出";
            this.btnLend.Click += new System.EventHandler(this.btnLend_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(345, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextColor = System.Drawing.Color.Red;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // LendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 594);
            this.Controls.Add(this.LendGrid);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "借出资料";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LendForm_FormClosing);
            this.Shown += new System.EventHandler(this.LendForm_Shown);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl LendGrid;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ButtonX btnLendRefresh;
        private DevComponents.DotNetBar.ButtonX btnSaveSend;
        private DevComponents.DotNetBar.ButtonX btnLend;
        private DevComponents.DotNetBar.ButtonX btnSaveAndReturn;
        private DevComponents.DotNetBar.ButtonX btnDelete;
    }
}