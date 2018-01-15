﻿namespace ArchiveHelper
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLendRefresh = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveSend = new DevComponents.DotNetBar.ButtonX();
            this.btnLend = new DevComponents.DotNetBar.ButtonX();
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
            this.LendGrid.Size = new System.Drawing.Size(1053, 456);
            this.LendGrid.TabIndex = 7;
            this.LendGrid.Text = "superGridControl3";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLendRefresh);
            this.panel3.Controls.Add(this.btnSaveSend);
            this.panel3.Controls.Add(this.btnLend);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 51);
            this.panel3.TabIndex = 6;
            // 
            // btnLendRefresh
            // 
            this.btnLendRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLendRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLendRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLendRefresh.Location = new System.Drawing.Point(129, 15);
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
            this.btnSaveSend.Location = new System.Drawing.Point(887, 15);
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
            // LendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 507);
            this.Controls.Add(this.LendGrid);
            this.Controls.Add(this.panel3);
            this.Name = "LendForm";
            this.Text = "LendForm";
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
    }
}