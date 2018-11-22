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
    public partial class Frheimingdan : DevExpress.XtraEditors.XtraForm
    {
        public Frheimingdan()
        {
            InitializeComponent();
        }

        private void Frheimingdan_Load(object sender, EventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
            string sql = "select *from tb_danganbiao where 离职='1' and  黑名单='1'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
    }
}