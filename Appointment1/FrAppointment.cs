using DevComponents.DotNetBar;
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
    public partial class FrAppointment : DevExpress.XtraEditors.XtraForm
    {
        public FrAppointment()
        {
            
            InitializeComponent();
        }
        public string yonghu;
        private void FrAppointment_Load(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //dtpStartTime1.Format = DateTimePickerFormat.Custom;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择部门！");
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            textBox1.Text += comboBoxEdit2.Text + ";";

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string strSql11 = "select 接收人分组 from tb_operator  where  用户名='" + yonghu + "' ";
            string fenzu = SQLhelp.ExecuteScalar(strSql11, CommandType.Text).ToString();
            if (fenzu == "")
            {
                MessageBox.Show("请先设置接收人分组！");
                return;
            }

            textBox1.Text = fenzu;
        }

        private void btntijiao_Click(object sender, EventArgs e)
        {
            if (dateEdit2.DateTime <= dateEdit1.DateTime)
            {
                MessageBox.Show("请重新设置时间！");
                return;
            }

            if (comboBoxEdit1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择部门！");
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择人员！");
                return;
            }
            if (comboBoxEdit3.SelectedIndex == -1)
            {
                MessageBox.Show("请选择会议室！");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入会议室主题！");
                return;
            }
            TimeSpan time = dateEdit2.DateTime - dateEdit1.DateTime;
            int xiaoshi = (int)time.TotalHours;
            if (xiaoshi > 14)
            {
                MessageBox.Show("时间设定过长！");
                return;

            }

            string sql1 = "select * from tb_huiyishi where 预约会议室='" + comboBoxEdit3.Text + "'";

            DataTable table = SQLhelp.GetDataTable(sql1, CommandType.Text);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime kaishi = Convert.ToDateTime(table.Rows[i]["预约开始时间"]);
                DateTime jieshu = Convert.ToDateTime(table.Rows[i]["预约结束时间"]);

                if (dateEdit1.DateTime < jieshu && dateEdit2.DateTime > kaishi || dateEdit1.DateTime > kaishi && dateEdit2.DateTime < jieshu || dateEdit1.DateTime < kaishi && dateEdit2.DateTime > jieshu)
                {
                    MessageBox.Show("预约时间有重叠！");
                    return;

                }

            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string sql = "insert into tb_huiyishi (预约会议室,预约人员,预约开始时间,预约结束时间,会议室主题) values('" + comboBoxEdit3.Text + "','" + textBox1.Text + "','" + dateEdit1.DateTime + "','" + dateEdit2.DateTime + "','" + textBox2.Text + "')";

                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("预约成功！");
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
