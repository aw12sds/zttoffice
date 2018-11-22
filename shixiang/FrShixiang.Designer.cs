namespace ztoffice
{
    partial class FrShixiang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrShixiang));
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtluoshiqingkuang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.txtluoshicuoshi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX2.Location = new System.Drawing.Point(327, 400);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(131, 50);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 106;
            this.buttonX2.Text = "提交";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Location = new System.Drawing.Point(113, 313);
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(345, 25);
            this.txtName.TabIndex = 104;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(12, 315);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 103;
            this.buttonX1.Text = "上传附件";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "落实情况:";
            // 
            // txtluoshiqingkuang
            // 
            // 
            // 
            // 
            this.txtluoshiqingkuang.Border.Class = "TextBoxBorder";
            this.txtluoshiqingkuang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtluoshiqingkuang.Location = new System.Drawing.Point(113, 35);
            this.txtluoshiqingkuang.Multiline = true;
            this.txtluoshiqingkuang.Name = "txtluoshiqingkuang";
            this.txtluoshiqingkuang.PreventEnterBeep = true;
            this.txtluoshiqingkuang.Size = new System.Drawing.Size(276, 237);
            this.txtluoshiqingkuang.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 97;
            this.label4.Text = "落实措施:";
            // 
            // txtluoshicuoshi
            // 
            // 
            // 
            // 
            this.txtluoshicuoshi.Border.Class = "TextBoxBorder";
            this.txtluoshicuoshi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtluoshicuoshi.Location = new System.Drawing.Point(488, 35);
            this.txtluoshicuoshi.Multiline = true;
            this.txtluoshicuoshi.Name = "txtluoshicuoshi";
            this.txtluoshicuoshi.PreventEnterBeep = true;
            this.txtluoshicuoshi.Size = new System.Drawing.Size(284, 237);
            this.txtluoshicuoshi.TabIndex = 96;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FrShixiang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 470);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtluoshiqingkuang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtluoshicuoshi);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrShixiang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "改善";
            this.Load += new System.EventHandler(this.FrShixiang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtluoshiqingkuang;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtluoshicuoshi;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}