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
    public partial class Frjixiaoidantongji : DevExpress.XtraEditors.XtraForm
    {
        public Frjixiaoidantongji()
        {
            
            InitializeComponent();
        }
        //DataTable dt;

        private void Frjixiaoidantongji_Load(object sender, EventArgs e)
        {
            string sql = "select 用户名,部门,序号 from tb_operator";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);

            string bumen = jieguo.Rows[0]["部门"].ToString();

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
            if (radioButton1.Checked == true)
            {

                DataTable da = new DataTable();
                da.Columns.Add("部门", typeof(string));
                da.Columns.Add("姓名", typeof(string));
                da.Columns.Add("考核绩效点", typeof(string));
                da.Columns.Add("详情", typeof(string));

                string[] stime = textBox1.Text.Split(new Char[] { ';' });
                for (int i = 0; i < stime.Length - 1; i++)
                {
                    DataRow dr1 = da.NewRow();
                    string wanchengzerenren = stime[i];
                    string sql = "select 考核绩效点 from tb_xiangxi where 完成责任人='" + wanchengzerenren + "' and 会议时间>'" + dateEdit1.DateTime + "' and 会议时间<'" + dateEdit2.DateTime + "'";
                    DataTable a = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (a.Rows.Count != 0)
                    {

                        int shu = 0;
                        for (int j = 0; j < a.Rows.Count; j++)
                        {
                            string shuliang = a.Rows[j][0].ToString();
                            if (shuliang != "")
                            {
                                shu += Convert.ToInt32(shuliang);

                            }

                        }
                        dr1["考核绩效点"] = shu;
                        dr1["姓名"] = stime[i];
                        string sql11 = "select 部门 from tb_operator where 用户名='" + stime[i] + "'";
                        dr1["部门"] = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    }


                    if (a.Rows.Count == 0)
                    {
                        int shu = 0;
                        dr1["考核绩效点"] = shu;
                        dr1["姓名"] = stime[i];
                        string sql11 = "select 部门 from tb_operator where 用户名='" + stime[i] + "'";
                        dr1["部门"] = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    }
                    da.Rows.Add(dr1);
                }
                frjixiaoidanjieguo form1 = new frjixiaoidanjieguo();
                form1.dt = da;
                form1.biaoji = "0";
                form1.kaishishijian = dateEdit1.DateTime.ToString();
                form1.jieshushijian = dateEdit2.DateTime.ToString();
                form1.ShowDialog();

            }
            if (radioButton2.Checked == true)
            {
                DataTable da = new DataTable();
                da.Columns.Add("部门", typeof(string));
                da.Columns.Add("姓名", typeof(string));
                da.Columns.Add("考核绩效点", typeof(string));
                da.Columns.Add("详情", typeof(string));

                string[] stime = textBox1.Text.Split(new Char[] { ';' });
                for (int i = 0; i < stime.Length - 1; i++)
                {
                    DataRow dr1 = da.NewRow();
                    string wanchengzerenren = stime[i];
                    string sql = "select 考核绩效点 from tb_xiangxi where 完成责任人='" + wanchengzerenren + "' ";
                    DataTable a = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (a.Rows.Count != 0)
                    {

                        int shu = 0;
                        for (int j = 0; j < a.Rows.Count; j++)
                        {
                            string shuliang = a.Rows[j][0].ToString();
                            if (shuliang != "")
                            {
                                shu += Convert.ToInt32(shuliang);

                            }

                        }
                        dr1["考核绩效点"] = shu;
                        dr1["姓名"] = stime[i];
                        string sql11 = "select 部门 from tb_operator where 用户名='" + stime[i] + "'";
                        dr1["部门"] = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    }


                    if (a.Rows.Count == 0)
                    {
                        int shu = 0;
                        dr1["考核绩效点"] = shu;
                        dr1["姓名"] = stime[i];
                        string sql11 = "select 部门 from tb_operator where 用户名='" + stime[i] + "'";
                        dr1["部门"] = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    }
                    da.Rows.Add(dr1);
                }
                frjixiaoidanjieguo form1 = new frjixiaoidanjieguo();
                form1.dt = da;
                form1.biaoji = "1";

                form1.ShowDialog();

            }
        }
    }
}
