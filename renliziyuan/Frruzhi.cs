using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace ztoffice.renliziyuan
{
    public partial class Frruzhi : DevExpress.XtraEditors.XtraForm
    {
        public Frruzhi()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (textEditName.Text.Trim() == "")
            {
                MessageBox.Show("请填写姓名！");
                    return;
            }
            string sql = "insert into tb_operator (用户名,电话,籍贯,毕业学校,专业,身份证号码,类别)  values ('" + textEditName.Text + "','" + textEditContact.Text + "','" + textEditLoc.Text + "','" + textEditSchool.Text + "','" + textEditSpeci.Text + "','" + textEditNum.Text + "',大学生)";

            if (MessageBox.Show("确认添加吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("提交成功！");
            }
        }

        private void Frruzhi_Load(object sender, EventArgs e)
        {

        }
    }
}