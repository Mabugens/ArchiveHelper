﻿namespace ArchiveHelper
{
    partial class NoReturnForm
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
            this.StatGrid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnRefreshArchive = new DevComponents.DotNetBar.ButtonX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatGrid
            // 
            this.StatGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.StatGrid.Location = new System.Drawing.Point(0, 51);
            this.StatGrid.Name = "StatGrid";
            this.StatGrid.PrimaryGrid.Caption.RowHeight = 40;
            this.StatGrid.PrimaryGrid.Caption.Text = "未归还统计";
            gridColumn1.DefaultNewRowCellValue = "";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl);
            gridColumn1.FilterPopupMaxItems = 75;
            gridColumn1.HeaderText = "项目名称";
            gridColumn1.Name = "gcProjectName";
            gridColumn1.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            gridColumn1.Width = 275;
            gridColumn2.HeaderText = "资料名称";
            gridColumn2.Name = "gcArchName";
            gridColumn2.Width = 360;
            gridColumn3.HeaderText = "未归还份数";
            gridColumn3.Name = "gcAllCount";
            gridColumn3.Width = 80;
            gridColumn4.HeaderText = "借出人";
            gridColumn4.Name = "gcBorrower";
            gridColumn5.HeaderText = "电话";
            gridColumn5.Name = "gcPhone";
            gridColumn6.HeaderText = "借出单位";
            gridColumn6.Name = "gcUnit";
            gridColumn7.HeaderText = "借出事由";
            gridColumn7.Name = "gcReason";
            gridColumn8.HeaderText = "是否需要归还";
            gridColumn8.Name = "gcNeedReturn";
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn1);
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn2);
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn3);
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn4);
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn5);
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn6);
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn7);
            this.StatGrid.PrimaryGrid.Columns.Add(gridColumn8);
            this.StatGrid.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StatGrid.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.Black;
            this.StatGrid.PrimaryGrid.EnableFiltering = true;
            this.StatGrid.PrimaryGrid.Filter.RowHeight = 25;
            this.StatGrid.PrimaryGrid.Filter.Visible = true;
            this.StatGrid.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.StatGrid.PrimaryGrid.RowHeaderWidth = 65;
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
            this.StatGrid.PrimaryGrid.Rows.Add(gridRow1);
            this.StatGrid.PrimaryGrid.Rows.Add(gridRow2);
            this.StatGrid.PrimaryGrid.ShowRowGridIndex = true;
            this.StatGrid.Size = new System.Drawing.Size(1290, 540);
            this.StatGrid.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonX1);
            this.panel2.Controls.Add(this.btnRefreshArchive);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1290, 51);
            this.panel2.TabIndex = 4;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(1140, 15);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "buttonX1";
            this.buttonX1.Visible = false;
            // 
            // btnRefreshArchive
            // 
            this.btnRefreshArchive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefreshArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshArchive.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefreshArchive.Location = new System.Drawing.Point(259, 15);
            this.btnRefreshArchive.Name = "btnRefreshArchive";
            this.btnRefreshArchive.Size = new System.Drawing.Size(75, 26);
            this.btnRefreshArchive.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnRefreshArchive.TabIndex = 2;
            this.btnRefreshArchive.Text = "未归还统计";
            this.btnRefreshArchive.Visible = false;
            this.btnRefreshArchive.Click += new System.EventHandler(this.btnRefreshArchive_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(26, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 26);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(164, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 26);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "打印";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // NoReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 591);
            this.Controls.Add(this.StatGrid);
            this.Controls.Add(this.panel2);
            this.Name = "NoReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "未归还统计";
            this.Shown += new System.EventHandler(this.NoReturnForm_Shown);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl StatGrid;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnRefreshArchive;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnPrint;
    }
}