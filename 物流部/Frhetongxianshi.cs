using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.物流部
{
    public partial class Frhetongxianshi : DevExpress.XtraEditors.XtraForm
    {
        public Frhetongxianshi()
        {
            InitializeComponent();
        }
        public DataTable dt;
        private void Frhetongxianshi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            Frhetongxinxi form = new Frhetongxinxi();
            form.hetonghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同号").ToString();            
            form.ShowDialog();
        }
    }
}
