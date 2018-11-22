namespace ztoffice
{
    partial class FrXiangqing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrXiangqing));
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看附件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.确认完成情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtshijian = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtzhuti = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtzhuchiren = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtjiluren = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcanhuirenyuan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.会议时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.纪要内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.完成责任人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.纪要上传人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.落实措施 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.落实情况 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.已查看 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.完成时间节点 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.完成时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.更新 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.批复 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.已完成 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.考核绩效点 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewX2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.会议时间,
            this.纪要内容,
            this.完成责任人,
            this.纪要上传人,
            this.落实措施,
            this.落实情况,
            this.已查看,
            this.完成时间节点,
            this.完成时间,
            this.更新,
            this.批复,
            this.已完成,
            this.考核绩效点});
            this.dataGridViewX2.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX2.Name = "dataGridViewX2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX2.RowTemplate.Height = 27;
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(1197, 591);
            this.dataGridViewX2.TabIndex = 35;
            this.dataGridViewX2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX2_CellDoubleClick);
            this.dataGridViewX2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX2_CellPainting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看附件ToolStripMenuItem,
            this.确认完成情况ToolStripMenuItem,
            this.保存时间ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 82);
            // 
            // 查看附件ToolStripMenuItem
            // 
            this.查看附件ToolStripMenuItem.Name = "查看附件ToolStripMenuItem";
            this.查看附件ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.查看附件ToolStripMenuItem.Text = "查看附件";
            this.查看附件ToolStripMenuItem.Click += new System.EventHandler(this.查看附件ToolStripMenuItem_Click);
            // 
            // 确认完成情况ToolStripMenuItem
            // 
            this.确认完成情况ToolStripMenuItem.Name = "确认完成情况ToolStripMenuItem";
            this.确认完成情况ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.确认完成情况ToolStripMenuItem.Text = "确认完成";
            this.确认完成情况ToolStripMenuItem.Click += new System.EventHandler(this.确认完成情况ToolStripMenuItem_Click);
            // 
            // 保存时间ToolStripMenuItem
            // 
            this.保存时间ToolStripMenuItem.Name = "保存时间ToolStripMenuItem";
            this.保存时间ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.保存时间ToolStripMenuItem.Text = "保存节点时间";
            this.保存时间ToolStripMenuItem.Click += new System.EventHandler(this.保存时间ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "会议时间:";
            // 
            // txtshijian
            // 
            // 
            // 
            // 
            this.txtshijian.Border.Class = "TextBoxBorder";
            this.txtshijian.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtshijian.Location = new System.Drawing.Point(227, 9);
            this.txtshijian.Name = "txtshijian";
            this.txtshijian.PreventEnterBeep = true;
            this.txtshijian.ReadOnly = true;
            this.txtshijian.Size = new System.Drawing.Size(158, 25);
            this.txtshijian.TabIndex = 37;
            // 
            // txtzhuti
            // 
            // 
            // 
            // 
            this.txtzhuti.Border.Class = "TextBoxBorder";
            this.txtzhuti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtzhuti.Location = new System.Drawing.Point(227, 63);
            this.txtzhuti.Name = "txtzhuti";
            this.txtzhuti.PreventEnterBeep = true;
            this.txtzhuti.ReadOnly = true;
            this.txtzhuti.Size = new System.Drawing.Size(158, 25);
            this.txtzhuti.TabIndex = 38;
            // 
            // txtzhuchiren
            // 
            // 
            // 
            // 
            this.txtzhuchiren.Border.Class = "TextBoxBorder";
            this.txtzhuchiren.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtzhuchiren.Location = new System.Drawing.Point(546, 9);
            this.txtzhuchiren.Name = "txtzhuchiren";
            this.txtzhuchiren.PreventEnterBeep = true;
            this.txtzhuchiren.ReadOnly = true;
            this.txtzhuchiren.Size = new System.Drawing.Size(100, 25);
            this.txtzhuchiren.TabIndex = 39;
            // 
            // txtjiluren
            // 
            // 
            // 
            // 
            this.txtjiluren.Border.Class = "TextBoxBorder";
            this.txtjiluren.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtjiluren.Location = new System.Drawing.Point(546, 63);
            this.txtjiluren.Name = "txtjiluren";
            this.txtjiluren.PreventEnterBeep = true;
            this.txtjiluren.ReadOnly = true;
            this.txtjiluren.Size = new System.Drawing.Size(100, 25);
            this.txtjiluren.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 41;
            this.label2.Text = "会议主题:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "主持人:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 43;
            this.label4.Text = "记录人:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(703, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 44;
            this.label5.Text = "参会人员:";
            // 
            // txtcanhuirenyuan
            // 
            // 
            // 
            // 
            this.txtcanhuirenyuan.Border.Class = "TextBoxBorder";
            this.txtcanhuirenyuan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtcanhuirenyuan.Location = new System.Drawing.Point(784, 9);
            this.txtcanhuirenyuan.Multiline = true;
            this.txtcanhuirenyuan.Name = "txtcanhuirenyuan";
            this.txtcanhuirenyuan.PreventEnterBeep = true;
            this.txtcanhuirenyuan.ReadOnly = true;
            this.txtcanhuirenyuan.Size = new System.Drawing.Size(273, 87);
            this.txtcanhuirenyuan.TabIndex = 45;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtcanhuirenyuan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtshijian);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtzhuti);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtzhuchiren);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtjiluren);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 100);
            this.panel1.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewX2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1197, 591);
            this.panel2.TabIndex = 47;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // 会议时间
            // 
            this.会议时间.DataPropertyName = "会议时间";
            this.会议时间.HeaderText = "会议时间";
            this.会议时间.Name = "会议时间";
            this.会议时间.ReadOnly = true;
            this.会议时间.Visible = false;
            // 
            // 纪要内容
            // 
            this.纪要内容.DataPropertyName = "纪要内容";
            this.纪要内容.HeaderText = "纪要内容";
            this.纪要内容.Name = "纪要内容";
            this.纪要内容.ReadOnly = true;
            // 
            // 完成责任人
            // 
            this.完成责任人.DataPropertyName = "完成责任人";
            this.完成责任人.HeaderText = "完成责任人";
            this.完成责任人.Name = "完成责任人";
            this.完成责任人.ReadOnly = true;
            // 
            // 纪要上传人
            // 
            this.纪要上传人.DataPropertyName = "纪要上传人";
            this.纪要上传人.HeaderText = "纪要上传人";
            this.纪要上传人.Name = "纪要上传人";
            this.纪要上传人.Visible = false;
            // 
            // 落实措施
            // 
            this.落实措施.DataPropertyName = "落实措施";
            this.落实措施.HeaderText = "落实措施";
            this.落实措施.Name = "落实措施";
            this.落实措施.ReadOnly = true;
            // 
            // 落实情况
            // 
            this.落实情况.DataPropertyName = "落实情况";
            this.落实情况.HeaderText = "落实情况";
            this.落实情况.Name = "落实情况";
            this.落实情况.ReadOnly = true;
            // 
            // 已查看
            // 
            this.已查看.Checked = true;
            this.已查看.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.已查看.CheckValue = "N";
            this.已查看.CheckValueChecked = "1";
            this.已查看.CheckValueUnchecked = "0";
            this.已查看.DataPropertyName = "已查看";
            this.已查看.HeaderText = "是否查看";
            this.已查看.Name = "已查看";
            this.已查看.ReadOnly = true;
            this.已查看.Visible = false;
            // 
            // 完成时间节点
            // 
            // 
            // 
            // 
            this.完成时间节点.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.完成时间节点.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.完成时间节点.ButtonDropDown.Visible = true;
            this.完成时间节点.CustomFormat = "yyyy-MM-dd HH:mm";
            this.完成时间节点.DataPropertyName = "完成时间节点";
            this.完成时间节点.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.完成时间节点.HeaderText = "完成时间节点";
            this.完成时间节点.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            // 
            // 
            // 
            this.完成时间节点.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.完成时间节点.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.完成时间节点.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.完成时间节点.MonthCalendar.DisplayMonth = new System.DateTime(2018, 3, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.完成时间节点.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.完成时间节点.Name = "完成时间节点";
            this.完成时间节点.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 完成时间
            // 
            this.完成时间.DataPropertyName = "完成时间";
            this.完成时间.HeaderText = "完成时间";
            this.完成时间.Name = "完成时间";
            this.完成时间.ReadOnly = true;
            this.完成时间.Visible = false;
            // 
            // 更新
            // 
            this.更新.DataPropertyName = "更新";
            this.更新.HeaderText = "更新";
            this.更新.Name = "更新";
            // 
            // 批复
            // 
            this.批复.DataPropertyName = "批复";
            this.批复.HeaderText = "批复";
            this.批复.Name = "批复";
            // 
            // 已完成
            // 
            this.已完成.Checked = true;
            this.已完成.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.已完成.CheckValue = "N";
            this.已完成.CheckValueChecked = "1";
            this.已完成.CheckValueUnchecked = "0";
            this.已完成.DataPropertyName = "已完成";
            this.已完成.HeaderText = "已完成";
            this.已完成.Name = "已完成";
            this.已完成.ReadOnly = true;
            // 
            // 考核绩效点
            // 
            this.考核绩效点.DataPropertyName = "考核绩效点";
            this.考核绩效点.HeaderText = "考核绩效点";
            this.考核绩效点.Name = "考核绩效点";
            this.考核绩效点.ReadOnly = true;
            // 
            // FrXiangqing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 691);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrXiangqing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详情";
            this.Load += new System.EventHandler(this.FrXiangqing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtshijian;
        private DevComponents.DotNetBar.Controls.TextBoxX txtzhuti;
        private DevComponents.DotNetBar.Controls.TextBoxX txtzhuchiren;
        private DevComponents.DotNetBar.Controls.TextBoxX txtjiluren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtcanhuirenyuan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看附件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 确认完成情况ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem 保存时间ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 会议时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 纪要内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 完成责任人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 纪要上传人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 落实措施;
        private System.Windows.Forms.DataGridViewTextBoxColumn 落实情况;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn 已查看;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn 完成时间节点;
        private System.Windows.Forms.DataGridViewTextBoxColumn 完成时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 更新;
        private System.Windows.Forms.DataGridViewTextBoxColumn 批复;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn 已完成;
        private System.Windows.Forms.DataGridViewTextBoxColumn 考核绩效点;
    }
}