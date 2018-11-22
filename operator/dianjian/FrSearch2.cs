using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ztoffice.dianjian
{
    public partial class FrSearch2 : Office2007Form
    {
        public FrSearch2()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;
        public string huiyishijian;
        public string huiyizhuti;
        public string lujing;
        private void FrSearch2_Load(object sender, EventArgs e)
        {
            Reload();
        }
        int RowIndexP = -1, RowBackP = -1;
        public void Reload()
        {
            string sql = "select id,会议时间,会议主题,参会人员,纪要上传人,纪要类型 from tb_xiangxi where 纪要类型='集团会议' ";

            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "会议时间";

            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            taxColumn.ColumnName = "会议主题";

            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string panduan1 = dt1.Rows[i]["纪要类型"].ToString();
                if (panduan1 == "集团会议")
                {
                    string str = dt1.Rows[i]["参会人员"].ToString();
                    //正则表达式

                    Match m;

                    Regex r = new Regex(yonghu);

                    m = r.Match(str);
                    string panduan = m.ToString();


                    if (panduan != "")
                    {
                        DataRow dr = table.NewRow();
                        string huiyishijian1 = dt1.Rows[i]["会议时间"].ToString();
                        string huiyizhuti1 = dt1.Rows[i]["会议主题"].ToString();
                        if (huiyizhuti != huiyizhuti1)
                        {
                            huiyizhuti = huiyizhuti1;
                            dr["会议时间"] = dt1.Rows[i]["会议时间"].ToString();

                            dr["会议主题"] = dt1.Rows[i]["会议主题"].ToString();

                            table.Rows.Add(dr);
                        }

                    }
                }

            }

            dataGridViewX1.DataSource = table;


            string sql2 = "select id,会议时间,会议主题,参会人员,纪要上传人,纪要类型 from tb_xiangxi where 纪要类型='会议' ";

            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);


            DataTable table2 = new DataTable();

            //创建table的第一列
            DataColumn priceColumn2 = new DataColumn();
            //该列的数据类型
            priceColumn2.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn2.ColumnName = "会议时间";

            DataColumn taxColumn2 = new DataColumn();
            taxColumn2.DataType = System.Type.GetType("System.String");
            taxColumn2.ColumnName = "会议主题";

            table2.Columns.Add(priceColumn2);
            table2.Columns.Add(taxColumn2);



            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string panduan1 = dt2.Rows[i]["纪要类型"].ToString();
                if (panduan1 == "会议")
                {
                    string str = dt2.Rows[i]["参会人员"].ToString();
                    //正则表达式

                    Match m;

                    Regex r = new Regex(yonghu);

                    m = r.Match(str);
                    string panduan = m.ToString();


                    if (panduan != "")
                    {
                        DataRow dr = table2.NewRow();
                        string huiyishijian1 = dt2.Rows[i]["会议时间"].ToString();
                        string huiyizhuti1 = dt2.Rows[i]["会议主题"].ToString();
                        if (huiyizhuti != huiyizhuti1)
                        {
                            huiyizhuti = huiyizhuti1;
                            dr["会议时间"] = dt2.Rows[i]["会议时间"].ToString();

                            dr["会议主题"] = dt2.Rows[i]["会议主题"].ToString();

                            table2.Rows.Add(dr);
                        }

                    }
                }

            }

            dataGridViewX2.DataSource = table2;


            string sql3 = "select id,会议时间,会议主题,参会人员,纪要上传人,纪要类型 from tb_xiangxi where 纪要类型='部门会议' ";

            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);


            DataTable table3 = new DataTable();

            //创建table的第一列
            DataColumn priceColumn3 = new DataColumn();
            //该列的数据类型
            priceColumn3.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn3.ColumnName = "会议时间";

            DataColumn taxColumn3 = new DataColumn();
            taxColumn3.DataType = System.Type.GetType("System.String");
            taxColumn3.ColumnName = "会议主题";

            table3.Columns.Add(priceColumn3);
            table3.Columns.Add(taxColumn3);



            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string panduan1 = dt3.Rows[i]["纪要类型"].ToString();
                if (panduan1 == "部门会议")
                {
                    string str = dt3.Rows[i]["参会人员"].ToString();
                    //正则表达式

                    Match m;

                    Regex r = new Regex(yonghu);

                    m = r.Match(str);
                    string panduan = m.ToString();


                    if (panduan != "")
                    {
                        DataRow dr = table3.NewRow();
                        string huiyishijian1 = dt3.Rows[i]["会议时间"].ToString();
                        string huiyizhuti1 = dt3.Rows[i]["会议主题"].ToString();
                        if (huiyizhuti != huiyizhuti1)
                        {
                            huiyizhuti = huiyizhuti1;
                            dr["会议时间"] = dt3.Rows[i]["会议时间"].ToString();

                            dr["会议主题"] = dt3.Rows[i]["会议主题"].ToString();

                            table3.Rows.Add(dr);
                        }

                    }
                }

            }

            dataGridViewX3.DataSource = table3;


            if (yonghu != "桑甜" && yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "赵蕾蕾" && yonghu != "徐魏魏" && yonghu != "蔡红兵" && yonghu != "钱陆亦")
            {
                string sql4 = "select id,会议时间,会议主题,纪要内容,完成责任人,落实措施,完成时间,落实情况,考核绩效点,完成时间节点 from tb_xiangxi where 纪要类型!='指示项' and 已完成=1 and 完成责任人='" + yonghu + "'";

                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql4, CommandType.Text);
            }
            else
            {
                string sql4 = "select id,会议时间,会议主题,纪要内容,完成责任人,落实措施,完成时间,落实情况,考核绩效点,完成时间节点 from tb_xiangxi where 纪要类型!='指示项' and 已完成=1";

                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql4, CommandType.Text);


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

        private void dataGridViewX3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridViewX2_MouseMove(object sender, MouseEventArgs e)
        {
            RowIndexP = this.dataGridViewX2.HitTest(e.X, e.Y).RowIndex; //行 
            //int c = this.dataGridView1.HitTest(e.X, e.Y).ColumnIndex; //列 
            if (RowBackP >= 0 && RowBackP < dataGridViewX2.Rows.Count)
                dataGridViewX2.Rows[RowBackP].Selected = false;
            if (RowIndexP >= 0 && RowIndexP < dataGridViewX2.Rows.Count)
                dataGridViewX2.Rows[RowIndexP].Selected = true;
            RowBackP = RowIndexP;
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrXiangqing form = new FrXiangqing();
            form.shijian = dataGridViewX2.CurrentRow.Cells["会议时间2"].Value.ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认上传集团会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "集团会议";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload();

                }
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认上传公司级会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "会议";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload();

                }
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认上传部门级会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "部门会议";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload();

                }
            }
        }

        private void dataGridViewX4_MouseMove(object sender, MouseEventArgs e)
        {
            RowIndexP = this.dataGridViewX4.HitTest(e.X, e.Y).RowIndex; //行 
            //int c = this.dataGridView1.HitTest(e.X, e.Y).ColumnIndex; //列 
            if (RowBackP >= 0 && RowBackP < dataGridViewX4.Rows.Count)
                dataGridViewX4.Rows[RowBackP].Selected = false;
            if (RowIndexP >= 0 && RowIndexP < dataGridViewX4.Rows.Count)
                dataGridViewX4.Rows[RowIndexP].Selected = true;
            RowBackP = RowIndexP;
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrXiangqing form = new FrXiangqing();
            form.shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX3.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrXiangqing form = new FrXiangqing();
            form.shijian = dataGridViewX3.CurrentRow.Cells["会议时间3"].Value.ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
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
