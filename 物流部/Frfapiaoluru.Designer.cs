namespace ztoffice.物流部
{
    partial class Frfapiaoluru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frfapiaoluru));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfapiaohao = new DevExpress.XtraEditors.TextEdit();
            this.txtjine = new DevExpress.XtraEditors.TextEdit();
            this.txtkaipiao = new DevExpress.XtraEditors.TextEdit();
            this.com = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txthetonghao = new DevExpress.XtraEditors.TextEdit();
            this.txthetongzongjia = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbeizhu = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtfapiaohao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtjine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkaipiao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.com.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthetonghao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthetongzongjia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbeizhu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "发票号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "发票金额:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "开票日期:";
            // 
            // txtfapiaohao
            // 
            this.txtfapiaohao.Enabled = false;
            this.txtfapiaohao.Location = new System.Drawing.Point(128, 118);
            this.txtfapiaohao.Name = "txtfapiaohao";
            this.txtfapiaohao.Size = new System.Drawing.Size(167, 24);
            this.txtfapiaohao.TabIndex = 3;
            // 
            // txtjine
            // 
            this.txtjine.Location = new System.Drawing.Point(128, 171);
            this.txtjine.Name = "txtjine";
            this.txtjine.Size = new System.Drawing.Size(167, 24);
            this.txtjine.TabIndex = 4;
            // 
            // txtkaipiao
            // 
            this.txtkaipiao.Enabled = false;
            this.txtkaipiao.Location = new System.Drawing.Point(128, 228);
            this.txtkaipiao.Name = "txtkaipiao";
            this.txtkaipiao.Size = new System.Drawing.Size(167, 24);
            this.txtkaipiao.TabIndex = 5;
            // 
            // com
            // 
            this.com.Location = new System.Drawing.Point(131, 65);
            this.com.Name = "com";
            this.com.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.com.Properties.Items.AddRange(new object[] {
            "0",
            "0.03",
            "0.1",
            "0.16",
            "0.17"});
            this.com.Size = new System.Drawing.Size(164, 24);
            this.com.TabIndex = 6;
            this.com.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "税率:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(395, 141);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(113, 41);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "提交";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "合同号:";
            // 
            // txthetonghao
            // 
            this.txthetonghao.Enabled = false;
            this.txthetonghao.Location = new System.Drawing.Point(131, 16);
            this.txthetonghao.Name = "txthetonghao";
            this.txthetonghao.Size = new System.Drawing.Size(167, 24);
            this.txthetonghao.TabIndex = 11;
            // 
            // txthetongzongjia
            // 
            this.txthetongzongjia.Enabled = false;
            this.txthetongzongjia.Location = new System.Drawing.Point(409, 16);
            this.txthetongzongjia.Name = "txthetongzongjia";
            this.txthetongzongjia.Size = new System.Drawing.Size(167, 24);
            this.txthetongzongjia.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "合同总价:";
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.Enabled = false;
            this.txtbeizhu.Location = new System.Drawing.Point(409, 62);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.Size = new System.Drawing.Size(167, 24);
            this.txtbeizhu.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "备注:";
            // 
            // Frfapiaoluru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 324);
            this.Controls.Add(this.txtbeizhu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txthetongzongjia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txthetonghao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.com);
            this.Controls.Add(this.txtkaipiao);
            this.Controls.Add(this.txtjine);
            this.Controls.Add(this.txtfapiaohao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frfapiaoluru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票录入";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frfapiaoluru_FormClosed);
            this.Load += new System.EventHandler(this.Frfapiaoluru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtfapiaohao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtjine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkaipiao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.com.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthetonghao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthetongzongjia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbeizhu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtfapiaohao;
        private DevExpress.XtraEditors.TextEdit txtjine;
        private DevExpress.XtraEditors.TextEdit txtkaipiao;
        private DevExpress.XtraEditors.ComboBoxEdit com;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txthetonghao;
        private DevExpress.XtraEditors.TextEdit txthetongzongjia;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtbeizhu;
        private System.Windows.Forms.Label label7;
    }
}