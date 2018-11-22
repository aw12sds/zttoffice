using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Schedule;
using DevComponents.Schedule.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.Appointment11
{
    public partial class FrAppointmentChaxun : Office2007Form
    {
        public FrAppointmentChaxun()
        {
            this.EnableGlass = false;
            InitializeComponent();
            calendarView1.CalendarModel = new CalendarModel();
            AddSampleAppointments();
        }
        public string yonghu;
        private void AddSampleAppointments()
        {
            calendarView1.CalendarModel.Appointments.Clear();
            string sql = "select * from tb_huiyishi ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                DateTime kaishishijian =Convert.ToDateTime(dt.Rows[i]["预约开始时间"]);
                DateTime jieshushijian = Convert.ToDateTime(dt.Rows[i]["预约结束时间"]);
                string huiyishi =dt.Rows[i]["预约会议室"].ToString();
                if (huiyishi == "1#会议室")
                {
                    string renyuan = dt.Rows[i]["预约人员"].ToString();
                    string huiyishizhuti = dt.Rows[i]["会议室主题"].ToString();
                    AddAppointment(huiyishi,
                   kaishishijian, jieshushijian,
                   Appointment.CategoryBlue, Appointment.TimerMarkerDefault, huiyishizhuti, renyuan);
                }
                if (huiyishi == "2#会议室")
                {
                    string renyuan = dt.Rows[i]["预约人员"].ToString();
                    string huiyishizhuti = dt.Rows[i]["会议室主题"].ToString();
                    AddAppointment(huiyishi,
                   kaishishijian, jieshushijian,
                   Appointment.CategoryYellow, Appointment.TimerMarkerDefault, huiyishizhuti, renyuan);
                }
                if (huiyishi == "3#会议室")
                {
                    string renyuan = dt.Rows[i]["预约人员"].ToString();
                    string huiyishizhuti = dt.Rows[i]["会议室主题"].ToString();
                    AddAppointment(huiyishi,
                   kaishishijian, jieshushijian,
                   Appointment.CategoryOrange, Appointment.TimerMarkerDefault, huiyishizhuti, renyuan);
                }


            }

        }

        private Appointment AddAppointment(string s,
           DateTime startTime, DateTime endTime, string color, string marker,string zhuti,string renyuan)
        {
            Appointment appointment = new Appointment();

            appointment.StartTime = startTime;
            appointment.EndTime = endTime;

            appointment.Subject = s;
            appointment.Description = renyuan;
            appointment.CategoryColor = color;
            appointment.TimeMarkedAs = marker;

            appointment.Tooltip = zhuti;
            appointment.Locked = true;
            calendarView1.CalendarModel.Appointments.Add(appointment);

            return (appointment);
        }

        private void FrAppointmentChaxun_Load(object sender, EventArgs e)
        {



        }

        private void FrAppointmentChaxun_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Day;
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Week;
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Month;
        }

        private void btnTimeLine_Click_1(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.TimeLine;
        }

        private void calendarView1_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            AppointmentView item = sender as AppointmentView;

            if (item != null)
            {
                Appointment ap = item.Appointment;

                string s = string.Format(
                    "会议室: {0}\n会议室主题: {1}\n参与人员: {2}\n\n" +
                    "开始时间: {3}\n结束时间: {4}",
                    ap.Subject, ap.Tooltip, ap.Description,
                    ap.StartTime, ap.EndTime);
                  
                MessageBox.Show(s);
               
            }
        }

        private void 预约会议室ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrAppointment form = new FrAppointment();
            form.yonghu = yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                AddSampleAppointments();
            }
        }

        private void calendarView1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
