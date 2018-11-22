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
    public partial class FrZhishixiangpifu : DevExpress.XtraEditors.XtraForm
    {
        public FrZhishixiangpifu()
        {
            
            InitializeComponent();
        }
        public string zerenren;
        public string shijian;
        public string id;
       
        private void FrZhishixiangpifu_Load(object sender, EventArgs e)
        {

        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "update  tb_xiangxi  set 批复 ='" + richTextBoxEx1.Text + "'   where  id='" + id + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);

            MessageBox.Show("批复成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
