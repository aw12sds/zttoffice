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
    public partial class FrXiugai : DevExpress.XtraEditors.XtraForm
    {
        public FrXiugai()
        {
            
            InitializeComponent();
        }
        public string zerenren;
        public string shijian;
        public string jiyaoneirong;

        private void FrXiugai_Load(object sender, EventArgs e)
        {

        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "update  tb_xiangxi  set 纪要内容 ='" + textBoxX1.Text + "'   where  会议时间='" + shijian + "' and 完成责任人='" + zerenren + "' and 纪要类型='指示项'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);

            string sql1 = "update  tb_zhishixiang  set 纪要内容 ='" + textBoxX1.Text + "'   where  会议时间='" + shijian + "' and 完成责任人='" + zerenren + "' and 纪要内容='" + jiyaoneirong + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);


            MessageBox.Show("修改成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
