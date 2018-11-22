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

namespace ztoffice.shixiang
{
    public partial class Frhuiyixiangxi : DevExpress.XtraEditors.XtraForm
    {
        public Frhuiyixiangxi()
        {
           
            InitializeComponent();
        }
        public string yonghu;
        public int dingwei;
        private void Frhuiyixiangxi_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql1 = "select id,创建时间,创建人,落实情况,落实措施,批复,附件名称,附件格式 from tb_huiyi  where 定位='" + dingwei + "'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["附件格式"].Visible = false;


        }
        
        private void 落实改善ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrShixiang form = new FrShixiang();
            form.id = dingwei;
            form.yonghu = yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

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
                string fujiangeshi = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件格式"));
                if (fujiangeshi == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }
                string fujianmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称"));
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "Select 附件 From tb_huiyi  Where id='" + id + "' ";
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
        }

        private void 导出表格ToolStripMenuItem_Click(object sender, EventArgs e)
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
