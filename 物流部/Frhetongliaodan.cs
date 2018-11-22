using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztoffice.物流部
{
    public partial class Frhetongliaodan : DevExpress.XtraEditors.XtraForm
    {
        public Frhetongliaodan()
        {
            InitializeComponent();
        }
        public string hetonghao;
        private void Frhetongliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,设备名称,名称,型号,单位,供方名称,合同号,实际采购数量,采购单价 from  tb_caigouliaodan  where 合同号='" + hetonghao + "'";
            gridControl4.DataSource = SQLhelp1.GetDataTable(sql1, CommandType.Text);
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}