using Aspose.Cells;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ztoffice.renliziyuan
{
    public partial class Frkaoqin : Office2007Form
    {
        public Frkaoqin()
        {
            this.EnableGlass = false;//关键
            InitializeComponent();
        }
       
      
        private void Frkaoqin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //if (dateTimeInput1.Text != "" & textBox2.Text != "")
            //{
            //    WorkDate = dateTimeInput1.Text;
            //    OpenFileDialog dialog = new OpenFileDialog();
            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string address = dialog.FileName;
            //        string strFilePath = Path.GetFileNameWithoutExtension(address);//文件名

            //        Workbook book = new Workbook(address);
            //        Worksheet sheet = book.Worksheets["Sheet1"];

            //        string hs = this.textBox2.Text.Trim();
            //        int hss = Convert.ToInt32(hs);
            //        DataTable DT = sheet.Cells.ExportDataTableAsString(0, 0, hss, 5);
            //        string d = DT.Rows[0][0].ToString();
            //        if (d == "工号")
            //        {
            //            DW = 2;//汉王
            //            dt = DT;
            //        }
            //        else
            //        {
            //            DataTable dts = new DataTable();
            //            DW = 1;
            //            DataRow[] drs = null;
            //            for (int i = 1; i < 6; i++)
            //            {
            //                DataColumn dc = new DataColumn();
            //                dc.DataType = System.Type.GetType("System.String");
            //                dc.ColumnName = "Column" + i + "";
            //                dts.Columns.Add(dc);
            //            }
            //            for (int i = 0; i < DT.Rows.Count; i++)
            //            {
            //                if (dts.Rows.Count > 0)
            //                {
            //                    string[] abc = DT.Rows[i].ItemArray[3].ToString().Split(' ');
            //                    drs = dts.Select("Column1 ='" + DT.Rows[i].ItemArray[2] + "' and Column4='" + Convert.ToDateTime(abc[0]).ToString("yyyy-MM-dd") + "'");
            //                    if (drs.Length > 0)
            //                    {
            //                        DataRow drr = drs[0];
            //                        string time = drr.ItemArray[4].ToString();
            //                        drr["Column5"] = time + " " + abc[1];
            //                    }
            //                    else
            //                    {
            //                        DataRow drr = dts.NewRow();
            //                        drr["Column1"] = DT.Rows[i].ItemArray[2];
            //                        drr["Column2"] = DT.Rows[i].ItemArray[1];
            //                        drr["Column3"] = DT.Rows[i].ItemArray[0];
            //                        drr["Column4"] = Convert.ToDateTime(abc[0]).ToString("yyyy-MM-dd");
            //                        drr["Column5"] = abc[1];

            //                        dts.Rows.Add(drr);
            //                    }
            //                }
            //                else
            //                {
            //                    DataRow drr = dts.NewRow();
            //                    drr["Column1"] = DT.Rows[i].ItemArray[2];
            //                    drr["Column2"] = DT.Rows[i].ItemArray[1];
            //                    drr["Column3"] = DT.Rows[i].ItemArray[0];
            //                    drr["Column4"] = DT.Rows[i].ItemArray[3];
            //                    drr["Column5"] = DT.Rows[i].ItemArray[4];
            //                    dts.Rows.Add(drr);
            //                }
            //            }
            //            dt = dts;
            //        }
            //        WorkTimeDGV.DataSource = dt;
            //        if (dt.Rows.Count > 0)
            //        {
            //            Thread thd = new Thread(ExcelGoSql);//使用线程保存到数据库
            //            thd.IsBackground = true;
            //            thd.Start();
            //            //ExcelGoSql();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请选择时间并填写需要导入的行数");
            //}
        }

        public void ExcelGoSql()
        {
            //string[] dates = WorkDate.Split('/');
            //if (timebll.GetModelList("Year='" + dates[0] + "' and Month='" + dates[1] + "' and DW='" + DW + "'").Count > 0)
            //{
            //    timebll.Delete(" Year='" + dates[0] + "' and Month='" + dates[1] + "' and DW='" + DW + "'");
            //}
            //foreach (DataGridViewRow item in WorkTimeDGV.Rows)
            //{
            //    if (item.Index != 0 & item.Index != WorkTimeDGV.Rows.Count - 1 & item.Cells[0].Value != null)
            //    {
            //        WorkExcelModel model = new WorkExcelModel();
            //        string[] date = null;
            //        #region 保存表格
            //        date = item.Cells[3].Value.ToString().Split('-');
            //        WorkExcelModel workExcelModel = new WorkExcelModel()
            //        {
            //            MorkNumb = item.Cells[0].Value.ToString(),
            //            MorkName = item.Cells[1].Value.ToString(),
            //            MorkDept = item.Cells[2].Value.ToString(),
            //            MorkDate = item.Cells[3].Value.ToString(),
            //            MorkTime = item.Cells[4].Value.ToString(),
            //            Month = dates[1],
            //            Year = date[0]
            //        };
            //        model = workExcelModel;
            //        WorkTimeModel timemodel = new WorkTimeModel()
            //        {
            //            Year = date[0],
            //            Month = dates[1],
            //            Date = date[2],
            //            WorkDate = item.Cells[3].Value.ToString(),
            //            WorkerName = item.Cells[1].Value.ToString(),
            //            WorkerNumb = item.Cells[0].Value.ToString(),
            //        };
            //        if (timebll.GetModel("WorkerNumb='" + item.Cells[0].Value.ToString() + "'") == null)
            //        {
            //            timebll.Add(timemodel, DW);
            //        }
            //        if (excelbll.GetModel("Year='" + model.Year + "' and Month='" + model.Month + "' and MorkDate='" + model.MorkDate + "'  and MorkNumb='" + model.MorkNumb + "'") == null)
            //        {
            //            excelbll.Add(model);
            //        }
            //        else
            //        {
            //            excelbll.Delete(" Year='" + model.Year + "' and Month='" + model.Month + "'  and MorkDate='" + model.MorkDate + "'   and MorkNumb='" + model.MorkNumb + "'");
            //            excelbll.Add(model);
            //        }
            //        #endregion
            //    }
            //}
            //Go();
        }
        public void Go()
        {
            //ExcelList.Clear();//清空原数据
            //ExcelOnlyNumb.Clear();

            //string WorkerNumbs = null;
            //for (int i = 1; i < dt.Rows.Count; i++)
            //{
            //    //去重保存
            //    if (dt.Rows[i][0].ToString() != WorkerNumbs)
            //    {
            //        WorkerNumbs = dt.Rows[i][0].ToString();
            //        ExcelOnlyNumb.Add(WorkerNumbs);
            //    }
            //}
            //for (int i = 0; i < ExcelOnlyNumb.Count; i++)//每个人操作
            //{
            //    double WorkTime = 0;//工作时长
            //    //double LackTime =0;//缺勤时长
            //    //double OverTime = 0;//加班时长
            //    double LateTime = 0;//        迟到时长
            //    DataRow[] drs = dt.Select("Column1 ='" + ExcelOnlyNumb[i] + "'");//获取相关人员的所有行数据
            //    for (int j = 0; j < drs.Length; j++)//循环所有行
            //    {
            //        double DayWorkTime = 0;//一天工作时长
            //        double DayLateTime = 0;
            //        double DayOverTime = 0;
            //        DataRow dr = drs[j];//逐行操作
            //        int Date = Convert.ToInt32(Convert.ToDateTime(dr.ItemArray[3]).ToString("yyyy-MM-dd").Split('-')[2]);
            //        DayOfWeek IsWeek = Convert.ToDateTime(dr.ItemArray[3]).DayOfWeek;
            //        string[] Alltime = dr.ItemArray[4].ToString().Split(' ');
            //        List<string> TimeList = new List<string>();
            //        for (int n = 0; n < Alltime.Length; n++)//筛选单行所有时间
            //        {
            //            if (Alltime[n] != "")
            //            {
            //                TimeList.Add(Alltime[n]);
            //            }
            //        }
            //        if (TimeList.Count > 1)//判断打卡时间是否有效
            //        {
            //            string[] T = TimeList[0].Split(':');
            //            if (TimeList.Count % 2 == 0)
            //            {
            //                bool zc = true;
            //                for (int v = 0; v < TimeList.Count; v++)
            //                {
            //                    if (zc)
            //                    {
            //                        if (TimeList[v].Split(':')[0] != TimeList[v + 1].Split(':')[0])
            //                        {
            //                            DayWorkTime = TimeSub(Convert.ToDateTime(TimeList[v + 1]), Convert.ToDateTime(TimeList[v])) + DayWorkTime;
            //                            WorkTime = WorkTime + DayWorkTime;
            //                            if (Convert.ToInt32(TimeList[v].Split(':')[0]) < 11)//上午
            //                            {
            //                                if (IsNoLate(UpActionTime, TimeList[v]) != true)//迟到
            //                                {
            //                                    DayLateTime = TimeSub(Convert.ToDateTime(TimeList[v]), Convert.ToDateTime(UpActionTime)) + DayLateTime;
            //                                    LateTime = LateTime + DayLateTime;
            //                                }
            //                                if (DayWorkTime >= 3.3)
            //                                {
            //                                    DayOverTime = DayWorkTime;
            //                                    DayWorkTime = 3.4;
            //                                }
            //                            }
            //                            else//下午
            //                            {
            //                                if (DayWorkTime > 8)
            //                                {
            //                                    if (IsNoLate(DownActionTime, TimeList[v]))
            //                                    {
            //                                        DayWorkTime = 3.4;
            //                                        DayWorkTime = TimeSub(Convert.ToDateTime(TimeList[v + 1]), Convert.ToDateTime(DownActionTime)) + DayWorkTime;
            //                                        if (DayWorkTime < 8)
            //                                        {
            //                                            DayWorkTime = 8;
            //                                        }
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    DayWorkTime = TimeSub(Convert.ToDateTime(TimeList[v + 1]), Convert.ToDateTime(TimeList[v])) + DayOverTime;
            //                                }
            //                                if (IsNoLate(DownActionTime, TimeList[v]) != true)//迟到
            //                                {
            //                                    DayLateTime = TimeSub(Convert.ToDateTime(TimeList[v]), Convert.ToDateTime(DownActionTime)) + DayLateTime;
            //                                    LateTime = LateTime + DayLateTime;
            //                                }
            //                            }
            //                            v = v + 1;
            //                        }
            //                        else
            //                        {
            //                            zc = false;
            //                        }
            //                    }
            //                }
            //                if (zc != true)
            //                {
            //                    DayWorkTime = -9999;
            //                }
            //            }
            //            else
            //            {
            //                DayWorkTime = -999;//缺卡
            //            }
            //        }
            //        else
            //        {
            //            DayWorkTime = -999;
            //        }
            //        if (IsWeek.ToString() == "Saturday" || IsWeek.ToString() == "Sunday")//周六
            //        {
            //            if (IsWeek.ToString() == "Saturday")//周六
            //            {
            //                if (DayWorkTime >= 3.2)
            //                {
            //                    if (DayWorkTime > 3.2 & TimeList.Count > 2)
            //                    {
            //                        string c = (DayWorkTime - 3.2).ToString("0.0");
            //                        timebll.Update("[" + Date + "]='" + c + "'   where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                    }
            //                    else
            //                    {
            //                        timebll.Update("[" + Date + "]='666'    where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                    }
            //                }
            //                else
            //                {
            //                    if (DayWorkTime != -999 & DayWorkTime != -9999)
            //                    {
            //                        if (DayWorkTime != 0)
            //                        {
            //                            string c = (3.2 - DayWorkTime).ToString("0.0");
            //                            timebll.Update("[" + Date + "]='-" + c + "'  where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                        }
            //                        else
            //                        {
            //                            timebll.Update("[" + Date + "]='-3.2'    where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (DayWorkTime == -999)
            //                        {
            //                            timebll.Update("[" + Date + "]='缺'      where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                        }
            //                        else
            //                        {
            //                            timebll.Update("[" + Date + "]='异'     where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (DayWorkTime != 0 & DayWorkTime != -999 & DayWorkTime != -9999)
            //                {
            //                    timebll.Update("[" + Date + "]='" + DayWorkTime.ToString("0.0") + "'    where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                }
            //                else
            //                {
            //                    if (DayWorkTime == -999)
            //                    {
            //                        timebll.Update("[" + Date + "]='缺'      where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                    }
            //                    else
            //                    {
            //                        timebll.Update("[" + Date + "]='异'     where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (DayWorkTime != -999 && DayWorkTime != -9999)
            //            {
            //                if (DayWorkTime != 0)
            //                {
            //                    if (DayWorkTime >= 8)
            //                    {
            //                        if (DayWorkTime > 8)
            //                        {
            //                            string c = (DayWorkTime - 8).ToString("0.0");
            //                            timebll.Update("[" + Date + "]='" + c + "'   where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                        }
            //                        else
            //                        {
            //                            timebll.Update("[" + Date + "]='666'     where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                        }
            //                    }
            //                    else
            //                    {
            //                        string c = (8 - DayWorkTime).ToString("0.0");
            //                        timebll.Update("[" + Date + "]='-" + c + "'  where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                    }
            //                }
            //                else
            //                {
            //                    timebll.Update("[" + Date + "]='-8'   where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                }
            //            }
            //            else
            //            {
            //                if (DayWorkTime == -999)
            //                {
            //                    timebll.Update("[" + Date + "]='缺'   where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                }
            //                else
            //                {
            //                    timebll.Update("[" + Date + "]='异'    where WorkerNumb='" + drs[j].ItemArray[0] + "'");
            //                }
            //            }


            //        }
            //        //MessageBox.Show("一行"+DayWorkTime.ToString()+"   |  "+DayLateTime.ToString());

            //    }

            //    timebll.Update("LateTime='" + LateTime.ToString("0.0") + "',WorkTime='" + WorkTime.ToString("0.0") + "'    where WorkerNumb='" + ExcelOnlyNumb[i] + "'");
            //}
        }
        private double TimeSub(DateTime DateTime1, DateTime DateTime2)//计算时长
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts.TotalHours;
        }

        public bool IsNoLate(string st1, string st2)
        {

            DateTime dt1 = Convert.ToDateTime(st1);

            DateTime dt2 = Convert.ToDateTime(st2);

            if (DateTime.Compare(dt1, dt2) > 0)

                //st1 + ">" + st2;
                return true;

            else

                // st1 + "<" + st2;
                return false;
        }
    }
}
