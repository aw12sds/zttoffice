using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.xuqiu
{
    public partial class FrLliulan : Office2007Form
    {
        public FrLliulan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void FrLliulan_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql = "select * from tb_xuqiu ";
            dataGridViewX1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);

        }
        private void 提交需求ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrXuqiu form = new FrXuqiu();
            form.yonghu = yonghu;
            form.ShowDialog();
            if(form.DialogResult==DialogResult.OK)
            {
                form.Close();

                Reload();

            }

        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string xuqiushijian = dataGridViewX1.CurrentRow.Cells["需求时间"].Value.ToString();
            string xuqiuren = dataGridViewX1.CurrentRow.Cells["需求人"].Value.ToString();
            if (yonghu != "钱陆亦")
            {

                MessageBox.Show("无权限！");
                return;
            }

            try
            {

                string xiugai = "update tb_xuqiu set 已完成=1 ,完成时间='"+DateTime.Now+"'Where 需求时间='" + xuqiushijian + "' and 需求人='" + xuqiuren + "'";
                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                MessageBox.Show("修改成功！");
                Reload();

            }
            catch (Exception ex)

            {

                MessageBox.Show("发生错误：" + ex.Message);


            }
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
