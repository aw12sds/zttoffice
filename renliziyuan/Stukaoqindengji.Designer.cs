namespace ztoffice.renliziyuan
{
    partial class Stukaoqindengji
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
            this.StuName = new System.Windows.Forms.Label();
            this.comboStuName = new System.Windows.Forms.ComboBox();
            this.leixing = new System.Windows.Forms.Label();
            this.kaoqinleixing = new System.Windows.Forms.ComboBox();
            this.Hour = new System.Windows.Forms.Label();
            this.HourText = new System.Windows.Forms.TextBox();
            this.Confirm = new DevExpress.XtraEditors.SimpleButton();
            this.datetime = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // StuName
            // 
            this.StuName.AutoSize = true;
            this.StuName.Location = new System.Drawing.Point(41, 19);
            this.StuName.Name = "StuName";
            this.StuName.Size = new System.Drawing.Size(67, 14);
            this.StuName.TabIndex = 0;
            this.StuName.Text = "大学生姓名";
            // 
            // comboStuName
            // 
            this.comboStuName.FormattingEnabled = true;
            this.comboStuName.Location = new System.Drawing.Point(124, 16);
            this.comboStuName.Name = "comboStuName";
            this.comboStuName.Size = new System.Drawing.Size(121, 22);
            this.comboStuName.TabIndex = 1;
            this.comboStuName.SelectedIndexChanged += new System.EventHandler(this.comboStuName_SelectedIndexChanged);
            // 
            // leixing
            // 
            this.leixing.AutoSize = true;
            this.leixing.Location = new System.Drawing.Point(53, 107);
            this.leixing.Name = "leixing";
            this.leixing.Size = new System.Drawing.Size(55, 14);
            this.leixing.TabIndex = 2;
            this.leixing.Text = "考勤类型";
            // 
            // kaoqinleixing
            // 
            this.kaoqinleixing.FormattingEnabled = true;
            this.kaoqinleixing.Items.AddRange(new object[] {
            "请假",
            "迟到",
            "早退",
            "旷工"});
            this.kaoqinleixing.Location = new System.Drawing.Point(124, 104);
            this.kaoqinleixing.Name = "kaoqinleixing";
            this.kaoqinleixing.Size = new System.Drawing.Size(121, 22);
            this.kaoqinleixing.TabIndex = 3;
            // 
            // Hour
            // 
            this.Hour.AutoSize = true;
            this.Hour.Location = new System.Drawing.Point(65, 155);
            this.Hour.Name = "Hour";
            this.Hour.Size = new System.Drawing.Size(31, 14);
            this.Hour.TabIndex = 4;
            this.Hour.Text = "小时";
            // 
            // HourText
            // 
            this.HourText.Location = new System.Drawing.Point(124, 152);
            this.HourText.Name = "HourText";
            this.HourText.Size = new System.Drawing.Size(121, 22);
            this.HourText.TabIndex = 5;
            this.HourText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HourText_KeyPress);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(296, 84);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(100, 23);
            this.Confirm.TabIndex = 12;
            this.Confirm.Text = "确认";
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // datetime
            // 
            this.datetime.AutoSize = true;
            this.datetime.Location = new System.Drawing.Point(53, 61);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(55, 14);
            this.datetime.TabIndex = 13;
            this.datetime.Text = "发生时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(124, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 22);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // Stukaoqindengji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 206);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.datetime);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.HourText);
            this.Controls.Add(this.Hour);
            this.Controls.Add(this.kaoqinleixing);
            this.Controls.Add(this.leixing);
            this.Controls.Add(this.comboStuName);
            this.Controls.Add(this.StuName);
            this.Name = "Stukaoqindengji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入";
            this.Load += new System.EventHandler(this.Stukaoqindengji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StuName;
        private System.Windows.Forms.ComboBox comboStuName;
        private System.Windows.Forms.Label leixing;
        private System.Windows.Forms.ComboBox kaoqinleixing;
        private System.Windows.Forms.Label Hour;
        private System.Windows.Forms.TextBox HourText;
        private DevExpress.XtraEditors.SimpleButton Confirm;
        private System.Windows.Forms.Label datetime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}