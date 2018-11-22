using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.report
{
    public partial class Frself : Office2007Form
    {
        public Frself()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        string leixing;
        string lujing;
        private void Frself_Load(object sender, EventArgs e)
        {
            Reload();


        }
        public void Reload()
        {

            string sql = "select 报告类型,提交时间,员工备注,批复,报告标题,附件名称 from tb_wenjian where 员工姓名='" + yonghu + "'";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
            dataGridViewX1.DataSource = jieguo;


        }
        
        private void 下载该报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FolderBrowserDialog lujingg = new FolderBrowserDialog();

            if (lujingg.ShowDialog() == DialogResult.OK)

            {
                string xuanzelujing = lujingg.SelectedPath;
                //string yonghu = dataGridViewX1.CurrentRow.Cells["员工姓名"].Value.ToString();
                string baogaoleixing = dataGridViewX1.CurrentRow.Cells["报告类型"].Value.ToString();
                string shijian = dataGridViewX1.CurrentRow.Cells["提交时间"].Value.ToString();
                string jingque = shijian.Substring(0, 10);
                try
                {
                    byte[] mypdffile = null;
                    string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

                    SqlConnection con = new SqlConnection(ConStr);
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandText = "Select 文件,报告标题,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        mypdffile = (byte[])dr.GetValue(0);
                        string biaoti = dr.GetValue(1).ToString();
                        string shijian1 = dr.GetValue(2).ToString(); 
                        
                        string lujing = xuanzelujing + "\\"  + shijian1 +yonghu+1 +baogaoleixing+".doc";
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();

                    }

                    con.Close();
                    MessageBox.Show("下载成功");//显示异常信息
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//显示异常信息
                }

            }
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string shijian = dataGridViewX1.CurrentRow.Cells["提交时间"].Value.ToString();
            if (shijian != "")
            {
                string a = dataGridViewX1.CurrentRow.Cells["报告标题"].Value.ToString();
               
                
                string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告标题='" + a + "'";
                leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();

               

                byte[] mypdffile = null;
                string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

                SqlConnection con = new SqlConnection(ConStr);
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "Select 文件 From tb_wenjian Where 报告标题='" + a + "' and  提交时间='" + shijian + "'and  员工姓名='" + yonghu + "' ";
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mypdffile = (byte[])dr.GetValue(0);
                }
                con.Close();
                this.Cursor = Cursors.WaitCursor;
                
                try
                {
                    Random ran = new Random();
                    //int RandKey = ran.Next(0, 999999999);
                    //string suijishu = RandKey.ToString();
                    string aaaa = System.Environment.CurrentDirectory;
                    lujing = aaaa + "\\" + a+"1"+  "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                }
                catch { }
                this.Cursor = Cursors.Default;

                System.Diagnostics.Process.Start(lujing);

            }
            if (shijian == "")
            {
                MessageBox.Show("该报告为空！");
                return;
            }
        }

        private void 设置个人密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrShezhi form = new FrShezhi();
            form.yonghu = yonghu;
            form.ShowDialog();
            if(form.DialogResult==DialogResult.OK)
            {
                this.Close();

                Reload();
            }


        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            FrPresentation form = new FrPresentation();

            form.yonghu = yonghu;
            form.panduan = "add";
            form.zhonglei = "日报";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            FrZhoubao form = new FrZhoubao();

            form.yonghu = yonghu;

            form.zhonglei = "周报";

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            FrShezhi form = new FrShezhi();
            form.yonghu = yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                this.Close();

                Reload();
            }

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            FrFenzu form = new FrFenzu();
            form.yonghu = yonghu;
            form.ShowDialog();
          
        }
        
        private void buttonItem10_Click(object sender, EventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            Frchanpinshiyebuzhoubao form = new Frchanpinshiyebuzhoubao();

            form.yonghu = yonghu;

            //form.zhonglei = "周报";

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            Frjingongmujvzhoubao form = new Frjingongmujvzhoubao();

            form.yonghu = yonghu;

            //form.zhonglei = "周报";

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            FrWuliubuzhoubao form = new FrWuliubuzhoubao();

            form.yonghu = yonghu;

            //form.zhonglei = "周报";

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            FrShichangbuzhoubao form = new FrShichangbuzhoubao();

            form.yonghu = yonghu;

            //form.zhonglei = "周报";

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
           
            Frchuchaibaogao form = new Frchuchaibaogao();

            form.yonghu = yonghu;
            
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }
    }
}
