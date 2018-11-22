using System;
using System.Data;
using System.Windows.Forms;
using ztoffice.Appointment11;
using ztoffice.dianjian;
using ztoffice.report;
using ztoffice.xuqiu;
using 项目管理系统;
using ztznpms.UI.查询项目;
using ztznpms;

namespace ztoffice
{
    public partial class Formzhujiemian : Form
    {
        public Formzhujiemian()
        {
            InitializeComponent();
        }
        public string yonghu;

        private void Formzhujiemian_Load(object sender, EventArgs e)
        {
            //labelX2.Text = "欢迎你！" + yonghu;

            string sql = "select 权限管理 from tb_operator where 用户名='" + yonghu + "'";
            if (Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text)) == 0)
            {
                appViewTile.Visible = false;
                Formchaxunxiangxi f = new Formchaxunxiangxi();
            }
        }

        private void metroTilePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void Formzhujiemian_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息

        }

        private void itemContainer1_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息

        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Close();//退出当前应用程序
            Frzhuyaojiemian.f1 = null;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//设置窗体最小化
        }

        private void newClientTile_Click(object sender, EventArgs e)
        {
            Frself form = new Frself();
            form.yonghu = yonghu;
            form.ShowDialog();

        }

        private void salesTile_Click(object sender, EventArgs e)
        {
            FrAppointmentChaxun form = new FrAppointmentChaxun();
            form.yonghu = yonghu;
            form.ShowDialog();

        }

        private void unpaidTile_Click(object sender, EventArgs e)
        {
            FrService form = new FrService();

            form.yonghu = yonghu;
            form.ShowDialog();

        }

        private void ytdTile_Click(object sender, EventArgs e)
        {
            FrSearch2 form = new FrSearch2();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void reportTile_Click(object sender, EventArgs e)
        {
            FrReport form = new FrReport();
            form.yonghu = yonghu;
            form.ShowDialog();
        }


        private void devCoTile_Click(object sender, EventArgs e)
        {
            FrLliulan form = new FrLliulan();
            form.yonghu = yonghu;
            form.ShowDialog();          
        }

        private void appViewTile_Click(object sender, EventArgs e)
        {
            FrOperator form = new FrOperator();            
            form.ShowDialog();           
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            FrSearch1 form = new FrSearch1();
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void newInvoiceTile_Click(object sender, EventArgs e)
        {
            FrDaiban form = new FrDaiban();         
            form.yonghu = yonghu;
            form.ShowDialog();          
        }

        private void Formzhujiemian_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            FrMain form = new FrMain();
            form.yonghu = yonghu;
           
            form.Show();
           
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            if(yonghu=="袁鹏"|| yonghu == "于爱青" || yonghu == "徐小明" || yonghu == "庄卫星" || yonghu == "桑甜" || yonghu == "聂燕" || yonghu == "蔡红兵" || yonghu == "徐魏魏" || yonghu == "赵蕾蕾" || yonghu == "王冬梅" || yonghu == "钱陆亦" || yonghu == "卫强")
            {
                FormMain form = new FormMain();
                form.yonghuming = yonghu;
                form.Show();
                
            }
            else
            {
                MessageBox.Show("无权限！");
                return;
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            
        }

        private void Formzhujiemian_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frzhuyaojiemian.f2 = null;
        }
    }
}
