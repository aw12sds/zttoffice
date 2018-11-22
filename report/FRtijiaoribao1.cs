using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Aspose.Words;
using NetWork.util;

namespace ztoffice.report
{
    public partial class FRtijiaoribao1 : DevExpress.XtraEditors.XtraForm
    {
        public FRtijiaoribao1()
        {
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
        private void FRtijiaoribao1_Load(object sender, EventArgs e)
        {
            string sql = "Select 序号 from tb_operator where 用户名='" + yonghu + "'";
            bianhao = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            string sql1 = "select 申请日期,申请部门 from workflow ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;

            string sql2 = "select 申请人,职务 from workflow ";
            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);
            gridControl2.DataSource = dt2;

            string sql3 = "select 调休原因 from workflow ";
            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            gridControl3.DataSource = dt3;

            string sql4 = "select 总计时数 from workflow ";
            DataTable dt4 = SQLhelp.GetDataTable(sql4, CommandType.Text);
            gridControl5.DataSource = dt4;

        }

        private void btnxuanzewenjian_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtwenjianlujing.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtwenjianlujing.Text);
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
                    FileStream file1 = new FileStream(txtwenjianlujing.Text, FileMode.Open, FileAccess.Read);
                    read2 = new BinaryReader(file1);
                    read2.Read(files2, 0, Convert.ToInt32(fileSize2));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void btntianjiajieshouren_Click(object sender, EventArgs e)
        {
            string strSql11 = "select 接收人分组 from tb_operator  where  用户名='" + yonghu + "' ";
            string fenzu = SQLhelp.ExecuteScalar(strSql11, CommandType.Text).ToString();
            if (fenzu == "")
            {
                MessageBox.Show("请先设置接收人分组！");
                return;
            }

           txtjieshouren.Text = fenzu;
        }

        private void btntijiaoribao_Click(object sender, EventArgs e)
        {
            if (txtjieshouren.Text == "")
            {
                MessageBox.Show("请选择接收人！");
                return;
            }

            if (zhonglei == "日报")
            {
                if (gridView1.RowCount > 11)
                {
                    MessageBox.Show("常规工作内容不得超过十条,请酌情压缩！");
                    return;

                }
                if (gridView3.RowCount > 6)
                {
                    MessageBox.Show("重点工作内容不得超过五条,请酌情压缩！");
                    return;

                }
                if (gridView6.RowCount > 6)
                {
                    MessageBox.Show("思考不得超过五条,请酌情压缩！");
                    return;

                }
                if (gridView5.RowCount > 6)
                {
                    MessageBox.Show("下阶段规划不得超过五条,请酌情压缩！");
                    return;

                }
                if (gridView6.RowCount == 1)
                {
                    MessageBox.Show("必须写思考内容！");
                    return;

                }
                if (gridView5.RowCount == 1)
                {
                    MessageBox.Show("必须写下阶段规划内容！");
                    return;

                }
                if (gridView6.RowCount > 1 && gridView6.RowCount < 7)
                {
                    if (gridView6.GetRowCellValue(0, "调休原因").ToString() == "")
                    {
                        MessageBox.Show("第一条思考内容必须大于十个字符！");
                        return;
                    }


                    string a = gridView6.GetRowCellValue(0, "调休原因").ToString();
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
                if (gridView5.RowCount > 1 && gridView5.RowCount < 7)
                {
                    if (gridView5.GetRowCellValue(0, "总计时数").ToString() == "")
                    {
                        MessageBox.Show("第一条下阶段内容必须大于十个字符！");
                        return;
                    }

                    string a = gridView5.GetRowCellValue(0, "总计时数").ToString();
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
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {

                        if (gridView1.GetRowCellValue(i, "申请日期").ToString() == "")
                        {
                            dr1["工作内容" + (i + 1)] = "";
                        }
                        if (gridView1.GetRowCellValue(i, "申请日期").ToString() != "")
                        {
                            dr1["工作内容" + (i + 1)] = gridView1.GetRowCellValue(i, "申请日期").ToString();
                        }

                        if (gridView1.GetRowCellValue(i, "申请部门").ToString() == "")
                        {
                            dr1["完成情况" + (i + 1)] = "";
                        }

                        if (gridView1.GetRowCellValue(i, "申请部门").ToString() != "")
                        {
                            dr1["完成情况" + (i + 1)] = gridView1.GetRowCellValue(i, "申请部门").ToString();
                        }
                    }
                    for (int i = 0; i < gridView3.RowCount - 1; i++)
                    {
                        if (gridView3.GetRowCellValue(i, "申请人").ToString() == "")
                        {
                            dr1["日" + (i + 1)] = "";
                        }


                        if (gridView3.GetRowCellValue(i, "申请人").ToString() != "")
                        {
                            dr1["日" + (i + 1)] = gridView3.GetRowCellValue(i, "申请人").ToString();
                        }

                        if (gridView3.GetRowCellValue(i, "职务").ToString() == "")
                        {
                            dr1["存在问题" + (i + 1)] = "";
                        }


                        if (gridView3.GetRowCellValue(i, "职务").ToString() != "")
                        {
                            dr1["存在问题" + (i + 1)] = gridView3.GetRowCellValue(i, "职务").ToString();
                        }


                    }
                    for (int i = 0; i < gridView6.RowCount - 1; i++)
                    {
                        if (gridView6.GetRowCellValue(i, "调休原因").ToString() == "")
                        {
                            dr1["思考" + (i + 1)] = "";
                        }
                        if (gridView6.GetRowCellValue(i, "调休原因").ToString() != "")
                        {
                            dr1["思考" + (i + 1)] = gridView6.GetRowCellValue(i, "调休原因").ToString();
                        }
                    }


                    for (int i = 0; i < gridView5.RowCount - 1; i++)
                    {
                        if (gridView5.GetRowCellValue(i, "总计时数").ToString() == "")
                        {
                            dr1["下阶段" + (i + 1)] = "";
                        }

                        if (gridView5.GetRowCellValue(i, "总计时数").ToString() != "")
                        {
                            dr1["下阶段" + (i + 1)] = gridView5.GetRowCellValue(i, "总计时数").ToString();
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



                    DateTime shijian1 = Convert.ToDateTime(getData.getservertime());
                    string sql1 = "INSERT INTO tb_wenjian(文件,提交时间,员工姓名) VALUES (@pic,'" + shijian1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files12);
                    string riqi = DateTime.Now.ToString("yyyy-MM-dd");
                    string biaoti = DateTime.Now.ToString("yyyy-MM-dd") + yonghu + "日报";
                    string sql = "update tb_wenjian set 报告类型='日报',提交时间='" + shijian1 + "',员工备注='" + txtnerirong.Text + "',文件类型='doc',部门='" + bumen + "',日期='" + riqi + "' ,报告标题='" + biaoti + "',接收人='" + txtjieshouren.Text + "',编号='" + bianhao + "'  where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";

                    int g = SQLhelp.innn(sql, CommandType.Text);


                    if (txtwenjianlujing.Text != "")
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

        
        private void txtjieshouren_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox1.SelectedItem = listBox1.Items[0];
                }
                else
                {
                    if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i =txtjieshouren.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString() + ";";//把选中的值给文本框
                    txtjieshouren.Text = chongxin;
                    this.txtjieshouren.SelectionStart = this.txtjieshouren.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtjieshouren.Text.Substring(0, i + 1);

                    txtjieshouren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtjieshouren.SelectionStart = this.txtjieshouren.TextLength;
                    listBox1.Visible = false;//隐藏这个控件
                }
            }
        }

        private void txtjieshouren_TextChanged_1(object sender, EventArgs e)
        {
            if (!txtjieshouren.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtjieshouren.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtjieshouren.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox1.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox1.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("用户名 like'%" + txtjieshouren.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (newdt.Rows.Count > 0 && (txtjieshouren.Text != ""))
                {
                    listBox1.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox1.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

                }

            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtjieshouren.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString() + ";";//把选中的值给文本框
                txtjieshouren.Text = chongxin;
                this.txtjieshouren.SelectionStart = this.txtjieshouren.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtjieshouren.Text.Substring(0, i + 1);

                txtjieshouren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                this.txtjieshouren.SelectionStart = this.txtjieshouren.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
        }

      

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        

        private void gridView6_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView3_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView3.DeleteRow(gridView3.FocusedRowHandle);
            }
        }

        private void gridView6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView6.DeleteRow(gridView6.FocusedRowHandle);
            }
        }

        private void gridView5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView5.DeleteRow(gridView5.FocusedRowHandle);
            }
        }
    }
}