namespace ztoffice.Service
{
    partial class Frchakan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frchakan));
            this.label1 = new System.Windows.Forms.Label();
            this.textNeirong = new System.Windows.Forms.RichTextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "公告内容:";
            // 
            // textNeirong
            // 
            this.textNeirong.Location = new System.Drawing.Point(42, 36);
            this.textNeirong.Name = "textNeirong";
            this.textNeirong.Size = new System.Drawing.Size(550, 366);
            this.textNeirong.TabIndex = 5;
            this.textNeirong.Text = "";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(612, 48);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(88, 38);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "下载附件";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Frchakan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 441);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textNeirong);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frchakan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看公告";
            this.Load += new System.EventHandler(this.Frchakan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textNeirong;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}