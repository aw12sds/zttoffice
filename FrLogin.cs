using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using NetWork.util;
using NetWorkLib.Net;
using NetWorkLib.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztoffice.view;
namespace ztoffice
{
    public partial class FrLogin : Form
    {
        public FrLogin()
        {
            InitializeComponent();
        }
        Frzhuyaojiemian aa = new Frzhuyaojiemian();
        private void Form1_Load(object sender, EventArgs e)
        {
            String versionlocal = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            label3.Text = versionlocal;
            version version = new version();
            getData getData = new getData();
            getData.getiprouter();
            //if (version.judgeversion(versionlocal) == true)
            //{
            //    this.Close();
            //    downloadexe downloadexe = new downloadexe();
            //    downloadexe.Show();
            //}
            //else
            //{
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("ztoffice");//获取指定的进程名   
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已启动！");
                Application.Exit();              //关闭系统
            }

            this.txtZerenren1.Text = Properties.Settings.Default.name;
            bool flag = Properties.Settings.Default.isrem;
            if (flag)
            {

                string sql_pass = "select 密码 from tb_operator where 用户名 = '" + txtZerenren1.Text.Trim() + "'";
                String password = Convert.ToString(SQLhelp.ExecuteScalar(sql_pass, CommandType.Text));
                this.checkbox1.Checked = true;
                this.txtPwd.Text = password;
            }

            string sql = "select 用户名 from tb_operator";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                //comboBox1.Items.Add(s);
            }
            //}
            
        }

        private void btnDenglu_Click(object sender, EventArgs e)
        {
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtZerenren1.Text = "";
            txtPwd.Text = "";
        }



        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDenglu_Click(sender, e);
            }
        }

        private void txtZerenren1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)//如果按了向上键
            //{
            //    int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
            //    if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
            //    {
            //        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
            //    }
            //    else
            //    {
            //        if (idx == 0)//等于零,表示此时选中的是在第一行.
            //        {
            //            listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
            //            idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
            //        }
            //        listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
            //    }
            //}
            //else if (e.KeyCode == Keys.Down)//如果按了向下键
            //{
            //    int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
            //    if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
            //    {
            //        //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
            //        listBox1.SelectedItem = listBox1.Items[0];
            //    }
            //    else
            //    {
            //        if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
            //        {
            //            listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
            //        }
            //        else
            //        {
            //            listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
            //        }
            //    }
            //    idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            //}
            //else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            //{
            //    //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
            //    if (listBox1.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("请选择对应的人员！");

            //        return;
            //    }

            //    int i = txtZerenren1.Text.LastIndexOf(";");
            //    if (i == -1)
            //    {
            //        string chongxin = "";
            //        chongxin = this.listBox1.SelectedItem.ToString() ;//把选中的值给文本框
            //        txtZerenren1.Text = chongxin;
            //        this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
            //        listBox1.Visible = false;//隐藏这个控件

            //    }
            //    if (i != -1)
            //    {
            //        string jiequ = txtZerenren1.Text.Substring(0, i + 1);

            //        txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
            //        this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
            //        listBox1.Visible = false;//隐藏这个控件
            //    }
            //}
        }

        private void txtZerenren1_TextChanged(object sender, EventArgs e)
        {

            //if (!txtZerenren1.Text.Contains("\r\n"))
            //{

            //    listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

            //    string sql = "select 用户名 from tb_operator ";
            //    DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //    int b = txtZerenren1.Text.LastIndexOf(";");

            //    if (b != -1)
            //    {
            //        string jiequ = txtZerenren1.Text.Substring(b + 1);


            //        DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
            //        DataTable newdtt = new DataTable(); //再新创建一个表,
            //        newdtt = dt.Clone();//复制dt表的所有结构

            //        foreach (DataRow row in drr)
            //        {
            //            newdtt.Rows.Add(row.ItemArray);
            //        }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



            //        if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
            //        {
            //            listBox1.Visible = true;      //listBox2显示出来  
            //            for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
            //            {
            //                listBox1.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
            //            }
            //        }

            //    }

            //    DataRow[] dr = dt.Select("用户名 like'%" + txtZerenren1.Text + "%'");
            //    DataTable newdt = new DataTable(); //再新创建一个表,
            //    newdt = dt.Clone();//复制dt表的所有结构

            //    foreach (DataRow row in dr)
            //    {
            //        newdt.Rows.Add(row.ItemArray);
            //    }

            //    if (newdt.Rows.Count > 0 && (txtZerenren1.Text != ""))
            //    {
            //        listBox1.Visible = true;
            //        for (int i = 0; i < newdt.Rows.Count; i++)
            //        {
            //            listBox1.Items.Add(newdt.Rows[i]["用户名"].ToString());//
            //        }
            //    }

            //    if (listBox1.Items.Count > 0)
            //    {
            //        listBox1.SelectedIndex = 0;

            //    }

            //}

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (listBox1.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请选择对应的人员");

            //    return;
            //}

            //int i = txtZerenren1.Text.LastIndexOf(";");
            //if (i == -1)
            //{
            //    string chongxin = "";
            //    chongxin = this.listBox1.SelectedItem.ToString() ;//把选中的值给文本框
            //    txtZerenren1.Text = chongxin;
            //    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
            //    listBox1.Visible = false;//隐藏这个控件

            //}
            //if (i != -1)
            //{
            //    string jiequ = txtZerenren1.Text.Substring(0, i + 1);

            //    txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
            //    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
            //    listBox1.Visible = false;//隐藏这个控件
            //}
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(txtZerenren1.Text.Trim()))
            {
                MessageBox.Show("登录用户不许为空！", "软件提示");

                return;
            }

            if (String.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("登录密码不许为空！", "软件提示");
                txtPwd.Focus();
                return;
            }
            //用户编码不重复
            string strSql = "select * from tb_operator where 用户名 = '" + txtZerenren1.Text.Trim() + "'";
            if (Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text)) == "")
            {
                MessageBox.Show("登录用户不正确！", "软件提示");

                return;
            }
            try
            {

                DataTable dt = SQLhelp.GetDataTable(strSql, CommandType.Text);
                DataRow dr = dt.Rows[0];



                string a = dt.Rows[0]["用户名"].ToString(); //用户名


                string ce = dt.Rows[0]["密码"].ToString();


                if (txtPwd.Text != dt.Rows[0]["密码"].ToString())  //若密码不相同
                {
                    MessageBox.Show("登录密码不正确！", "软件提示");
                    txtPwd.Focus();
                }
                else
                {
                    String Triton = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    version version = new version();
                    if(version.pluto(Triton, "zttoffice") && judgedepartment(a))
                    {
                        downloadexe downloadexe = new downloadexe();
                        downloadexe.ShowDialog();
                        this.Close();
                    }else if (version.pluto1(Triton))
                    {
                        version.setprocess();
                    }
               
                    else
                    {
                        BonusSkins.Register();
                        SkinManager.EnableFormSkins();
                        UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");  // 设置皮肤样式
                        getdevice getdevice = new getdevice();
                        getData getData = new getData();
                        //string s = Convert.ToDateTime(getData.getservertime());
                        Dictionary<string, string> dty = getdevice.getdevice1();
                        //getdevice.readdata(dt.Rows[0]["用户名"].ToString());
                        string sql = "insert into tb_denglu (登录人,登录时间,mac号,cpuid,硬盘序号,操作系统,内外网,公网ip,内网ip,显卡信息,机子类型,版本号) values('" + dt.Rows[0]["用户名"].ToString() + "','" + Convert.ToDateTime(getData.getservertime())
                           + "','" + dty["mac号"] + "','" + dty["cpuid"] + "','" + dty["硬盘序号"] + "','" + dty["操作系统"] + "','" + dty["内外网"] + "','" + dty["公网ip"] + "','" + dty["内网ip"] + "','" + dty["显卡信息"] + "','" + dty["机子类型"] + "','" + Triton + "')";
                        xiangmusql.ExecuteScalar(sql, CommandType.Text);

                        aa.yonghu = dt.Rows[0]["用户名"].ToString();
                        Properties.Settings.Default.isrem = this.checkbox1.Checked;
                        Properties.Settings.Default.name = this.txtZerenren1.Text;
                        Properties.Settings.Default.Save();

                        byte[] byData = new byte[100];
                        char[] charData = new char[1000];
                        FileStream file = new FileStream(Application.StartupPath + "\\提示.txt", FileMode.Open);
                        file.Seek(0, SeekOrigin.Begin);
                        file.Read(byData, 0, 100);
                        Decoder d = Encoding.Default.GetDecoder();
                        d.GetChars(byData, 0, byData.Length, charData, 0);

                        file.Close();

                        FileStream fs = new FileStream(Application.StartupPath + "\\提示.txt", FileMode.Open);
                        //获得字节数组
                        byte[] data = System.Text.Encoding.Default.GetBytes("1");
                        //开始写入
                        fs.Write(data, 0, data.Length);
                        //清空缓冲区、关闭流
                        fs.Flush();
                        fs.Close();
                        if (charData[0].ToString() == "0")
                        {
                            Frtishi form1 = new Frtishi();
                            form1.yonghu = dt.Rows[0]["用户名"].ToString();
                            form1.Show();
                            this.Hide();
                        }

                        string sql3 = "select mac号 from tb_mac where mac号='" + dty["mac号"] + "'";
                        DataTable dt1 = xiangmusql.GetDataTable(sql3, CommandType.Text);
                        if (dt1.Rows.Count < 1)
                        {
                            Frtishi1 Frtishi1 = new Frtishi1(dty["mac号"]);
                            Frtishi1.ShowDialog();
                        }
                        else
                        {
                            if (charData[0].ToString() == "1")
                            {
                                aa.Show();
                                this.Hide();
                            }
                        }
                    }





                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
            }

        }

        public static bool judgedepartment(string yonghu)
        {
            bool flag=false;
            version version = new version();
            string sql = "select * from tb_update";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            string sql1 = "select * from tb_operator where 用户名 = '" + yonghu + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string 服务器版本号= version.getversion("zttogffice");
            string 版本号=dt.Rows[0]["版本号"].ToString();
            string 部门 = dt.Rows[0]["部门"].ToString();
            string 人员 = dt.Rows[0]["人员"].ToString();
            if (服务器版本号.Equals(版本号))
            {
                if(部门.Contains(dt1.Rows[0]["部门"].ToString())){
                    flag = true;
                }
                if (人员.Contains(yonghu))
                {
                    flag = true;
                }
            }
            if (部门.Equals("全员"))
            {
                flag = true;
            }
            return flag;
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        
      
        private void txtPwd_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(sender, e);
                e.SuppressKeyPress = false;
            }
        }

        private void txtZerenren1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(sender, e);
                e.SuppressKeyPress = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string yonghu = txtZerenren1.Text.Trim();
            Frxiugaimima form1 = new Frxiugaimima();       
            form1.yonghu = yonghu;        
            form1.Show();
        }
    }
}


