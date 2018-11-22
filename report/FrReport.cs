using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using DevComponents.DotNetBar.SuperGrid;
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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ztoffice.report;

namespace ztoffice
{
    public partial class FrReport : DevExpress.XtraEditors.XtraForm
    {
        //Office2007Form
        public FrReport()
        {
            //this.EnableGlass = false;//关键,
            InitializeComponent();
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Blue);



        }
        public string yonghu;
        public string lujing;
        public string leixing;

        private void FrReport_Load(object sender, EventArgs e)
        {
            //string sql = "select 编号,员工姓名,报告类型,提交时间,员工备注,批复,报告标题,附件名称 from tb_wenjian where 员工姓名='" + yonghu + "'";
            //DataTable baobiao = SQLhelp.GetDataTable(sql, CommandType.Text);
            //gridControl1.DataSource = baobiao;


            Reload();
            Reload1();


        }

        //public void Reload()
        //{
        //    string sql = "select 编号,员工姓名,报告类型,提交时间,员工备注,批复,报告标题,附件名称 from tb_wenjian where 员工姓名='" + yonghu + "'";
        //    DataTable baobiao = SQLhelp.GetDataTable(sql, CommandType.Text);
        //    gridControl1.DataSource = baobiao;
        //}
        public void Reload()
        {
            DateTime dangqian = DateTime.Now;
            DateTime bangeyue = dangqian.AddDays(-7);
            string sql = "select 员工姓名,报告类型,提交时间,员工备注,附件名称,批复,报告标题,编号,接收人 from tb_wenjian  where  提交时间>'" + bangeyue + "' order by 提交时间 desc ";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "员工姓名";
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn.ColumnName = "报告类型";


            DataColumn taxColumn1 = new DataColumn();
            taxColumn1.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn1.ColumnName = "提交时间";


            DataColumn taxColumn2 = new DataColumn();
            taxColumn2.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn2.ColumnName = "员工备注";


            DataColumn taxColumn3 = new DataColumn();
            taxColumn3.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn3.ColumnName = "批复";

            DataColumn taxColumn4 = new DataColumn();
            taxColumn4.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn4.ColumnName = "报告标题";



            DataColumn taxColumn5 = new DataColumn();
            taxColumn5.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn5.ColumnName = "编号";

            DataColumn taxColumn6 = new DataColumn();
            taxColumn6.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn6.ColumnName = "附件名称";



            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(taxColumn1);
            table.Columns.Add(taxColumn2);
            table.Columns.Add(taxColumn3);
            table.Columns.Add(taxColumn4);
            table.Columns.Add(taxColumn5);
            table.Columns.Add(taxColumn6);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = dt.Rows[i]["接收人"].ToString();
                //正则表达式

                Match m;

                Regex r = new Regex(yonghu);

                m = r.Match(str);
                string panduan = m.ToString();

                if (panduan != "")
                {
                    DataRow dr = table.NewRow();

                    dr["员工姓名"] = dt.Rows[i]["员工姓名"].ToString();

                    dr["报告类型"] = dt.Rows[i]["报告类型"].ToString();
                    dr["提交时间"] = dt.Rows[i]["提交时间"].ToString();
                    dr["员工备注"] = dt.Rows[i]["员工备注"].ToString();
                    dr["批复"] = dt.Rows[i]["批复"].ToString();
                    dr["报告标题"] = dt.Rows[i]["报告标题"].ToString();
                    dr["编号"] = dt.Rows[i]["编号"].ToString();
                    dr["附件名称"] = dt.Rows[i]["附件名称"].ToString();
                    table.Rows.Add(dr);
                }
            }
            //个人的绑定
            gridControl1.DataSource = table;
        }

        public void Reload1()
        {
            if (yonghu == "桑甜" || yonghu == "聂燕" || yonghu == "庄卫星" || yonghu == "赵蕾蕾")
            {
                DateTime dangqian = DateTime.Now;
                DateTime bangeyue = dangqian.AddDays(-7);
                string sql = "select 员工姓名,报告类型,提交时间,员工备注,附件名称,批复,报告标题,编号,接收人 from tb_wenjian  where  提交时间>'" + bangeyue + "' order by 提交时间 desc ";

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                DataTable table = new DataTable();

                //创建table的第一列
                DataColumn priceColumn = new DataColumn();
                //该列的数据类型
                priceColumn.DataType = System.Type.GetType("System.String");
                //该列得名称
                priceColumn.ColumnName = "员工姓名";
                DataColumn taxColumn = new DataColumn();
                taxColumn.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn.ColumnName = "报告类型";


                DataColumn taxColumn1 = new DataColumn();
                taxColumn1.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn1.ColumnName = "提交时间";


                DataColumn taxColumn2 = new DataColumn();
                taxColumn2.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn2.ColumnName = "员工备注";


                DataColumn taxColumn3 = new DataColumn();
                taxColumn3.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn3.ColumnName = "批复";

                DataColumn taxColumn4 = new DataColumn();
                taxColumn4.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn4.ColumnName = "报告标题";



                DataColumn taxColumn5 = new DataColumn();
                taxColumn5.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn5.ColumnName = "编号";

                DataColumn taxColumn6 = new DataColumn();
                taxColumn6.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn6.ColumnName = "附件名称";



                table.Columns.Add(priceColumn);
                table.Columns.Add(taxColumn);
                table.Columns.Add(taxColumn1);
                table.Columns.Add(taxColumn2);
                table.Columns.Add(taxColumn3);
                table.Columns.Add(taxColumn4);
                table.Columns.Add(taxColumn5);
                table.Columns.Add(taxColumn6);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string str = dt.Rows[i]["接收人"].ToString();
                    ////正则表达式

                    //Match m;

                    //Regex r = new Regex(yonghu);

                    //m = r.Match(str);
                    //string panduan = m.ToString();

                    //if (panduan != "")
                    //{
                        DataRow dr = table.NewRow();

                        dr["员工姓名"] = dt.Rows[i]["员工姓名"].ToString();

                        dr["报告类型"] = dt.Rows[i]["报告类型"].ToString();
                        dr["提交时间"] = dt.Rows[i]["提交时间"].ToString();
                        dr["员工备注"] = dt.Rows[i]["员工备注"].ToString();
                        dr["批复"] = dt.Rows[i]["批复"].ToString();
                        dr["报告标题"] = dt.Rows[i]["报告标题"].ToString();
                        dr["编号"] = dt.Rows[i]["编号"].ToString();
                        dr["附件名称"] = dt.Rows[i]["附件名称"].ToString();
                        table.Rows.Add(dr);
                    //}
                }
                //个人的绑定
                gridControl2.DataSource = table;
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 权限管理 from tb_operator where 用户名='" + yonghu + "'";
            if (Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text)) == 0)
            {
                MessageBox.Show("无权限！");
                return;
            }
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrDetails form1 = new FrDetails();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 下载该报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FolderBrowserDialog lujingg = new FolderBrowserDialog();

            if (lujingg.ShowDialog() == DialogResult.OK)

            {
                string xuanzelujing = lujingg.SelectedPath;
                string yonghu = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();
                string baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();
                string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
                string jingque = shijian.Substring(0, 10);
                try
                {
                    byte[] mypdffile = null;
                    string ConStr = "Select 文件,员工姓名,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";



                    mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                    string dt1 = "Select 员工姓名 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    string mingcheng = SQLhelp.ExecuteScalar(dt1, CommandType.Text).ToString();

                    string dt2 = "Select 日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    string shijian1 = SQLhelp.ExecuteScalar(dt2, CommandType.Text).ToString();

                    string lujing = xuanzelujing + "\\" + mingcheng + shijian1 + baogaoleixing + ".doc";
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();


                    MessageBox.Show("下载成功");//显示异常信息
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//显示异常信息
                }
            }


        }

        private void 点评ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrReply form1 = new FrReply();
            form1.yonghu = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();

            string yonghu = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();
            form1.baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();
            string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
            form1.shijian = shijian;
            form1.ShowDialog();
        }

        
       

        private void chaxun_Click(object sender, EventArgs e)
        {
            string chaxun = toolchaxun.Text;
            string sql = " SELECT  员工姓名,报告类型,提交时间,员工备注,批复,报告标题,编号,接收人 from tb_wenjian where 员工姓名 = '" + chaxun + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);



            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "员工姓名";
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn.ColumnName = "报告类型";


            DataColumn taxColumn1 = new DataColumn();
            taxColumn1.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn1.ColumnName = "提交时间";


            DataColumn taxColumn2 = new DataColumn();
            taxColumn2.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn2.ColumnName = "员工备注";


            DataColumn taxColumn3 = new DataColumn();
            taxColumn3.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn3.ColumnName = "批复";

            DataColumn taxColumn4 = new DataColumn();
            taxColumn4.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn4.ColumnName = "报告标题";



            DataColumn taxColumn5 = new DataColumn();
            taxColumn5.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn5.ColumnName = "编号";



            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(taxColumn1);
            table.Columns.Add(taxColumn2);
            table.Columns.Add(taxColumn3);
            table.Columns.Add(taxColumn4);
            table.Columns.Add(taxColumn5);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = dt.Rows[i]["接收人"].ToString();
                //正则表达式

                Match m;

                Regex r = new Regex(yonghu);

                m = r.Match(str);
                string panduan = m.ToString();

                if (panduan != "")
                {
                    DataRow dr = table.NewRow();

                    dr["员工姓名"] = dt.Rows[i]["员工姓名"].ToString();

                    dr["报告类型"] = dt.Rows[i]["报告类型"].ToString();
                    dr["提交时间"] = dt.Rows[i]["提交时间"].ToString();
                    dr["员工备注"] = dt.Rows[i]["员工备注"].ToString();
                    dr["批复"] = dt.Rows[i]["批复"].ToString();
                    dr["报告标题"] = dt.Rows[i]["报告标题"].ToString();
                    dr["编号"] = dt.Rows[i]["编号"].ToString();

                    table.Rows.Add(dr);

                }



            }

            //个人的绑定
            gridControl1.DataSource = table;


        }



        



        

        private void 下载此页面所有文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
           
            FolderBrowserDialog lujingg = new FolderBrowserDialog();
            if (lujingg.ShowDialog() == DialogResult.OK)
            {
                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < gridView1.RowCount; i++)
                {

                    string yonghu = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();
                    string baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();
                    string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
                    string jingque = shijian.Substring(0, 10);

                    string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();

                    try
                    {

                        byte[] mypdffile = null;
                        string ConStr = "Select 文件,员工姓名,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";

                        mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                        string sql11 = "Select 员工姓名 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                        string mingcheng = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();
                        string sql111 = "Select 日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                        string shijian1 = SQLhelp.ExecuteScalar(sql111, CommandType.Text).ToString();
                        string lujing = xuanzelujing + "\\" + mingcheng + shijian1 + baogaoleixing + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//显示异常信息
                    }

                }
                MessageBox.Show("下载成功");//显示异常信息

            }
        }

        private void xianshi_Click(object sender, EventArgs e)
        {
            string sql = "select 员工姓名,报告类型,提交时间,员工备注,批复,报告标题,编号,接收人 from tb_wenjian   order by 提交时间 desc ";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "员工姓名";
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn.ColumnName = "报告类型";


            DataColumn taxColumn1 = new DataColumn();
            taxColumn1.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn1.ColumnName = "提交时间";


            DataColumn taxColumn2 = new DataColumn();
            taxColumn2.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn2.ColumnName = "员工备注";


            DataColumn taxColumn3 = new DataColumn();
            taxColumn3.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn3.ColumnName = "批复";

            DataColumn taxColumn4 = new DataColumn();
            taxColumn4.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn4.ColumnName = "报告标题";



            DataColumn taxColumn5 = new DataColumn();
            taxColumn5.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn5.ColumnName = "编号";



            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(taxColumn1);
            table.Columns.Add(taxColumn2);
            table.Columns.Add(taxColumn3);
            table.Columns.Add(taxColumn4);
            table.Columns.Add(taxColumn5);






            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = dt.Rows[i]["接收人"].ToString();
                //正则表达式

                Match m;

                Regex r = new Regex(yonghu);

                m = r.Match(str);
                string panduan = m.ToString();

                if (panduan != "")
                {
                    DataRow dr = table.NewRow();

                    dr["员工姓名"] = dt.Rows[i]["员工姓名"].ToString();

                    dr["报告类型"] = dt.Rows[i]["报告类型"].ToString();
                    dr["提交时间"] = dt.Rows[i]["提交时间"].ToString();
                    dr["员工备注"] = dt.Rows[i]["员工备注"].ToString();
                    dr["批复"] = dt.Rows[i]["批复"].ToString();
                    dr["报告标题"] = dt.Rows[i]["报告标题"].ToString();
                    dr["编号"] = dt.Rows[i]["编号"].ToString();

                    table.Rows.Add(dr);

                }

            }

            //个人的绑定
            gridControl1.DataSource = table;
        }        
        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();

            if (shijian != "")
            {
                string a = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称").ToString();
                if (a != "")
                {
                    string b = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();
                    string baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();

                    string chaxun11 = "select 附件类型 from tb_wenjian where 员工姓名='" + b + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    string leixing1 = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();
                    byte[] mypdffile = null;

                    string sql = "Select 附件 From tb_wenjian Where 附件名称='" + a + "' and  提交时间='" + shijian + "'and  员工姓名='" + b + "' ";

                    mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                    this.Cursor = Cursors.WaitCursor;

                    string aaaa = System.Environment.CurrentDirectory;
                    string lujing = aaaa + "\\" + a + "1" + "." + leixing1;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    this.Cursor = Cursors.Default;
                    System.Diagnostics.Process.Start(lujing);
                }
                if (a == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }
            }
        }
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                if (gridView1.RowCount <= 0)//判断是否选中要删除的行
                {
                    MessageBox.Show("请选中行！");
                    return;
                }
                string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "提交时间").ToString();
                if (shijian != "")
                {
                    string a = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告标题").ToString();
                    string b = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "员工姓名").ToString();
                    string baogaoleixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报告类型").ToString();
                    string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + b + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();
                    byte[] mypdffile = null;
                    string sql = "Select 文件 From tb_wenjian Where 报告标题='" + a + "' and  提交时间='" + shijian + "'and  员工姓名='" + b + "' ";
                    mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                    this.Cursor = Cursors.WaitCursor;
                    string aaaa = System.Environment.CurrentDirectory;
                    string lujing = aaaa + "\\" + a + "1" + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    this.Cursor = Cursors.Default;
                    Frchakanbaogao form1 = new Frchakanbaogao();
                    form1.lujing = lujing;
                    form1.Show();
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (yonghu == "桑甜" || yonghu == "聂燕" || yonghu == "庄卫星" || yonghu == "赵蕾蕾")
            {
                string sql = "select 员工姓名,报告类型,提交时间,员工备注,批复,报告标题,编号,接收人 from tb_wenjian   order by 提交时间 desc ";

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                DataTable table = new DataTable();

                //创建table的第一列
                DataColumn priceColumn = new DataColumn();
                //该列的数据类型
                priceColumn.DataType = System.Type.GetType("System.String");
                //该列得名称
                priceColumn.ColumnName = "员工姓名";
                DataColumn taxColumn = new DataColumn();
                taxColumn.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn.ColumnName = "报告类型";


                DataColumn taxColumn1 = new DataColumn();
                taxColumn1.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn1.ColumnName = "提交时间";


                DataColumn taxColumn2 = new DataColumn();
                taxColumn2.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn2.ColumnName = "员工备注";


                DataColumn taxColumn3 = new DataColumn();
                taxColumn3.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn3.ColumnName = "批复";

                DataColumn taxColumn4 = new DataColumn();
                taxColumn4.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn4.ColumnName = "报告标题";



                DataColumn taxColumn5 = new DataColumn();
                taxColumn5.DataType = System.Type.GetType("System.String");
                //列名
                taxColumn5.ColumnName = "编号";



                table.Columns.Add(priceColumn);
                table.Columns.Add(taxColumn);
                table.Columns.Add(taxColumn1);
                table.Columns.Add(taxColumn2);
                table.Columns.Add(taxColumn3);
                table.Columns.Add(taxColumn4);
                table.Columns.Add(taxColumn5);






                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string str = dt.Rows[i]["接收人"].ToString();
                    //正则表达式

                    Match m;

                    Regex r = new Regex(yonghu);

                    m = r.Match(str);
                    string panduan = m.ToString();

                    if (panduan != "")
                    {
                        DataRow dr = table.NewRow();

                        dr["员工姓名"] = dt.Rows[i]["员工姓名"].ToString();

                        dr["报告类型"] = dt.Rows[i]["报告类型"].ToString();
                        dr["提交时间"] = dt.Rows[i]["提交时间"].ToString();
                        dr["员工备注"] = dt.Rows[i]["员工备注"].ToString();
                        dr["批复"] = dt.Rows[i]["批复"].ToString();
                        dr["报告标题"] = dt.Rows[i]["报告标题"].ToString();
                        dr["编号"] = dt.Rows[i]["编号"].ToString();

                        table.Rows.Add(dr);

                    }

                }

                //个人的绑定
                gridControl2.DataSource = table;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string chaxun = toolchaxun.Text;
            string sql = " SELECT  员工姓名,报告类型,提交时间,员工备注,批复,报告标题,编号,接收人 from tb_wenjian where 员工姓名 = '" + TextBox1 + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);



            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "员工姓名";
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn.ColumnName = "报告类型";


            DataColumn taxColumn1 = new DataColumn();
            taxColumn1.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn1.ColumnName = "提交时间";


            DataColumn taxColumn2 = new DataColumn();
            taxColumn2.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn2.ColumnName = "员工备注";


            DataColumn taxColumn3 = new DataColumn();
            taxColumn3.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn3.ColumnName = "批复";

            DataColumn taxColumn4 = new DataColumn();
            taxColumn4.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn4.ColumnName = "报告标题";



            DataColumn taxColumn5 = new DataColumn();
            taxColumn5.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn5.ColumnName = "编号";



            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(taxColumn1);
            table.Columns.Add(taxColumn2);
            table.Columns.Add(taxColumn3);
            table.Columns.Add(taxColumn4);
            table.Columns.Add(taxColumn5);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //string str = dt.Rows[i]["接收人"].ToString();
                ////正则表达式

                //Match m;

                //Regex r = new Regex(yonghu);

                //m = r.Match(str);
                //string panduan = m.ToString();

                //if (panduan != "")
                //{
                    DataRow dr = table.NewRow();

                    dr["员工姓名"] = dt.Rows[i]["员工姓名"].ToString();

                    dr["报告类型"] = dt.Rows[i]["报告类型"].ToString();
                    dr["提交时间"] = dt.Rows[i]["提交时间"].ToString();
                    dr["员工备注"] = dt.Rows[i]["员工备注"].ToString();
                    dr["批复"] = dt.Rows[i]["批复"].ToString();
                    dr["报告标题"] = dt.Rows[i]["报告标题"].ToString();
                    dr["编号"] = dt.Rows[i]["编号"].ToString();

                    table.Rows.Add(dr);

                //}



            }

            //个人的绑定
            gridControl2.DataSource = table;
        }

        private void 查看toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "提交时间").ToString();

            if (shijian != "")
            {
                string a = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "附件名称").ToString();
                if (a != "")
                {
                    string b = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "员工姓名").ToString();
                    string baogaoleixing = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "报告类型").ToString();

                    string chaxun11 = "select 附件类型 from tb_wenjian where 员工姓名='" + b + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    string leixing1 = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();
                    byte[] mypdffile = null;

                    string sql = "Select 附件 From tb_wenjian Where 附件名称='" + a + "' and  提交时间='" + shijian + "'and  员工姓名='" + b + "' ";

                    mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                    this.Cursor = Cursors.WaitCursor;

                    string aaaa = System.Environment.CurrentDirectory;
                    string lujing = aaaa + "\\" + a + "1" + "." + leixing1;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    this.Cursor = Cursors.Default;
                    System.Diagnostics.Process.Start(lujing);
                }
                if (a == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }
            }
        }

        private void 回复toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrReply form1 = new FrReply();
            form1.yonghu = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "员工姓名").ToString();

            string yonghu = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "员工姓名").ToString();
            form1.baogaoleixing = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "报告类型").ToString();
            string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "提交时间").ToString();
            form1.shijian = shijian;
            form1.ShowDialog();
        }

        private void 一键下载toolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 权限管理 from tb_operator where 用户名='" + yonghu + "'";
            if (Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text)) == 0)
            {
                MessageBox.Show("无权限！");
                return;
            }
            if (gridView2.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrDetails form1 = new FrDetails();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void 下载toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FolderBrowserDialog lujingg = new FolderBrowserDialog();

            if (lujingg.ShowDialog() == DialogResult.OK)

            {
                string xuanzelujing = lujingg.SelectedPath;
                string yonghu = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "员工姓名").ToString();
                string baogaoleixing = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "报告类型").ToString();
                string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "提交时间").ToString();
                string jingque = shijian.Substring(0, 10);
                try
                {
                    byte[] mypdffile = null;
                    string ConStr = "Select 文件,员工姓名,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";



                    mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                    string dt1 = "Select 员工姓名 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    string mingcheng = SQLhelp.ExecuteScalar(dt1, CommandType.Text).ToString();

                    string dt2 = "Select 日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    string shijian1 = SQLhelp.ExecuteScalar(dt2, CommandType.Text).ToString();

                    string lujing = xuanzelujing + "\\" + mingcheng + shijian1 + baogaoleixing + ".doc";
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();


                    MessageBox.Show("下载成功");//显示异常信息
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//显示异常信息
                }
            }

        }

        private void 下载所有toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }

            FolderBrowserDialog lujingg = new FolderBrowserDialog();
            if (lujingg.ShowDialog() == DialogResult.OK)
            {
                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < gridView2.RowCount; i++)
                {

                    string yonghu = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "员工姓名").ToString();
                    string baogaoleixing = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "报告类型").ToString();
                    string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "提交时间").ToString();
                    string jingque = shijian.Substring(0, 10);

                    string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();

                    try
                    {

                        byte[] mypdffile = null;
                        string ConStr = "Select 文件,员工姓名,日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";

                        mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                        string sql11 = "Select 员工姓名 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                        string mingcheng = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();
                        string sql111 = "Select 日期 From tb_wenjian Where 员工姓名='" + yonghu + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                        string shijian1 = SQLhelp.ExecuteScalar(sql111, CommandType.Text).ToString();
                        string lujing = xuanzelujing + "\\" + mingcheng + shijian1 + baogaoleixing + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//显示异常信息
                    }

                }
                MessageBox.Show("下载成功");//显示异常信息

            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                if (gridView2.RowCount <= 0)//判断是否选中要删除的行
                {
                    MessageBox.Show("请选中行！");
                    return;
                }
                string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "提交时间").ToString();
                if (shijian != "")
                {
                    string a = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "报告标题").ToString();
                    string b = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "员工姓名").ToString();
                    string baogaoleixing = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "报告类型").ToString();
                    string chaxun11 = "select 文件类型 from tb_wenjian where 员工姓名='" + b + "'and 提交时间='" + shijian + "' and 报告类型='" + baogaoleixing + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();
                    byte[] mypdffile = null;
                    string sql = "Select 文件 From tb_wenjian Where 报告标题='" + a + "' and  提交时间='" + shijian + "'and  员工姓名='" + b + "' ";
                    mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                    this.Cursor = Cursors.WaitCursor;
                    string aaaa = System.Environment.CurrentDirectory;
                    string lujing = aaaa + "\\" + a + "1" + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    this.Cursor = Cursors.Default;
                    Frchakanbaogao form1 = new Frchakanbaogao();
                    form1.lujing = lujing;
                    form1.Show();
                }
            }
        }
    }
}
