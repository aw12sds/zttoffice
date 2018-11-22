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
using ztoffice.dianjian;

namespace ztoffice.shixiang
{
    public partial class FrChakan : DevExpress.XtraEditors.XtraForm
    {
        public FrChakan()
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
        private void FrChakan_Load(object sender, EventArgs e)
        {
            Reload(); 
        }
        
        public void Reload()
        {
            string strsql1 = "select id,创建时间,会议时间,纪要内容,落实措施,落实情况,纪要上传人,附件格式,附件名称,批复,完成责任人 from tb_zhishixiang  where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' ";        
            gridControl1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            gridView1.Columns["附件格式"].Visible = false;
            gridView1.Columns["完成责任人"].Visible = false;
            gridView1.Columns["id"].Visible = false;

        }


        private void 创建新回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrFenkaipifu form = new FrFenkaipifu();
            form.shijian = shijian;
            form.jiyaoneirong = jiyaoneirong;
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = jiyaoshangchuanren;
            form.zerenren = zerenren;
            form.zhonglei = "2";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
          
        }

        private void 回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人"));

            string neirong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容"));

            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "会议时间"));

            string jiyaoshangchuanren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人"));


            string chuangjianshijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "创建时间"));


            FrFenkaipifu form = new FrFenkaipifu();
            form.shijian = shijian;
            form.jiyaoneirong = jiyaoneirong;
            form.chuangjianshijian = chuangjianshijian;
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = jiyaoshangchuanren;
            form.zerenren = zerenren;
            form.zhonglei = "1";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

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

                string chuangjianshijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "创建时间"));

                string wanchengzerenren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人"));
                string id= Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "Select 附件 From tb_zhishixiang  Where id='" + id + "' ";
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
