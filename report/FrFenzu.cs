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
    public partial class FrFenzu : DevExpress.XtraEditors.XtraForm
    {
        public FrFenzu()
        {
            //this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;

        private void FrFenzu_Load(object sender, EventArgs e)
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

        private void 选定该员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxEx2.Items.Clear();
            //string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEx1.Text + "'";
            //DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            //List<string> spaceminute = new List<string>();
            //for (int i = 0; i < aaaa.Rows.Count; i++)
            //{

            //    string n = aaaa.Rows[i]["用户名"].ToString();
            //    spaceminute.Add(n);
            //}


            //foreach (string s in spaceminute)
            //{
            //    comboBoxEx2.Items.Add(s);
            //}
        }

        
        

        private void btn_AddQuanyuan_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择部门！");
                return;
            }
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
                textBox1.Text += s + ";";
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            textBox1.Text += comboBoxEdit2.Text + ";";
        }

        private void btn_tijiao_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("接收人不许为空！", "软件提示");

                return;
            }

            string strSql1 = "update tb_operator set 接收人分组= '" + textBox1.Text + "'  where 用户名='" + yonghu + "'";
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
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
                comboBoxEdit2.Properties.Items.Add(s);
            }
        }
    }
}
