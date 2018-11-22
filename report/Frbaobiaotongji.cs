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
    public partial class Frbaobiaotongji : DevExpress.XtraEditors.XtraForm
    {
        public Frbaobiaotongji()
        {
            //this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        private void Frbaobiaotongji_Load(object sender, EventArgs e)
        {

        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("请添加搜索人！");
                return;
            }
            if (comboBoxEdit1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择报告类型！");
                return;
            }

            if (dateEdit2.DateTime <= dateEdit1.DateTime)
            {
                MessageBox.Show("请重新设置时间！");
                return;
            }


            string shujv = textEdit1.Text.Trim();
            //String[] result = shujv.Split(';');


            string sql = "select 员工姓名,报告类型,提交时间,员工备注,批复,报告标题,编号,接收人 from tb_wenjian where  报告类型='" + comboBoxEdit1.Text + "' and 员工姓名='" + shujv + "' and 提交时间<= '" + dateEdit2.Text + "' and 提交时间>= '" + dateEdit1.Text + "'";

            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);

            Frjieguo aa = new Frjieguo();
            aa.dt = dt1;
            aa.ShowDialog();

        }
    }
}

