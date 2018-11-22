using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.Service
{
    public partial class Frgonggao : Form
    {
        public Frgonggao()
        {
            InitializeComponent();
            
        }

        private void Frgonggao_Load(object sender, EventArgs e)
        {
            string sql = "select 公告标题,公告人,公告时间 from tb_gonggao where 公告类型='公告' order by 公告时间 desc ";



            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
        }
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                
                string biaoti = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "公告标题").ToString();
                Frchakan form = new Frchakan();
                form.biaoti = biaoti;

                form.ShowDialog();
            }
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
