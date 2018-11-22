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
    public partial class Frgerenbaobiao : Form
    {
        public Frgerenbaobiao()
        {
            InitializeComponent();
        }
        public string yonghu;
        string leixing;
        string lujing;
        private void 下载该报告ToolStripMenuItem_Click(object sender, EventArgs e)
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
           
                string baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();
                string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();

                try
                {
                    byte[] mypdffile = null;
                
                    string sql= "Select 文件,报告标题,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    mypdffile= SQLhelp.duqu(sql, CommandType.Text);
                    DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       
                        DataRow row = dt.Rows[i];
                        string biaoti = row["报告标题"].ToString();
                        string shijian1 = row["日期"].ToString();
                        string lujing = xuanzelujing + "\\" + shijian1 + yonghu + 1 + baogaoleixing + ".doc";
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();

                    }

                    //con.Close();
                    MessageBox.Show("下载成功");//显示异常信息
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//显示异常信息
                }

            }
        }

        private void Frgerenbaobiao_Load(object sender, EventArgs e)
        {
            string sql = "select 报告类型,提交时间,员工备注,批复,报告标题,附件名称 from tb_wenjian where 员工姓名='" + yonghu + "'";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = jieguo;

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
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
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

                    string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告标题='" + a + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();



                    byte[] mypdffile = null;
                    string ConStr = "Select 文件 From tb_wenjian Where 报告标题='" + a + "' and  提交时间='" + shijian + "'and  员工姓名='" + yonghu + "' ";


                    mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                   
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        Random ran = new Random();

                        string aaaa = System.Environment.CurrentDirectory;
                        lujing = aaaa + "\\" + a + "1" + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();
                    }
                    catch { }
                    this.Cursor = Cursors.Default;

                    Frchakanbaogao form1 = new Frchakanbaogao();
                    form1.lujing = lujing;
                    form1.Show();

                    //System.Diagnostics.Process.Start(lujing);

                }
                if (shijian == "")
                {
                    MessageBox.Show("该报告为空！");
                    return;
                }
            }
        }
    }
}
