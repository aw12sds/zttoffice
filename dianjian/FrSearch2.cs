using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ztoffice.dianjian
{
    public partial class FrSearch2 : DevExpress.XtraEditors.XtraForm
    {
        public FrSearch2()
        {
            
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

            gridControl2.DataSource = table;


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

            gridControl3.DataSource = table2;


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

            gridControl4.DataSource = table3;


            if (yonghu != "桑甜" && yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "赵蕾蕾" && yonghu != "徐魏魏" && yonghu != "蔡红兵" && yonghu != "钱陆亦")
            {
                string sql4 = "select id,会议时间,会议主题,纪要内容,完成责任人,落实措施,完成时间,落实情况,考核绩效点,完成时间节点 from tb_xiangxi where 纪要类型!='指示项' and 已完成=1 and 完成责任人='" + yonghu + "'";

                gridControl5.DataSource = SQLhelp.GetDataTable(sql4, CommandType.Text);
            }
            else
            {
                string sql4 = "select id,会议时间,会议主题,纪要内容,完成责任人,落实措施,完成时间,落实情况,考核绩效点,完成时间节点 from tb_xiangxi where 纪要类型!='指示项' and 已完成=1";

                gridControl5.DataSource = SQLhelp.GetDataTable(sql4, CommandType.Text);


            }

            string sql1 = "select id,会议时间,纪要内容,完成责任人,落实措施,完成时间,落实情况,已完成,完成时间节点,考核绩效点,更新,纪要上传人,批复 from tb_xiangxi  where 已完成=0 and 主持人 is not null and 纪要上传人='"+yonghu+"'";
            DataTable dt11= SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt11;

            string wanchengshijian = DateTime.Now.ToString();
            DateTime zuizhong = DateTime.Now;

            for (int i = 0; i < dt11.Rows.Count; i++)
            {
                string jiedan = dt11.Rows[i]["完成时间节点"].ToString();
                string yiwancheng = dt11.Rows[i]["已完成"].ToString();
                if (yiwancheng != "1")
                {
                    if (jiedan != "")
                    {
                        DateTime kaishi = Convert.ToDateTime(dt11.Rows[i]["会议时间"]);
                        DateTime jieshu = Convert.ToDateTime(dt11.Rows[i]["完成时间节点"]);

                        string kaishi1 = Convert.ToDateTime(dt11.Rows[i]["会议时间"]).ToString("yyyy - MM - dd");

                        string jieshu1 = Convert.ToDateTime(dt11.Rows[i]["完成时间节点"]).ToString("yyyy - MM - dd");

                        string zerenren = dt11.Rows[i]["完成责任人"].ToString();
                        string neirong = dt11.Rows[i]["纪要内容"].ToString();
                        string shijian = dt11.Rows[i]["会议时间"].ToString();

                        if (jieshu1 != kaishi1)
                        {

                            if (zuizhong < jieshu)
                            {
                                string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                            if (zuizhong > jieshu)
                            {
                                TimeSpan shijianshu = zuizhong - jieshu;

                                int shuliang = Convert.ToInt32(shijianshu.TotalDays - 0.5);
                                int shuliang1 = (Convert.ToInt32((shuliang / 7)) + 1) * 2;

                                string xiugai = "update tb_xiangxi set  考核绩效点='" + shuliang1 + "' Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                        }
                        if (jieshu1 == kaishi1)
                        {
                            string xiugai = "update tb_xiangxi set 考核绩效点=0 Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                        }
                    }
                }
            }



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

        

        
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

            string sql = "select 附件名称 from tb_xiangxi where id='" + id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            string sql2 = "select 附件格式 from tb_xiangxi where id='" + id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
            byte[] mypdffile = null;
            string sql4 = "Select 附件 From tb_xiangxi Where id='" + id + "' ";
            mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
            this.Cursor = Cursors.WaitCursor;
            string aaaa = System.Environment.CurrentDirectory;
            string bbbb = mingcheng.Replace("?", "1");
            string lujing = aaaa + "\\" + bbbb + "1" + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }

        private void 确认完成情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }


            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string xiugai = "update tb_xiangxi set 已完成=1 Where id='" + id + "' ";
                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                MessageBox.Show("修改成功！");
                Reload();
            }
        }

        private void 保存时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string shiijandianjie = gridView1.GetRowCellValue(i, "完成时间节点").ToString();
                if (shiijandianjie != "")
                {
                    string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' where id= '" + id + "'";

                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }

            }
            MessageBox.Show("修改成功！");
            Reload();

        }

        private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

            string shangchuanren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人"));

            if (shangchuanren == yonghu)
            {
                string sql1 = "update tb_xiangxi set 更新='' where id='" + id+ "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                Frhuifuhuiyijiyao form = new Frhuifuhuiyijiyao();
                form.yonghu = yonghu;
                form.dingwei = id;
                form.ShowDialog();
                Reload();
            }

            if (shangchuanren != yonghu)
            {
                Frhuifuhuiyijiyao form = new Frhuifuhuiyijiyao();
                form.yonghu = yonghu;
                form.dingwei = id;
                form.ShowDialog();
            }

        }

        

        



        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView2.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrXiangqing form = new FrXiangqing();
            form.shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "会议时间").ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView3.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrXiangqing form = new FrXiangqing();
            form.shijian = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "会议时间").ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView4.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            FrXiangqing form = new FrXiangqing();
            form.shijian = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "会议时间").ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void 导出Excel表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView1.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl1.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void 查看附件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

            string sql = "select 附件名称 from tb_xiangxi where id='" + id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            string sql2 = "select 附件格式 from tb_xiangxi where id='" + id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
            byte[] mypdffile = null;
            string sql4 = "Select 附件 From tb_xiangxi Where id='" + id + "' ";
            mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
            this.Cursor = Cursors.WaitCursor;
            string aaaa = System.Environment.CurrentDirectory;
            string bbbb = mingcheng.Replace("?", "1");
            string lujing = aaaa + "\\" + bbbb + "1" + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }

        private void 查看详情ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

            string shangchuanren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人"));

            if (shangchuanren == yonghu)
            {
                string sql1 = "update tb_xiangxi set 更新='' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                Frhuifuhuiyijiyao form = new Frhuifuhuiyijiyao();
                form.yonghu = yonghu;
                form.dingwei = id;
                form.ShowDialog();
                Reload();
            }

            if (shangchuanren != yonghu)
            {
                Frhuifuhuiyijiyao form = new Frhuifuhuiyijiyao();
                form.yonghu = yonghu;
                form.dingwei = id;
                form.ShowDialog();
            }
        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }

            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string xiugai = "update tb_xiangxi set 已完成=1 Where id='" + id + "' ";
                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                MessageBox.Show("修改成功！");
                Reload();
                gridView1.TopRowIndex = topIndex;
            }
        }

        private void 导出Excel表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
        int topIndex = -1;
        private void gridView1_TopRowChanged(object sender, EventArgs e)
        {
            topIndex = gridView1.TopRowIndex;
        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        
    }
}
