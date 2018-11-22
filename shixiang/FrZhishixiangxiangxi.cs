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

namespace ztoffice.shixiang
{
    public partial class FrZhishixiangxiangxi : DevExpress.XtraEditors.XtraForm
    {
        public FrZhishixiangxiangxi()
        {          
            InitializeComponent();
        }
        public string shijian;
        public string zerenren;
        public string jiyaoneirong;
        public string yonghu;
        public string jiyaoshangchuanren;       
        public string lujing;
        public string leixing;
        private void FrZhishixiangxiangxi_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string strsql1 = "select id,创建时间,会议时间,纪要内容,落实措施,落实情况,纪要上传人,附件格式,附件名称,批复,完成责任人 from tb_zhishixiang  where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);

            gridView1.Columns["纪要上传人"].Visible = false;
            gridView1.Columns["附件格式"].Visible = false;
            gridView1.Columns["完成责任人"].Visible = false;
            gridView1.Columns["id"].Visible = false;
        }

        private void 落实改善ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(zerenren!=yonghu)
            {
                MessageBox.Show("非该用户无法继续编辑！");
                return;                
            }           
            FrZhishixiangluoshi form = new FrZhishixiangluoshi();
            form.shijian = shijian;
            form.jiyaoneirong = jiyaoneirong;
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = jiyaoshangchuanren;
            form.zerenren = zerenren;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }


            string fujiangeshi = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件格式"));

            if (fujiangeshi == "")
            {
                MessageBox.Show("没有附件！");
                return;

            }

            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string fujianmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称"));
            string chuangjianshijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "创建时间"));
            string wanchengzerenren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人"));

            string sql = "Select 附件 From tb_zhishixiang  Where id='"+id+"' ";

            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);
            
            string aaaa = System.Environment.CurrentDirectory;
            string lujing = aaaa + "\\" + fujianmingcheng + "." + fujiangeshi;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            System.Diagnostics.Process.Start(lujing);

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void 导出报表ToolStripMenuItem_Click(object sender, EventArgs e)
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
}
