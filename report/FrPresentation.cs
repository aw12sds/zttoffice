using Aspose.Words;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice
{
    public partial class FrPresentation : Office2007Form
    {

        public FrPresentation()
        {
            this.EnableGlass = false;
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
        

        private void FrPresentation_Load(object sender, EventArgs e)
        {

            string sql = "select 用户名,部门,序号 from tb_operator where 用户名='" + yonghu + "'";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);

            bumen = jieguo.Rows[0]["部门"].ToString();
            bianhao = jieguo.Rows[0]["序号"].ToString();

            string sql1 = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql1, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["部门"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBoxEx1.Items.Add(s);
            }

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择接收人！");
                return;
            }

            if (zhonglei == "日报")
            {
                if (dataGridViewX1.Rows.Count > 11)
                {
                    MessageBox.Show("常规工作内容不得超过十条,请酌情压缩！");
                    return;

                }
                if (dataGridViewX2.Rows.Count > 6)
                {
                    MessageBox.Show("重点工作内容不得超过五条,请酌情压缩！");
                    return;

                }
                if (dataGridViewX3.Rows.Count > 6)
                {
                    MessageBox.Show("思考不得超过五条,请酌情压缩！");
                    return;

                }
                if (dataGridViewX4.Rows.Count > 6)
                {
                    MessageBox.Show("下阶段规划不得超过五条,请酌情压缩！");
                    return;

                }
                if (dataGridViewX3.Rows.Count == 1)
                {
                    MessageBox.Show("必须写思考内容！");
                    return;

                }
                if (dataGridViewX4.Rows.Count == 1)
                {
                    MessageBox.Show("必须写下阶段规划内容！");
                    return;

                }
                if (dataGridViewX3.Rows.Count > 1 && dataGridViewX3.Rows.Count < 7)
                {
                    if (dataGridViewX3.Rows[0].Cells["开展情况3"].Value == null)
                    {
                        MessageBox.Show("第一条思考内容必须大于十个字符！");
                        return;
                    }


                    string a = dataGridViewX3.Rows[0].Cells["开展情况3"].Value.ToString();
                    int changdu = a.Length;
                    if (changdu < 10)
                    {
                        MessageBox.Show("第一条思考内容必须大于十个字符！");
                        return;

                    }
                    if (a.Trim() == "")
                    {
                        MessageBox.Show("不准投机取巧，必须输入十个真实文字！");
                        return;

                    }

                }
                if (dataGridViewX4.Rows.Count > 1 && dataGridViewX4.Rows.Count < 7)
                {
                    if (dataGridViewX4.Rows[0].Cells["规划情况"].Value == null)
                    {
                        MessageBox.Show("第一条下阶段内容必须大于十个字符！");
                        return;
                    }

                    string a = dataGridViewX4.Rows[0].Cells["规划情况"].Value.ToString();
                    int changdu = a.Length;
                    if (changdu < 10)
                    {
                        MessageBox.Show("第一条下阶段内容必须大于十个字符！");
                        return;

                    }
                    if (a.Trim() == "")
                    {
                        MessageBox.Show("不准投机取巧，必须输入十个真实文字！");
                        return;

                    }

                }



                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {


                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("日期", typeof(string)); //工程名称
                    dt1.Columns.Add("汇报人", typeof(string));
                    dt1.Columns.Add("工作类别1", typeof(string));
                    dt1.Columns.Add("工作类别2", typeof(string));
                    dt1.Columns.Add("工作类别3", typeof(string));
                    dt1.Columns.Add("工作类别4", typeof(string));
                    dt1.Columns.Add("工作类别5", typeof(string));
                    dt1.Columns.Add("工作类别6", typeof(string));
                    dt1.Columns.Add("工作类别7", typeof(string));
                    dt1.Columns.Add("工作类别8", typeof(string));
                    dt1.Columns.Add("工作类别9", typeof(string));
                    dt1.Columns.Add("工作类别10", typeof(string));



                    dt1.Columns.Add("工作内容1", typeof(string));
                    dt1.Columns.Add("工作内容2", typeof(string));
                    dt1.Columns.Add("工作内容3", typeof(string));
                    dt1.Columns.Add("工作内容4", typeof(string));
                    dt1.Columns.Add("工作内容5", typeof(string));
                    dt1.Columns.Add("工作内容6", typeof(string));
                    dt1.Columns.Add("工作内容7", typeof(string));
                    dt1.Columns.Add("工作内容8", typeof(string));
                    dt1.Columns.Add("工作内容9", typeof(string));
                    dt1.Columns.Add("工作内容10", typeof(string));



                    dt1.Columns.Add("完成情况1", typeof(string));
                    dt1.Columns.Add("完成情况2", typeof(string));
                    dt1.Columns.Add("完成情况3", typeof(string));
                    dt1.Columns.Add("完成情况4", typeof(string));
                    dt1.Columns.Add("完成情况5", typeof(string));
                    dt1.Columns.Add("完成情况6", typeof(string));
                    dt1.Columns.Add("完成情况7", typeof(string));
                    dt1.Columns.Add("完成情况8", typeof(string));
                    dt1.Columns.Add("完成情况9", typeof(string));
                    dt1.Columns.Add("完成情况10", typeof(string));

                    dt1.Columns.Add("思考1", typeof(string));
                    dt1.Columns.Add("思考2", typeof(string));
                    dt1.Columns.Add("思考3", typeof(string));
                    dt1.Columns.Add("思考4", typeof(string));
                    dt1.Columns.Add("思考5", typeof(string));

                    dt1.Columns.Add("下阶段1", typeof(string));
                    dt1.Columns.Add("下阶段2", typeof(string));
                    dt1.Columns.Add("下阶段3", typeof(string));
                    dt1.Columns.Add("下阶段4", typeof(string));
                    dt1.Columns.Add("下阶段5", typeof(string));

                    dt1.Columns.Add("日1", typeof(string));
                    dt1.Columns.Add("日2", typeof(string));
                    dt1.Columns.Add("日3", typeof(string));
                    dt1.Columns.Add("日4", typeof(string));
                    dt1.Columns.Add("日5", typeof(string));


                    dt1.Columns.Add("存在问题1", typeof(string));
                    dt1.Columns.Add("存在问题2", typeof(string));
                    dt1.Columns.Add("存在问题3", typeof(string));
                    dt1.Columns.Add("存在问题4", typeof(string));
                    dt1.Columns.Add("存在问题5", typeof(string));

                    DataRow dr1 = dt1.NewRow();

                    dr1["日期"] = DateTime.Now.ToString("yyyy-MM-dd");
                    dr1["汇报人"] = yonghu;
                    for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
                    {
                        if (dataGridViewX1.Rows[i].Cells["工作类别"].Value == null)
                        {
                            dr1["工作类别" + (i + 1)] = "";
                        }
                        if (dataGridViewX1.Rows[i].Cells["工作类别"].Value != null)
                        {
                            dr1["工作类别" + (i + 1)] = dataGridViewX1.Rows[i].Cells["工作类别"].Value.ToString();
                        }
                        if (dataGridViewX1.Rows[i].Cells["工作内容"].Value == null)
                        {
                            dr1["工作内容" + (i + 1)] = "";
                        }
                        if (dataGridViewX1.Rows[i].Cells["工作内容"].Value != null)
                        {
                            dr1["工作内容" + (i + 1)] = dataGridViewX1.Rows[i].Cells["工作内容"].Value.ToString();
                        }

                        if (dataGridViewX1.Rows[i].Cells["完成情况"].Value == null)
                        {
                            dr1["完成情况" + (i + 1)] = "";
                        }

                        if (dataGridViewX1.Rows[i].Cells["完成情况"].Value != null)
                        {
                            dr1["完成情况" + (i + 1)] = dataGridViewX1.Rows[i].Cells["完成情况"].Value.ToString();
                        }
                    }
                    for (int i = 0; i < dataGridViewX2.Rows.Count - 1; i++)
                    {
                        if (dataGridViewX2.Rows[i].Cells["开展情况2"].Value == null)
                        {
                            dr1["日" + (i + 1)] = "";
                        }


                        if (dataGridViewX2.Rows[i].Cells["开展情况2"].Value != null)
                        {
                            dr1["日" + (i + 1)] = dataGridViewX2.Rows[i].Cells["开展情况2"].Value.ToString();
                        }

                        if (dataGridViewX2.Rows[i].Cells["存在问题"].Value == null)
                        {
                            dr1["存在问题" + (i + 1)] = "";
                        }


                        if (dataGridViewX2.Rows[i].Cells["存在问题"].Value != null)
                        {
                            dr1["存在问题" + (i + 1)] = dataGridViewX2.Rows[i].Cells["存在问题"].Value.ToString();
                        }
                       

                    }
                    for (int i = 0; i < dataGridViewX3.Rows.Count - 1; i++)
                    {
                        if (dataGridViewX3.Rows[i].Cells["开展情况3"].Value == null)
                        {
                            dr1["思考" + (i + 1)] = "";
                        }
                        if (dataGridViewX3.Rows[i].Cells["开展情况3"].Value != null)
                        {
                            dr1["思考" + (i + 1)] = dataGridViewX3.Rows[i].Cells["开展情况3"].Value.ToString();
                        }
                    }
                  

                    for (int i = 0; i < dataGridViewX4.Rows.Count - 1; i++)
                    {
                        if (dataGridViewX4.Rows[i].Cells["规划情况"].Value == null)
                        {
                            dr1["下阶段" + (i + 1)] = "";
                        }

                        if (dataGridViewX4.Rows[i].Cells["规划情况"].Value != null)
                        {
                            dr1["下阶段" + (i + 1)] = dataGridViewX4.Rows[i].Cells["规划情况"].Value.ToString();
                        }

                    }
                    
                    dt1.Rows.Add(dr1);


                    string tempFile = Application.StartupPath + "\\日报模板.doc";
                    Document doc = new Document(tempFile);
                    DocumentBuilder builder = new DocumentBuilder(doc);
                    NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    DataRow dr = dt1.Rows[0];
                    dic.Add("日期", dr["日期"].ToString());
                    dic.Add("汇报人", dr["汇报人"].ToString());


                    dic.Add("工作类别1", dr["工作类别1"].ToString());
                    dic.Add("工作类别2", dr["工作类别2"].ToString());
                    dic.Add("工作类别3", dr["工作类别3"].ToString());
                    dic.Add("工作类别4", dr["工作类别4"].ToString());
                    dic.Add("工作类别5", dr["工作类别5"].ToString());
                    dic.Add("工作类别6", dr["工作类别6"].ToString());
                    dic.Add("工作类别7", dr["工作类别7"].ToString());
                    dic.Add("工作类别8", dr["工作类别8"].ToString());
                    dic.Add("工作类别9", dr["工作类别9"].ToString());
                    dic.Add("工作类别10", dr["工作类别10"].ToString());

                    dic.Add("工作内容1", dr["工作内容1"].ToString());
                    dic.Add("工作内容2", dr["工作内容2"].ToString());
                    dic.Add("工作内容3", dr["工作内容3"].ToString());
                    dic.Add("工作内容4", dr["工作内容4"].ToString());
                    dic.Add("工作内容5", dr["工作内容5"].ToString());
                    dic.Add("工作内容6", dr["工作内容6"].ToString());
                    dic.Add("工作内容7", dr["工作内容7"].ToString());
                    dic.Add("工作内容8", dr["工作内容8"].ToString());
                    dic.Add("工作内容9", dr["工作内容9"].ToString());
                    dic.Add("工作内容10", dr["工作内容10"].ToString());

                    dic.Add("完成情况1", dr["完成情况1"].ToString());
                    dic.Add("完成情况2", dr["完成情况2"].ToString());
                    dic.Add("完成情况3", dr["完成情况3"].ToString());
                    dic.Add("完成情况4", dr["完成情况4"].ToString());
                    dic.Add("完成情况5", dr["完成情况5"].ToString());
                    dic.Add("完成情况6", dr["完成情况6"].ToString());
                    dic.Add("完成情况7", dr["完成情况7"].ToString());
                    dic.Add("完成情况8", dr["完成情况8"].ToString());
                    dic.Add("完成情况9", dr["完成情况9"].ToString());
                    dic.Add("完成情况10", dr["完成情况10"].ToString());

                    dic.Add("思考1", dr["思考1"].ToString());
                    dic.Add("思考2", dr["思考2"].ToString());
                    dic.Add("思考3", dr["思考3"].ToString());
                    dic.Add("思考4", dr["思考4"].ToString());
                    dic.Add("思考5", dr["思考5"].ToString());

                    dic.Add("下阶段1", dr["下阶段1"].ToString());
                    dic.Add("下阶段2", dr["下阶段2"].ToString());
                    dic.Add("下阶段3", dr["下阶段3"].ToString());
                    dic.Add("下阶段4", dr["下阶段4"].ToString());
                    dic.Add("下阶段5", dr["下阶段5"].ToString());

                    dic.Add("日1", dr["日1"].ToString());
                    dic.Add("日2", dr["日2"].ToString());
                    dic.Add("日3", dr["日3"].ToString());
                    dic.Add("日4", dr["日4"].ToString());
                    dic.Add("日5", dr["日5"].ToString());

                    dic.Add("存在问题1", dr["存在问题1"].ToString());
                    dic.Add("存在问题2", dr["存在问题2"].ToString());
                    dic.Add("存在问题3", dr["存在问题3"].ToString());
                    dic.Add("存在问题4", dr["存在问题4"].ToString());
                    dic.Add("存在问题5", dr["存在问题5"].ToString());


                    foreach (var key in dic.Keys)
                    {
                        builder.MoveToBookmark(key);
                        builder.Write(dic[key]);
                    }
                    string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "日报" + ".doc";
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
                    string riqi = DateTime.Now.ToString("yyyy-MM-dd");
                    string biaoti = DateTime.Now.ToString("yyyy-MM-dd") + yonghu + "日报";
                    string sql = "update tb_wenjian set 报告类型='日报',提交时间='" + shijian1 + "',员工备注='" + txtBeizhu.Text + "',文件类型='doc',部门='" + bumen + "',日期='" + riqi + "' ,报告标题='" + biaoti + "',接收人='" + textBox1.Text + "',编号='" + bianhao + "'  where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";

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
        

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEx2.Items.Clear();
            string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEx1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBoxEx2.Items.Add(s);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (comboBoxEx1.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择部门！");
                return;
            }
            string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEx1.Text + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }
            foreach (string s in spaceminute)
            {
                textBox1.Text += s + ";";
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (comboBoxEx2.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择人员！");
                return;
            }

            textBox1.Text += comboBoxEx2.Text + ";";
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            string strSql11 = "select 接收人分组 from tb_operator  where  用户名='"+yonghu+"' ";
           string fenzu = SQLhelp.ExecuteScalar(strSql11, CommandType.Text).ToString();
            if (fenzu == "")
            {
                MessageBox.Show("请先设置接收人分组！");
                return;
            }

            textBox1.Text = fenzu;

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

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

