using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ztoffice.report;
using System.Globalization;
using ztoffice.Service;
using ztoffice.dianjian;
using ztoffice.xuqiu;
using ztoffice.Appointment11;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using ztoffice.renliziyuan;
using DevExpress.XtraScheduler;
using WindowsFormsApplication2;
using System.Data.SqlClient;
using DevExpress.XtraTab;
using 项目管理系统.个人管理;
using 项目管理系统.我的任务;
using 项目管理系统.市场部;
using ztoffice.jingying;
using ztoffice.物流部;

namespace ztoffice
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string yonghu;
        public RibbonForm1(string yonghu)
        {

            UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            InitializeComponent();
            this.yonghu = yonghu;
            firestreact();


        }
        public void firestreact()
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bumen == "人力资源部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup47").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup48").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup24").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup27").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup49").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup21").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup32").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup23").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup25").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup28").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup29").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup30").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup55").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup56").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup80").Enabled = true;
            }
            else if (bumen == "市场部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup44").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup33").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup45").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup7").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup46").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup50").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup51").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup64").Enabled = true;
            }
            else if (bumen == "薄材事业部" || bumen == "产品事业部" || bumen == "石英事业部" || bumen == "线缆事业部" || bumen == "新材事业部" || bumen == "智能事业部" || bumen == "技术部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup52").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup35").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup53").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup3").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup54").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup58").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup59").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup65").Enabled = true;
            }
            else if (bumen == "精工事业部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup16").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup20").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup17").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup26").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup37").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup39").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup40").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup41").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup42").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup43").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup57").Enabled = true;
            }
            else if (bumen == "模具事业部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup88").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup89").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup103").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup104").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup105").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup106").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup107").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup108").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup109").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup110").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup111").Enabled = true;
            }
            else if (bumen == "研发部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup60").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup38").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup61").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup8").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup62").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup66").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup67").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup71").Enabled = true;
            }
            else if (bumen == "物流部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup68").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup34").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup69").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup9").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup70").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup74").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup75").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup81").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup87").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup72").Enabled = true;
            }
            else if (bumen == "质监部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup76").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup6").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup77").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup10").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup78").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup82").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup83").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup73").Enabled = true;
            }
            else if (bumen == "财务部")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup84").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup13").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup85").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup14").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup86").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup90").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup91").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup79").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup23").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup29").Enabled = true;
            }
            else if (bumen == "总经办")
            {
                quanxianall();
            }
            else if (bumen == "信息化事业部")
            {
                quanxianall();
            }
            else if (bumen == "办公室"|| bumen == "仓库")
            {
                this.ribbon.GetGroupByName("ribbonPageGroup93").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup1").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup94").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup2").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup95").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup36").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup4").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup11").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup12").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup96").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup102").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup63").Enabled = true;
            }
        }
      public void quanxianall()
        {
           
                this.ribbon.GetGroupByName("ribbonPageGroup47").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup48").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup24").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup27").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup49").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup21").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup32").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup23").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup25").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup28").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup29").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup30").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup55").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup56").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup80").Enabled = true;
          
                this.ribbon.GetGroupByName("ribbonPageGroup44").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup33").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup45").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup7").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup46").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup50").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup51").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup64").Enabled = true;
           
                this.ribbon.GetGroupByName("ribbonPageGroup52").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup35").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup53").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup3").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup54").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup58").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup59").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup65").Enabled = true;
           
                this.ribbon.GetGroupByName("ribbonPageGroup16").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup20").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup17").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup26").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup37").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup39").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup40").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup41").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup42").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup43").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup57").Enabled = true;
           
                this.ribbon.GetGroupByName("ribbonPageGroup88").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup89").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup103").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup104").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup105").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup106").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup107").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup108").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup109").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup110").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup111").Enabled = true;
           
                this.ribbon.GetGroupByName("ribbonPageGroup60").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup38").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup61").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup8").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup62").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup66").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup67").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup71").Enabled = true;
           
                this.ribbon.GetGroupByName("ribbonPageGroup68").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup34").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup69").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup9").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup70").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup74").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup75").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup81").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup87").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup72").Enabled = true;
            
                this.ribbon.GetGroupByName("ribbonPageGroup76").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup6").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup77").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup10").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup78").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup82").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup83").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup73").Enabled = true;
          
                this.ribbon.GetGroupByName("ribbonPageGroup84").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup13").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup85").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup14").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup86").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup90").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup91").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup79").Enabled = true;
           
                this.ribbon.GetGroupByName("ribbonPageGroup97").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup18").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup98").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup19").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup99").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup5").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup100").Enabled = true;
                this.ribbon.GetGroupByName("ribbonPageGroup101").Enabled = true;

            this.ribbon.GetGroupByName("ribbonPageGroup93").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup1").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup94").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup2").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup95").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup36").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup4").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup11").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup12").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup96").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup102").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup63").Enabled = true;
            this.ribbon.GetGroupByName("ribbonPageGroup31").Enabled = true;
        }
        public static FRtijiaoribao1 f1;
        public static Frgerenbaobiao f2;
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        public void zhuanzhengtixing()
        {
            string tixing = "select *from tb_danganbiao where 入职时间1<'" + DateTime.Now.AddDays(-75) + "'and 是否转正 is null";
            DataTable jieguo = SQLhelp.GetDataTable(tixing, CommandType.Text);
            MessageBox.Show("员工即将转正，请及时查看。");
        }
        public void hetongtixing()
        {
            string hetongtixing = "select *from tb_danganbiao where (合同到期时间a<'" + DateTime.Now.AddDays(+60) + "'and 是否签订合同1 is null)or (合同到期时间b<'" + DateTime.Now.AddDays(+60) + "'and 是否签订合同2 is null) or (合同到期时间b<'" + DateTime.Now.AddDays(+60) + "'and 是否签订合同3 is null)";
            DataTable jieguo = SQLhelp.GetDataTable(hetongtixing, CommandType.Text);
            MessageBox.Show("员工即将合同到期，请及时查看。");
        }
        public void fushentixing()
        {
            //string fushentixing = "select *from tb_danganbiao where 合同到期时间a<'" + DateTime.Now.AddDays(-60) + "'or 合同到期时间b<'" + DateTime.Now.AddDays(-60) + "'or 合同到期时间b<'" + DateTime.Now.AddDays(-60) + "'";
            //DataTable jieguo = SQLhelp.GetDataTable(fushentixing, CommandType.Text);
            //MessageBox.Show("员工即将合同到期，请及时查看。");
        }
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "IT需求管理";
            FrLliulan form1 = new FrLliulan();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }
        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrXuqiu form = new FrXuqiu();
            form.yonghu = yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {

            }
        }

        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "权限管理";
            FrOperator form1 = new FrOperator();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void RibbonForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            RibbonForm1.f1 = null;
        }

        private void RibbonForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RibbonForm1.f1 = null;
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "组织架构";
            Form1 form1 = new Form1();
            form1.TopLevel = false;
            //form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (bumen == "人力资源部")
            {

                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "OA考勤查询";
                Froakaoqin form1 = new Froakaoqin();
                form1.TopLevel = false;

                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;


            }
            if (bumen != "人力资源部")
            {
                if (yonghu == "钱陆亦" || yonghu == "庄卫星")
                {

                    XtraTabPage newPage = new XtraTabPage();
                    newPage.Text = "OA考勤查询";
                    Froakaoqin form1 = new Froakaoqin();
                    form1.TopLevel = false;

                    newPage.Controls.Add(form1);
                    form1.Show();
                    form1.Dock = DockStyle.Fill;
                    xtraTabControl1.TabPages.Add(newPage);
                    xtraTabControl1.SelectedTabPage = newPage;

                }
                if (yonghu != "钱陆亦" && yonghu != "庄卫星")
                {
                    MessageBox.Show("无权限！");
                    return;
                }

            }
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (bumen == "人力资源部")
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "考勤表汇总";
                Froakaoqin form1 = new Froakaoqin();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
            }
            if (bumen != "人力资源部")
            {
                if (yonghu == "钱陆亦" || yonghu == "庄卫星")
                {

                    XtraTabPage newPage = new XtraTabPage();
                    newPage.Text = "考勤表汇总";
                    Froakaoqin form1 = new Froakaoqin();
                    form1.TopLevel = false;
                    newPage.Controls.Add(form1);
                    form1.Show();
                    form1.Dock = DockStyle.Fill;
                    xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;

                }
                if (yonghu != "钱陆亦" && yonghu != "庄卫星")
                {
                    MessageBox.Show("无权限！");
                    return;
                }
            }
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (bumen == "人力资源部")
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "大学生入职管理";
                Frdaxueshengguanli form1 = new Frdaxueshengguanli();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;

            }
            if (bumen != "人力资源部")
            {
                if (yonghu == "钱陆亦" || yonghu == "庄卫星")
                {

                    XtraTabPage newPage = new XtraTabPage();
                    newPage.Text = "大学生入职管理";
                    Frdaxueshengguanli form1 = new Frdaxueshengguanli();
                    form1.TopLevel = false;
                    newPage.Controls.Add(form1);
                    form1.Show();
                    form1.Dock = DockStyle.Fill;
                    xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;

                }
                if (yonghu != "钱陆亦" && yonghu != "庄卫星")
                {
                    MessageBox.Show("无权限！");
                    return;
                }
            }
        }

        private void tongyongzhishi_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "通用知识培训";
            Frtongyongzhishi form1 = new Frtongyongzhishi();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;


        }

        private void Stukaoqin_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 类别='大学生'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();


            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "大学生考勤";
            Frdaxueshengkaoqin form1 = new Frdaxueshengkaoqin();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;




        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 类别='大学生'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "大学生考勤";
            Frweiji form1 = new Frweiji();
            form1.TopLevel = false;

            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text  
            foreach (XtraTabPage page in xtraTabControl1.TabPages)//遍历得到和关闭的选项卡一样的Text  
            {
                if (page.Text == name)
                {
                    xtraTabControl1.TabPages.Remove(page);
                    page.Dispose();
                    return;
                }
            }
        }

        private void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            //string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            //if (bumen == "人力资源部")
            //{
            //    if (yonghu=="李野然")
            //    {

            //    }



                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "档案管理";
                Frdangan form1 = new Frdangan();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;

            //}
            //if (bumen != "人力资源部")
            //{
            //    if (yonghu == "钱陆亦" || yonghu == "庄卫星" || yonghu == "桑甜")
            //    {

            //        XtraTabPage newPage = new XtraTabPage();
            //        newPage.Text = "档案管理";
            //        Frdangan form1 = new Frdangan();
            //        form1.TopLevel = false;
            //        newPage.Controls.Add(form1);
            //        form1.yonghu = yonghu;
            //        form1.Show();
            //        form1.Dock = DockStyle.Fill;
            //        xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;

                   
            //    }
            //    if (yonghu != "钱陆亦" && yonghu != "庄卫星" && yonghu != "桑甜")
            //    {
            //        MessageBox.Show("无权限！");
            //        return;
            //    }
            //}
            //if(yonghu=="李野然")
            //{
            //    string sql1= "select from *tb_danganbiao where DateDiff(dd,合同到期时间1,getdate())<=45";
            //}
       
        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {
            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;




        }

        private void barButtonItem57_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "市场部周报";
            Frshichangbuzhoubao1 form1 = new Frshichangbuzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;



        }

        private void barButtonItem66_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "产品经理周报";
            Frchanpinshiyebuzhoubao1 form1 = new Frchanpinshiyebuzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;



        }

        private void barButtonItem72_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem77_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem60_ItemClick(object sender, ItemClickEventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }


            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "物流部周报";
            FrWuliubuzhoubao form1 = new FrWuliubuzhoubao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;




        }

        private void barButtonItem10_ItemClick_1(object sender, ItemClickEventArgs e)
        {
           

        }

        private void barButtonItem11_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }


            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "模具事业部周报";
            Frjingongmujvzhoubao form1 = new Frjingongmujvzhoubao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;



        }

        private void barButtonItem9_ItemClick_1(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem12_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "公告查询";
            Frgonggao form1 = new Frgonggao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem70_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "人力资源部公告查询";
            Frrenliziyuangonggao form1 = new Frrenliziyuangonggao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem71_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人公告查询";
            Frgerengonggao form1 = new Frgerengonggao();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem16_ItemClick_1(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem19_ItemClick_1(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem20_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FrFabu form1 = new FrFabu();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void barButtonItem75_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议指示项";
            FrSearch2 form1 = new FrSearch2();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem76_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "领导指示项";
            FrSearch1 form1 = new FrSearch1();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem21_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确认上传集团会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "集团会议";
                form.ShowDialog();
            }
        }

        private void barButtonItem72_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确认上传公司级会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "会议";
                form.ShowDialog();
            }
        }

        private void barButtonItem73_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确认上传部门级会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "部门会议";
                form.ShowDialog();
            }
        }

        private void barButtonItem74_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确认上传集团指示项吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShangchuanzhishixiang form = new FrShangchuanzhishixiang();
                form.yonghu = yonghu;
                form.zhonglei = "集团指示项";
                form.ShowDialog();
            }
        }

        private void barButtonItem9_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确认上传总经理指示项吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShangchuanzhishixiang form = new FrShangchuanzhishixiang();
                form.yonghu = yonghu;
                form.zhonglei = "指示项";
                form.ShowDialog();
            }
        }

        private void barButtonItem14_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            if (MessageBox.Show("确认上传其他指示项吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShangchuanzhishixiang form = new FrShangchuanzhishixiang();
                form.yonghu = yonghu;
                form.zhonglei = "其他指示项";
                form.ShowDialog();
            }
        }

        private void barButtonItem15_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办事项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem77_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室查询";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem78_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrAppointment form = new FrAppointment();
            form.yonghu = yonghu;
            form.Show();
        }

        private void barButtonItem18_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办事项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem22_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem30_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem29_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem81_ItemClick(object sender, ItemClickEventArgs e)
        {

            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem26_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem67_ItemClick(object sender, ItemClickEventArgs e)
        {

            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {

            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem84_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrSousuo form = new FrSousuo();
            form.yonghu = yonghu;

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                FrXianshi form1 = new FrXianshi();

                form1.aaa = form.dtt;
                form1.ShowDialog();
                form.Close();

            }
        }

        private void barButtonItem85_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frbaobiaotongji aa = new Frbaobiaotongji();
            aa.ShowDialog();
        }

        private void barButtonItem86_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (yonghu == "桑甜" || yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "赵蕾蕾" || yonghu == "钱陆亦")
            {
                Frjixiaoidantongji form1 = new Frjixiaoidantongji();
                form1.ShowDialog();
            }
            else
            {


                MessageBox.Show("无权限！");
                return;
            }
        }

        private void barButtonItem31_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FrShezhi form = new FrShezhi();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void barButtonItem32_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

       

        private void barButtonItem33_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem59_ItemClick(object sender, ItemClickEventArgs e)
        {

            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem64_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem68_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem82_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem80_ItemClick(object sender, ItemClickEventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }


            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "精工(模具)事业部周报";
            Frjingongmujvzhoubao form1 = new Frjingongmujvzhoubao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem65_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem69_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem61_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem83_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem79_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem88_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem95_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem96_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem87_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (yonghu != "庄卫星" && yonghu != "钱陆亦" && yonghu != "桑甜")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "合同料单审核";
                Frhetongliaodanshencha form1 = new Frhetongliaodanshencha();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                //form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        

        private void barButtonItem90_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "技术指标审核";
            FrJinzhantixing form1 = new FrJinzhantixing();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "技术指标审核";
            FrJinzhantixing form1 = new FrJinzhantixing();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem93_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "技术指标审核";
            FrJinzhantixing form1 = new FrJinzhantixing();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "部门经理审核";
            Frjishubushenhe form1 = new Frjishubushenhe();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem91_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "部门经理审核";
            Frjishubushenhe form1 = new Frjishubushenhe();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem94_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "部门经理审核";
            Frjishubushenhe form1 = new Frjishubushenhe();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem97_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem99_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem100_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem101_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem102_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem103_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem104_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem105_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem110_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (yonghu != "庄卫星" && yonghu != "钱陆亦")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "采购料单审核";
                Frcaigoushenghe form1 = new Frcaigoushenghe();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem111_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem98_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem106_ItemClick(object sender, ItemClickEventArgs e)
        {
            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem107_ItemClick(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem108_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem92_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 市场审批 from tb_operator where 用户名='" + yonghu + "'";
            string 市场审批 = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (市场审批 != "1")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "待立项项目";
                FrXiangmuguanli1 form1 = new FrXiangmuguanli1();
                form1.yonghu = yonghu;
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.FormBorderStyle = FormBorderStyle.None;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }


        }

        private void barButtonItem112_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bumen != "市场部")
            {
                MessageBox.Show("无权限！");
                return;
            }
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "已审批项目";
            FrXiangmuguanli2 form1 = new FrXiangmuguanli2();
            form1.yonghu = yonghu;
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.FormBorderStyle = FormBorderStyle.None;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem113_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "总经理指示项";
            FrSearch1 form1 = new FrSearch1();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem292_ItemClick(object sender, ItemClickEventArgs e)
        {
            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem293_ItemClick(object sender, ItemClickEventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem294_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem295_ItemClick(object sender, ItemClickEventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }


            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "精工(模具)事业部周报";
            Frjingongmujvzhoubao form1 = new Frjingongmujvzhoubao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem300_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "待办指示项";
            FrDaiban form1 = new FrDaiban();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem301_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "技术指标审核";
            FrJinzhantixing form1 = new FrJinzhantixing();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem302_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "部门经理审核";
            Frjishubushenhe form1 = new Frjishubushenhe();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem299_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("此功能是部门需求采购，跟项目有关的采购请按照原先的模式进行,定时审查，如果是项目采购用了此采购功能将被考核！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "申购";
                Frgerengoumai form1 = new Frgerengoumai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem119_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bumen == "人力资源部")
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "离职管理";
                Frlizhi form1 = new Frlizhi();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;

            }
            if (bumen != "人力资源部")
            {
                if (yonghu == "钱陆亦" || yonghu == "庄卫星")
                {

                    XtraTabPage newPage = new XtraTabPage();
                    newPage.Text = "离职管理";
                    Frlizhi form1 = new Frlizhi();
                    form1.TopLevel = false;
                    newPage.Controls.Add(form1);
                    form1.Show();
                    form1.Dock = DockStyle.Fill;
                    xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;

                }
                if (yonghu != "钱陆亦" && yonghu != "庄卫星")
                {
                    MessageBox.Show("无权限！");
                    return;
                }
            }
        }

        private void barButtonItem143_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem154_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem176_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem122_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem306_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem165_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem187_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem199_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem211_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem222_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem232_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议室管理";
            FrAppointmentChaxun form1 = new FrAppointmentChaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem323_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bumen == "人力资源部")
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "提醒管理";
                Frdaitixing form1 = new Frdaitixing();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
            }
            else
            {
                MessageBox.Show("无权限！");
                return;
            }
        }

        private void barButtonItem303_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bumen == "人力资源部")
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "黑名单";
                Frheimingdan form1 = new Frheimingdan();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem324_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select *from tb_stutest ";
            string bumen = SQLhelp.ExecuteScalarxiangmuguanli(sql, CommandType.Text).ToString();
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "大学生维保评分";
            Frweibaodengji form1= new Frweibaodengji();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "销售概况";
            Frcaiwu form1 = new Frcaiwu();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {

            string sql = "select 权限管理 from tb_operator where 用户名='" + yonghu + "'";
            if (Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text)) == 0)
            {
                ribbonPage10.Visible = false;
            }
            if (yonghu == "郑坤")
            {
                zhuanzhengtixing();

                ribbonPage9.Visible = true;
                ribbonPageGroup29.Visible = true;
            }
            if (yonghu == "李野然")
            {
                hetongtixing();
                fushentixing();
                ribbonPage9.Visible = true;
                ribbonPageGroup29.Visible = true;
            }
            else
            {
                string sql1 = "select * from tb_operator where 用户名='" + yonghu + "'";
                DataTable dtt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (dtt.Rows[0]["用户名"].ToString() != "庄卫星" && dtt.Rows[0]["用户名"].ToString() != "钱陆亦" && dtt.Rows[0]["用户名"].ToString() != "赵蕾蕾" && dtt.Rows[0]["用户名"].ToString() != "桑甜" && dtt.Rows[0]["用户名"].ToString() != "王冬梅" && dtt.Rows[0]["用户名"].ToString() != "聂燕" && dtt.Rows[0]["用户名"].ToString() != "袁鹏" && dtt.Rows[0]["用户名"].ToString() != "徐魏魏" && dtt.Rows[0]["用户名"].ToString() != "蔡红兵" && dtt.Rows[0]["用户名"].ToString() != "韩小建")
                {
                    //if (dtt.Rows[0]["部门"].ToString() == "办公室")
                    //{
                    //    ribbonPageGroup1.Visible = true;
                    //    ribbonPageGroup12.Visible = true;
                    //    ribbonPageGroup2.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "薄材事业部")
                    //{
                    //    ribbonPage13.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "线缆事业部")
                    //{
                    //    ribbonPage13.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "新材事业部")
                    //{
                    //    ribbonPage13.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "智能事业部")
                    //{
                    //    ribbonPage13.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "石英事业部")
                    //{
                    //    ribbonPage13.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "信息化事业部")
                    //{
                    //    ribbonPage13.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;

                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "精工事业部")
                    //{
                    //    ribbonPage6.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "模具事业部")
                    //{
                    //    ribbonPage8.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "财务部")
                    //{
                    //    ribbonPage4.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "仓库")
                    //{
                    //    ribbonPageGroup1.Visible = true;
                    //    ribbonPageGroup12.Visible = true;
                    //    ribbonPageGroup2.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "技术部")
                    //{
                    //    ribbonPage13.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "人力资源部")
                    //{
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = true;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "市场部")
                    //{
                    //    ribbonPage11.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "物流部")
                    //{
                    //    ribbonPage12.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "研发部")
                    //{
                    //    ribbonPage14.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "质监部")
                    //{
                    //    ribbonPage3.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //    ribbonPageGroup29.Visible = false;
                    //}
                    //if (dtt.Rows[0]["部门"].ToString() == "总经办")
                    //{
                    //    ribbonPage7.Visible = true;
                    //    ribbonPage9.Visible = true;
                    //}

                }
                else
                {
                    //ribbonPageGroup1.Visible = true;
                    //ribbonPageGroup12.Visible = true;
                    //ribbonPageGroup2.Visible = true;
                    //ribbonPage13.Visible = true;
                    //ribbonPage6.Visible = true;
                    //ribbonPage4.Visible = true;
                    //ribbonPageGroup1.Visible = true;
                    //ribbonPageGroup2.Visible = true;
                    //ribbonPage9.Visible = true;
                    //ribbonPage11.Visible = true;
                    //ribbonPage14.Visible = true;
                    //ribbonPage3.Visible = true;
                    //ribbonPage7.Visible = true;
                    //ribbonPage5.Visible = true;
                    //ribbonPage12.Visible = true;
                    //ribbonPage8.Visible = true;
                }

                this.WindowState = FormWindowState.Maximized;
            }



        }

        private void barButtonItem325_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem327_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem329_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem331_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem333_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem335_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem337_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem339_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem341_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem343_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem345_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem326_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem328_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem330_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem332_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem334_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem336_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem338_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem340_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem342_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem344_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem346_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem327_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "个人报表";
            Frgerenbaobiao form1 = new Frgerenbaobiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem244_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "采购台账";
            Frcaigoutaizhang form1 = new Frcaigoutaizhang();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem328_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议指示项";
            FrSearch2 form1 = new FrSearch2();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem196_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem347_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确认上传公司级会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "会议";
                form.ShowDialog();
            }
        }

        private void barButtonItem8_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string sql1 = "select 提交时间 from tb_wenjian  where 员工姓名='" + yonghu + "' and 报告类型='周报'  ";

            DataTable jieguo = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                string jingqueshijian = jieguo.Rows[i]["提交时间"].ToString();
                DateTime shijian1 = Convert.ToDateTime(jingqueshijian);
                int dangqianweek = gc.GetWeekOfYear(shijian1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (dangqianweek == weekOfYear)
                {
                    MessageBox.Show("本周已经提交过周报，请勿重复提交！");
                    return;
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "常规周报";
            Frzhoubao1 form1 = new Frzhoubao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.zhonglei = "周报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem7_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string tianshu = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "Select 报告类型 From tb_wenjian Where 员工姓名 = '" + yonghu + "'and 日期 = '" + tianshu + "'";
            string yanzheng = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if (yanzheng == "日报")
            {
                MessageBox.Show("今天已经提交过日报！");
                return;

            }
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "日报";
            FRtijiaoribao1 form1 = new FRtijiaoribao1();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.panduan = "add";
            form1.zhonglei = "日报";
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem13_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "出差报告";
            Frchuchaibaogao form1 = new Frchuchaibaogao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem348_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "报表查阅";
            FrReport form1 = new FrReport();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem349_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "权限管理";
            FrOperator form1 = new FrOperator();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem350_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "会议指示项";
            FrSearch2 form1 = new FrSearch2();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem152_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem141_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem163_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem174_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem120_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem304_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem185_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem197_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem209_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem220_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem230_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "考核管理";
            Frkaohedan form1 = new Frkaohedan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage); xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem350_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确认上传部门级会议纪要吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShangchuan form = new FrShangchuan();
                form.yonghu = yonghu;
                form.zhonglei = "部门会议";
                form.ShowDialog();
            }
        }
    }
}