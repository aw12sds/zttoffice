﻿namespace ztoffice.shixiang
{
    partial class Frhuiyixiangxi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frhuiyixiangxi));
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.落实改善ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.导出表格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 762);
            this.panel2.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.落实改善ToolStripMenuItem,
            this.导出表格ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 52);
            // 
            // 落实改善ToolStripMenuItem
            // 
            this.落实改善ToolStripMenuItem.Name = "落实改善ToolStripMenuItem";
            this.落实改善ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.落实改善ToolStripMenuItem.Text = "落实改善";
            this.落实改善ToolStripMenuItem.Click += new System.EventHandler(this.落实改善ToolStripMenuItem_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.gridControl1.Size = new System.Drawing.Size(1014, 762);
            this.gridControl1.TabIndex = 41;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 50;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Appearance.BackColor = System.Drawing.Color.White;
            this.repositoryItemProgressBar1.EndColor = System.Drawing.Color.Blue;
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // 导出表格ToolStripMenuItem
            // 
            this.导出表格ToolStripMenuItem.Name = "导出表格ToolStripMenuItem";
            this.导出表格ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.导出表格ToolStripMenuItem.Text = "导出表格";
            this.导出表格ToolStripMenuItem.Click += new System.EventHandler(this.导出表格ToolStripMenuItem_Click);
            // 
            // Frhuiyixiangxi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 762);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frhuiyixiangxi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详情";
            this.Load += new System.EventHandler(this.Frhuiyixiangxi_Load);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 落实改善ToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem 导出表格ToolStripMenuItem;
    }
}