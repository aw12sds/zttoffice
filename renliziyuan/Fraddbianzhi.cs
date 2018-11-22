using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace ztoffice.renliziyuan
{
    
    public partial class Fraddbianzhi : DevExpress.XtraEditors.XtraForm
    {
        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string lujing2;
        public Fraddbianzhi()
        {
            InitializeComponent();
        }

        private void Fraddbianzhi_Load(object sender, EventArgs e)
        {
            string sql1 = "select 部门 from tb_danganbiao";
            DataTable aaaa = SQLhelp.GetDataTable(sql1, CommandType.Text);
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxEdit2.Properties.Items.Clear();
            string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEdit1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["岗位"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBoxEdit2.Properties.Items.Add(s);
            }
        }

        private void btnShangchuan_Click(object sender, EventArgs e)
        {
            
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件扩展名
                    fileType2 = info.Extension.Replace(".", "");
                    if (fileType2 == "pdf")
                    {
                        //获得文件大小
                        fileSize2 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName2 = info.FullName.Remove(index);
                        fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);
                        textBox3.Text = fileName2;

                        //把文件转换成二进制流
                        files2 = new byte[Convert.ToInt32(fileSize2)];
                        FileStream file1 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read2 = new BinaryReader(file1);
                        read2.Read(files2, 0, Convert.ToInt32(fileSize2));
                    }
                    else
                    {
                        MessageBox.Show("必须上传PDF格式的文件！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }

        }

        private void btn_tijiao_Click(object sender, EventArgs e)
        {
            var uuid = Guid.NewGuid().ToString();
            string sql1 = "insert into tb_bianzhixuqiu (部门,岗位,附件名称,附件类型,定编原则,编制,在编)values('"+ comboBoxEdit1.Text+ "','"+comboBoxEdit2.Text+"','" + fileName2 + "','" + fileType2 + "') ";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            //string sql2 = "update tb_bianzhixuqiu set 职位说明书=@pic where id ='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "'";
        }
    }
}