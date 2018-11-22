namespace ztoffice.物流部
{
    partial class Frshougongfapiao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frshougongfapiao));
            this.txthetonghao = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtjine = new DevExpress.XtraEditors.TextEdit();
            this.txtfapiaohao = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtkaipiao = new DevExpress.XtraEditors.DateEdit();
            this.txthetongzongjia = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbeizhu = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txthetonghao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtjine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfapiaohao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkaipiao.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkaipiao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthetongzongjia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbeizhu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txthetonghao
            // 
            this.txthetonghao.Enabled = false;
            this.txthetonghao.Location = new System.Drawing.Point(128, 24);
            this.txthetonghao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txthetonghao.Name = "txthetonghao";
            this.txthetonghao.Size = new System.Drawing.Size(146, 20);
            this.txthetonghao.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "合同号:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(246, 139);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 32);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Text = "提交";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtjine
            // 
            this.txtjine.Location = new System.Drawing.Point(388, 63);
            this.txtjine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtjine.Name = "txtjine";
            this.txtjine.Size = new System.Drawing.Size(146, 20);
            this.txtjine.TabIndex = 16;
            // 
            // txtfapiaohao
            // 
            this.txtfapiaohao.Location = new System.Drawing.Point(128, 63);
            this.txtfapiaohao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfapiaohao.Name = "txtfapiaohao";
            this.txtfapiaohao.Size = new System.Drawing.Size(146, 20);
            this.txtfapiaohao.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "开票日期:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "发票金额:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "发票号:";
            // 
            // txtkaipiao
            // 
            this.txtkaipiao.EditValue = null;
            this.txtkaipiao.Location = new System.Drawing.Point(128, 104);
            this.txtkaipiao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtkaipiao.Name = "txtkaipiao";
            this.txtkaipiao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtkaipiao.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtkaipiao.Properties.DisplayFormat.FormatString = "yyyyMMdd";
            this.txtkaipiao.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtkaipiao.Properties.EditFormat.FormatString = "yyyyMMdd";
            this.txtkaipiao.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtkaipiao.Properties.Mask.EditMask = "yyyyMMdd";
            this.txtkaipiao.Size = new System.Drawing.Size(146, 20);
            this.txtkaipiao.TabIndex = 23;
            // 
            // txthetongzongjia
            // 
            this.txthetongzongjia.Enabled = false;
            this.txthetongzongjia.Location = new System.Drawing.Point(388, 24);
            this.txthetongzongjia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txthetongzongjia.Name = "txthetongzongjia";
            this.txthetongzongjia.Size = new System.Drawing.Size(146, 20);
            this.txthetongzongjia.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "合同总价:";
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.Enabled = false;
            this.txtbeizhu.Location = new System.Drawing.Point(388, 102);
            this.txtbeizhu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.Size = new System.Drawing.Size(146, 20);
            this.txtbeizhu.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "备注:";
            // 
            // Frshougongfapiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 194);
            this.Controls.Add(this.txtbeizhu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txthetongzongjia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtkaipiao);
            this.Controls.Add(this.txthetonghao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtjine);
            this.Controls.Add(this.txtfapiaohao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frshougongfapiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入发票";
            this.Load += new System.EventHandler(this.Frshougongfapiao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txthetonghao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtjine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfapiaohao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkaipiao.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkaipiao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthetongzongjia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbeizhu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txthetonghao;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtjine;
        private DevExpress.XtraEditors.TextEdit txtfapiaohao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit txtkaipiao;
        private DevExpress.XtraEditors.TextEdit txthetongzongjia;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtbeizhu;
        private System.Windows.Forms.Label label7;
    }
}