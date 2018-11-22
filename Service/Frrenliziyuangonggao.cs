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
    public partial class Frrenliziyuangonggao : Form
    {
        public Frrenliziyuangonggao()
        {
            InitializeComponent();
        }

        private void Frrenliziyuangonggao_Load(object sender, EventArgs e)
        {

            string sql11 = "select 公告标题,公告人,公告时间 from tb_gonggao where 公告类型='人力'  order  by 公告时间 desc ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
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
