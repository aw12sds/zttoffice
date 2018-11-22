using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztoffice.物流部
{
    public partial class Frfapiaoliuzhuanbiao : DevExpress.XtraEditors.XtraForm
    {
        public Frfapiaoliuzhuanbiao()
        {
            InitializeComponent();
        }

        private void Frfapiaoliuzhuanbiao_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql = "select id,提交人,收到发票日期,供方名称,发票编号,发票日期,发票金额,合同号,采购员,审核确认,审核人,审核时间 from tb_fapiaodengjibiao";
            gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);
        
    }
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 导出报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView4.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl4.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void 撤回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {
                string shenhe= gridView4.GetRowCellValue(i, "审核确认").ToString();

                if(shenhe=="1")
                {
                    MessageBox.Show("已经确认，无法删除！");
                    return;
                }
            }
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                string hetonghao= gridView4.GetRowCellValue(i, "合同号").ToString();
                string fapiaohao = gridView4.GetRowCellValue(i, "发票编号").ToString() +";" ;
                string fapiaoriqi = gridView4.GetRowCellValue(i, "发票日期").ToString() + ";";
                string fapiaojine = gridView4.GetRowCellValue(i, "发票金额").ToString() + ";";
                string kaijvriqi = gridView4.GetRowCellValue(i, "收到发票日期").ToString() + ";";
                string sql = "select * from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
                DataTable dt = SQLhelp1.GetDataTable(sql, CommandType.Text);
                string fapiaobianhao = dt.Rows[0]["发票编号"].ToString();
                string zuizhongfapiaohao = fapiaobianhao.Replace(fapiaohao, "");
                string fapiaoriqi1 = dt.Rows[0]["发票开具日期"].ToString();
                string zuifapiaoriqi1 = fapiaoriqi1.Replace(fapiaoriqi, "");
                string fapiaojine11 = dt.Rows[0]["发票金额"].ToString();                
                string zuizhongfapiaojine = fapiaojine11.Replace(fapiaojine, "");

                string kaijvriqi11 = dt.Rows[0]["发票收到日期"].ToString();
                string zuizhongkaijvriqi = kaijvriqi11.Replace(kaijvriqi, "");
                string sql1 = "update tb_caigoutaizhang set 发票编号='" + zuizhongfapiaohao + "',发票收到日期='" + zuizhongkaijvriqi + "',发票金额='" + zuizhongfapiaojine + "',发票开具日期='" + zuifapiaoriqi1 + "',发票状态=NULL  where 合同号='" + hetonghao + "'";
                SQLhelp1.ExecuteScalar(sql1, CommandType.Text);

                string sql12 = "delete from tb_fapiaodengjibiao where id='"+ id + "'";
                SQLhelp1.ExecuteScalar(sql12, CommandType.Text);

            }
            MessageBox.Show("撤回成功！");
            Reload();
            this.DialogResult = DialogResult.OK;
        }

        private void 合并发票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("提交人");
            dt.Columns.Add("收到发票日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("发票编号");
            dt.Columns.Add("发票日期");
            dt.Columns.Add("发票金额");
            dt.Columns.Add("合同号");
            dt.Columns.Add("采购员");

            dt1.Columns.Add("id");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("收到发票日期");
            dt1.Columns.Add("供方名称");
            dt1.Columns.Add("发票编号");
            dt1.Columns.Add("发票日期");
            dt1.Columns.Add("发票金额");
            dt1.Columns.Add("合同号");
            dt1.Columns.Add("采购员");

            string fapiao= Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "发票编号"));
            
            string sql = "select 提交人,收到发票日期,供方名称,发票编号,发票日期,发票金额,合同号,采购员 from tb_caigoutaizhang where 发票编号='"+fapiao+"'";
            dt = SQLhelp.GetDataTablexiangmuguanli(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);
            double jine = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jine += Convert.ToDouble(dt.Rows[i] ["发票金额"]);
            }
            string hetonghao = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hetonghao += dt.Rows[i]["合同号"].ToString() + ";";
            }
            string caigouyuan = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                caigouyuan += dt.Rows[i]["采购员"].ToString() + ";";
            }
        }
    }
}