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
    public partial class FrDetails : DevExpress.XtraEditors.XtraForm
    {
        

        static string SaveDir = string.Empty;
        public FrJindutiao fpro = null;
        public string yonghu;
        public string bumen;
        public string leixing;
        public string kaishishijian;
        public string jieshushijian;
        public string xuanzelujing;
        public FrDetails()
        {
            
            InitializeComponent();
            fpro = new FrJindutiao();
            
        }
        
        private void FrDetails_Load(object sender, EventArgs e)
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

       
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                byte[] mypdffile = null;
              


                string sql = "Select 文件,员工姓名,日期,报告类型 From tb_wenjian Where 部门='" + bumen + "' and 报告类型='" + leixing + "' and 日期>='" + kaishishijian + "' and 日期<='" + jieshushijian + "' ";
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    DataRow row = dt.Rows[i];
                    string mingcheng = row["员工姓名"].ToString();
                    string shijian = row["日期"].ToString();
                    string leixing = row["报告类型"].ToString();

                    string aaaa = System.Environment.CurrentDirectory;
                        string lujing = xuanzelujing + "\\" + mingcheng + shijian + leixing + ".doc";
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();

                    }

                //con.Close();

            }
            


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//显示异常信息
            }

           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            btnDown.Enabled = true;
            MessageBox.Show("下载成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            fpro.Close();
            this.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int val = e.ProgressPercentage;
           
            //this.fpro.progressBar1.Value = val;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                byte[] mypdffile = null;
            

               string sql = "Select 文件,员工姓名,日期,报告类型 From tb_wenjian Where  报告类型='" + leixing + "' and 日期>='" + kaishishijian + "' and 日期<='" + jieshushijian + "' ";
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                    DataRow row = dt.Rows[i];
                    string mingcheng = row["员工姓名"].ToString();
                    string shijian = row["日期"].ToString();
                    string leixing = row["报告类型"].ToString();
                    string aaaa = System.Environment.CurrentDirectory;
                        string lujing = xuanzelujing + "\\" + mingcheng + shijian + leixing + ".doc";
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();

                    }

                    //con.Close();

                }
            


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//显示异常信息
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDown.Enabled = true;
            MessageBox.Show("下载成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            fpro.Close();
            this.Close();
         
        }

        

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2.Items.Clear();
            //string sql = "select 用户名 from tb_operator where 部门='" +comboBox1.Text + "'";
            //DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            //List<string> spaceminute = new List<string>();
            //for (int i = 0; i < aaaa.Rows.Count; i++)
            //{

            //    string n = aaaa.Rows[i]["用户名"].ToString();
            //    spaceminute.Add(n);
            //}


            //foreach (string s in spaceminute)
            //{
            //    comboBox2.Items.Add(s);
            //}
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择部门！");
                return;
            }
            if (comboBoxEdit2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择报告类型！");
                return;
            }
            if (comboBoxEdit1.SelectedIndex != 13)
            {
                FolderBrowserDialog lujingg = new FolderBrowserDialog();

                if (lujingg.ShowDialog() == DialogResult.OK)

                {
                    xuanzelujing = lujingg.SelectedPath;

                    bumen = comboBoxEdit1.Text;
                    leixing = comboBoxEdit2.Text;
                    kaishishijian = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                    jieshushijian = dateEdit2.DateTime.ToString("yyyy-MM-dd");

                    btnDown.Enabled = false;

                    this.backgroundWorker1.RunWorkerAsync();
                    fpro.ShowDialog(this);
                    // 在开始异步操作后ShowDialog
                    // 这样即使代码停在那里也不会影响后台任务的执行

                }
            }


            if (comboBoxEdit1.SelectedIndex == 13)
            {
                FolderBrowserDialog lujingg = new FolderBrowserDialog();
                if (lujingg.ShowDialog() == DialogResult.OK)

                {
                    xuanzelujing = lujingg.SelectedPath;

                    leixing = comboBoxEdit2.Text;
                    kaishishijian = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                    jieshushijian = dateEdit2.DateTime.ToString("yyyy-MM-dd");

                    btnDown.Enabled = false;

                    this.backgroundWorker2.RunWorkerAsync();
                    fpro.ShowDialog(this);


                }
            }
        }

        private void btnquxiao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
