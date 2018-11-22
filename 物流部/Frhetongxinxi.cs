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
    public partial class Frhetongxinxi : Form
    {
        public Frhetongxinxi()
        {
            InitializeComponent();
        }
        public string hetonghao;
        private void Frhetongxinxi_Load(object sender, EventArgs e)
        {
            string sql = "select 合同号,采购员,供方名称,工作令号,采购单价 from tb_caigouliaodan where 合同号='" + hetonghao + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
        }
    }
}
