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
    public partial class Frweibaodengji : DevExpress.XtraEditors.XtraForm
    {
        public Frweibaodengji()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frweibaodengji_Load(object sender, EventArgs e)
        {
            Reload();

        }
        private void Reload()
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (bumen == "人力资源部")
            {
                string sql2 = "select * from tb_stutest ";
                gridControl1.DataSource = SQLhelp.GetDataTablexiangmuguanli(sql2, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
            }


            else
            {
                string sql1 = "select * from tb_stutest where 审批人姓名='" + yonghu + "'";
                gridControl1.DataSource = SQLhelp.GetDataTablexiangmuguanli(sql1, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sql = "update tb_stutest  set 日常行为规范评分='" + gridView1.GetRowCellValue(i, "日常行为规范评分").ToString() + "'";
                SQLhelp.ExecuteScalarxiangmuguanli(sql, CommandType.Text);
            }
            MessageBox.Show("保存成功！");
            Reload();
        }
    }
}