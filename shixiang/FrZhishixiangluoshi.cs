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

namespace ztoffice.shixiang
{
    public partial class FrZhishixiangluoshi : Office2007Form
    {
        public FrZhishixiangluoshi()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string shijian;
        public string zerenren;
        public string jiyaoneirong;
        public string yonghu;
        public string jiyaoshangchuanren;
        
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string lujing;
        private void FrZhishixiangluoshi_Load(object sender, EventArgs e)
        {
            txthuiyishijian.Text = shijian;
            txtjiyaoneirong.Text = jiyaoneirong;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string huifu = DateTime.Now.ToString();
               
                    string sql3 = "update tb_xiangxi  set 更新='有更新！' , 是否有回复='有' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + zerenren + "'  and  纪要上传人='" + jiyaoshangchuanren + "'";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                    if (txtName.Text == "")
                    {                    
                        string sql1 = "INSERT INTO tb_zhishixiang(创建时间,会议时间,纪要内容,落实措施,落实情况,纪要上传人,完成责任人) VALUES('" + huifu + "', '" + shijian + "', '" + jiyaoneirong + "','" + txtluoshicuoshi.Text + "','" + txtluoshiqingkuang.Text + "','" + jiyaoshangchuanren + "','" + zerenren + "')";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                    }
                    if (txtName.Text != "")
                    {
                        string sql11 = "INSERT INTO tb_zhishixiang(创建时间,会议时间,纪要内容,落实措施,落实情况,纪要上传人,完成责任人,附件格式,附件,附件名称) VALUES('" + huifu + "', '" + shijian + "', '" + jiyaoneirong + "','" + txtluoshicuoshi.Text + "','" + txtluoshiqingkuang.Text + "','" + jiyaoshangchuanren + "','" + zerenren + "','" + fileType + "',@pic,'" + fileName + "')";
                        SQLhelp.ExecuteNonquery(sql11, CommandType.Text, files);
                    }
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                


            }
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
    }
}
