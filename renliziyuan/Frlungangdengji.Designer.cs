﻿namespace ztoffice.renliziyuan
{
    partial class Frlungangdengji
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
            this.labelStuName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStuName
            // 
            this.labelStuName.AutoSize = true;
            this.labelStuName.Location = new System.Drawing.Point(27, 13);
            this.labelStuName.Name = "labelStuName";
            this.labelStuName.Size = new System.Drawing.Size(67, 14);
            this.labelStuName.TabIndex = 0;
            this.labelStuName.Text = "大学生姓名";
            // 
            // Frlungangdengji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 282);
            this.Controls.Add(this.labelStuName);
            this.Name = "Frlungangdengji";
            this.Text = "Frlungangdengji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStuName;
    }
}