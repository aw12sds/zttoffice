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
    public partial class Frchakan : DevExpress.XtraEditors.XtraForm
    {
        public Frchakan()
        {
            
            InitializeComponent();
        }
        public string biaoti;
        private string leixing;
        string c;
        private void Frchakan_Load(object sender, EventArgs e)
        {
            string strSql = "select 公告内容 from tb_gonggao where 公告标题='"+biaoti+"'";
            textNeirong.Text = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));
            string strSql1= "select 公告附件类型 from tb_gonggao where 公告标题='" + biaoti + "'";
            leixing= Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));
        }

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "select 公告附件类型 from tb_gonggao where 公告标题='" + biaoti + "'";

            string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (jiance == "")
            {
                MessageBox.Show("无附件！");
                return;

            }
            FolderBrowserDialog lujingg = new FolderBrowserDialog();

            if (lujingg.ShowDialog() == DialogResult.OK)

            {
                string xuanzelujing = lujingg.SelectedPath;



                c = xuanzelujing + "\\" + biaoti + "." + leixing;
                try
                {


                    if (jiance != "")
                    {


                        byte[] mypdffile = null;
                        string ConStr = "select 公告附件 from tb_gonggao where 公告标题='" + biaoti + "'";


                        mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);

                        FileStream fs = new FileStream(c, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();


                        MessageBox.Show("下载成功！");//显示异常信息
                        this.Close();
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//显示异常信息
                }

            }
        }
    }
}
