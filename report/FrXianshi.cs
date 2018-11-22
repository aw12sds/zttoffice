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

namespace ztoffice.report
{
    public partial class FrXianshi : DevExpress.XtraEditors.XtraForm
    {
        public FrXianshi()
        {
            //this.EnableGlass = false;
            InitializeComponent();
        }
        public DataTable aaa;
        string lujing;
        public string leixing;
        private void FrXianshi_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            gridControl1.DataSource = aaa;

        }

        private void 回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrReply form1 = new FrReply();
            form1.yonghu = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();

            string yonghu = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();
            form1.baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();
            string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
            if (shijian != "")
            {
                form1.shijian = shijian;
                form1.ShowDialog();
            }
            if (shijian == "")
            {
                MessageBox.Show("该报告为空！");
                return;
            }

        }

        private void 下载该报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }


            string shijian11 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
            if (shijian11 != "")
            {



                FolderBrowserDialog lujingg = new FolderBrowserDialog();

                if (lujingg.ShowDialog() == DialogResult.OK)

                {
                    string xuanzelujing = lujingg.SelectedPath;
                    string yonghu = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();
                    string baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();
                    string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
                    string jingque = shijian.Substring(0, 10);





                    string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();







                    try
                    {
                        byte[] mypdffile = null;
                        string ConStr = "Select 文件,员工姓名,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";

                        mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);

                        string sql1 = "Select 员工姓名 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";

                        string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                        string sql2 = "Select 日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                        string shijian1 = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
                            string lujing = xuanzelujing + "\\" + mingcheng + shijian1 + baogaoleixing + "."+leixing;
                            FileStream fs = new FileStream(lujing, FileMode.Create);
                            fs.Write(mypdffile, 0, mypdffile.Length);
                            fs.Flush();
                            fs.Close();

                       
                        MessageBox.Show("下载成功");//显示异常信息
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//显示异常信息
                    }
                }

            }



            if (shijian11 == "")
            {
                MessageBox.Show("该报告为空！");
                return;
            }

        }

        private void 一键下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }



            FolderBrowserDialog lujingg = new FolderBrowserDialog();

            if (lujingg.ShowDialog() == DialogResult.OK)

            {

               
                


                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < aaa.Rows.Count; i++)
                {


                    
                    
                    string shijian11 = aaa.Rows[i]["提交时间"].ToString();
                    if (shijian11 != "")
                    {

                        string yonghu = aaa.Rows[i]["员工姓名"].ToString();
                        string baogaoleixing = aaa.Rows[i]["报告类型"].ToString();
                        string shijian = aaa.Rows[i]["提交时间"].ToString();
                        string jingque = shijian.Substring(0, 10);

                        
                        string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                        leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();


                        

                        try
                        {
                            byte[] mypdffile = null;
                            string ConStr = "Select 文件,员工姓名,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";


                            mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);

                            string sql1 = "Select 员工姓名 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                            string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                            string sql2 = "Select 日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";

                            string shijian1 = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
                                string lujing = xuanzelujing + "\\" + mingcheng + shijian1 + baogaoleixing + "."+leixing;
                                FileStream fs = new FileStream(lujing, FileMode.Create);
                                fs.Write(mypdffile, 0, mypdffile.Length);
                                fs.Flush();
                                fs.Close();

                           

                            
                            
                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);//显示异常信息
                        }

                        
                    }
 

                }
                MessageBox.Show("下载成功");//显示异常信息

            }
        }

        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
            if (shijian != "")
            {
                string a = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告标题").ToString();
                string b = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();




                string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + b + "'and 提交时间='" + shijian + "' and 报告标题='" + a + "'";
                leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();



                byte[] mypdffile = null;

                string sql = "Select 文件 From tb_wenjian Where 报告标题='" + a + "' and  提交时间='" + shijian + "'and  员工姓名='" + b + "' ";
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
            if (shijian == "")
            {
                MessageBox.Show("该报告为空！");
                return;
            }
        }
    }
}
