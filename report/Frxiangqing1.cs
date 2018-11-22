using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.report
{
    public partial class Frxiangqing1 : DevExpress.XtraEditors.XtraForm
    {
        public Frxiangqing1()
        {
            
            InitializeComponent();
        }
        public string yonghu;
        public string kashi;
        public string jieshu;
        public string biaoji;
        private void Frxiangqing_Load(object sender, EventArgs e)
        {
            if (biaoji == "0")
            {
                DateTime datekaishi = Convert.ToDateTime(kashi);
                DateTime datejieshu = Convert.ToDateTime(jieshu);
                string sql = " select id, 会议时间, 纪要内容, 批复, 纪要上传人, 完成责任人, 完成时间, 已完成, 完成时间节点, 考核绩效点 from tb_xiangxi  where 完成责任人 = '" + yonghu + "' and 会议时间>'" + datekaishi + "' and 会议时间 <'" + datejieshu + "'";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }

            if (biaoji == "1")
            {
                
                string sql = " select id, 会议时间, 纪要内容, 批复, 纪要上传人, 完成责任人, 完成时间, 已完成, 完成时间节点, 考核绩效点 from tb_xiangxi  where 完成责任人 = '" + yonghu + "' ";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
                
            }

        }

        private void dataGridViewX4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
