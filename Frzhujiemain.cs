using Microsoft.AspNet.SignalR.Client;
using NetWork.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztznpms;
using 项目管理系统;

namespace ztoffice
{
    public partial class Frzhujiemain : Form
    {
        public Frzhujiemain()
        {
            InitializeComponent();
            
        }
        public string yonghu;
        private void Frzhujiemain_Load(object sender, EventArgs e)
        { 
            labelX2.Text = "欢迎你！" + yonghu;
            NetWork3J NetWork3J = new NetWork3J(yonghu, "http://10.15.1.252:81/");
            NetWork3J.connection();


        }
      

        private void newClientTile_Click(object sender, EventArgs e)
        {
            Formzhujiemian form = new Formzhujiemian();
            form.yonghu = yonghu;
            form.ShowDialog();
           
        }

        private void unpaidTile_Click(object sender, EventArgs e)
        {
            FrMain form = new FrMain();
            form.yonghu = yonghu;
            form.ShowDialog();
           

        }

        private void ytdTile_Click(object sender, EventArgs e)
        {
            if (yonghu == "袁鹏" || yonghu == "于爱青" || yonghu == "徐小明" || yonghu == "庄卫星" || yonghu == "桑甜" || yonghu == "聂燕" || yonghu == "蔡红兵" || yonghu == "徐魏魏" || yonghu == "赵蕾蕾" || yonghu == "王冬梅" || yonghu == "钱陆亦" || yonghu == "卫强" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "石炜" || yonghu == "袁天坤" || yonghu == "吴贞国")
            {
                FormMain form = new FormMain();
                form.yonghuming = yonghu;
                form.ShowDialog();
              


            }
            else
            {
                MessageBox.Show("无权限！");
                return;
            }

        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //_conn.Stop();

        }

        private void Frzhujiemain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Frzhujiemain_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void itemContainer1_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void metroTilePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void labelX1_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void labelX2_MouseMove(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//设置窗体最小化
        }

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
    }
}
