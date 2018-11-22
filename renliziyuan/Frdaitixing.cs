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
    public partial class Frdaitixing : DevExpress.XtraEditors.XtraForm
    {
        public Frdaitixing()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {
            string sql1 = "select * from tb_danganbiao where 离职=''or 离职 is null";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            this.gridView1.IndicatorWidth = 40;
            gridView1.Columns.ColumnByName("姓名").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }
        
        private void Frdaitixing_Load(object sender, EventArgs e)
        {
            Reload();
           
        }
        private void Reload()
        {
            string sql1 = "select * from tb_danganbiao where 入职时间1<'" + DateTime.Now.AddDays(-75) + "'and 是否转正 is null";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);

            gridView1.Columns["id"].Visible = false;
            this.gridView1.IndicatorWidth = 40;
            gridView1.Columns.ColumnByName("姓名").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            string sql2 = "select *from tb_danganbiao where (合同到期时间a<'" + DateTime.Now.AddDays(+60) + "'and 是否签订合同1 is null)or (合同到期时间b<'" + DateTime.Now.AddDays(+60) + "'and 是否签订合同2 is null) or (合同到期时间b<'" + DateTime.Now.AddDays(+60) + "'and 是否签订合同3 is null)";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql2, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            this.gridView2.IndicatorWidth = 40;
            gridView2.Columns.ColumnByName("gridColumn13").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            string sql3 = "select *from tb_danganbiao where 复审日期1<'" + DateTime.Now.AddDays(+90) + "'and 是否已复审 is null";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql3, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            this.gridView4.IndicatorWidth = 40;
            gridView4.Columns.ColumnByName("gridColumn30").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void 转正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string zhuanzheng = Convert.ToString(gridView1.GetRowCellValue(i, "是否转正"));

                string time = DateTime.Now.ToString();
                if (zhuanzheng == "")
                {
                    string sql4 = "update tb_danganbiao  set  是否转正=1    where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                }
            }

            MessageBox.Show("转正成功！");
            Reload();
        }

        private void 已签订合同1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string hetongqianding = Convert.ToString(gridView1.GetRowCellValue(i, "是否签订合同1"));

                string time = DateTime.Now.ToString();
                if (hetongqianding == "")
                {
                    string sqlht = "update tb_danganbiao  set  是否签订合同1=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlht, CommandType.Text);

                }
            }

            MessageBox.Show("合同签订确认！");
            Reload();
        }

        private void 已签订合同2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string hetongqianding = Convert.ToString(gridView1.GetRowCellValue(i, "是否签订合同2"));

                string time = DateTime.Now.ToString();
                if (hetongqianding == "")
                {
                    string sqlht = "update tb_danganbiao  set  是否签订合同2=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlht, CommandType.Text);

                }
            }

            MessageBox.Show("合同签订确认！");
            Reload();
        }

        private void 已签订合同3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string hetongqianding = Convert.ToString(gridView1.GetRowCellValue(i, "是否签订合同3"));

                string time = DateTime.Now.ToString();
                if (hetongqianding == "")
                {
                    string sqlht = "update tb_danganbiao  set  是否签订合同3=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlht, CommandType.Text);

                }
            }

            MessageBox.Show("合同签订确认！");
            Reload();
        }
    }
}