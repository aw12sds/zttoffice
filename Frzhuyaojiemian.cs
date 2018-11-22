using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetWork.util;
using 项目管理系统;
using DevExpress.XtraBars.Ribbon;
using ztoffice;
using System.Runtime.InteropServices;
using NetWorkLib;
using ztznpms;

namespace ztoffice
{
    public partial class Frzhuyaojiemian : DevExpress.XtraEditors.XtraForm
    {
        public Frzhuyaojiemian()
        {
            //this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            InitializeComponent();
        }
        public string yonghu;
        public static RibbonForm1 f1;

        public static newFormMain f3;
        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (f1 == null)
            {
                f1 = new RibbonForm1(yonghu);//将主窗体对象传递过去
                f1.yonghu = yonghu;
                f1.Show();//显示窗体二

            }
            else
            {
                f1.Activate();
                f1 = null;
            }
        }
        public static Frxiangmuguanli f2;
        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (f2 == null)
            {
                f2 = new Frxiangmuguanli();//将主窗体对象传递过去
                f2.yonghu = yonghu;
                f2.Show();//显示窗体二
            }
            else
            {
                f2.Activate();
                f2 = null;
            }
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            string sql = "select * from tb_operator where 用户名='" + yonghu + "'";
            DataTable dtt = sqlhelp111.GetDataTable(sql, CommandType.Text);
            string yuancailiao = Convert.ToString(dtt.Rows[0]["生产执行系统权限"]);
            //string wujinfucaicaigou = Convert.ToString(dtt.Rows[0]["五金辅材采购"]);
            if (yuancailiao == "1")
            {

                    if (f3 == null)
                    {
                        f3 = new newFormMain();//将主窗体对象传递过去   
                        f3.yonghu = yonghu;
                        f3.Show();//显示窗体二
                    }
                    else
                    {
                        f3.Activate();
                        f3 = null;
                    }


                }
                else
                {
                    MessageBox.Show("无权限！");
                    return;
                
            }
        }

        private void tileControl1_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void Frzhuyaojiemian_Load(object sender, EventArgs e)
        {
            labelControl1.Text = yonghu;
            NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
            NetWork3J.connection();
            string a = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string b = a.Substring(a.Length - 2, 2);
            Frzhuyaojiemian form1 = new Frzhuyaojiemian();
            //this.Text = "ZOMS." + b;
            Bitmap bm = new Bitmap(System.Environment.CurrentDirectory + "\\" + "男.jpg");
            pictureEdit1.Image = null;
            pictureEdit1.Image = bm;

            timer2.Interval = 1;
            timer2.Start();
            timer3.Start();

        }
        
        private void Frzhuyaojiemian_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
        [DllImport("User32.dll")]
        public static extern bool PtInRect(ref Rectangle r, Point p);
        private void Frzhuyaojiemian_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            System.Drawing.Point pp = new Point(Cursor.Position.X, Cursor.Position.Y);
            Rectangle Rects = new Rectangle(this.Left, this.Top, this.Left + this.Width, this.Top + this.Height);

            if ((this.Top < 0 && Frzhuyaojiemian.PtInRect(ref Rects, pp)))     //这里的Form2是窗体的名字
            {
                this.Top = 0;
            }
            else
            {
                if (this.Top > -5 && this.Top < 5 && !(Frzhuyaojiemian.PtInRect(ref Rects, pp)))
                {
                    this.Top = 2 - this.Height;
                }
            }
        }
        bool suo = false;
        string type = "";
        private void timer2_Tick(object sender, EventArgs e)
        {
            Point pt = new Point(Form.MousePosition.X, Form.MousePosition.Y);//获得当前鼠标位置 
            Screen screen = Screen.PrimaryScreen;
            int width = screen.Bounds.Width;         //宽 
            int height = screen.Bounds.Height;         //高
            if (!this.Bounds.Contains(pt))//判断鼠标是否在窗体内 
            {
                if (suo == false)
                {
                    if (this.Location.X < 10)
                    {
                        this.Left = -this.Width + 5;
                        suo = true;
                        type = "left";
                    }
                    else if (width - this.Location.X - this.Width < 10)
                    {
                        this.Left = width - 5;
                        suo = true;
                        type = "right";
                    }
                    else if (this.Location.Y < 10)
                    {
                        this.Top = -this.Height + 5;
                        suo = true;
                        type = "up";
                    }                 
                }

            }
            else
            {
                if (this.Location.X > 20 && type == "left")
                {
                    suo = false;
                }
                else if (width - this.Location.X - this.Width > 20 && type == "right")
                {
                    suo = false;
                }
                else if (this.Location.Y > 20 && type == "up")
                {
                    suo = false;
                }          
                if (suo == true)
                {
                    if (type == "left")
                    {
                        this.Left = 0;
                        suo = false;
                    }
                    else if (type == "right")
                    {
                        this.Left = width - this.Width;
                        suo = false;
                    }
                    else if (type == "up")
                    {
                        this.Top = 0;
                        suo = false;
                    }

                }
            }

        }
        int WM_NCLBUTTONDBLCLK = 0xA3;

        int h = 100;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                if (this.Height < 35)
                {
                    this.Height = h;
                }
                else
                {
                    h = this.Height;
                    this.Height = -10;
                }
                return;
            }
            base.WndProc(ref m);
        }       
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        private void 打开主页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (yonghu == "袁天坤")
            {
                string sql1 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 加工单位备注='自制' and 完成='机修待审批' and 当前状态='待责任人审核' order by 接单日期";
                DataTable dt = SQLhelp.GetDataTablexiangmuguanli(sql1, CommandType.Text);
                if (dt.Columns.Count > 0)
                {
                    MessageBox.Show("有自制机修件待审批");
                }
            }
            else if (yonghu == "袁鹏")
            {
                string sql1 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 加工单位备注='自制' and 完成='机修待审批' and 当前状态='机修待袁鹏审批'  order by 接单日期";
                DataTable dt = SQLhelp.GetDataTablexiangmuguanli(sql1, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("有自制机修件待审批");
                }
            }
            else if (yonghu == "于嘉嘉")
            {
                string sql1 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 加工单位备注='外协' and 完成='机修待审批'  order by 接单日期";
                DataTable dt = SQLhelp.GetDataTablexiangmuguanli(sql1, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("有外协机修件待审批");
                }
            }
        }
        //private void Form1_SizeChanged(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Minimized)
        //    {
        //        this.Hide();
        //        this.notifyIcon1.Visible = true;
        //        this.notifyIcon1.ShowBalloonTip(30, "注意", "大家好，这是一个事例", ToolTipIcon.Info);
        //    }
        //}
    }
}
