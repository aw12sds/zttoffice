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
    public partial class FrZhishixaingchakan : Office2007Form
    {
        public FrZhishixaingchakan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string shijian;
        public string zerenren;
        public string jiyaoneirong;
        public string yonghu;
        public string jiyaoshangchuanren;

        public string dingwei;

        public string lujing;
        public string leixing;
        private void FrZhishixaingchakan_Load(object sender, EventArgs e)
        {
            Reload();

        }
        public void Reload()
        {

            string strsql1 = "select 创建时间,会议时间,纪要内容,落实措施,落实情况,纪要上传人,附件格式,附件名称,批复,完成责任人 from tb_zhishixiang  where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' ";
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
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

            string chuangjianshijian = dataGridViewX2.CurrentRow.Cells["创建时间"].Value.ToString();
            string wanchengzerenren = dataGridViewX2.CurrentRow.Cells["完成责任人"].Value.ToString();

            string sql = "Select 附件 From tb_zhishixiang  Where 创建时间='" + chuangjianshijian + "' and  完成责任人='" + wanchengzerenren + "' ";

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

        private void 回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人"].Value.ToString();
            string neirong = dataGridViewX2.CurrentRow.Cells["纪要内容"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["会议时间"].Value.ToString();
            string jiyaoshangchuanren = dataGridViewX2.CurrentRow.Cells["纪要上传人"].Value.ToString();

            string chuangjianshijian = dataGridViewX2.CurrentRow.Cells["创建时间"].Value.ToString();

            if (yonghu != jiyaoshangchuanren)
            {
                MessageBox.Show("非指示项发起人无权限批复！");
                return;

            }

            FrFenkaipifu form = new FrFenkaipifu();
            form.shijian = shijian;
            form.jiyaoneirong = jiyaoneirong;
            form.chuangjianshijian = chuangjianshijian;
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = jiyaoshangchuanren;
            form.zerenren = zerenren;
            form.dingwei = dingwei;
            form.zhonglei = "1";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }
        int RowIndexP1 = -1, RowBackP1 = -1;

        private void 创建新回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu != jiyaoshangchuanren)
            {
                MessageBox.Show("非指示项发起人无权限批复！");
                return;

            }

            FrFenkaipifu form = new FrFenkaipifu();
            form.shijian = shijian;
            form.dingwei = dingwei;
            form.jiyaoneirong = jiyaoneirong;
            
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = jiyaoshangchuanren;
            form.zerenren = zerenren;
            form.zhonglei = "2";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
            
        }

        private void FrZhishixaingchakan_MouseMove(object sender, MouseEventArgs e)
        {
            RowIndexP1 = this.dataGridViewX2.HitTest(e.X, e.Y).RowIndex; //行 

            if (RowBackP1 >= 0 && RowBackP1 < dataGridViewX2.Rows.Count)
                dataGridViewX2.Rows[RowBackP1].Selected = false;
            if (RowIndexP1 >= 0 && RowIndexP1 < dataGridViewX2.Rows.Count)
                dataGridViewX2.Rows[RowIndexP1].Selected = true;
            RowBackP1 = RowIndexP1;
        }
    }
}
