using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Aspose.Cells;

namespace ztoffice.renliziyuan
{
    public partial class Frkaoqinbiao : DevExpress.XtraEditors.XtraForm
    {
        public Frkaoqinbiao()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            int hangshu = Convert.ToInt32(txthangshu.Text);
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string b = dialog.FileName;
                Workbook book = new Workbook(b);
                Worksheet sheet = book.Worksheets["Sheet1"];
                dt = sheet.Cells.ExportDataTableAsString(0, 0, hangshu, 6);
                dt.Columns["Column1"].ColumnName = "1";
                dt.Columns["Column2"].ColumnName = "2";
                dt.Columns["Column3"].ColumnName = "3";
                dt.Columns["Column4"].ColumnName = "4";
                dt.Columns["Column5"].ColumnName = "5";
                dt.Columns["Column6"].ColumnName = "6";
                string sql = "delete from tb_kaoqin";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql1 = "insert into tb_kaoqin (时间,员工) values ('" + dt.Rows[i][1] + "','" + dt.Rows[i][5] + "')";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                }
            }
            DataTable dtt = new DataTable();
            List<string> list = new List<string>();
            DateTime a = Convert.ToDateTime( dateriqi.Text);
            string tianshu = a.Month.ToString();
            int days = DateTime.DaysInMonth(2018,Convert.ToInt32(tianshu));
            if (days == 31)
            {
                dtt.Columns.Add("姓名");
                dtt.Columns.Add("26");
                dtt.Columns.Add("27");
                dtt.Columns.Add("28");
                dtt.Columns.Add("29");
                dtt.Columns.Add("30");
                dtt.Columns.Add("31");
                dtt.Columns.Add("01");
                dtt.Columns.Add("02");
                dtt.Columns.Add("03");
                dtt.Columns.Add("04");
                dtt.Columns.Add("05");
                dtt.Columns.Add("06");
                dtt.Columns.Add("07");
                dtt.Columns.Add("08");
                dtt.Columns.Add("09");
                dtt.Columns.Add("10");
                dtt.Columns.Add("11");
                dtt.Columns.Add("12");
                dtt.Columns.Add("13");
                dtt.Columns.Add("14");
                dtt.Columns.Add("15");
                dtt.Columns.Add("16");
                dtt.Columns.Add("17");
                dtt.Columns.Add("18");
                dtt.Columns.Add("19");
                dtt.Columns.Add("20");
                dtt.Columns.Add("21");
                dtt.Columns.Add("22");
                dtt.Columns.Add("23");
                dtt.Columns.Add("24");
                dtt.Columns.Add("25");           
            }
            if (days == 30)
            {           
                dtt.Columns.Add("姓名");
                dtt.Columns.Add("26");
                dtt.Columns.Add("27");
                dtt.Columns.Add("28");
                dtt.Columns.Add("29");
                dtt.Columns.Add("30");              
                dtt.Columns.Add("01");
                dtt.Columns.Add("02");
                dtt.Columns.Add("03");
                dtt.Columns.Add("04");
                dtt.Columns.Add("05");
                dtt.Columns.Add("06");
                dtt.Columns.Add("07");
                dtt.Columns.Add("08");
                dtt.Columns.Add("09");
                dtt.Columns.Add("10");
                dtt.Columns.Add("11");
                dtt.Columns.Add("12");
                dtt.Columns.Add("13");
                dtt.Columns.Add("14");
                dtt.Columns.Add("15");
                dtt.Columns.Add("16");
                dtt.Columns.Add("17");
                dtt.Columns.Add("18");
                dtt.Columns.Add("19");
                dtt.Columns.Add("20");
                dtt.Columns.Add("21");
                dtt.Columns.Add("22");
                dtt.Columns.Add("23");
                dtt.Columns.Add("24");
                dtt.Columns.Add("25");             
            }

            for (int i = 0; i < dt.Rows.Count; i++)//遍历数组成员
            {
                if (list.IndexOf(dt.Rows[i][5].ToString().Trim()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(dt.Rows[i][5].ToString().Trim());
            }
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dtt.NewRow();
                dr[0] = list[i];
                dtt.Rows.Add(dr);//把新行加入表
            }

            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                string xingming = dtt.Rows[i][0].ToString().Trim();
                DateTime aa = Convert.ToDateTime(dateriqi.Text);
                string tianshua = aa.Month.ToString();         
                if (Convert.ToInt32(tianshua)<10)
                {
                    tianshua = "0" + tianshua;
                }
                for (int ii = 0; ii < dtt.Columns.Count-1; ii++)
                {
                    if (Convert.ToInt32(  dtt.Columns[ii + 1].ColumnName)>=26 && Convert.ToInt32(dtt.Columns[ii + 1].ColumnName) <= 31)
                    {
                        string riqi = dtt.Columns[ii + 1].ColumnName;
                        string riqi1 = (Convert.ToInt32(dtt.Columns[ii + 1].ColumnName) + 1).ToString();
                        string cou = "2018-" + tianshua + "-" + riqi + " " + "00:00:00.000";
                        string cou1 = Convert.ToDateTime(cou).AddDays(1).ToString();
                        string sql = "select * from tb_kaoqin where 员工='" + xingming + "' and 时间>='" + cou + "' and 时间<'" + cou1 + "'";
                        DataTable dttt = SQLhelp.GetDataTable(sql, CommandType.Text);
                        if (dttt.Rows.Count >= 4)
                        {
                            int panduan1 = 0;
                            int panduan2 = 0;
                            int panduan3 = 0;
                            for (int j = 0; j < dttt.Rows.Count; j++)
                            {
                                if (Convert.ToDateTime(dttt.Rows[j]["时间"]) <= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 08:00:00")))
                                {
                                    panduan1 += 1;

                                }
                                if (Convert.ToDateTime(dttt.Rows[j]["时间"]) >= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 11:30:00")) && Convert.ToDateTime(dttt.Rows[j]["时间"]) <= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 12:50:00")))
                                {
                                    panduan2 += 1;


                                }
                                if (Convert.ToDateTime(dttt.Rows[j]["时间"]) >= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 17:30:00")))
                                {
                                    panduan3 += 1;

                                }
                            }

                            if (panduan1 >= 1 && panduan2 >= 2 && panduan3 >= 1)
                            {
                                string mingzi = dtt.Columns[ii + 1].ColumnName;
                                dtt.Rows[i][mingzi] = "111";
                            }
                            else
                            {
                                string mess = "";
                                string mingzi = dtt.Columns[ii + 1].ColumnName;
                                for (int iiii = 0; iiii < dttt.Rows.Count; iiii++)
                                {
                                    mess += dttt.Rows[iiii]["时间"].ToString() + "  ";

                                }
                                if (mess.Trim() == "")
                                {
                                    dtt.Rows[i][mingzi] = "异常";
                                }
                                if (mess.Trim() != "")
                                {
                                    dtt.Rows[i][mingzi] = mess;
                                }
                            }
                        }
                        else
                        {
                            string mess = "";
                            string mingzi = dtt.Columns[ii + 1].ColumnName;
                            for (int iiii = 0; iiii < dttt.Rows.Count; iiii++)
                            {
                                mess += dttt.Rows[iiii]["时间"].ToString() + "  ";

                            }
                            if (mess.Trim() == "")
                            {
                                dtt.Rows[i][mingzi] = "异常";
                            }
                            if (mess.Trim() != "")
                            {
                                dtt.Rows[i][mingzi] = mess;
                            }
                        }
                    }
                    if (Convert.ToInt32(dtt.Columns[ii + 1].ColumnName) < 26 )
                    {
                        int tianshua11 = Convert.ToInt32(tianshua) + 1;                        
                        string riqi = dtt.Columns[ii + 1].ColumnName;
                        string riqi1 = (Convert.ToInt32(dtt.Columns[ii + 1].ColumnName) + 1).ToString();
                        string cou = "2018-" + tianshua11 + "-" + riqi + " " + "00:00:00.000";
                        string cou1 = Convert.ToDateTime(cou).AddDays(1).ToString();
                        string sql = "select * from tb_kaoqin where 员工='" + xingming + "' and 时间>='" + cou + "' and 时间<'" + cou1 + "'";
                        DataTable dttt = SQLhelp.GetDataTable(sql, CommandType.Text);
                        if (dttt.Rows.Count >= 4)
                        {
                            int panduan1 = 0;
                            int panduan2 = 0;
                            int panduan3 = 0;
                            for (int j = 0; j < dttt.Rows.Count; j++)
                            {
                                if (Convert.ToDateTime(dttt.Rows[j]["时间"]) <= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 08:00:00")))
                                {
                                    panduan1 += 1;

                                }
                                if (Convert.ToDateTime(dttt.Rows[j]["时间"]) >= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 11:30:00")) && Convert.ToDateTime(dttt.Rows[j]["时间"]) <= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 12:50:00")))
                                {
                                    panduan2 += 1;


                                }
                                if (Convert.ToDateTime(dttt.Rows[j]["时间"]) >= Convert.ToDateTime(Convert.ToDateTime(dttt.Rows[j]["时间"]).ToString("yyyy-MM-dd 17:30:00")))
                                {
                                    panduan3 += 1;

                                }
                            }

                            if (panduan1 >= 1 && panduan2 >= 2 && panduan3 >= 1)
                            {
                                string mingzi = dtt.Columns[ii + 1].ColumnName;
                                dtt.Rows[i][mingzi] = "111";
                            }
                            else
                            {
                                string mess = "";
                                string mingzi = dtt.Columns[ii + 1].ColumnName;
                                for (int iiii = 0; iiii < dttt.Rows.Count; iiii++)
                                {
                                    mess += dttt.Rows[iiii]["时间"].ToString() + "  ";

                                }
                                if (mess.Trim() == "")
                                {
                                    dtt.Rows[i][mingzi] = "异常";
                                }
                                if (mess.Trim() != "")
                                {
                                    dtt.Rows[i][mingzi] = mess;
                                }
                            }
                        }
                        else
                        {
                            string mess = "";
                            string mingzi = dtt.Columns[ii + 1].ColumnName;
                            for(int iiii=0; iiii<dttt.Rows.Count;iiii++)
                            {
                                mess += dttt.Rows[iiii]["时间"].ToString() + "  ";
                                
                            }
                            if (mess.Trim() == "")
                            {
                                dtt.Rows[i][mingzi] = "异常";
                            }
                            if (mess.Trim() != "")
                            {
                                dtt.Rows[i][mingzi] = mess;
                            }
                        }
                    }
                    
                }
            }
            gridControl1.DataSource = dtt;
            
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          string yuangong=  Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "姓名"));
            int riqi = Convert.ToInt32( gridView1.FocusedColumn.FieldName);
            if(riqi>=26)
            {
                DateTime aa = Convert.ToDateTime(dateriqi.Text);
                string tianshua = aa.Month.ToString();
                if (Convert.ToInt32(tianshua) < 10)
                {
                    tianshua = "0" + tianshua;
                }
                string cou = "2018-" + tianshua + "-" + riqi + " " + "00:00:00.000";
                string cou1 = Convert.ToDateTime(cou).AddDays(1).ToString();
                string sql = "select * from tb_kaoqin where 员工='" + yuangong + "' and 时间>='" + cou + "' and 时间<'" + cou1 + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql, CommandType.Text);
                string mess = "";
                for(int i=0;i<dttt.Rows.Count;i++)
                {
                    mess += dttt.Rows[i]["时间"].ToString()+"\r\n";
                    
                }
                MessageBox.Show(mess);

            }
            if (riqi < 26)
            {
                DateTime aa = Convert.ToDateTime(dateriqi.Text);
                string tianshua = aa.Month.ToString();
                if (Convert.ToInt32(tianshua) < 10)
                {
                    tianshua = "0" + tianshua;
                }
                int tianshuaaaa = Convert.ToInt32(tianshua) + 1;
                tianshua = tianshuaaaa.ToString();
                string cou = "2018-" + tianshua + "-" + riqi + " " + "00:00:00.000";
                string cou1 = Convert.ToDateTime(cou).AddDays(1).ToString();
                string sql = "select * from tb_kaoqin where 员工='" + yuangong + "' and 时间>='" + cou + "' and 时间<'" + cou1 + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql, CommandType.Text);
                string mess = "";
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    mess += dttt.Rows[i]["时间"].ToString() + "\r\n";

                }
                MessageBox.Show(mess);

            }






            //Frchakna form1 = new Frchakna();
            //form1.riqi = riqi;
            //form1.renyuan = yuangong;
            //form1.shijian =Convert.ToDateTime( dateriqi.Text);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Frchakna form1 = new Frchakna();
            form1.ShowDialog();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
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