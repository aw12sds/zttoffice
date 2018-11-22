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
    public partial class Frtongyongzhishi : DevExpress.XtraEditors.XtraForm
    {
        public Frtongyongzhishi()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frtongyongdengji form1 = new Frtongyongdengji();
            form1.yonghu = yonghu;
            form1.ShowDialog();
            Reload();
        }

        private void Frtongyongzhishi_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public  void Reload()
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (bumen == "人力资源部")
            {
                string sql2 = "select * from tb_Stutypeixun ";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql2, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
            }


            else 
            {
                string sql1= "select * from tb_Stutypeixun where 负责人='" + yonghu + "'";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            for (int i=0;i<gridView1.RowCount;i++)
            {
                string sql = "update tb_Stutypeixun  set 考核得分='" + gridView1.GetRowCellValue(i, "考核得分").ToString() + "' where id='" + gridView1.GetRowCellValue(i, "id").ToString() + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("保存成功！");
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}