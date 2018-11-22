using DevComponents.DotNetBar;
using NetWork.util;
using NetWorkLib;
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
using ztoffice.shixiang;

namespace ztoffice
{
    public partial class FrShixiang : Office2007Form
    {
        public FrShixiang()
        {
            fpro = new Frjindutiao();
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public Frjindutiao fpro = null;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string lujing;
        public string shijian;
        public string mingcheng;
        public string yonghu;
        public string neirong;
        public string wanchengshijian;
        public int id;
        public string dingwei1;
        private void FrShixiang_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {


            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtName.Text);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    //txtMingcheng.Text = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(txtName.Text, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }

        }
        private void buttonX2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string quorysql = "select * from tb_xiangxi where id='" + id + "'";
                DataTable dt1 = SQLhelp.GetDataTable(quorysql, CommandType.Text);
                string 纪要内容 = dt1.Rows[0]["纪要内容"].ToString();
                string 纪要类型 = dt1.Rows[0]["纪要类型"].ToString();
                string shangchuanren = dt1.Rows[0]["纪要上传人"].ToString();
                //string message = 纪要类型+"纪要内容:" + 纪要内容 + ","+yonghu+"已回复,请查看";
                //NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                //NetWork3J.sendmessageById(shangchuanren, message);
                try
                {
                    if (txtName.Text != "")
                    {


                        DateTime shijian = DateTime.Now;
                        string sql1 = "insert into tb_huiyi (落实措施,落实情况,定位,创建人,创建时间,附件格式,附件名称,附件) values('" + txtluoshicuoshi.Text + "','" + txtluoshiqingkuang.Text + "','" + id + "','" + yonghu + "','" + shijian + "','" + fileType + "','" + fileName + "',@pic)";
                        SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                        string sql2 = "Select id from tb_huiyi where 落实措施='" + txtluoshicuoshi.Text + "' and 落实情况='" + txtluoshiqingkuang.Text + "' and 创建人='" + yonghu + "' and 创建时间='" + shijian + "'";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);
              
                        string sql = "update tb_xiangxi set 落实措施='" + txtluoshicuoshi.Text + "',落实情况='" + txtluoshiqingkuang.Text + "',更新='有更新！'    where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        MessageBox.Show("提交成功！", "软件提示");
                        DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    if (txtName.Text == "")
                    {
                        DateTime shijian = DateTime.Now;
                        string sql1 = "insert into tb_huiyi (落实措施,落实情况,定位,创建人,创建时间) values('" + txtluoshicuoshi.Text + "','" + txtluoshiqingkuang.Text + "','" + id + "','" + yonghu + "','" + shijian + "')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                        string sql = "update tb_xiangxi set 落实措施='" + txtluoshicuoshi.Text + "',落实情况='" + txtluoshiqingkuang.Text + "',更新='有更新！'    where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        MessageBox.Show("提交成功！", "软件提示");
                        DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                }

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
          

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fpro.Close();

        }
    }
}
