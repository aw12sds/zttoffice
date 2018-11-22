namespace ztoffice
{
    partial class Frxiugaimima
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJiu = new System.Windows.Forms.TextBox();
            this.txtXin = new System.Windows.Forms.TextBox();
            this.txtQueren = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 310);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认新密码：";
            // 
            // txtJiu
            // 
            this.txtJiu.Location = new System.Drawing.Point(183, 101);
            this.txtJiu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJiu.Name = "txtJiu";
            this.txtJiu.Size = new System.Drawing.Size(132, 26);
            this.txtJiu.TabIndex = 3;
            this.txtJiu.UseSystemPasswordChar = true;
            this.txtJiu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJiu_KeyPress);
            // 
            // txtXin
            // 
            this.txtXin.Location = new System.Drawing.Point(183, 197);
            this.txtXin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXin.Name = "txtXin";
            this.txtXin.Size = new System.Drawing.Size(132, 26);
            this.txtXin.TabIndex = 4;
            this.txtXin.UseSystemPasswordChar = true;
            this.txtXin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXin_KeyPress);
            // 
            // txtQueren
            // 
            this.txtQueren.Location = new System.Drawing.Point(183, 305);
            this.txtQueren.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQueren.Name = "txtQueren";
            this.txtQueren.Size = new System.Drawing.Size(132, 26);
            this.txtQueren.TabIndex = 5;
            this.txtQueren.UseSystemPasswordChar = true;
            this.txtQueren.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQueren_KeyPress);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(183, 425);
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 35);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "提交";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Frxiugaimima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 521);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtQueren);
            this.Controls.Add(this.txtXin);
            this.Controls.Add(this.txtJiu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frxiugaimima";
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.Frxiugaimima_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJiu;
        private System.Windows.Forms.TextBox txtXin;
        private System.Windows.Forms.TextBox txtQueren;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}