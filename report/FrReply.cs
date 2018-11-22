using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.report
{
    public partial class FrReply : DevExpress.XtraEditors.XtraForm
    {
        public FrReply()
        {
            
            InitializeComponent();
        }
        public string yonghu;
        public string baogaoleixing;
        public string shijian;
        private void FrReply_Load(object sender, EventArgs e)
        {

        }
        
       

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql1 = "update tb_wenjian   set 批复='" + textBox1.Text + "' Where 员工姓名 = '" + yonghu + "'and 提交时间 = '" + shijian + "' and 报告类型= '" + baogaoleixing + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            MessageBox.Show("回复成功");
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
