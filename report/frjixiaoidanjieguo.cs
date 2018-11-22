using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.report
{
    public partial class frjixiaoidanjieguo : DevExpress.XtraEditors.XtraForm
    {
        public frjixiaoidanjieguo()
        {
            
            InitializeComponent();
        }
        public DataTable dt;
        public string biaoji;
        public string kaishishijian;
        public string jieshushijian;

        private void frjixiaoidanjieguo_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;


            //按钮所在列为第五列，列下标从0开始的  

            if (CIndex == 3)
            {
               if(biaoji=="0")
                {
                    string xingming = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "姓名").ToString();

                    Frxiangqing1 form1 = new Frxiangqing1();
                    form1.yonghu = xingming;
                    form1.kashi = kaishishijian;
                    form1.jieshu = jieshushijian;
                    form1.biaoji = "0";
                    form1.ShowDialog();   

                }

                if (biaoji == "1")
                {
                    string xingming = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "姓名").ToString();

                    Frxiangqing1 form1 = new Frxiangqing1();
                    form1.yonghu = xingming;
                   
                    form1.biaoji = "1";
                    form1.ShowDialog();

                    
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

        

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            


            //按钮所在列为第五列，列下标从0开始的  

            
                if (biaoji == "0")
                {
                    string xingming = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "姓名").ToString();

                    Frxiangqing1 form1 = new Frxiangqing1();
                    form1.yonghu = xingming;
                    form1.kashi = kaishishijian;
                    form1.jieshu = jieshushijian;
                    form1.biaoji = "0";
                    form1.ShowDialog();

                }

                if (biaoji == "1")
                {
                    string xingming = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "姓名").ToString();

                    Frxiangqing1 form1 = new Frxiangqing1();
                    form1.yonghu = xingming;

                    form1.biaoji = "1";
                    form1.ShowDialog();


                }


            }
        
    }
}
