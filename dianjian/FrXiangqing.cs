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
    public partial class FrXiangqing : DevExpress.XtraEditors.XtraForm
    {
        public FrXiangqing()
        {
            
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
                textshijian.Text = dt.Rows[i]["会议时间"].ToString();
                txtcanhuirenyuan.Text = dt.Rows[i]["参会人员"].ToString();
                textjiluren.Text = dt.Rows[i]["记录人"].ToString();
                textzhuchiren.Text = dt.Rows[i]["主持人"].ToString();
                textzhuti.Text = dt.Rows[i]["会议主题"].ToString();
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
            gridControl1.DataSource = dt1;
            
        }




        

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            zerenren = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人").ToString();

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
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }


            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string zerenren = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人").ToString();
                string jiyaoneirong = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容").ToString();
                string huiyishijian = textshijian.Text;
                string huiyizhuti = textzhuti.Text;



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
        }

        private void 取消完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人").ToString();
            string huiyishijian = textshijian.Text;
            string huiyizhuti = textzhuti.Text;


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
            
            string sql= "Select 附件 From tb_xiangxi  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "'";
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);
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

            string zerenren = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "会议时间").ToString();
            string jiyaoshangchuanren= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人").ToString();

            if (yonghu != jiyaoshangchuanren)
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();
                    string shiijandianjie = gridView1.GetRowCellValue(i, "完成时间节点").ToString();
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

        

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dingwei = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

            string shangchuanren = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人").ToString();
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

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView1.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl1.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
