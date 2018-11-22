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
    public partial class FrShangchuan : DevExpress.XtraEditors.XtraForm
    {
        public FrShangchuan()
        {
          
            InitializeComponent();
        }
        public string yonghu;
        public string zhonglei;
        private void FrShangchuan_Load(object sender, EventArgs e)
        {
            string sql1 = "select 纪要内容,完成责任人 from tb_jjiyaoneirong";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string sql8 = "select 用户名 from tb_operator  ";
            DataTable dtttt = SQLhelp.GetDataTable(sql8, CommandType.Text);
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < dtttt.Rows.Count; i++)
            {

                string n = dtttt.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }

            foreach (string s in spaceminute)
            {
                repositoryItemComboBox2.Items.Add(s);

            }

            string sql123 = "select 部门  from tb_bumen ";
            DataTable daa = SQLhelp.GetDataTable(sql123, CommandType.Text);
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < daa.Rows.Count; i++)
            {

                string n = daa.Rows[i]["部门"].ToString();
                spaceminute1.Add(n);
            }

            foreach (string s in spaceminute1)
            {
                comboBoxEdit1.Properties.Items.Add(s);

            }

        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            txtName.Text += comboBoxEdit2.Text + ";";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择部门！");
                return;
            }
            string sql = "select 用户名 from tb_operator where 部门='" +comboBoxEdit1.Text + "'";
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

        private void simpleButton3_Click(object sender, EventArgs e)
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

                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        string neirong =Convert.ToString(gridView1.GetRowCellValue(i, "纪要内容"));
                        string fuzeren = Convert.ToString(gridView1.GetRowCellValue(i, "完成责任人"));

                        string sql = "INSERT INTO tb_xiangxi(会议时间,会议主题,主持人,记录人,参会人员,纪要内容,完成责任人,纪要上传人,纪要类型,已完成) VALUES('" + dateEdit1.Text + "', '" + txtZhuti.Text + "', '" + txtZhuchiren.Text + "', '" + txtJiluren.Text + "', '" + txtName.Text + "', '" + neirong + "', '" + fuzeren + "', '" + yonghu + "', '集团会议',0)";
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

                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        string neirong = Convert.ToString(gridView1.GetRowCellValue(i, "纪要内容"));
                        string fuzeren = Convert.ToString(gridView1.GetRowCellValue(i, "完成责任人"));

                        string sql = "INSERT INTO tb_xiangxi(会议时间,会议主题,主持人,记录人,参会人员,纪要内容,完成责任人,纪要上传人,纪要类型,已完成) VALUES('" + dateEdit1.Text + "', '" + txtZhuti.Text + "', '" + txtZhuchiren.Text + "', '" + txtJiluren.Text + "', '" + txtName.Text + "', '" + neirong + "', '" + fuzeren + "', '" + yonghu + "', '会议',0)";
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

                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        string neirong = Convert.ToString(gridView1.GetRowCellValue(i, "纪要内容"));
                        string fuzeren = Convert.ToString(gridView1.GetRowCellValue(i, "完成责任人"));

                        string sql = "INSERT INTO tb_xiangxi(会议时间,会议主题,主持人,记录人,参会人员,纪要内容,完成责任人,纪要上传人,纪要类型,已完成) VALUES('" + dateEdit1.Text + "', '" + txtZhuti.Text + "', '" + txtZhuchiren.Text + "', '" + txtJiluren.Text + "', '" + txtName.Text + "', '" + neirong + "', '" + fuzeren + "', '" + yonghu + "', '部门会议',0)";
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEdit1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
               comboBoxEdit2.Properties.Items.Add(s);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
