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
    public partial class Frkaohedengji : DevExpress.XtraEditors.XtraForm
    {
        public Frkaohedengji()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frkaohedengji_Load(object sender, EventArgs e)
        {
            string sql1 = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql1, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["部门"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBoxEdit1.Properties.Items.Add(s);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (comboBoxEditbeikaohe.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            textBox1.Text += comboBoxEditbeikaohe.Text + ";";

        }

        private void btn_tijiao_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("接收人不许为空！", "软件提示");

                return;
            }

            string strSql1 = "insert into tb_kaohe (姓名,部门,考核类型,考核事由,登记人 ) values ('" + textBox1.Text + "','" + comboBoxEdit1.Text + "','" + comboBoxleixing.Text + "','" + richTextBox1.Text + "','"  + textBox2.Text + "')";
            try
            {
                if (MessageBox.Show("确认添加吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    SQLhelp.ExecuteScalar(strSql1, CommandType.Text);
                    MessageBox.Show("保存成功！", "软件提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }
            
        }

        private void comboBoxEditbeikaohe_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxEditbeikaohe.Properties.Items.Clear();
            //string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEdit1.Text + "'";
            //DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            //List<string> spaceminute = new List<string>();
            //for (int i = 0; i < aaaa.Rows.Count; i++)
            //{

            //    string n = aaaa.Rows[i]["用户名"].ToString();
            //    spaceminute.Add(n);
            //}


            //foreach (string s in spaceminute)
            //{
            //    comboBoxEditbeikaohe.Properties.Items.Add(s);
            //}
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEditbeikaohe.Properties.Items.Clear();
            string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEdit1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBoxEditbeikaohe.Properties.Items.Add(s);
            }
        }
    }
}