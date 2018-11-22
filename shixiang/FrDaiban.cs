using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztoffice.shixiang;

namespace ztoffice
{
    public partial class FrDaiban : Office2007Form
    {
        public FrDaiban()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void FrDaiban_Load(object sender, EventArgs e)
        {
            Reload();
          
        }
        public void Reload()
        {
            string strsql1 = "select id,会议时间,会议主题,纪要内容,落实措施,完成时间,落实情况,已完成,完成时间节点,批复,指示项附件名称,纪要上传人,纪要类型,关联责任人,考核绩效点 from tb_xiangxi  where 完成责任人='" + yonghu + "'and 已完成=0";  
            gridControl1.DataSource= SQLhelp.GetDataTable(strsql1, CommandType.Text);
            gridView1.Columns["会议时间"].Caption = "创建时间";
            gridView1.Columns["会议主题"].Caption = "来源";
            gridView1.Columns["纪要上传人"].Visible = false;
            gridView1.Columns["纪要类型"].Visible = false;
            gridView1.Columns["id"].Visible = false;
            string strsql2 = "select id,会议时间,会议主题,纪要内容,落实措施,完成时间,落实情况,已完成,完成时间节点,批复,指示项附件名称,考核绩效点,纪要类型,完成责任人,纪要上传人 from tb_xiangxi  where 完成责任人='" + yonghu + "'and 已完成=1";       
            gridControl2.DataSource = SQLhelp.GetDataTable(strsql2, CommandType.Text);
            gridView2.Columns["会议时间"].Caption = "创建时间";
            gridView2.Columns["会议主题"].Caption = "来源";
            gridView2.Columns["纪要上传人"].Visible = false;
            gridView2.Columns["纪要类型"].Visible = false;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["完成责任人"].Visible = false;
            string strsql3 = "select id,会议时间,会议主题,纪要内容,落实措施,落实情况,完成时间,已完成,完成时间节点,批复,指示项附件名称,纪要上传人,纪要类型,关联责任人,完成责任人,更新,考核绩效点 from tb_xiangxi  where 关联责任人='" + yonghu + "'";        
            gridControl3.DataSource = SQLhelp.GetDataTable(strsql3, CommandType.Text);
            gridView3.Columns["会议时间"].Caption = "创建时间";
            gridView3.Columns["会议主题"].Caption = "来源";
            gridView3.Columns["纪要上传人"].Visible = false;
            gridView3.Columns["纪要类型"].Visible = false;
            gridView3.Columns["id"].Visible = false;
        }
    
        private void 设置完成时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成时间节点"));
            if (shijian != "")
            {
                MessageBox.Show("已经设定完成时间，无法修改！");
                return;

            }
            FrShedingshijian form = new FrShedingshijian();
            form.jiyaoneirong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容"));
            form.shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "会议时间"));
            form.zerenren = yonghu;
            form.jiyaoshangchuanren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人"));
            form.ShowDialog();
            if(form.DialogResult==DialogResult.OK)
            {
                Reload();              
            }
        }
        private void 分解指示项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrFenjiezhishixiang form = new FrFenjiezhishixiang();
            form.jiyaoneirong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容"));
            form.shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "会议时间"));
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人"));
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }
        
        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView3.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));

            try
            {
                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;
                string jiedian = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "完成时间节点"));
                if (jiedian == "")
                {
                    MessageBox.Show("请先让责任人输入完成时间节点，再确认完成");
                    return;

                }
                if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string xiugai = "update tb_xiangxi set 已完成=1,完成时间='" + wanchengshijian + "' Where id='" + id + "'";
                    SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                    MessageBox.Show("修改成功！");
                    Reload();
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show("发生错误：" + ex.Message);
            }

        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "指示项附件名称")) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "指示项附件名称")) != "")
            {
                string zerenren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容"));
                string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "会议时间"));
                string aa = "Select 指示项附件类型 From tb_xiangxi Where 纪要内容='" + zerenren + "' and 会议时间='" + shijian + "'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();
                string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "指示项附件名称"));
                byte[] mypdffile = null;
                string sql4 = "Select 指示项附件 From tb_xiangxi   Where 纪要内容='" + zerenren + "' and 会议时间='" + shijian + "'";
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
        }
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                int dingwei = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成时间节点"));
                if (shijian == "")
                {
                    MessageBox.Show("请先设定完成时间再提交指示项回复！");
                    return;

                }

                string leixing = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要类型"));

                if (leixing != "会议" && leixing != "集团会议" && leixing != "部门会议")
                {

                    FrZhishixiangxiangxi form = new FrZhishixiangxiangxi();
                    form.jiyaoneirong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容"));

                    form.shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "会议时间"));


                    form.zerenren = yonghu;
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人"));

                    form.ShowDialog();
                }

                if (leixing == "会议" || leixing == "集团会议" || leixing == "部门会议")
                {

                    Frhuiyixiangxi form = new Frhuiyixiangxi();
                    form.yonghu = yonghu;
                    form.dingwei = dingwei;
                    form.ShowDialog();


                }
            }


        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                int dingwei = Convert.ToInt32(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));

            string leixing = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要类型"));

            if (leixing != "会议")
            {

                FrZhishixiangxiangxi form = new FrZhishixiangxiangxi();
                form.jiyaoneirong = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要内容"));
                form.shijian = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "会议时间"));

                form.zerenren = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "完成责任人"));
                form.yonghu = yonghu;
                form.jiyaoshangchuanren = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要上传人"));
                form.ShowDialog();
            }

                if (leixing == "会议")
                {

                    Frhuiyixiangxi form = new Frhuiyixiangxi();
                    form.yonghu = yonghu;
                    form.dingwei = dingwei;
                    form.ShowDialog();

                }
            }
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                int dingwei = Convert.ToInt32(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));

                string leixing = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要类型"));

                if (leixing == "指示项" || leixing == "集团指示项" || leixing == "其他指示项")
                {

                    string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));

                    string sql12 = "update tb_xiangxi  set 更新 = '' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);

                    FrChakan form = new FrChakan();
                    form.jiyaoneirong = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要内容"));
                    form.shijian = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "会议时间"));
                    form.zerenren = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "完成责任人"));
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要上传人"));
                    form.ShowDialog();
                    Reload();

                }

                if (leixing == "会议")
                {
                    string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));

                    string sql12 = "update tb_xiangxi  set 更新 = '' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                    Reload();
                    Frhuiyixiangxi form = new Frhuiyixiangxi();
                    form.yonghu = yonghu;
                    form.dingwei = dingwei;
                    form.ShowDialog();
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

        private void 导出附件ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 导出附件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl2.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 导出附件ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl3.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
