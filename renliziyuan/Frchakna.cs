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
    public partial class Frchakna : DevExpress.XtraEditors.XtraForm
    {
        public Frchakna()
        {
            InitializeComponent();
        }
        public string riqi;
        public string renyuan;
        public DateTime shijian;
        private void Frchakna_Load(object sender, EventArgs e)
        {
            string sql = "select 员工,时间 from tb_kaoqin";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}