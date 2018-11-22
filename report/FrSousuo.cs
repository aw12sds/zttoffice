using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ztoffice.report
{
    public partial class FrSousuo : DevExpress.XtraEditors.XtraForm
    {
        public FrSousuo()
        {
            //this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public DataTable dtt;
        public string yonghu;
        private void FrSousuo_Load(object sender, EventArgs e)
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
                txtName1.Text += s + ";";
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            txtName1.Text += comboBoxEdit2.Text + ";";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string strSql11 = "select 用户名 from tb_operator  where  报告组=1 ";
            DataTable dt = SQLhelp.GetDataTable(strSql11, CommandType.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtName1.Text += dt.Rows[i]["用户名"].ToString() + ";";
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txtName1.Text == "")
            {
                MessageBox.Show("请添加搜索人！");
                return;
            }
            if (comboBoxEdit3.SelectedIndex == -1)
            {
                MessageBox.Show("请选择报告类型！");
                return;
            }

            if (dateEdit2.DateTime <= dateEdit1.DateTime)
            {
                MessageBox.Show("请重新设置时间！");
                return;
            }


            string shujv = txtName1.Text;
            String[] result = shujv.Split(';');
            DataTable dt = new DataTable();


            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "员工姓名";
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn.ColumnName = "报告类型";


            DataColumn taxColumn5 = new DataColumn();
            taxColumn5.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn5.ColumnName = "编号";

            DataColumn taxColumn6 = new DataColumn();
            taxColumn6.DataType = System.Type.GetType("System.Int32");
            //列名
            taxColumn6.ColumnName = "已交";


            DataColumn taxColumn4 = new DataColumn();
            taxColumn4.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn4.ColumnName = "报告标题";


            DataColumn taxColumn10 = new DataColumn();
            taxColumn10.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn10.ColumnName = "员工备注";

            DataColumn taxColumn11 = new DataColumn();
            taxColumn11.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn11.ColumnName = "批复";

            DataColumn taxColumn12 = new DataColumn();
            taxColumn12.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn12.ColumnName = "提交时间";



            dt.Columns.Add(priceColumn);
            dt.Columns.Add(taxColumn);
            dt.Columns.Add(taxColumn4);
            dt.Columns.Add(taxColumn5);
            dt.Columns.Add(taxColumn6);
            dt.Columns.Add(taxColumn10);
            dt.Columns.Add(taxColumn11);
            dt.Columns.Add(taxColumn12);

            foreach (string i in result)
            {
                if (i != "")
                {
                    string sql = "select 员工姓名,报告类型,提交时间,员工备注,批复,报告标题,编号,接收人 from tb_wenjian where  报告类型='" + comboBoxEdit3.Text + "' and 员工姓名='" + i + "' and 提交时间<= '" + dateEdit2.Text + "' and 提交时间>= '" + dateEdit1.Text + "'";

                    DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
                    string sql1 = "select 序号 from tb_operator where 用户名='" + i + "'";
                    string xuhao = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                    if (dt1.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {
                            string str = dt1.Rows[j]["接收人"].ToString();
                            //正则表达式

                            Match m;

                            Regex r = new Regex(yonghu);

                            m = r.Match(str);
                            string panduan = m.ToString();

                            if (panduan != "")
                            {

                                DataRow dr = dt.NewRow();

                                dr["员工姓名"] = dt1.Rows[j]["员工姓名"].ToString();

                                dr["报告类型"] = dt1.Rows[j]["报告类型"].ToString();
                                dr["报告标题"] = dt1.Rows[j]["报告标题"].ToString();
                                dr["员工备注"] = dt1.Rows[j]["员工备注"].ToString();
                                dr["批复"] = dt1.Rows[j]["批复"].ToString();
                                dr["提交时间"] = dt1.Rows[j]["提交时间"].ToString();
                                dr["编号"] = dt1.Rows[j]["编号"].ToString();
                                dr["已交"] = 1;

                                dt.Rows.Add(dr);


                            }

                        }
                    }
                    if (dt1.Rows.Count == 0)
                    {




                        DataRow dr = dt.NewRow();

                        dr["员工姓名"] = i;

                        dr["报告类型"] = comboBoxEdit3.Text;

                        dr["编号"] = xuhao;
                        dr["已交"] = 0;

                        dt.Rows.Add(dr);

                    }

                    dt1.Clear();

                }
            }
            dtt = dt;
            MessageBox.Show("搜查成功！");
            this.DialogResult = DialogResult.OK;
        }
    }
}
