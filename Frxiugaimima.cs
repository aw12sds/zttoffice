using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice
{
    public partial class Frxiugaimima : DevExpress.XtraEditors.XtraForm
    {
        public Frxiugaimima()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql1 = "select 密码 from tb_operator where 用户名='" + yonghu + "'";
            string jiumima = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
            
            if (txtJiu.Text != jiumima)
            {
                MessageBox.Show("旧密码输入错误，请重新输入！");
                return;
            }
            else
            {
                if (txtXin.Text == txtQueren.Text)
                {
                    string sql2 = "update tb_operator set 密码='" + txtXin.Text + "' where 用户名='" + yonghu + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                    MessageBox.Show("密码修改成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("两次密码输入不相同，请重新输入！");
                    return;
                }
            }
        }

        private void txtJiu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))//如果不是输入数字就不让输入
            {
                e.Handled = true;
            }
        }

        private void txtXin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))//如果不是输入数字就不让输入
            {
                e.Handled = true;
            }
        }

        private void txtQueren_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))//如果不是输入数字就不让输入
            {
                e.Handled = true;
            }
        }

        private void Frxiugaimima_Load(object sender, EventArgs e)
        {

        }
    }
}
