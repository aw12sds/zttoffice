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
using System.Windows.Forms;
using ztoffice.dianjian;

namespace ztoffice
{
    public partial class FrXiangqing : Office2007Form
    {
        public FrXiangqing()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
            fpro = new Frtiao();
        }
        public string yonghu;
        public string shijian;
        public string leixing;
        public string mingcheng;
        public string lujing;
        public string zerenren;
        public Frtiao fpro = null;
        private void FrXiangqing_Load(object sender, EventArgs e)
        {
            Reload();




        }

        public void Reload()
        {

            string strsql = "select 会议时间,会议主题,主持人,记录人,参会人员 from tb_xiangxi  where 会议时间='" + shijian + "' ";
            DataTable dt = SQLhelp.GetDataTable(strsql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtshijian.Text = dt.Rows[i]["会议时间"].ToString();
                txtcanhuirenyuan.Text = dt.Rows[i]["参会人员"].ToString();
                txtjiluren.Text = dt.Rows[i]["记录人"].ToString();
                txtzhuchiren.Text = dt.Rows[i]["主持人"].ToString();
                txtzhuti.Text = dt.Rows[i]["会议主题"].ToString();
            }
  
            string sql1 = "select id,会议时间,纪要内容,完成责任人,落实措施,完成时间,落实情况,已查看,已完成,完成时间节点,考核绩效点,更新,纪要上传人,批复 from tb_xiangxi  where 会议时间='" + shijian + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            string wanchengshijian = DateTime.Now.ToString();
            DateTime zuizhong = DateTime.Now;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string jiedan = dt1.Rows[i]["完成时间节点"].ToString();
                string yiwancheng=dt1.Rows[i]["已完成"].ToString();
                if(yiwancheng!="1")
                {
                    if (jiedan != "")
                    {
                        DateTime kaishi = Convert.ToDateTime(dt1.Rows[i]["会议时间"]);
                        DateTime jieshu = Convert.ToDateTime(dt1.Rows[i]["完成时间节点"]);

                        string kaishi1 = Convert.ToDateTime(dt1.Rows[i]["会议时间"]).ToString("yyyy - MM - dd");

                        string jieshu1 = Convert.ToDateTime(dt1.Rows[i]["完成时间节点"]).ToString("yyyy - MM - dd");

                        string zerenren = dt1.Rows[i]["完成责任人"].ToString();
                        string neirong = dt1.Rows[i]["纪要内容"].ToString();
                        string shijian = dt1.Rows[i]["会议时间"].ToString();

                        if (jieshu1 != kaishi1)
                        {

                            if (zuizhong < jieshu)
                            {
                                string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                            if (zuizhong > jieshu)
                            {
                                TimeSpan shijianshu = zuizhong - jieshu;

                                int shuliang = Convert.ToInt32(shijianshu.TotalDays - 0.5);
                                int shuliang1 = (Convert.ToInt32((shuliang / 7)) + 1) * 2;

                                string xiugai = "update tb_xiangxi set  考核绩效点='" + shuliang1 + "' Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                        }
                        if (jieshu1 == kaishi1)
                        {
                            string xiugai = "update tb_xiangxi set 考核绩效点=0 Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                        }
                    }
                }
            }
            dataGridViewX2.DataSource = dt1;
            
        }




        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人"].Value.ToString();

            string aa = "Select 附件格式 From tb_xiangxi Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "'";
            leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            string panduan = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            if (panduan == "")
            {
                MessageBox.Show("没有附件！");
                return;

            }
            this.backgroundWorker1.RunWorkerAsync();
            fpro.ShowDialog(this);

        }

        private void 确认完成情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人"].Value.ToString();
            string jiyaoneirong = dataGridViewX2.CurrentRow.Cells["纪要内容"].Value.ToString();
            string huiyishijian = txtshijian.Text;
            string huiyizhuti = txtzhuti.Text;



            string chaxun = "select 纪要上传人 from tb_xiangxi  Where 完成责任人='" + zerenren + "' and 会议时间='" + huiyishijian + "' and 纪要内容='" + jiyaoneirong + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != ren)
            {

                MessageBox.Show("无权限！");
                return;
            }

            try
            {

                string xiugai = "update tb_xiangxi set 已完成=1 Where 完成责任人='" + zerenren + "' and 会议时间='" + huiyishijian + "'and 纪要内容='" + jiyaoneirong + "'";
                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                MessageBox.Show("修改成功！");
                Reload();

            }
            catch (Exception ex)

            {

                MessageBox.Show("发生错误：" + ex.Message);


            }
        }

        private void 取消完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人"].Value.ToString();
            string huiyishijian = txtshijian.Text;
            string huiyizhuti = txtzhuti.Text;


            string chaxun = "select 纪要上传人 from tb_xiangxi  Where 完成责任人='" + zerenren + "' and 会议时间='" + huiyishijian + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != ren)
            {

                MessageBox.Show("无权限！");
                return;
            }

            try
            {

                string xiugai = "update tb_xiangxi set 已完成=0 Where 完成责任人='" + zerenren + "' and 会议时间='" + huiyishijian + "'";
                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                MessageBox.Show("修改成功！");
                Reload();

            }
            catch (Exception ex)

            {

                MessageBox.Show("发生错误：" + ex.Message);


            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string aaa = "Select 附件名称 From tb_xiangxi Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "'";
            mingcheng = SQLhelp.ExecuteScalar(aaa, CommandType.Text).ToString();
            byte[] mypdffile = null;
            string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

            SqlConnection con = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "Select 附件 From tb_xiangxi  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "'";
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                mypdffile = (byte[])dr.GetValue(0);
            }
            con.Close();
            //this.Cursor = Cursors.WaitCursor;

            try
            {
                Random ran = new Random();

                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + mingcheng + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
            }
            catch { }
         
            System.Diagnostics.Process.Start(lujing);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fpro.Close();
        }

        private void 保存时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX2.CurrentRow.Cells["纪要内容"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["会议时间"].Value.ToString();
            string jiyaoshangchuanren= dataGridViewX2.CurrentRow.Cells["纪要上传人"].Value.ToString();

            if (yonghu != jiyaoshangchuanren)
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = dataGridViewX2.Rows[i].Cells["id"].Value.ToString();
                    string shiijandianjie = dataGridViewX2.Rows[i].Cells["完成时间节点"].Value.ToString();
                    if (shiijandianjie != "")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' where id= '" + id + "'";

                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                    }

                }
                MessageBox.Show("修改成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int dingwei = Convert.ToInt32(dataGridViewX2.CurrentRow.Cells["id"].Value);

            string shangchuanren = dataGridViewX2.CurrentRow.Cells["纪要上传人"].Value.ToString();
            if (shangchuanren == yonghu)
            {
                string sql1 = "update tb_xiangxi set 更新='' where id='" + dingwei + "'";
                 SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                
                Frhuifuhuiyijiyao form = new Frhuifuhuiyijiyao();
                form.yonghu = yonghu;
                form.dingwei = dingwei;
                form.ShowDialog();
                Reload();
            }

            if (shangchuanren != yonghu)
            {
                Frhuifuhuiyijiyao form = new Frhuifuhuiyijiyao();
                form.yonghu = yonghu;
                form.dingwei = dingwei;
                form.ShowDialog();
            }
            
        }
        
    }
}
