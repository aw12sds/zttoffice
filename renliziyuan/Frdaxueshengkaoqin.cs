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
    public partial class Frdaxueshengkaoqin : DevExpress.XtraEditors.XtraForm
    {
        public Frdaxueshengkaoqin()
        {
            InitializeComponent();
        }
        public string yonghu;
     
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           Stukaoqindengji form1 = new Stukaoqindengji();
            form1.ShowDialog();
            
        }

        private void Frdaxueshengkaoqin_Load_1(object sender, EventArgs e)
        {
            string sql = "select 大学生姓名,发生时间,考勤类型,时长 FROM  tb_daxueshengkaoqin";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
    }
}