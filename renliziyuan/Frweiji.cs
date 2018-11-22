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
    public partial class Frweiji : DevExpress.XtraEditors.XtraForm
    {
        public Frweiji()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Frweiji_Load(object sender, EventArgs e)
        {
            string sql = "select  大学生姓名,违纪类型,事件,次数 from tb_weiji";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frwejidengji Form1 = new Frwejidengji();
            Form1.ShowDialog();
        }
    }
}