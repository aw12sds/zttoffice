using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.renliziyuan
{
    public partial class Froakaoqin : Form
    {
        public Froakaoqin()
        {
            InitializeComponent();
        }

        private void Froakaoqin_Load(object sender, EventArgs e)
        {
            string sql1 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,请休假原因,请休假代理人,请休假开始日期,请休假开始时间,请休假结束日期,请休假结束时间,请休假天数,销假日期,销假时间,请假类型 from officeworkflow where 流程类型='请假'";
            gridControl1.DataSource = xiangmusql.GetDataTable(sql1, CommandType.Text);

            string sql2 = "select 申请日期,申请部门,申请人,职务,总计时数,加班日期,起讫时间,加班种类,加班开始时间,加班结束时间 from officeworkflow where 流程类型 = '加班'";
            gridControl2.DataSource = xiangmusql.GetDataTable(sql2, CommandType.Text);
            string sql3 = "select 申请日期,申请部门,申请人,职务,合计,是否为补假,起讫时间,调休原因,调休开始日期,调休结束日期,调休开始时间,调休结束时间 from officeworkflow where 流程类型 = '调休'";
            gridControl3.DataSource = xiangmusql.GetDataTable(sql3, CommandType.Text);
            string sql4 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,外出开始日期,外出开始时间,预计外出结束时间,实际外出结束时间,预计外出结束日期,预计外出结束时间,前往地点,前往联系人,外出事由,共计外出时间 from officeworkflow where 流程类型 = '外出'";
            gridControl4.DataSource = xiangmusql.GetDataTable(sql4, CommandType.Text);
            string sql5 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,出差开始日期,出差结束日期,出差开始时间,出差结束时间,出差地点,出差工作目的和内容,交通工具,预计出差费用,借款,乘坐飞机理由 from officeworkflow  where 流程类型 = '出差'";
            gridControl5.DataSource = xiangmusql.GetDataTable(sql5, CommandType.Text);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

                }

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

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {



            if (datejieshu.Text == "")
            {
                MessageBox.Show("请设定结束时间");
                return;
            }
            if (datekaishi.Text == "")
            {
                MessageBox.Show("请设定开始时间");
                return;
            }
            DateTime a = Convert.ToDateTime(datekaishi.Text);
            string aa=a.ToString("yyyy-MM-dd 00:00:00");
            DateTime b = Convert.ToDateTime(datejieshu.Text);
            string bb = b.ToString("yyyy-MM-dd 23:59:59");
            if (a > b)
            {
                MessageBox.Show("开始时间不能大于结束时间！");
                return;
            }

            DataTable zongbiao = new DataTable();
            zongbiao.Columns.Add("申请日期");
            zongbiao.Columns.Add("申请部门");
            zongbiao.Columns.Add("申请人");
            zongbiao.Columns.Add("职务");
            zongbiao.Columns.Add("总计时数");
            zongbiao.Columns.Add("是否为补假");
            zongbiao.Columns.Add("请休假原因");
            zongbiao.Columns.Add("请休假代理人");
            zongbiao.Columns.Add("请休假开始日期");
            zongbiao.Columns.Add("请休假开始时间");
            zongbiao.Columns.Add("请休假结束日期");
            zongbiao.Columns.Add("请休假结束时间");
            zongbiao.Columns.Add("请休假天数");
            zongbiao.Columns.Add("销假日期");
            zongbiao.Columns.Add("销假时间");
            zongbiao.Columns.Add("请假类型");


            DataTable zongbiao2 = new DataTable();
            zongbiao2.Columns.Add("申请日期");
            zongbiao2.Columns.Add("申请部门");
            zongbiao2.Columns.Add("申请人");
            zongbiao2.Columns.Add("职务");
            zongbiao2.Columns.Add("总计时数");
            zongbiao2.Columns.Add("加班日期");
            zongbiao2.Columns.Add("起讫时间");
            zongbiao2.Columns.Add("加班种类");
            zongbiao2.Columns.Add("加班开始时间");
            zongbiao2.Columns.Add("加班结束时间");


            DataTable zongbiao3 = new DataTable();
            zongbiao3.Columns.Add("申请日期");
            zongbiao3.Columns.Add("申请部门");
            zongbiao3.Columns.Add("申请人");
            zongbiao3.Columns.Add("职务");
            zongbiao3.Columns.Add("合计");
            zongbiao3.Columns.Add("是否为补假");
            zongbiao3.Columns.Add("起讫时间");
            zongbiao3.Columns.Add("调休原因");
            zongbiao3.Columns.Add("调休开始日期");
            zongbiao3.Columns.Add("调休结束日期");
            zongbiao3.Columns.Add("调休开始时间");
            zongbiao3.Columns.Add("调休结束时间");

            DataTable zongbiao4 = new DataTable();
            zongbiao4.Columns.Add("申请日期");
            zongbiao4.Columns.Add("申请部门");
            zongbiao4.Columns.Add("申请人");
            zongbiao4.Columns.Add("职务");
            zongbiao4.Columns.Add("总计时数");
            zongbiao4.Columns.Add("是否为补假");
            zongbiao4.Columns.Add("外出开始日期");
            zongbiao4.Columns.Add("外出开始时间");
            zongbiao4.Columns.Add("预计外出结束时间");
            zongbiao4.Columns.Add("实际外出结束时间");
            zongbiao4.Columns.Add("预计外出结束日期");
            zongbiao4.Columns.Add("实际外出结束日期");
            zongbiao4.Columns.Add("前往地点");
            zongbiao4.Columns.Add("前往联系人");
            zongbiao4.Columns.Add("外出事由");
            zongbiao4.Columns.Add("共计外出时间");


            DataTable zongbiao5 = new DataTable();
            zongbiao5.Columns.Add("申请日期");
            zongbiao5.Columns.Add("申请部门");
            zongbiao5.Columns.Add("申请人");
            zongbiao5.Columns.Add("职务");
            zongbiao5.Columns.Add("总计时数");
            zongbiao5.Columns.Add("是否为补假");
            zongbiao5.Columns.Add("出差开始日期");
            zongbiao5.Columns.Add("出差结束日期");
            zongbiao5.Columns.Add("出差开始时间");
            zongbiao5.Columns.Add("出差结束时间");
            zongbiao5.Columns.Add("出差地点");
            zongbiao5.Columns.Add("出差工作目的和内容");
            zongbiao5.Columns.Add("交通工具");
            zongbiao5.Columns.Add("预计出差费用");
            zongbiao5.Columns.Add("借款");
            zongbiao5.Columns.Add("乘坐飞机理由");
            

            string aaa = txtZerenren1.Text;

            string[] stime = aaa.Split(new Char[] { ';' });

            for (int i = 0; i < stime.Length - 1; i++)
            {

                string sql1 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,请休假原因,请休假代理人,请休假开始日期,请休假开始时间,请休假结束日期,请休假结束时间,请休假天数,销假日期,销假时间,请假类型 from officeworkflow where 流程类型='请假' and 申请人 like '%" + stime[i] + "%' and 实际申请日期>='"+aa+"' and 实际申请日期<='"+bb+"' ";
                DataTable dt = xiangmusql.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                string sql2 = "select 申请日期,申请部门,申请人,职务,总计时数,加班日期,起讫时间,加班种类,加班开始时间,加班结束时间 from officeworkflow where 流程类型 = '加班' and 申请人 like '%" + stime[i] + "%' and 实际申请日期 >='" + aa + "' and 实际申请日期<='" + bb + "' ";
                DataTable dt2 = xiangmusql.GetDataTable(sql2, CommandType.Text);
                zongbiao2.Merge(dt2, true, MissingSchemaAction.Ignore);


                string sql3 = "select 申请日期,申请部门,申请人,职务,合计,是否为补假,起讫时间,调休原因,调休开始日期,调休结束日期,调休开始时间,调休结束时间 from officeworkflow where 流程类型 = '调休' and 申请人 like '%" + stime[i] + "%' and 实际申请日期>='" + aa + "' and 实际申请日期<='" + bb + "' ";

                DataTable dt3 = xiangmusql.GetDataTable(sql3, CommandType.Text);
                zongbiao3.Merge(dt3, true, MissingSchemaAction.Ignore);


                string sql4 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,外出开始日期,外出开始时间,预计外出结束时间,实际外出结束时间,预计外出结束日期,实际外出结束日期,前往地点,前往联系人,外出事由,共计外出时间 from officeworkflow where 流程类型 = '外出'and 申请人 like '%" + stime[i] + "%' and 实际申请日期>='" + aa + "' and 实际申请日期<='" + bb + "' ";
                DataTable dt4 = xiangmusql.GetDataTable(sql4, CommandType.Text);
                zongbiao4.Merge(dt4, true, MissingSchemaAction.Ignore);



                string sql5 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,出差开始日期,出差结束日期,出差开始时间,出差结束时间,出差地点,出差工作目的和内容,交通工具,预计出差费用,借款,乘坐飞机理由 from officeworkflow  where 流程类型 = '出差'and 申请人 like '%" + stime[i] + "%'  and 实际申请日期>='" + aa + "' and 实际申请日期<='" + bb + "' ";
                DataTable dt5 = xiangmusql.GetDataTable(sql5, CommandType.Text);
                zongbiao5.Merge(dt5, true, MissingSchemaAction.Ignore);

            }

            gridControl1.DataSource = zongbiao;
            gridControl2.DataSource = zongbiao2;
            gridControl3.DataSource = zongbiao3;
            gridControl4.DataSource = zongbiao4;
            gridControl5.DataSource = zongbiao5;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DateTime a1 = Convert.ToDateTime(datekaishi.Text);
            string aaaa = a1.ToString("yyyy-MM-dd 00:00:00");
            DateTime b1 = Convert.ToDateTime(datejieshu.Text);
            string bbbb = b1.ToString("yyyy-MM-dd 23:59:59");
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                float a = 0;
                if (float.TryParse(gridView1.GetRowCellValue(i, "请休假天数").ToString(), out a) == false)
                {
                    int aaa = i + 1;
                    MessageBox.Show("第" + aaa + "行请假申请总计时数不是数字！,无法统计");
                    return;
                }
            }
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                float a = 0;
                if (float.TryParse(gridView2.GetRowCellValue(i, "总计时数").ToString(), out a) == false)
                {
                    int aaa = i + 1;
                    MessageBox.Show("第" + aaa + "行加班申请总计时数不是数字！,无法统计");
                    return;
                }
            }
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                float a = 0;
                if (float.TryParse(gridView3.GetRowCellValue(i, "合计").ToString(), out a) == false)
                {
                    int aaa = i + 1;
                    MessageBox.Show("第" + aaa + "行调休申请总计时数不是数字！,无法统计");
                    return;
                }
            }
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                float a = 0;
                if (float.TryParse(gridView4.GetRowCellValue(i, "总计时数").ToString(), out a) == false)
                {
                    int aaa = i + 1;
                    MessageBox.Show("第" + aaa + "行外出申请总计时数不是数字！,无法统计");
                    return;
                }
            }
            for (int i = 0; i < gridView5.RowCount; i++)
            {
                float a = 0;
                if (float.TryParse(gridView5.GetRowCellValue(i, "总计时数").ToString(), out a) == false)
                {
                    int aaa = i + 1;
                    MessageBox.Show("第" + aaa + "行出差申请总计时数不是数字！,无法统计");
                    return;
                }
            }
            string aa = txtZerenren1.Text;
            string[] stime = aa.Split(new Char[] { ';' });
            DataTable dtt = new DataTable();
            dtt.Columns.Add("姓名");
            dtt.Columns.Add("类型");
            dtt.Columns.Add("总计时数");
            for (int i = 0; i < stime.Length - 1; i++)
            {
                string sql1 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,请休假原因,请休假代理人,请休假开始日期,请休假开始时间,请休假结束日期,请休假结束时间,请休假天数,销假日期,销假时间,请假类型 from officeworkflow where 流程类型='请假' and 申请人 like '%"+stime[i]+ "%' and 实际申请日期>='" + aaaa + "' and 实际申请日期<='" + bbbb + "' ";
                DataTable qingjia =xiangmusql.GetDataTable(sql1, CommandType.Text);


                string sql2 = "select 申请日期,申请部门,申请人,职务,总计时数,加班日期,起讫时间,加班种类,加班开始时间,加班结束时间 from officeworkflow where 流程类型 = '加班' and 申请人 like '%" + stime[i] + "%' and 实际申请日期>='" + aaaa + "' and 实际申请日期<='" + bbbb + "' ";
                DataTable jiaban = xiangmusql.GetDataTable(sql2, CommandType.Text);


                string sql3 = "select 申请日期,申请部门,申请人,职务,合计,是否为补假,起讫时间,调休原因,调休开始日期,调休结束日期,调休开始时间,调休结束时间 from officeworkflow where 流程类型 = '调休' and 申请人 like '%" + stime[i] + "%' and 实际申请日期>='" + aaaa + "' and 实际申请日期<='" + bbbb + "' ";
                DataTable tiaoxiu = xiangmusql.GetDataTable(sql3, CommandType.Text);

                string sql4 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,外出开始日期,外出开始时间,预计外出结束时间,实际外出结束时间,预计外出结束日期,实际外出结束日期,前往地点,前往联系人,外出事由,共计外出时间 from officeworkflow where 流程类型 = '外出'and 申请人 like '%" + stime[i] + "%'  and 实际申请日期>='" + aaaa + "' and 实际申请日期<='" + bbbb + "' ";
                DataTable waichu = xiangmusql.GetDataTable(sql4, CommandType.Text);

                string sql5 = "select 申请日期,申请部门,申请人,职务,总计时数,是否为补假,出差开始日期,出差结束日期,加班开始时间,加班结束时间,出差地点,出差工作目的和内容,交通工具,预计出差费用,借款,乘坐飞机理由 from officeworkflow  where 流程类型 = '出差'and 申请人 like '%" + stime[i] + "%' and 实际申请日期>='" + aaaa + "' and 实际申请日期<='" + bbbb + "' ";
                DataTable chuchai = xiangmusql.GetDataTable(sql5, CommandType.Text);             
                if (qingjia.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("类型");
                    dt.Columns.Add("总计时数");
                    DataRow dr = dt.NewRow();
                    dr["姓名"]= stime[i];
                    dr["类型"] = "请假";                  
                    double shuliang = 0;
                    for (int j = 0; j < qingjia.Rows.Count; j++)
                    {
                        shuliang +=Convert.ToDouble( qingjia.Rows[j]["请休假天数"]);

                    }
                    dr["总计时数"] = shuliang;                   
                    dt.Rows.Add(dr);
                    dtt.Merge(dt, true, MissingSchemaAction.Ignore);
                }
            

                if (jiaban.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("类型");
                    dt.Columns.Add("总计时数");
                    DataRow dr = dt.NewRow();
                    dr["姓名"] = stime[i];
                    dr["类型"] = "加班";
                    double shuliang = 0;
                    for (int j = 0; j < jiaban.Rows.Count; j++)
                    {
                        shuliang += Convert.ToDouble(jiaban.Rows[j]["总计时数"]);


                    }
                    dr["总计时数"] = shuliang;
                    dt.Rows.Add(dr);
                    dtt.Merge(dt, true, MissingSchemaAction.Ignore);
                }
                if (tiaoxiu.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("类型");
                    dt.Columns.Add("总计时数");
                    DataRow dr = dt.NewRow();
                    dr["姓名"] = stime[i];
                    dr["类型"] = "调休";
                    double shuliang = 0;
                 
                    for (int j = 0; j < tiaoxiu.Rows.Count; j++)
                    {
                        shuliang += Convert.ToDouble(tiaoxiu.Rows[j]["合计"]);

                    }
                    dr["总计时数"] = shuliang;
                    dt.Rows.Add(dr);
                    dtt.Merge(dt, true, MissingSchemaAction.Ignore);
                }
                if (waichu.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("类型");
                    dt.Columns.Add("总计时数");
                    DataRow dr = dt.NewRow();
                    dr["姓名"] = stime[i];
                    dr["类型"] = "外出";
                    double shuliang = 0;
                    for (int j = 0; j < waichu.Rows.Count; j++)
                    {
                        shuliang += Convert.ToDouble(waichu.Rows[j]["总计时数"]);
                    }
                    dr["总计时数"] = shuliang;
                    dt.Rows.Add(dr);
                    dtt.Merge(dt, true, MissingSchemaAction.Ignore);
                }
                if (chuchai.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("类型");
                    dt.Columns.Add("总计时数");
                    DataRow dr = dt.NewRow();
                    dr["姓名"] = stime[i];
                    dr["类型"] = "出差";
                    double shuliang = 0;
                    for (int j = 0; j < chuchai.Rows.Count; j++)
                    {
                        shuliang += Convert.ToDouble(chuchai.Rows[j]["总计时数"]);

                    }
                    dr["总计时数"] = shuliang;
                    dt.Rows.Add(dr);
                    dtt.Merge(dt, true, MissingSchemaAction.Ignore);
                }
            }

            Frkaoqinzongbiao form1 = new Frkaoqinzongbiao();
            form1.dt = dtt;
            form1.ShowDialog();
        }
    }
}
