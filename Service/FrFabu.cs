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

namespace ztoffice.Service
{
    public partial class FrFabu : DevExpress.XtraEditors.XtraForm
    {
        public FrFabu()
        {
            
            InitializeComponent();
        }
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string yonghu;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = false;
        }

        private void FrFabu_Load(object sender, EventArgs e)
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
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = true;
        }
       
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtlujing.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtlujing.Text);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(txtlujing.Text, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
            textBiaoti.Text = fileName;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBiaoti.Text == "")
            {
                MessageBox.Show("请先设置标题！");
                return;
            }

            if (radioButton3.Checked == true)
            {

                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (txtlujing.Text != "")
                    {

                        try
                        {

                            string xianzai = DateTime.Now.ToString();


                            string sql1 = "INSERT INTO tb_gonggao(公告附件,公告提交时间) VALUES (@pic,'" + xianzai + "')";
                            SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                            string shijian = DateTime.Now.ToString("yyyy-MM-dd");

                            string sql = "update tb_gonggao set 公告内容='" + textneirong.Text + "',公告标题='" + textBiaoti.Text + "',公告时间='" + shijian + "',公告类型='" + radioButton3.Text + "',公告人='" + yonghu + "',公告附件类型='" + fileType + "'  where 公告提交时间='" + xianzai + "' ";

                            int g = SQLhelp.innn(sql, CommandType.Text);
                            if (g > 0)
                            {


                                MessageBox.Show("提交成功！", "软件提示");
                                this.Close();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }
                    }

                    if (txtlujing.Text == "")
                    {
                        try
                        {
                            string xianzai = DateTime.Now.ToString();
                            string shijian = DateTime.Now.ToString("yyyy-MM-dd");

                            string sql = "insert into tb_gonggao (公告内容,公告标题,公告时间,公告类型,公告人,公告提交时间) values('" + textneirong.Text + "','" + textBiaoti.Text + "','" + shijian + "','" + radioButton3.Text + "','" + yonghu + "','" + xianzai + "')";

                            int g = SQLhelp.innn(sql, CommandType.Text);
                            if (g > 0)
                            {


                                MessageBox.Show("提交成功！", "软件提示");
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }


                    }


                }


            }


            if (radioButton1.Checked == true)
            {
                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (txtlujing.Text != "")
                    {

                        try
                        {

                            string xianzai = DateTime.Now.ToString();


                            string sql1 = "INSERT INTO tb_gonggao(公告附件,公告提交时间) VALUES (@pic,'" + xianzai + "')";
                            SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                            string shijian = DateTime.Now.ToString("yyyy-MM-dd");

                            string sql = "update tb_gonggao set 公告内容='" + textneirong.Text + "',公告标题='" + textBiaoti.Text + "',公告时间='" + shijian + "',公告类型='" + radioButton1.Text + "',公告人='" + yonghu + "',公告附件类型='" + fileType + "'  where 公告提交时间='" + xianzai + "' ";

                            int g = SQLhelp.innn(sql, CommandType.Text);
                            if (g > 0)
                            {


                                MessageBox.Show("提交成功！", "软件提示");
                                this.Close();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }
                    }

                    if (txtlujing.Text == "")
                    {
                        try
                        {
                            string xianzai = DateTime.Now.ToString();
                            string shijian = DateTime.Now.ToString("yyyy-MM-dd");

                            string sql = "insert into tb_gonggao (公告内容,公告标题,公告时间,公告类型,公告人,公告提交时间) values('" + textneirong.Text + "','" + textBiaoti.Text + "','" + shijian + "','" + radioButton1.Text + "','" + yonghu + "','" + xianzai + "')";

                            int g = SQLhelp.innn(sql, CommandType.Text);
                            if (g > 0)
                            {


                                MessageBox.Show("提交成功！", "软件提示");
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }


                    }


                }
            }
            if (radioButton2.Checked == true)
            {
                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (txtlujing.Text != "")
                    {
                        try
                        {

                            string xianzai = DateTime.Now.ToString();


                            string sql1 = "INSERT INTO tb_gonggao(公告附件,公告提交时间) VALUES (@pic,'" + xianzai + "')";
                            SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                            string shijian = DateTime.Now.ToString("yyyy-MM-dd");

                            string sql = "update tb_gonggao set 公告内容='" + textneirong.Text + "',公告标题='" + textBiaoti.Text + "',公告时间='" + shijian + "',公告类型='" + radioButton2.Text + "',公告人='" + yonghu + "',公告接收人='" + textName.Text + "',公告附件类型='" + fileType + "'  where 公告提交时间='" + xianzai + "' ";

                            int g = SQLhelp.innn(sql, CommandType.Text);
                            if (g > 0)
                            {


                                MessageBox.Show("提交成功！", "软件提示");
                                this.Close();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }
                    }

                    if (txtlujing.Text == "")
                    {

                        try
                        {

                            string xianzai = DateTime.Now.ToString();

                            string shijian = DateTime.Now.ToString("yyyy-MM-dd");
                            string sql = "insert into tb_gonggao (公告内容,公告标题,公告时间,公告类型,公告人,公告接收人,公告提交时间) values('" + textneirong.Text + "','" + textBiaoti.Text + "','" + shijian + "','" + radioButton1.Text + "','" + yonghu + "','" + textName.Text + "','" + xianzai + "')  ";

                            int g = SQLhelp.innn(sql, CommandType.Text);
                            if (g > 0)
                            {


                                MessageBox.Show("提交成功！", "软件提示");
                                this.Close();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }


                    }

                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择部门！");
                return;
            }
            string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEdit1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }
            foreach (string s in spaceminute)
            {
                textName.Text += s + ";";
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            textName.Text += comboBoxEdit2.Text + ";";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            string strSql11 = "select 接收人分组 from tb_operator  where  用户名='" + yonghu + "' ";
            string fenzu = SQLhelp.ExecuteScalar(strSql11, CommandType.Text).ToString();
            if (fenzu == "")
            {
                MessageBox.Show("请先设置接收人分组！");
                return;
            }
            textName.Text = fenzu;
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEdit1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBoxEdit2.Properties.Items.Add(s);
            }
        }
    }
}
