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
    public partial class Frkaohedan : DevExpress.XtraEditors.XtraForm
    {
        public Frkaohedan()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void button1_Click(object sender, EventArgs e)
        {
            Frkaohedengji form1 = new Frkaohedengji();
            form1.ShowDialog();
        }

        private void 新建考核_Click(object sender, EventArgs e)
        {
            Frkaohedengji form1 = new Frkaohedengji();
            form1.ShowDialog();
        }

        private void Frkaohedan_Load(object sender, EventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
            string sql1 = "select *from tb_kaohe";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            this.gridView1.IndicatorWidth = 40;
        }
    }
}