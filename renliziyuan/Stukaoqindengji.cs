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
    public partial class Stukaoqindengji : DevExpress.XtraEditors.XtraForm
    {
        public Stukaoqindengji()
        {
            InitializeComponent();
        }

        private void Stukaoqindengji_Load(object sender, EventArgs e)
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
                comboStuName.Items.Add(s);

            }
        }

        private void HourText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31)) { if (e.KeyChar == '.') { if (((TextBox)sender).Text.Trim().IndexOf('.') > -1) e.Handled = true; } else e.Handled = true; } else { if (e.KeyChar <= 31) { e.Handled = false; } }
            if (e.KeyChar == 46) { if (((TextBox)sender).Text.Trim().Length <= 0) e.Handled = true; }
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31)) { if (e.KeyChar == '.') { if (((TextBox)sender).Text.Trim().IndexOf('.') > -1) e.Handled = true; } else e.Handled = true; }
            else { if (e.KeyChar <= 31) { e.Handled = false; } }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认新增考勤信息吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {



                string sql1 = " insert into tb_daxueshengkaoqin (大学生姓名,发生时间,考勤类型,时长) values ('" + comboStuName.Text + "','" + dateTimePicker1.Text + "','" + kaoqinleixing.Text + "','" + HourText.Text + "')";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                MessageBox.Show("插入成功！");
                this.Close();
            }
        }

        private void comboStuName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}