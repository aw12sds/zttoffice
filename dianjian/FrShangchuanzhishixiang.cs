using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ztoffice.dianjian
{
    public partial class FrShangchuanzhishixiang : DevExpress.XtraEditors.XtraForm
    {
        public FrShangchuanzhishixiang()
        {
            
            InitializeComponent();
        }
        public string yonghu;
        public string zhonglei;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string lujing;


        private void FrShangchuanzhishixiang_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(FormSample_MouseWheel);

        }

        void FormSample_MouseWheel(object sender, MouseEventArgs e)
        {
            //获取光标位置
            Point mousePoint = new Point(e.X, e.Y);
            //换算成相对本窗体的位置
            mousePoint.Offset(this.Location.X, this.Location.Y);
            //判断是否在panel内
            if (panel1.RectangleToScreen(panel1.DisplayRectangle).Contains(mousePoint))
            {            
                  panel1.AutoScrollPosition = new Point(0, panel1.VerticalScroll.Value - e.Delta);
            }
        }


        
        
        private void txtZerenren1_TextChanged(object sender, EventArgs e)
        {


            if (!txtZerenren1.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                
                int b = txtZerenren1.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtZerenren1.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox1.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox1.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }
                
                DataRow[] dr = dt.Select("用户名 like'%" + txtZerenren1.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }
                
                if (newdt.Rows.Count > 0 && (txtZerenren1.Text != ""))
                {
                    listBox1.Visible = true;      
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox1.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }
              
                if (listBox1.Items.Count>0)
                {
                    listBox1.SelectedIndex = 0;
                    
                }
                
            }
            txtNeirong2.Enabled = true;
            txtZerenren2.Enabled = true;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
           if( listBox1.SelectedIndex==-1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtZerenren1.Text.LastIndexOf(";");
            if(i==-1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString() +";" ;//把选中的值给文本框
                txtZerenren1.Text = chongxin;
                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
           if(i!=-1)
            {
                 string jiequ=  txtZerenren1.Text.Substring(0,i+1);
                
                txtZerenren1.Text= jiequ+ this.listBox1.SelectedItem.ToString() + ";";
                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
            
        }

        private void txtZerenren1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox1.SelectedItem = listBox1.Items[0];
                }
                else
                {
                    if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtZerenren1.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString() + ";";//把选中的值给文本框
                    txtZerenren1.Text = chongxin;
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren1.Text.Substring(0, i + 1);

                    txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    listBox1.Visible = false;//隐藏这个控件
                }
            }
        }

        private void txtZerenren2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox2.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox2.SelectedItem = listBox2.Items[listBox2.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox2.SelectedItem = listBox2.Items[listBox2.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox2.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox2.SelectedItem = listBox2.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox2.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox2.SelectedItem = listBox2.Items[0];
                }
                else
                {
                    if (idx == listBox2.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox2.SelectedItem = listBox2.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox2.SelectedItem = listBox2.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox2.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox2.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtZerenren2.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox2.SelectedItem.ToString() + ";";//把选中的值给文本框
                    txtZerenren2.Text = chongxin;
                    this.txtZerenren2.SelectionStart = this.txtZerenren2.TextLength;
                    listBox2.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren2.Text.Substring(0, i + 1);

                    txtZerenren2.Text = jiequ + this.listBox2.SelectedItem.ToString() + ";";
                    this.txtZerenren2.SelectionStart = this.txtZerenren2.TextLength;
                    listBox2.Visible = false;//隐藏这个控件
                }
            }

        }

        private void txtZerenren2_TextChanged(object sender, EventArgs e)
        {
            if (!txtZerenren2.Text.Contains("\r\n"))
            {

                listBox2.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtZerenren2.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtZerenren2.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox2.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox2.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("用户名 like'%" + txtZerenren2.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (dt.Rows.Count > 0 && (txtZerenren2.Text != ""))
                {
                    listBox2.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox2.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }
                if (listBox2.Items.Count > 0)
                {
                    listBox2.SelectedIndex = 0;

                }

            }
            txtNeirong3.Enabled = true;
            txtZerenren3.Enabled = true;
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtZerenren2.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox2.SelectedItem.ToString() + ";";//把选中的值给文本框
                txtZerenren2.Text = chongxin;
                this.txtZerenren2.SelectionStart = this.txtZerenren2.TextLength;
                listBox2.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtZerenren2.Text.Substring(0, i + 1);

                txtZerenren2.Text = jiequ + this.listBox2.SelectedItem.ToString() + ";";
                this.txtZerenren2.SelectionStart = this.txtZerenren2.TextLength;
                listBox2.Visible = false;//隐藏这个控件
            }

        }

        private void txtZerenren3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox3.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox3.SelectedItem = listBox3.Items[listBox3.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox3.SelectedItem = listBox3.Items[listBox3.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox3.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox3.SelectedItem = listBox3.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox3.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox3.SelectedItem = listBox3.Items[0];
                }
                else
                {
                    if (idx == listBox3.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox3.SelectedItem = listBox3.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox3.SelectedItem = listBox3.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox3.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox3.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtZerenren3.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox3.SelectedItem.ToString() + ";";//把选中的值给文本框
                    txtZerenren3.Text = chongxin;
                    this.txtZerenren3.SelectionStart = this.txtZerenren3.TextLength;
                    listBox3.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren3.Text.Substring(0, i + 1);

                    txtZerenren3.Text = jiequ + this.listBox3.SelectedItem.ToString() + ";";
                    this.txtZerenren3.SelectionStart = this.txtZerenren3.TextLength;
                    listBox3.Visible = false;//隐藏这个控件
                }
            }

        }

        private void txtZerenren3_TextChanged(object sender, EventArgs e)
        {
            if (!txtZerenren3.Text.Contains("\r\n"))
            {

                listBox3.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtZerenren3.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtZerenren3.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox3.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox3.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("用户名 like'%" + txtZerenren3.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (dt.Rows.Count > 0 && (txtZerenren3.Text != ""))
                {
                    listBox3.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox3.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }
                if (listBox3.Items.Count > 0)
                {
                    listBox3.SelectedIndex = 0;

                }

            }
            txtNeirong4.Enabled = true;
            txtZerenren4.Enabled = true;
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox3.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtZerenren3.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox3.SelectedItem.ToString() + ";";//把选中的值给文本框
                txtZerenren3.Text = chongxin;
                this.txtZerenren3.SelectionStart = this.txtZerenren3.TextLength;
                listBox3.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtZerenren3.Text.Substring(0, i + 1);

                txtZerenren3.Text = jiequ + this.listBox3.SelectedItem.ToString() + ";";
                this.txtZerenren3.SelectionStart = this.txtZerenren3.TextLength;
                listBox3.Visible = false;//隐藏这个控件
            }


        }

        private void txtZerenren4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox4.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox4.SelectedItem = listBox4.Items[listBox4.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox4.SelectedItem = listBox4.Items[listBox4.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox4.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox4.SelectedItem = listBox4.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox4.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox4.SelectedItem = listBox4.Items[0];
                }
                else
                {
                    if (idx == listBox4.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox4.SelectedItem = listBox4.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox4.SelectedItem = listBox4.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox4.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox4.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtZerenren4.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox4.SelectedItem.ToString() + ";";//把选中的值给文本框
                    txtZerenren4.Text = chongxin;
                    this.txtZerenren4.SelectionStart = this.txtZerenren4.TextLength;
                    listBox4.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren4.Text.Substring(0, i + 1);

                    txtZerenren4.Text = jiequ + this.listBox4.SelectedItem.ToString() + ";";
                    this.txtZerenren4.SelectionStart = this.txtZerenren4.TextLength;
                    listBox4.Visible = false;//隐藏这个控件
                }
            }
        }

        private void txtZerenren4_TextChanged(object sender, EventArgs e)
        {
            if (!txtZerenren4.Text.Contains("\r\n"))
            {

                listBox4.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtZerenren4.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtZerenren4.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox4.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox4.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("用户名 like'%" + txtZerenren4.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (dt.Rows.Count > 0 && (txtZerenren4.Text != ""))
                {
                    listBox4.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox4.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }
                if (listBox4.Items.Count > 0)
                {
                    listBox4.SelectedIndex = 0;

                }

            }
            txtNeirong5.Enabled = true;
            txtZerenren5.Enabled = true;
        }

        private void listBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox4.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtZerenren4.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox4.SelectedItem.ToString() + ";";//把选中的值给文本框
                txtZerenren4.Text = chongxin;
                this.txtZerenren4.SelectionStart = this.txtZerenren4.TextLength;
                listBox4.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtZerenren4.Text.Substring(0, i + 1);

                txtZerenren4.Text = jiequ + this.listBox4.SelectedItem.ToString() + ";";
                this.txtZerenren4.SelectionStart = this.txtZerenren4.TextLength;
                listBox4.Visible = false;//隐藏这个控件
            }

        }

        private void txtZerenren5_TextChanged(object sender, EventArgs e)
        {
            if (!txtZerenren5.Text.Contains("\r\n"))
            {

                listBox5.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtZerenren5.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtZerenren5.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox5.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox5.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("用户名 like'%" + txtZerenren5.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (dt.Rows.Count > 0 && (txtZerenren5.Text != ""))
                {
                    listBox5.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox5.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }
                if (listBox5.Items.Count > 0)
                {
                    listBox5.SelectedIndex = 0;

                }

            }
            txtNeirong6.Enabled = true;
            txtZerenren6.Enabled = true;
        }

        private void listBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox5.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtZerenren5.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox5.SelectedItem.ToString() + ";";//把选中的值给文本框
                txtZerenren5.Text = chongxin;
                this.txtZerenren5.SelectionStart = this.txtZerenren5.TextLength;
                listBox5.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtZerenren5.Text.Substring(0, i + 1);

                txtZerenren5.Text = jiequ + this.listBox5.SelectedItem.ToString() + ";";
                this.txtZerenren5.SelectionStart = this.txtZerenren5.TextLength;
                listBox5.Visible = false;//隐藏这个控件
            }
        }

        private void txtZerenren5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox5.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox5.SelectedItem = listBox5.Items[listBox5.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox5.SelectedItem = listBox5.Items[listBox5.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox5.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox5.SelectedItem = listBox5.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox5.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox5.SelectedItem = listBox5.Items[0];
                }
                else
                {
                    if (idx == listBox5.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox5.SelectedItem = listBox5.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox5.SelectedItem = listBox5.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox5.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox5.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox5.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtZerenren5.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox5.SelectedItem.ToString() + ";";//把选中的值给文本框
                    txtZerenren5.Text = chongxin;
                    this.txtZerenren5.SelectionStart = this.txtZerenren5.TextLength;
                    listBox5.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren5.Text.Substring(0, i + 1);

                    txtZerenren5.Text = jiequ + this.listBox5.SelectedItem.ToString() + ";";
                    this.txtZerenren5.SelectionStart = this.txtZerenren5.TextLength;
                    listBox5.Visible = false;//隐藏这个控件
                }
            }
        }

        private void txtZerenren6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtZerenren6_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxX1.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@textBoxX1.Text);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    //txtMingcheng.Text = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(textBoxX1.Text, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (zhonglei == "指示项")
            {
                if (txtNeirong1.Text.Trim() != "")
                {
                    string a = txtZerenren1.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong1.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(i).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }

                    }

                }

                if (txtNeirong2.Text.Trim() != "")
                {
                    string a = txtZerenren2.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong2.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(2).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);

                        }
                    }
                }

                if (txtNeirong3.Text.Trim() != "")
                {
                    string a = txtZerenren3.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong3.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(3).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }
                    }
                }

                if (txtNeirong4.Text.Trim() != "")
                {
                    string a = txtZerenren4.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong4.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(4).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);



                        }
                    }
                }



                if (txtNeirong5.Text.Trim() != "")
                {
                    string a = txtZerenren5.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong5.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(5).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }
                    }
                }

                MessageBox.Show("上传成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();


            }

            if (zhonglei == "集团指示项")
            {
                if (txtNeirong1.Text.Trim() != "")
                {
                    string a = txtZerenren1.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong1.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(i).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '集团指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='集团指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }

                    }

                }

                if (txtNeirong2.Text.Trim() != "")
                {
                    string a = txtZerenren2.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong2.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(2).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '集团指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='集团指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);

                        }
                    }
                }

                if (txtNeirong3.Text.Trim() != "")
                {
                    string a = txtZerenren3.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong3.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(3).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '集团指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='集团指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }
                    }
                }

                if (txtNeirong4.Text.Trim() != "")
                {
                    string a = txtZerenren4.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong4.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(4).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '集团指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='集团指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);



                        }
                    }
                }



                if (txtNeirong5.Text.Trim() != "")
                {
                    string a = txtZerenren5.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong5.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(5).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '集团指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='集团指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }
                    }
                }

                MessageBox.Show("上传成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();



            }
            if (zhonglei == "其他指示项")
            {
                if (txtNeirong1.Text.Trim() != "")
                {
                    string a = txtZerenren1.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong1.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(i).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '其他指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='其他指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }

                    }

                }

                if (txtNeirong2.Text.Trim() != "")
                {
                    string a = txtZerenren2.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong2.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(2).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '其他指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='其他指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);

                        }
                    }
                }

                if (txtNeirong3.Text.Trim() != "")
                {
                    string a = txtZerenren3.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong3.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(3).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '其他指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='其他指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }
                    }
                }

                if (txtNeirong4.Text.Trim() != "")
                {
                    string a = txtZerenren4.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong4.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(4).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '其他指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='其他指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);

                        }
                    }
                }

                if (txtNeirong5.Text.Trim() != "")
                {
                    string a = txtZerenren5.Text;
                    string[] stime = a.Split(new Char[] { ';' });
                    for (int i = 0; i < stime.Length - 1; i++)
                    {
                        string wanchengzerenren = stime[i];
                        string jiyaoneirong = txtNeirong5.Text.Trim();
                        DateTime dangqian = DateTime.Now;
                        string shijian = dangqian.AddMinutes(5).ToString();
                        string sql = "INSERT INTO tb_xiangxi(会议时间,纪要内容,完成责任人,纪要上传人,纪要类型,已完成,会议主题) VALUES('" + shijian + "', '" + jiyaoneirong + "', '" + wanchengzerenren + "', '" + yonghu + "', '其他指示项',0,'" + yonghu + "')";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        if (textBoxX1.Text != "")
                        {
                            string sql2 = "update tb_xiangxi  set 指示项附件=@pic,指示项附件名称='" + fileName + "',指示项附件类型='" + fileType + "' where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + wanchengzerenren + "'  and  纪要上传人='" + yonghu + "' and  纪要类型='其他指示项'";
                            SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);


                        }
                    }
                }

                MessageBox.Show("上传成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}
