using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztoffice.renliziyuan
{
    public partial class Frlungangpeixun : DevExpress.XtraEditors.XtraForm
    {
        public Frlungangpeixun()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frlungangdengji Form1 = new Frlungangdengji();
            Form1.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Frlungangpeixun_Load(object sender, EventArgs e)
        {
            string sql = "select  大学生姓名,违纪类型,事件,次数 from tb_weiji";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
    }
}