using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
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
using ztoffice.dianjian;
using ztoffice.shixiang;

namespace ztoffice
{
    public partial class FrSearch : Office2007Form
    {
        public FrSearch()
        {
            this.EnableGlass = false;
            InitializeComponent();
            
        }
        public string yonghu;
        public string huiyishijian;
        public string huiyizhuti;
        public string lujing;
        private void FrSearch_Load(object sender, EventArgs e)
        {
            Reload();
            reload1();
            reload2();
            Reload3();
        }
        public void Reload()
        {
            string sql = "select id,会议时间,会议主题,参会人员,纪要上传人,纪要类型 from tb_xiangxi where 纪要类型='会议' ";
           
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            
            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "会议时间";
            
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            taxColumn.ColumnName = "会议主题";
            
            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
          
            for (int i = 0; i < dt1.Rows.Count; i++)
            {

                string panduan1= dt1.Rows[i]["纪要类型"].ToString();
                if (panduan1 == "会议")
                {

                    string str = dt1.Rows[i]["参会人员"].ToString();
                    //正则表达式

                    Match m;

                    Regex r = new Regex(yonghu);

                    m = r.Match(str);
                    string panduan = m.ToString();


                    if (panduan != "")
                    {
                        DataRow dr = table.NewRow();
                        string huiyishijian1 = dt1.Rows[i]["会议时间"].ToString();
                        string huiyizhuti1 = dt1.Rows[i]["会议主题"].ToString();
                        if (huiyizhuti != huiyizhuti1)
                        {
                            huiyizhuti = huiyizhuti1;
                            dr["会议时间"] = dt1.Rows[i]["会议时间"].ToString();

                            dr["会议主题"] = dt1.Rows[i]["会议主题"].ToString();

                            table.Rows.Add(dr);
                        }

                    }
                }

            }

            //个人的绑定
           
            
        }
        
        public void Reload3()
        {
            string sql = "select id,会议时间,会议主题,纪要内容,完成责任人,落实措施,完成时间,落实情况,考核绩效点,已完成 from tb_xiangxi where 纪要类型='会议' and 已完成=1";

            dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            
        }
        
        public void reload1()
        {
            if (yonghu == "桑甜")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);

            }
            if (yonghu == "聂燕")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "庄卫星")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' "; ;
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "赵蕾蕾")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "徐魏巍")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "蔡红兵")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "钱陆亦")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                DataTable dt = SQLhelp.GetDataTable(strsql1, CommandType.Text);

                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string jiedan = dt.Rows[i]["完成时间节点"].ToString();

                    if (jiedan != "")
                    {
                        DateTime kaishi = Convert.ToDateTime(dt.Rows[i]["会议时间"]);
                        DateTime jieshu = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]);

                        string kaishi1 = Convert.ToDateTime(DateTime.Now).ToString("yyyy - MM - dd");

                        string jieshu1 = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]).ToString("yyyy - MM - dd");

                        string zerenren = dt.Rows[i]["完成责任人"].ToString();
                        string neirong = dt.Rows[i]["纪要内容"].ToString();
                        string shijian = dt.Rows[i]["会议时间"].ToString();

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
                            string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                        }

                    }
                }
                dataGridViewX1.DataSource = dt;
            }

            
        }

        public void reload2()
        {


            if (yonghu == "桑甜")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型='指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "聂燕")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型='指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "庄卫星")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型='指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "赵蕾蕾")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成 ,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型='指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "徐魏巍")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型='指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "蔡红兵")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型='指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "钱陆亦")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型='指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }

            
        }
        
       
        
        private void 上传会议纪要ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrShangchuan form = new FrShangchuan();
            form.yonghu = yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrShangchuanzhishixiang form = new FrShangchuanzhishixiang();
            form.yonghu = yonghu;
            form.ShowDialog();
            if(form.DialogResult==DialogResult.OK)
            {
                reload1();

            }
        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["纪要内容"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            string aa = "Select 附件格式 From tb_xiangxi Where 完成责任人='" + zerenren + "' and 纪要内容='" + neirong + "' and 会议时间='" + shijian + "'";
             string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            string panduan = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
            if (panduan == "")
            {
                MessageBox.Show("没有附件！");
                return;

            }


            string aaa = "Select 附件名称 From tb_xiangxi Where 完成责任人='" + zerenren + "' and 纪要内容='" + neirong + "' and 会议时间='" + shijian + "'";
            string  mingcheng = SQLhelp.ExecuteScalar(aaa, CommandType.Text).ToString();
            byte[] mypdffile = null;
            string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

            SqlConnection con = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "Select 附件 From tb_xiangxi  Where 完成责任人='" + zerenren + "'  and 纪要内容='" + neirong + "' and 会议时间='" + shijian + "'";
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

                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + mingcheng + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
            }
            catch { }
            this.Cursor = Cursors.Default;

            System.Diagnostics.Process.Start(lujing);
        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["待完成指示项内容"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();


            string chaxun = "select 纪要上传人 from tb_xiangxi  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != ren)
            {

                MessageBox.Show("无权限！");
                return;
            }

            try
            {
                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;
                string jiedian = dataGridViewX1.CurrentRow.Cells["完成时间节点2"].Value.ToString();
                if (jiedian == "")
                {
                    MessageBox.Show("请先让责任人输入完成时间节点，再确认完成");
                    return;

                }
                if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                   
                        string xiugai = "update tb_xiangxi set 已完成=1,完成时间='" + wanchengshijian + "' Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                        SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                        MessageBox.Show("修改成功！");
                        reload1();
                        Reload();
                        reload2();
                    
                    
                }


            }

            catch (Exception ex)

            {
            
                MessageBox.Show("发生错误：" + ex.Message);
                
            }

        }

       
        private void 批复ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["待完成指示项内容"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();


            string sql = "select 纪要上传人 from tb_xiangxi  where   会议时间='" + shijian + "' and 完成责任人='" + zerenren + "' and 纪要类型='指示项'";
            string shangchuanren = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();


            if(yonghu!=shangchuanren)
            {
                MessageBox.Show("非指示项发起人无权限批复！");
                return;

            }
            
            FrZhishixiangpifu form = new FrZhishixiangpifu();
            form.zerenren = zerenren;
            form.shijian = shijian;
            form.ShowDialog();
            if (form.DialogResult==DialogResult.OK)
            {

                reload1();

            }

        }
     
        
        private void dataGridViewX1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridViewX3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridViewX3_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["待完成指示项内容"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            string jiyaoshangchuanren = dataGridViewX1.CurrentRow.Cells["纪要上传人"].Value.ToString();

            string sql = "select 关联责任人 from tb_xiangxi  where   会议时间='" + shijian + "' and 完成责任人='" + zerenren + "' and 纪要类型='指示项'";
            string shangchuanren = Convert.ToString( SQLhelp.ExecuteScalar(sql, CommandType.Text));
         

            if ( shangchuanren !="")
            {
                FrZhishixaingchakan form = new FrZhishixaingchakan();
                form.jiyaoneirong = neirong;
                form.shijian = shijian;

                form.zerenren = zerenren;

                form.yonghu = yonghu;
                form.jiyaoshangchuanren = jiyaoshangchuanren;
                form.ShowDialog();

            }
            if (shangchuanren == "")
            {
                if (yonghu == "庄卫星")
                {
                    string sql12 = "update tb_xiangxi  set 更新 = '' where 会议时间 = '" + shijian + "' and 纪要内容 = '" + neirong + "' and 完成责任人 = '" + zerenren + "'  and 会议时间 = '" + shijian + "'";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);

                    reload1();
                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;

                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }


                if (yonghu != "庄卫星")
                {
                   
                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;

                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }


            }


        }

        private void 修改指示项内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["待完成指示项内容"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            string chaxun = "select 纪要上传人 from tb_xiangxi  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != ren)
            {

                MessageBox.Show("无权限！");
                return;
            }

            string sql = "select 纪要上传人 from tb_xiangxi  where   会议时间='" + shijian + "' and 完成责任人='" + zerenren + "' and 纪要类型='指示项'";
            string shangchuanren = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();


            if (yonghu != shangchuanren)
            {
                MessageBox.Show("非指示项发起人无权限修改！");
                return;

            }

            FrXiugai form = new FrXiugai();
            form.zerenren = zerenren;
            form.shijian = shijian;
            form.jiyaoneirong = neirong;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {

                reload1();

            }
        }

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrZhishixiangxiangxi form = new FrZhishixiangxiangxi();
            form.jiyaoneirong = dataGridViewX3.CurrentRow.Cells["纪要内容2"].Value.ToString();
            form.shijian = dataGridViewX3.CurrentRow.Cells["会议时间2"].Value.ToString();
            form.zerenren = dataGridViewX3.CurrentRow.Cells["完成责任人2"].Value.ToString();
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = dataGridViewX3.CurrentRow.Cells["纪要上传人2"].Value.ToString();
            form.ShowDialog();
        }

        private void dataGridViewX4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void 保存时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["待完成指示项内容"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();

            
            string chaxun = "select 纪要上传人 from tb_xiangxi  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = dataGridViewX1.Rows[i].Cells["id2"].Value.ToString();
                    string shiijandianjie = dataGridViewX1.Rows[i].Cells["完成时间节点2"].Value.ToString();
                  if(shiijandianjie!="")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie)+ "' where id= '" + id + "'";

                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                    }
                  
                }
                MessageBox.Show("修改成功！");
                reload1();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void 查看指示项附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(dataGridViewX1.CurrentRow.Cells["指示项附件名称"].Value) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(dataGridViewX1.CurrentRow.Cells["指示项附件名称"].Value) != "")
            {
                string zerenren = dataGridViewX1.CurrentRow.Cells["待完成指示项内容"].Value.ToString();
                string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
                string aa = "Select 指示项附件类型 From tb_xiangxi Where 纪要内容='" + zerenren + "' and 会议时间='" + shijian + "'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();



                string mingcheng = Convert.ToString(dataGridViewX1.CurrentRow.Cells["待完成指示项内容"].Value);
                byte[] mypdffile = null;
                string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

                SqlConnection con = new SqlConnection(ConStr);
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "Select 指示项附件 From tb_xiangxi   Where 纪要内容='" + zerenren + "' and 会议时间='" + shijian + "'";
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
                    string lujing = aaaa + "\\" + mingcheng + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    System.Diagnostics.Process.Start(lujing);
                }
                catch { }
            }


        }

        private void dataGridViewX1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

       
      
    }
}
