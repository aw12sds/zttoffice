using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.report
{
    public partial class FrShezhi : DevExpress.XtraEditors.XtraForm
    {
        public FrShezhi()
        {
            //this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;

        private void FrShezhi_Load(object sender, EventArgs e)
        {
            txtOperatorName.Text = yonghu;
        }

        

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("操作密码不许为空！", "软件提示");
                txtPassword.Focus();
                return;
            }
            if (!(txtPassword.Text.Trim() == txtAffirmPassword.Text.Trim()))
            {
                MessageBox.Show("确认密码与操作密码不相同！", "软件提示");
                txtAffirmPassword.Focus();
                return;
            }

            if (txtPassword.Text.Trim() == txtAffirmPassword.Text.Trim())
            {

                string strSql1 = "update tb_operator set 密码= '" + txtPassword.Text + "' where 用户名='" + yonghu + "'";

                if (MessageBox.Show("确认修改吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string aa = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));
                    MessageBox.Show("保存成功！", "软件提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                    txtOperatorName.SelectAll();
                    txtOperatorName.Focus();

                }
            }
            else
            {
                MessageBox.Show("两次输入密码不同！");
                txtPassword.Focus();
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
