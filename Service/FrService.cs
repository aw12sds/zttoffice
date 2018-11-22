using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ztoffice.Service;

namespace ztoffice
{
    public partial class FrService : DevExpress.XtraEditors.XtraForm
    {
        public FrService()
        {
            
            InitializeComponent();
        }
        string lujing;
        string leixing;

        public string yonghu;
        private void FrService_Load(object sender, EventArgs e)
        {
            string sql = "select 公告标题,公告人,公告时间 from tb_gonggao where 公告类型='公告' order by 公告时间 desc ";

           

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dataGridViewX1.DataSource = dt;


            string sql1 = "select 公告标题,公告人,公告时间,公告接收人 from tb_gonggao where 公告类型='选择型'  order  by 公告时间 desc ";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "公告标题";
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn.ColumnName = "公告人";
            DataColumn taxColumn1 = new DataColumn();
            taxColumn1.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn1.ColumnName = "公告时间";
            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(taxColumn1);

            
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string str = dt1.Rows[i]["公告接收人"].ToString();
                //正则表达式

                Match m;

                Regex r = new Regex(yonghu);

                m = r.Match(str);
                string panduan = m.ToString();

                if (panduan != "")
                {
                    DataRow dr = table.NewRow();
                    string a = dt1.Rows[i]["公告标题"].ToString();
                    dr["公告标题"] = dt1.Rows[i]["公告标题"].ToString();

                    dr["公告人"] = dt1.Rows[i]["公告人"].ToString();
                    dr["公告时间"] = dt1.Rows[i]["公告时间"].ToString();
                    table.Rows.Add(dr);

                }
                
            }

            //个人的绑定
            dataGridViewX3.DataSource = table;


            string sql11 = "select 公告标题,公告人,公告时间 from tb_gonggao where 公告类型='人力'  order  by 公告时间 desc ";
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);



        }

        private void 发布公告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }

            string biaoti = this.dataGridViewX1.CurrentRow.Cells["公告标题"].Value.ToString();
            Frchakan form = new Frchakan();
            form.biaoti = biaoti;

            form.ShowDialog();
           

        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }

            string biaoti = this.dataGridViewX2.CurrentRow.Cells["公告标题1"].Value.ToString();
            Frchakan form = new Frchakan();
            form.biaoti = biaoti;

            form.ShowDialog();
            
        }

        private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }

            string a = dataGridViewX1.CurrentRow.Cells["公告标题"].Value.ToString();

            string aa = "Select 公告附件类型 From tb_gonggao Where 公告标题='" + a + "'";
            leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            string panduan = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            if (panduan == "")
            {
                MessageBox.Show("该公告没有附件！");
                return;

            }
            
            string sqll = "Select 公告附件类型 From tb_gonggao Where 公告标题='" + a + "'";
            leixing = SQLhelp.ExecuteScalar(sqll, CommandType.Text).ToString();



            byte[] mypdffile = null;
            
            string sql = "Select 公告附件 From tb_gonggao Where 公告标题='" + a + "' and  公告类型='公告'";
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);

            try
            {
                Random ran = new Random();
                //int RandKey = ran.Next(0, 999999999);
                //string suijishu = RandKey.ToString();
                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + a + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
            }
            catch { }
            this.Cursor = Cursors.Default;

            System.Diagnostics.Process.Start(lujing);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrFabu form1 = new FrFabu();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            

            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }

            string a = dataGridViewX2.CurrentRow.Cells["公告标题2"].Value.ToString();

            string aa = "Select 公告附件类型 From tb_gonggao Where 公告标题='" + a + "'";
            leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            string panduan = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            if (panduan == "")
            {
                MessageBox.Show("该公告没有附件！");
                return;

            }

            string sqll = "Select 公告附件类型 From tb_gonggao Where 公告标题='" + a + "'";
            leixing = SQLhelp.ExecuteScalar(sqll, CommandType.Text).ToString();

            byte[] mypdffile = null;
            
            string sql = "Select 公告附件 From tb_gonggao Where 公告标题='" + a + "' and  公告类型='选择型'";
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);

            try
            {
                Random ran = new Random();
               
                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + a + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
            }
            catch { }
            this.Cursor = Cursors.Default;

            System.Diagnostics.Process.Start(lujing);
            
        }

        private void z_Click(object sender, EventArgs e)
        {
            FrFabu form1 = new FrFabu();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void 查看详情ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }

            string a = dataGridViewX3.CurrentRow.Cells["公告标题3"].Value.ToString();

            string aa = "Select 公告附件类型 From tb_gonggao Where 公告标题='" + a + "'";
            leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            string panduan = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            if (panduan == "")
            {
                MessageBox.Show("该公告没有附件！");
                return;

            }

            string sqll = "Select 公告附件类型 From tb_gonggao Where 公告标题='" + a + "'";
            leixing = SQLhelp.ExecuteScalar(sqll, CommandType.Text).ToString();

            byte[] mypdffile = null;
            
            string sql = "Select 公告附件 From tb_gonggao Where 公告标题='" + a + "' and  公告类型='选择型'";
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);

            try
            {
                Random ran = new Random();

                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + a + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
            }
            catch { }
            this.Cursor = Cursors.Default;

            System.Diagnostics.Process.Start(lujing);

        }

        private void dataGridViewX2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }

            string biaoti = this.dataGridViewX2.CurrentRow.Cells["公告标题2"].Value.ToString();
            Frchakan form = new Frchakan();
            form.biaoti = biaoti;

            form.ShowDialog();

        }

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX3.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }

            string biaoti = this.dataGridViewX3.CurrentRow.Cells["公告标题3"].Value.ToString();
            Frchakan form = new Frchakan();
            form.biaoti = biaoti;

            form.ShowDialog();

        }
    }
}
