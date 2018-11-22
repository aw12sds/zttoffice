using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.dianjian
{
    public partial class FrFenkaipifu : Office2007Form
    {
        public FrFenkaipifu()
        {
            this.EnableGlass = false;//关键
            InitializeComponent();
        }
        public string shijian;
        public string zerenren;
        public string jiyaoneirong;
        public string yonghu;
        public string jiyaoshangchuanren;
        public string chuangjianshijian;
        public string zhonglei;
        public string dingwei;
        private void FrFenkaipifu_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (zhonglei == "1")
            {
                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    try
                    {

                        string sql2 = "update tb_zhishixiang  set 批复='" + richTextBoxEx1.Text + "'   where 会议时间= '" + shijian + "'  and  完成责任人='" + zerenren + "'  and  纪要上传人='" + jiyaoshangchuanren + "' and 创建时间='" + chuangjianshijian + "'  ";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);


                        string sql = "update  tb_xiangxi  set 批复 ='" + richTextBoxEx1.Text + "'   where  id='"+dingwei+"'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);



                        MessageBox.Show("提交成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("提交的时候发生了" + ex.Message);
                    }
                }
               
                }
            if (zhonglei == "2")
            {

                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    try
                    {
                        string huifu = DateTime.Now.ToString();
                        string sql1 = "INSERT INTO tb_zhishixiang(创建时间,会议时间,纪要内容,批复,纪要上传人,完成责任人) VALUES('" + huifu + "', '" + shijian + "', '" + jiyaoneirong + "','" + richTextBoxEx1.Text + "','" + jiyaoshangchuanren + "','" + zerenren + "')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                        
                        string sql = "update  tb_xiangxi  set 批复 ='" + richTextBoxEx1.Text + "'   where id='" + dingwei + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        
                        MessageBox.Show("提交成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("提交的时候发生了" + ex.Message);
                    }
                    
                }
            }
        }
    }
}
