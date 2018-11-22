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
    public partial class Frdaxueshengguanli : DevExpress.XtraEditors.XtraForm
    {
        public Frdaxueshengguanli()
        {
            InitializeComponent();
        }

        private void Fryuangongguanli_Load(object sender, EventArgs e)
        {
            string sql = "select 用户名,电话,籍贯,毕业学校,专业 FROM  tb_operator where 类别='大学生'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frruzhi FROM1 = new Frruzhi();
            FROM1.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
                
        }
    }
}