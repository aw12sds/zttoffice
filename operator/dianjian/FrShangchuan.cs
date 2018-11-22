using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice
{
    public partial class FrShangchuan : Office2007Form
    {
        public FrShangchuan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        public string zhonglei;
        private void FrShangchuan_Load(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["部门"].ToString();
                spaceminute.Add(n);
            }

            foreach (string s in spaceminute)
            {
                comboBox1.Items.Add(s);

            }

            DataGridViewComboBoxExColumn column = new DataGridViewComboBoxExColumn();
            column.Name = "完成责任人";
            column.DataPropertyName = "用户名";
            column.HeaderText = "完成责任人";
            column.DropDownStyle = ComboBoxStyle.DropDownList;

            this.dataGridViewX1.Columns.Add(column);
            string sql1 = "select 用户名 from tb_operator";
            DataTable aaaaa = SQLhelp.GetDataTable(sql1, CommandType.Text);

            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < aaaaa.Rows.Count; i++)
            {

                string n = aaaaa.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);
            }

            foreach (string s in spaceminute1)
            {
                column.Items.Add(s);

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string sql = "select 用户名 from tb_operator where 部门='" + comboBox1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBox2.Items.Add(s);
            }
        }

        private void btnAddall_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择部门！");
                return;
            }
            string sql = "select 用户名 from tb_operator where 部门='" + comboBox1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }
            foreach (string s in spaceminute)
            {
                txtName.Text += s + ";";
            }
        }

        private void btnAddone_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            txtName.Text += comboBox2.Text + ";";
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (zhonglei == "集团会议")

            {

                if (txtName.Text == "")
                {
                    MessageBox.Show("请选择参会人员！");
                    return;
                }
                if (txtJiluren.Text == "")
                {
                    MessageBox.Show("请选择记录人！");
                    return;
                }
                if (txtZhuchiren.Text == "")
                {
                    MessageBox.Show("请选择主持人！");
                    return;
                }
                if (txtZhuti.Text == "")
                {
                    MessageBox.Show("请输入会议主题！");
                    return;
                }
                try
                {

                    for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
                    {
                        string neirong = dataGridViewX1.Rows[i].Cells["纪要内容"].Value.ToString();
                        string fuzeren = dataGridViewX1.Rows[i].Cells["完成责任人"].Value.ToString();

                        string sql = "INSERT INTO tb_xiangxi(会议时间,会议主题,主持人,记录人,参会人员,纪要内容,完成责任人,纪要上传人,纪要类型,已完成) VALUES('" + dateTimePicker1.Text + "', '" + txtZhuti.Text + "', '" + txtZhuchiren.Text + "', '" + txtJiluren.Text + "', '" + txtName.Text + "', '" + neirong + "', '" + fuzeren + "', '" + yonghu + "', '集团会议',0)";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    }
                    MessageBox.Show("上传成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报错: " + ex.Message);
                }
            }
            if (zhonglei == "会议")

            {

                if (txtName.Text == "")
                {
                    MessageBox.Show("请选择参会人员！");
                    return;
                }
                if (txtJiluren.Text == "")
                {
                    MessageBox.Show("请选择记录人！");
                    return;
                }
                if (txtZhuchiren.Text == "")
                {
                    MessageBox.Show("请选择主持人！");
                    return;
                }
                if (txtZhuti.Text == "")
                {
                    MessageBox.Show("请输入会议主题！");
                    return;
                }
                try
                {

                    for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
                    {
                        string neirong = dataGridViewX1.Rows[i].Cells["纪要内容"].Value.ToString();
                        string fuzeren = dataGridViewX1.Rows[i].Cells["完成责任人"].Value.ToString();

                        string sql = "INSERT INTO tb_xiangxi(会议时间,会议主题,主持人,记录人,参会人员,纪要内容,完成责任人,纪要上传人,纪要类型,已完成) VALUES('" + dateTimePicker1.Text + "', '" + txtZhuti.Text + "', '" + txtZhuchiren.Text + "', '" + txtJiluren.Text + "', '" + txtName.Text + "', '" + neirong + "', '" + fuzeren + "', '" + yonghu + "', '会议',0)";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    }
                    MessageBox.Show("上传成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报错: " + ex.Message);
                }
                
            }
            if (zhonglei == "部门会议")

            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("请选择参会人员！");
                    return;
                }
                if (txtJiluren.Text == "")
                {
                    MessageBox.Show("请选择记录人！");
                    return;
                }
                if (txtZhuchiren.Text == "")
                {
                    MessageBox.Show("请选择主持人！");
                    return;
                }
                if (txtZhuti.Text == "")
                {
                    MessageBox.Show("请输入会议主题！");
                    return;
                }
                try
                {

                    for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
                    {
                        string neirong = dataGridViewX1.Rows[i].Cells["纪要内容"].Value.ToString();
                        string fuzeren = dataGridViewX1.Rows[i].Cells["完成责任人"].Value.ToString();

                        string sql = "INSERT INTO tb_xiangxi(会议时间,会议主题,主持人,记录人,参会人员,纪要内容,完成责任人,纪要上传人,纪要类型,已完成) VALUES('" + dateTimePicker1.Text + "', '" + txtZhuti.Text + "', '" + txtZhuchiren.Text + "', '" + txtJiluren.Text + "', '" + txtName.Text + "', '" + neirong + "', '" + fuzeren + "', '" + yonghu + "', '部门会议',0)";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    }
                    MessageBox.Show("上传成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报错: " + ex.Message);
                }
                
            }
        }
    }
}
