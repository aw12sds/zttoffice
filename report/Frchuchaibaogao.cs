using Aspose.Words;
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

namespace ztoffice.report
{
    public partial class Frchuchaibaogao : DevExpress.XtraEditors.XtraForm
    {
        public Frchuchaibaogao()
        {
            //this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string lujing;
        public string yonghu;
        public string bumen;
        public string panduan;//判断窗体
        public string tijiaoshijian;//修改时使用
        public string bianhao;
        public string zhonglei;

        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string lujing2;
        private void Frchuchaibaogao_Load(object sender, EventArgs e)
        {
            string sql12 = "Select 序号 from tb_operator where 用户名='" + yonghu + "'";
            bianhao = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
            string sql = "select 用户名,部门,序号 from tb_operator where 用户名='" + yonghu + "'";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);

            bumen = jieguo.Rows[0]["部门"].ToString();
            bianhao = jieguo.Rows[0]["序号"].ToString();

            string sql1 = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql1, CommandType.Text);

            string sql3 = "select 申请人,职务 from workflow ";
            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            gridControl1.DataSource = dt3;

            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {
                string n = aaaa.Rows[i]["部门"].ToString();
                spaceminute.Add(n);
            }


            //foreach (string s in spaceminute)
            //{
            //    comboBoxEx1.Items.Add(s);
            //}
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxEx2.Items.Clear();
            //string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEx1.Text + "'";
            //DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            //List<string> spaceminute = new List<string>();
            //for (int i = 0; i < aaaa.Rows.Count; i++)
            //{

            //    string n = aaaa.Rows[i]["用户名"].ToString();
            //    spaceminute.Add(n);
            //}


            //foreach (string s in spaceminute)
            //{
            //    comboBoxEx2.Items.Add(s);
            //}
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtName.Text);
                    //获得文件大小
                    fileSize2 = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName2 = info.FullName.Remove(index);
                    fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);

                    //获得文件扩展名
                    fileType2 = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files2 = new byte[Convert.ToInt32(fileSize2)];
                    FileStream file1 = new FileStream(txtName.Text, FileMode.Open, FileAccess.Read);
                    read2 = new BinaryReader(file1);
                    read2.Read(files2, 0, Convert.ToInt32(fileSize2));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //if (comboBoxEx1.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请先选择部门！");
            //    return;
            //}
            //string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEx1.Text + "'";
            //DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);
            //List<string> spaceminute = new List<string>();
            //for (int i = 0; i < aaaa.Rows.Count; i++)
            //{

            //    string n = aaaa.Rows[i]["用户名"].ToString();
            //    spaceminute.Add(n);
            //}
            //foreach (string s in spaceminute)
            //{
            //    textBox1.Text += s + ";";
            //}
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //if (comboBoxEx2.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请先选择人员！");
            //    return;
            //}

            //textBox1.Text += comboBoxEx2.Text + ";";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string strSql11 = "select 接收人分组 from tb_operator  where  用户名='" + yonghu + "' ";
            string fenzu = SQLhelp.ExecuteScalar(strSql11, CommandType.Text).ToString();
            if (fenzu == "")
            {
                MessageBox.Show("请先设置接收人分组！");
                return;
            }

            textBox1.Text = fenzu;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择接收人！");
                return;
            }


            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("出差时间", typeof(string)); //工程名称
                dt1.Columns.Add("出差地点", typeof(string));
                dt1.Columns.Add("出差人", typeof(string));
                dt1.Columns.Add("出差事由", typeof(string));
                dt1.Columns.Add("对象单位", typeof(string));
                dt1.Columns.Add("出差见闻", typeof(string));
                dt1.Columns.Add("出差过程", typeof(string));



                dt1.Columns.Add("存在问题1", typeof(string));
                dt1.Columns.Add("存在问题2", typeof(string));
                dt1.Columns.Add("存在问题3", typeof(string));
                dt1.Columns.Add("存在问题4", typeof(string));
                dt1.Columns.Add("存在问题5", typeof(string));
                dt1.Columns.Add("存在问题6", typeof(string));
                dt1.Columns.Add("存在问题7", typeof(string));
                dt1.Columns.Add("存在问题8", typeof(string));
                dt1.Columns.Add("存在问题9", typeof(string));
                dt1.Columns.Add("存在问题10", typeof(string));



                dt1.Columns.Add("改善措施1", typeof(string));
                dt1.Columns.Add("改善措施2", typeof(string));
                dt1.Columns.Add("改善措施3", typeof(string));
                dt1.Columns.Add("改善措施4", typeof(string));
                dt1.Columns.Add("改善措施5", typeof(string));
                dt1.Columns.Add("改善措施6", typeof(string));
                dt1.Columns.Add("改善措施7", typeof(string));
                dt1.Columns.Add("改善措施8", typeof(string));
                dt1.Columns.Add("改善措施9", typeof(string));
                dt1.Columns.Add("改善措施10", typeof(string));


                DataRow dr1 = dt1.NewRow();

                dr1["出差时间"] = dateEdit1.Text;
                dr1["出差地点"] = textchuchaididian.Text;
                dr1["出差事由"] = textchuchashiyou.Text;
                dr1["对象单位"] = textduixiangdanwei.Text;
                dr1["出差见闻"] = textjianwen.Text;
                dr1["出差过程"] = textguocheng.Text;
                dr1["出差人"] = yonghu;

                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {

                    if (gridView1.GetRowCellValue(i, "申请人").ToString() == "")
                    {
                        dr1["存在问题" + (i + 1)] = "";
                    }


                    if (gridView1.GetRowCellValue(i, "申请人").ToString() != "")
                    {
                        dr1["存在问题" + (i + 1)] = gridView1.GetRowCellValue(i, "申请人").ToString();
                    }

                    if (gridView1.GetRowCellValue(i, "职务").ToString() == "")
                    {
                        dr1["改善措施" + (i + 1)] = "";
                    }


                    if (gridView1.GetRowCellValue(i, "职务").ToString() != "")
                    {
                        dr1["改善措施" + (i + 1)] = gridView1.GetRowCellValue(i, "职务").ToString();
                    }

                }


                dt1.Rows.Add(dr1);


                string tempFile = Application.StartupPath + "\\出差报告模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];
                dic.Add("出差时间", dr["出差时间"].ToString());
                dic.Add("出差地点", dr["出差地点"].ToString());
                dic.Add("出差事由", dr["出差事由"].ToString());
                dic.Add("对象单位", dr["对象单位"].ToString());
                dic.Add("出差见闻", dr["出差见闻"].ToString());
                dic.Add("出差过程", dr["出差过程"].ToString());
                dic.Add("出差人", dr["出差人"].ToString());



                dic.Add("存在问题1", dr["存在问题1"].ToString());
                dic.Add("存在问题2", dr["存在问题2"].ToString());
                dic.Add("存在问题3", dr["存在问题3"].ToString());
                dic.Add("存在问题4", dr["存在问题4"].ToString());
                dic.Add("存在问题5", dr["存在问题5"].ToString());
                dic.Add("存在问题6", dr["存在问题6"].ToString());
                dic.Add("存在问题7", dr["存在问题7"].ToString());
                dic.Add("存在问题8", dr["存在问题8"].ToString());
                dic.Add("存在问题9", dr["存在问题9"].ToString());
                dic.Add("存在问题10", dr["存在问题10"].ToString());


                dic.Add("改善措施1", dr["改善措施1"].ToString());
                dic.Add("改善措施2", dr["改善措施2"].ToString());
                dic.Add("改善措施3", dr["改善措施3"].ToString());
                dic.Add("改善措施4", dr["改善措施4"].ToString());
                dic.Add("改善措施5", dr["改善措施5"].ToString());
                dic.Add("改善措施6", dr["改善措施6"].ToString());
                dic.Add("改善措施7", dr["改善措施7"].ToString());
                dic.Add("改善措施8", dr["改善措施8"].ToString());
                dic.Add("改善措施9", dr["改善措施9"].ToString());
                dic.Add("改善措施10", dr["改善措施10"].ToString());


                foreach (var key in dic.Keys)
                {
                    builder.MoveToBookmark(key);
                    builder.Write(dic[key]);
                }
                string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "出差报告" + ".doc";
                FileInfo info1 = new FileInfo(Application.StartupPath + "\\" + mingcheng);
                string fileName11 = info1.Name.ToString();
                string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();

                doc.Save(info1.DirectoryName + "\\" + fileName11);

                FileInfo info = new FileInfo(info1.DirectoryName + "\\" + fileName11);
                //获得文件大小
                long fileSize12 = info.Length;
                //提取文件名,三步走
                int index = info.FullName.LastIndexOf(".");
                string fileName12 = info.FullName.Remove(index);
                fileName12 = fileName12.Substring(fileName12.LastIndexOf(@"\") + 1);
                //txtMingcheng.Text = fileName;
                //获得文件扩展名
                string fileType12 = info.Extension.Replace(".", "");
                //把文件转换成二进制流
                byte[] files12 = new byte[Convert.ToInt32(fileSize12)];
                FileStream file = new FileStream(info1.DirectoryName + "\\" + fileName11, FileMode.Open, FileAccess.Read);
                BinaryReader read = new BinaryReader(file);
                read.Read(files12, 0, Convert.ToInt32(fileSize12));

                DateTime shijian1 = DateTime.Now;
                string sql1 = "INSERT INTO tb_wenjian(文件,提交时间,员工姓名) VALUES (@pic,'" + shijian1 + "','" + yonghu + "')";
                SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files12);

                string sql = "update tb_wenjian set 报告类型='出差报告',提交时间='" + shijian1 + "',员工备注='" + txtBeizhu.Text + "',文件类型='doc',部门='" + bumen + "',日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ,报告标题='" + DateTime.Now.ToString("yyyy-MM-dd") + yonghu + "出差报告" + "',接收人='" + textBox1.Text + "',编号='" + bianhao + "'  where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";

                int g = SQLhelp.innn(sql, CommandType.Text);

                if (txtName.Text != "")
                {
                    string sql2 = "update tb_wenjian  set 附件=@pic where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";
                    SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files2);

                    string sql3 = "update tb_wenjian  set 附件名称='" + fileName2 + "',附件类型='" + fileType2 + "'  where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                }
                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }


        }
    }
}
