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
    public partial class Frlizhi : DevExpress.XtraEditors.XtraForm
    {
        public Frlizhi()
        {
            InitializeComponent();
        }

        private void Frlizhi_Load(object sender, EventArgs e)
        {
            Reload();
            
           

        }
        private void Reload()
        {
            string sql = "select *from tb_danganbiao where 离职='1' and 黑名单 is null";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void 添加黑名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sql = "update tb_danganbiao  set 黑名单='1' where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("添加成功！");
            Reload();
        }

        private void 恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sql = "update tb_danganbiao  set 离职 = null where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("恢复成功！");
            Reload();
        }
    }
}