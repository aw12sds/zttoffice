namespace ztoffice.renliziyuan
{
    partial class Frwejidengji
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
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxStu = new System.Windows.Forms.ComboBox();
            this.Events = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Confirm = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(67, 14);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "大学生姓名";
            // 
            // comboBoxStu
            // 
            this.comboBoxStu.FormattingEnabled = true;
            this.comboBoxStu.Location = new System.Drawing.Point(86, 10);
            this.comboBoxStu.Name = "comboBoxStu";
            this.comboBoxStu.Size = new System.Drawing.Size(121, 22);
            this.comboBoxStu.TabIndex = 1;
            // 
            // Events
            // 
            this.Events.Location = new System.Drawing.Point(26, 74);
            this.Events.Name = "Events";
            this.Events.Size = new System.Drawing.Size(54, 20);
            this.Events.TabIndex = 2;
            this.Events.Text = "违纪类型";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "警告",
            "记过",
            "记大过"});
            this.comboBox1.Location = new System.Drawing.Point(86, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "违纪事件";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(86, 197);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(100, 23);
            this.Confirm.TabIndex = 12;
            this.Confirm.Text = "确认";
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "违纪次数";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 14;
            // 
            // Frwejidengji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Events);
            this.Controls.Add(this.comboBoxStu);
            this.Controls.Add(this.labelName);
            this.Name = "Frwejidengji";
            this.Text = "Frwejidengji";
            this.Load += new System.EventHandler(this.Frwejidengji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxStu;
        private System.Windows.Forms.Label Events;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton Confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}