using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.dianjian
{
    public partial class Frhuifuhuiyijiyao : Office2007Form
    {
        public Frhuifuhuiyijiyao()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        public int dingwei;
        private void Frhuifuhuiyijiyao_Load(object sender, EventArgs e)
        {
            Reload();
           
        }
        public void Reload()
        {
            string sql1 = "select id,创建时间,创建人,落实情况,落实措施,批复,附件名称,附件格式 from tb_huiyi  where 定位='" + dingwei + "'";
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }


            string fujiangeshi = dataGridViewX2.CurrentRow.Cells["附件格式"].Value.ToString();

            if (fujiangeshi == "")
            {
                MessageBox.Show("没有附件！");
                return;

            }

            string fujianmingcheng = dataGridViewX2.CurrentRow.Cells["附件名称"].Value.ToString();

            string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
           

            string sql = "Select 附件 From tb_huiyi  Where id='" + id + "' ";

            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);


            string aaaa = System.Environment.CurrentDirectory;
            string lujing = aaaa + "\\" + fujianmingcheng + "." + fujiangeshi;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string sql1 = "insert into tb_huiyi (批复,定位,创建人,创建时间) values('"+textBox1.Text+"','"+dingwei+"','"+yonghu+"','"+DateTime.Now+"')";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            
            string sql2 = "update tb_xiangxi set 批复='"+textBox1.Text+"' where id='" + dingwei + "'";
            SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            textBox1.Text = "";
            Reload();
        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }
    }
}
