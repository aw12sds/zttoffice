using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice
{
    public partial class FrOperatorEdit : Office2007Form
    {
        public FrOperatorEdit()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string code;
        public string yonghu;
      

        private void FrOperatorEdit_Load(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);

            txtOperatorName.Text = yonghu;
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["部门"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBox1.Items.Add(s);
            }

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            
            int b = 0;

            int a = 0;

            if (String.IsNullOrEmpty(txtOperatorName.Text.Trim()))
            {
                MessageBox.Show("操作名称不许为空！", "软件提示");
                txtOperatorName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("操作密码不许为空！", "软件提示");
                txtPassword.Focus();
                return;
            }
            if (!(txtPassword.Text == txtAffirmPassword.Text))
            {
                MessageBox.Show("确认密码与操作密码不相同！", "软件提示");
                txtAffirmPassword.Focus();
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择部门！", "软件提示");
                txtPassword.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("序号不许为空！", "软件提示");
                txtPassword.Focus();
                return;
            }

            if (code == "Add")
            {
               
                if (Chquanxian.Checked == true)
                {
                    b = 1;

                }
                if (checkBox1.Checked == true)
                {
                    a = 1;

                }


                if (txtPassword.Text == txtAffirmPassword.Text)
                {
                    string strSql11 = "select 用户名 from tb_operator  where  用户名='" + txtOperatorName.Text + "' ";
                    string result = Convert.ToString(SQLhelp.ExecuteScalar(strSql11, CommandType.Text));
                    if (result != "")
                    {
                        MessageBox.Show("该账号已存在！");
                        txtOperatorName.Focus();

                        return;
                    }

                    string strSql = string.Format(@"insert into tb_operator(用户名,密码,权限管理,部门,序号,报告组) values('{0}','{1}','{2}','{3}','{4}','{5}')", txtOperatorName.Text, txtPassword.Text,b, comboBox1.Text,textBox1.Text,a);

                    


                    if (MessageBox.Show("确认添加吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string aa = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));

                        

                        string sql= "insert into tb_operator1(用户名,密码,权限管理,部门,序号,报告组) values('" + txtOperatorName.Text + "','" + txtPassword.Text + "','" + b + "','" + comboBox1.Text + "','" + textBox1.Text + "','" + a + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);




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
            if (code == "Edit")
            {

               
                if (Chquanxian.Checked == true)
                {
                    b = 1;

                }
                if (checkBox1.Checked == true)
                {
                    a = 1;

                }


                if (txtPassword.Text == txtAffirmPassword.Text)
                {

                    string strSql1 = "update tb_operator set 用户名= '" + txtOperatorName.Text + "' ,密码= " + txtPassword.Text + ",报告组= " + a + " ,权限管理= " + b + ",部门= '" + comboBox1.Text + "',序号= '" + textBox1.Text + "' where 用户名='" + yonghu + "'";

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
        }

        
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
