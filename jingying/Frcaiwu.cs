using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.jingying
{
    public partial class Frcaiwu : Form
    {
        public Frcaiwu()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frcaiwu_Load(object sender, EventArgs e)
        {
            string startDay = DateTime.Now.ToShortDateString();
            string endDay = DateTime.Now.AddDays(1).ToShortDateString();
            load(startDay,endDay);
            tubiaoload();
            
        }

        private void tubiaoload()
        {
            string year = DateTime.Now.Year.ToString();
            string sql = "select 销售部,SUM(销售额) 年度销售总额,SUM(产值) 年度总产值,SUM(开票额) 年度总开票额 from tb_xiaoshou where 提交时间>'"+year+"'group by 销售部";
            DataTable dtt = SQLhelp1.GetDataTable(sql, CommandType.Text);
            for (int j = 0; j < dtt.Rows.Count; j++)
            {
                string b = Convert.ToString(dtt.Rows[j]["年度销售总额"]);
                if (b == "")
                {
                    dtt.Rows[j]["年度销售总额"] = 0;
                }
                b = Convert.ToString(dtt.Rows[j]["年度总产值"]);
                if (b == "")
                {
                    dtt.Rows[j]["年度总产值"] = 0;
                }
                b = Convert.ToString(dtt.Rows[j]["年度总开票额"]);
                if (b == "")
                {
                    dtt.Rows[j]["年度总开票额"] = 0;
                }
            }
            Series Series1 = new Series("销售总额", ViewType.Bar);
            Series Series2= new Series("总产值", ViewType.Bar);
            Series Series3= new Series("开票总额", ViewType.Bar);
            Series1.ArgumentScaleType = ScaleType.Qualitative;
            Series2.ArgumentScaleType = ScaleType.Qualitative;
            Series3.ArgumentScaleType = ScaleType.Qualitative;
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(String));
            table.Columns.Add("Value1", typeof(Double));
            table.Columns.Add("Value2", typeof(Double));
            table.Columns.Add("Value3", typeof(Double));
            foreach (DataRow item in dtt.Rows)
            {
                var array = new object[] { item["销售部"], item["年度销售总额"],item["年度总产值"],item["年度总开票额"] };
                table.Rows.Add(array);
            }
            Series1.ArgumentDataMember = "Name";
            Series1.ValueDataMembers[0] = "Value1";
            Series1.DataSource = table;
            Series1.Label.TextPattern = "{A}:{VP:0.00%}";
            Series2.ArgumentDataMember = "Name";
            Series2.ValueDataMembers[0] = "Value2";
            Series2.DataSource = table;
            Series2.Label.TextPattern = "{A}:{VP:0.00%}";
            Series3.ArgumentDataMember = "Name";
            Series3.ValueDataMembers[0] = "Value3";
            Series3.DataSource = table;
            Series3.Label.TextPattern = "{A}:{VP:0.00%}";
            chartControl1.Series.Add(Series1);
            chartControl1.Series.Add(Series2);
            chartControl1.Series.Add(Series3);
        }

        private void load(string starttime,string endtime)
        {
            string xianlan = "select 销售额,产值,开票额 from tb_xiaoshou where 销售部='线缆装备销售部' and 提交时间 between '"+starttime+"'and'"+endtime+"'";
            DataTable dt1 = SQLhelp1.GetDataTable(xianlan, CommandType.Text);
            string xiaoshoue;
            string chanzhi;
            string kaipiaoe;
            if (dt1.Rows.Count == 0)
            {
                xiaoshoue = "0";
                chanzhi = "0";
                kaipiaoe = "0";
            }
            else{
                xiaoshoue = Convert.ToString(dt1.Rows[0]["销售额"]);
                chanzhi = Convert.ToString(dt1.Rows[0]["产值"]);
                kaipiaoe = Convert.ToString(dt1.Rows[0]["开票额"]);

            }
            tileBarItem1.Text = tileBarItem1.Text + "\n 销售额:" + xiaoshoue+"\n 产值:"+chanzhi+"\n 开票额:"+kaipiaoe;
            string shiying = "select 销售额,产值,开票额 from tb_xiaoshou where 销售部='石英装备销售部' and 提交时间 between '" + starttime+"'and'"+endtime+"'";
            DataTable dt2 = SQLhelp1.GetDataTable(shiying, CommandType.Text);
            if (dt2.Rows.Count == 0)
            {
                xiaoshoue = "0";
                chanzhi = "0";
                kaipiaoe = "0";
            }
            else
            {
                xiaoshoue = Convert.ToString(dt2.Rows[0]["销售额"]);
                chanzhi = Convert.ToString(dt2.Rows[0]["产值"]);
                kaipiaoe = Convert.ToString(dt2.Rows[0]["开票额"]);

            }
            tileBarItem2.Text = tileBarItem2.Text + "\n 销售额:" + xiaoshoue + "\n 产值:" + chanzhi + "\n 开票额:" + kaipiaoe;
            string bocai = "select 销售额,产值,开票额 from tb_xiaoshou where 销售部='薄材装备销售部' and 提交时间 between '" + starttime + "'and'" + endtime + "'";
            DataTable dt3 = SQLhelp1.GetDataTable(bocai, CommandType.Text);
            if (dt3.Rows.Count == 0)
            {
                xiaoshoue = "0";
                chanzhi = "0";
                kaipiaoe = "0";
            }
            else
            {
                xiaoshoue = Convert.ToString(dt3.Rows[0]["销售额"]);
                chanzhi = Convert.ToString(dt3.Rows[0]["产值"]);
                kaipiaoe = Convert.ToString(dt3.Rows[0]["开票额"]);

            }
            tileBarItem3.Text = tileBarItem3.Text + "\n 销售额:" + xiaoshoue + "\n 产值:" + chanzhi + "\n 开票额:" + kaipiaoe;
            string xincai = "select 销售额,产值,开票额 from tb_xiaoshou where 销售部='新材装备销售部' and 提交时间 between '" + starttime + "'and'" + endtime + "'";
            DataTable dt4 = SQLhelp1.GetDataTable(xincai, CommandType.Text);
            if (dt4.Rows.Count == 0)
            {
                xiaoshoue = "0";
                chanzhi = "0";
                kaipiaoe = "0";
            }
            else
            {
                xiaoshoue = Convert.ToString(dt4.Rows[0]["销售额"]);
                chanzhi = Convert.ToString(dt4.Rows[0]["产值"]);
                kaipiaoe = Convert.ToString(dt4.Rows[0]["开票额"]);

            }
            tileBarItem4.Text = tileBarItem4.Text + "\n 销售额:" + xiaoshoue + "\n 产值:" + chanzhi + "\n 开票额:" + kaipiaoe;
            string zhineng = "select 销售额,产值,开票额 from tb_xiaoshou where 销售部='智能装备销售部' and 提交时间 between '" + starttime + "'and'" + endtime + "'";
            DataTable dt5 = SQLhelp1.GetDataTable(zhineng, CommandType.Text);
            if (dt5.Rows.Count == 0)
            {
                xiaoshoue = "0";
                chanzhi = "0";
                kaipiaoe = "0";
            }
            else
            {
                xiaoshoue = Convert.ToString(dt5.Rows[0]["销售额"]);
                chanzhi = Convert.ToString(dt5.Rows[0]["产值"]);
                kaipiaoe = Convert.ToString(dt5.Rows[0]["开票额"]);

            }
            tileBarItem5.Text = tileBarItem5.Text + "\n 销售额:" + xiaoshoue + "\n 产值:" + chanzhi + "\n 开票额:" + kaipiaoe;
            string jinggong = "select 销售额,产值,开票额 from tb_xiaoshou where 销售部='精工配件销售部' and 提交时间 between '" + starttime + "'and'" + endtime + "'";
            DataTable dt6 = SQLhelp1.GetDataTable(jinggong, CommandType.Text);
            if (dt6.Rows.Count == 0)
            {
                xiaoshoue = "0";
                chanzhi = "0";
                kaipiaoe = "0";
            }
            else
            {
                xiaoshoue = Convert.ToString(dt6.Rows[0]["销售额"]);
                chanzhi = Convert.ToString(dt6.Rows[0]["产值"]);
                kaipiaoe = Convert.ToString(dt6.Rows[0]["开票额"]);

            }
            tileBarItem6.Text = tileBarItem6.Text + "\n 销售额:" + xiaoshoue + "\n 产值:" + chanzhi + "\n 开票额:" + kaipiaoe;
            string mujv = "select 销售额,产值,开票额 from tb_xiaoshou where 销售部='模具销售部' and 提交时间 between '" + starttime + "'and'" + endtime + "'";
            DataTable dt7 = SQLhelp1.GetDataTable(mujv, CommandType.Text);
            if (dt7.Rows.Count == 0)
            {
                xiaoshoue = "0";
                chanzhi = "0";
                kaipiaoe = "0";
            }
            else
            {
                xiaoshoue = Convert.ToString(dt7.Rows[0]["销售额"]);
                chanzhi = Convert.ToString(dt7.Rows[0]["产值"]);
                kaipiaoe = Convert.ToString(dt7.Rows[0]["开票额"]);

            }
            tileBarItem7.Text = tileBarItem7.Text + "\n 销售额:" + xiaoshoue + "\n 产值:" + chanzhi + "\n 开票额:" + kaipiaoe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateEdit1.Text=="")
            {
                MessageBox.Show("请输入想要查询信息的日期");
            }
            else
            {
                string starttime = dateEdit1.Text;
                string endtime = DateTime.Parse(starttime).AddDays(1).ToShortDateString();
                region();
                load(starttime, endtime);
            }
        }

        private void region()
        {
            tileBarItem1.Text = "线缆装备销售部";
            tileBarItem2.Text = "石英装备销售部";
            tileBarItem3.Text = "薄材装备销售部";
            tileBarItem4.Text = "新材装备销售部";
            tileBarItem5.Text = "智能装备销售部";
            tileBarItem6.Text = "精工配件销售部";
            tileBarItem7.Text = "模具销售部";
        }
    }
}
