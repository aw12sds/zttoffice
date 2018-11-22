using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztoffice.renliziyuan
{
    public partial class Frwejidengji : DevExpress.XtraEditors.XtraForm
    {
        public Frwejidengji()
        {
            InitializeComponent();
        }

        private void Frwejidengji_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_operator   where 类别='大学生'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string n = dt.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);
            }
            foreach (string s in spaceminute1)
            {
                comboBoxStu.Items.Add(s);
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认新增违纪信息吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {             
                string sql1 = " insert into tb_weiji(大学生姓名,违纪类型,事件,次数) values ('" + comboBoxStu.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                MessageBox.Show("插入成功！");
                this.Close();
            }
        }
    }
    
}