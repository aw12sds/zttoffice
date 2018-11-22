using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztoffice.dianjian;
using ztoffice.shixiang;

namespace ztoffice.dianjian
{
    public partial class FrSearch1 : DevExpress.XtraEditors.XtraForm
    {
        public FrSearch1()
        {
            
            InitializeComponent();
        }
        public string yonghu;
        private void FrSearch1_Load(object sender, EventArgs e)
        {
            Reload();
            Reload2();
            Reload3();
            Reload4();
        }
        
        public  void Reload()
        {
            if (yonghu == "桑甜" || yonghu == "聂燕" || yonghu == "庄卫星" || yonghu == "赵蕾蕾" || yonghu == "徐魏魏" || yonghu == "蔡红兵" || yonghu == "钱陆亦" )
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='集团指示项' ";
                DataTable dt = SQLhelp.GetDataTable(strsql1, CommandType.Text);
                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string jiedan = dt.Rows[i]["完成时间节点"].ToString();

                    if (jiedan != "")
                    {
                        DateTime kaishi = Convert.ToDateTime(dt.Rows[i]["会议时间"]);
                        DateTime jieshu = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]);

                        string kaishi1 = Convert.ToDateTime(DateTime.Now).ToString("yyyy - MM - dd");

                        string jieshu1 = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]).ToString("yyyy - MM - dd");

                        string zerenren = dt.Rows[i]["完成责任人"].ToString();
                        string neirong = dt.Rows[i]["纪要内容"].ToString();
                        string shijian = dt.Rows[i]["会议时间"].ToString();

                        if (jieshu1 != kaishi1)
                        {

                            if (zuizhong < jieshu)
                            {
                                string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                            if (zuizhong > jieshu)
                            {
                                TimeSpan shijianshu = zuizhong - jieshu;

                                int shuliang = Convert.ToInt32(shijianshu.TotalDays - 0.5);
                                int shuliang1 = (Convert.ToInt32((shuliang / 7)) + 1) * 2;

                                string xiugai = "update tb_xiangxi set  考核绩效点='" + shuliang1 + "' Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                            }

                        }
                        if (jieshu1 == kaishi1)
                        {
                            string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                        }
                    }
                }
                gridControl2.DataSource = dt;
            }
        }
        public void Reload4()
        {
            if (yonghu == "桑甜"|| yonghu == "聂燕"|| yonghu == "庄卫星"|| yonghu == "赵蕾蕾"|| yonghu == "徐魏魏"|| yonghu == "蔡红兵" || yonghu == "钱陆亦")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                gridControl1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
                
            }
       
        }
        public void Reload2()
        {
            string sql = "select 级别 from tb_operator where  用户名='" + yonghu + "'";
            string jibie = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            if (yonghu == "桑甜" || yonghu == "聂燕" || yonghu == "庄卫星" || yonghu == "赵蕾蕾" || yonghu == "徐魏魏" || yonghu == "蔡红兵" || yonghu == "钱陆亦")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                DataTable dt = SQLhelp.GetDataTable(strsql1, CommandType.Text);

                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string jiedan = dt.Rows[i]["完成时间节点"].ToString();

                    if (jiedan != "")
                    {
                        DateTime kaishi = Convert.ToDateTime(dt.Rows[i]["会议时间"]);
                        DateTime jieshu = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]);

                        string kaishi1 = Convert.ToDateTime(DateTime.Now).ToString("yyyy - MM - dd");

                        string jieshu1 = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]).ToString("yyyy - MM - dd");

                        string zerenren = dt.Rows[i]["完成责任人"].ToString();
                        string neirong = dt.Rows[i]["纪要内容"].ToString();
                        string shijian = dt.Rows[i]["会议时间"].ToString();

                        if (jieshu1 != kaishi1)
                        {

                            if (zuizhong < jieshu)
                            {
                                string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                            if (zuizhong > jieshu)
                            {
                                TimeSpan shijianshu = zuizhong - jieshu;

                                int shuliang = Convert.ToInt32(shijianshu.TotalDays - 0.5);
                                int shuliang1 = (Convert.ToInt32((shuliang / 7)) + 1) * 2;

                                string xiugai = "update tb_xiangxi set  考核绩效点='" + shuliang1 + "' Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                        }
                        if (jieshu1 == kaishi1)
                        {
                            string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                        }

                    }
                }
                gridControl3.DataSource = dt;
            }
            if (jibie == "经理")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                DataTable dt = SQLhelp.GetDataTable(strsql1, CommandType.Text);

                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string jiedan = dt.Rows[i]["完成时间节点"].ToString();

                    if (jiedan != "")
                    {
                        DateTime kaishi = Convert.ToDateTime(dt.Rows[i]["会议时间"]);
                        DateTime jieshu = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]);

                        string kaishi1 = Convert.ToDateTime(DateTime.Now).ToString("yyyy - MM - dd");

                        string jieshu1 = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]).ToString("yyyy - MM - dd");

                        string zerenren = dt.Rows[i]["完成责任人"].ToString();
                        string neirong = dt.Rows[i]["纪要内容"].ToString();
                        string shijian = dt.Rows[i]["会议时间"].ToString();

                        if (jieshu1 != kaishi1)
                        {

                            if (zuizhong < jieshu)
                            {
                                string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                            if (zuizhong > jieshu)
                            {
                                TimeSpan shijianshu = zuizhong - jieshu;

                                int shuliang = Convert.ToInt32(shijianshu.TotalDays - 0.5);
                                int shuliang1 = (Convert.ToInt32((shuliang / 7)) + 1) * 2;

                                string xiugai = "update tb_xiangxi set  考核绩效点='" + shuliang1 + "' Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                                SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                            }

                        }
                        if (jieshu1 == kaishi1)
                        {
                            string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                        }

                    }
                }
                gridControl3.DataSource = dt;
            }
            
        }
        public void Reload3()
        {

            string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='其他指示项' and 纪要上传人='"+yonghu+"' ";
            DataTable dt = SQLhelp.GetDataTable(strsql1, CommandType.Text);

            string wanchengshijian = DateTime.Now.ToString();
            DateTime zuizhong = DateTime.Now;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string jiedan = dt.Rows[i]["完成时间节点"].ToString();

                if (jiedan != "")
                {
                    DateTime kaishi = Convert.ToDateTime(dt.Rows[i]["会议时间"]);
                    DateTime jieshu = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]);

                    string kaishi1 = Convert.ToDateTime(DateTime.Now).ToString("yyyy - MM - dd");

                    string jieshu1 = Convert.ToDateTime(dt.Rows[i]["完成时间节点"]).ToString("yyyy - MM - dd");

                    string zerenren = dt.Rows[i]["完成责任人"].ToString();
                    string neirong = dt.Rows[i]["纪要内容"].ToString();
                    string shijian = dt.Rows[i]["会议时间"].ToString();

                    if (jieshu1 != kaishi1)
                    {

                        if (zuizhong < jieshu)
                        {
                            string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                        }

                        if (zuizhong > jieshu)
                        {
                            TimeSpan shijianshu = zuizhong - jieshu;

                            int shuliang = Convert.ToInt32(shijianshu.TotalDays - 0.5);
                            int shuliang1 = (Convert.ToInt32((shuliang / 7)) + 1) * 2;

                            string xiugai = "update tb_xiangxi set  考核绩效点='" + shuliang1 + "' Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                            SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                        }

                    }
                    if (jieshu1 == kaishi1)
                    {
                        string xiugai = "update tb_xiangxi set 考核绩效点=0  Where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' and 纪要内容='" + neirong + "'";
                        SQLhelp.ExecuteScalar(xiugai, CommandType.Text);

                    }

                }
            }
            gridControl4.DataSource = dt;

        }
        
        

       

        

       
       

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "会议时间").ToString();
            string id= gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='"+id+"'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }

            try
            {
                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;
                string jiedian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "完成时间节点").ToString();
                if (jiedian == "")
                {
                    MessageBox.Show("请先让责任人输入完成时间节点，再确认完成");
                    return;

                }
                if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    string xiugai = "update tb_xiangxi set 已完成=1,完成时间='" + wanchengshijian + "' Where id='" + id + "'";
                    SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                    MessageBox.Show("确认成功！");
                    Reload();
                   
                }


            }

            catch (Exception ex)

            {

                MessageBox.Show("发生错误：" + ex.Message);

            }
        }

        private void 保存时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string zerenren = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "会议时间").ToString();
            string id1 = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='"+id1+"'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                    string shiijandianjie = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "完成时间节点").ToString();
                    string jixiaodian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "考核绩效点").ToString();
                    if (shiijandianjie != "")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' ,考核绩效点='"+jixiaodian+"'where id= '" + id + "'";

                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                    }

                }
                MessageBox.Show("修改成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void 批复ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "会议时间").ToString();
            string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

            string sql = "select 纪要上传人 from tb_xiangxi   Where id='" + id + "'";
            string shangchuanren = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();


            if (yonghu != "庄卫星")
            {
                MessageBox.Show("非指示项发起人无权限批复！");
                return;

            }

            FrZhishixiangpifu form = new FrZhishixiangpifu();
            form.zerenren = zerenren;
            form.shijian = shijian;
            form.id = id;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {

                Reload2();

            }
        }

        private void 查看指示项附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "指示项附件名称")) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "指示项附件名称")) != "")
            {
                //string zerenren = dataGridViewX1.CurrentRow.Cells["纪要内容1"].Value.ToString();
                //string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
                string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                string aa = "Select 指示项附件类型 From tb_xiangxi Where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();



                string mingcheng = Convert.ToString(gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "指示项附件名称"));
                byte[] mypdffile = null;


                string sql = "Select 指示项附件 From tb_xiangxi  Where id='" + id + "'";
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);


                try
                {
                    Random ran = new Random();

                    string aaaa = System.Environment.CurrentDirectory;
                    string lujing = aaaa + "\\" + mingcheng + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    System.Diagnostics.Process.Start(lujing);
                }
                catch { }
            }
            

        }

        private void 确认完成ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gridView3.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "会议时间").ToString();
            string id = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='" + id + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }

            try
            {
                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;
                string jiedian = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "完成时间节点").ToString();
                if (jiedian == "")
                {
                    MessageBox.Show("请先让责任人输入完成时间节点，再确认完成");
                    return;

                }
                if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    string xiugai = "update tb_xiangxi set 已完成=1,完成时间='" + wanchengshijian + "' Where id='" + id + "'";
                    SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                    MessageBox.Show("确认成功！");
                    Reload2();

                }


            }

            catch (Exception ex)

            {

                MessageBox.Show("发生错误：" + ex.Message);

            }
        }

        private void 批复ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (gridView3.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "会议时间").ToString();
            string id = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();

            string sql = "select 纪要上传人 from tb_xiangxi   Where id='" + id + "'";
            string shangchuanren = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();


            if (yonghu != "庄卫星")
            {
                MessageBox.Show("非指示项发起人无权限批复！");
                return;

            }

            FrZhishixiangpifu form = new FrZhishixiangpifu();
            form.zerenren = zerenren;
            form.shijian = shijian;
            form.id = id;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {

                Reload2();

            }
        }

        private void 保存时间ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            string zerenren = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "会议时间").ToString();
            string id1 = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='" + id1 + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    string id = gridView3.GetRowCellValue(i, "id").ToString();
                    string shiijandianjie = gridView3.GetRowCellValue(i, "完成时间节点").ToString();
                    string jixiaodian = gridView3.GetRowCellValue(i, "考核绩效点").ToString();
                    if (shiijandianjie != "")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "',考核绩效点='"+jixiaodian+"' where id= '" + id + "'";

                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                    }

                }
                MessageBox.Show("修改成功！");
                Reload2();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void 查看指示项附件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gridView3.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "指示项附件名称")) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "指示项附件名称")) != "")
            {
              
                string id = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();
                string aa = "Select 指示项附件类型 From tb_xiangxi Where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();



                string mingcheng = Convert.ToString(gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "指示项附件名称"));
                byte[] mypdffile = null;
               
                string sql= "Select 指示项附件 From tb_xiangxi  Where id='" + id + "'";
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                try
                {
                    Random ran = new Random();

                    string aaaa = System.Environment.CurrentDirectory;
                    string lujing = aaaa + "\\" + mingcheng + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    System.Diagnostics.Process.Start(lujing);
                }
                catch { }
            }
        }

        private void 确认完成ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "会议时间").ToString();

            string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();

            try
            {
                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;
                string jiedian = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "完成时间节点").ToString();
                if (jiedian == "")
                {
                    MessageBox.Show("请先让责任人输入完成时间节点，再确认完成");
                    return;

                }
                if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    string xiugai = "update tb_xiangxi set 已完成=1,完成时间='" + wanchengshijian + "' Where id='" + id + "'";
                    SQLhelp.ExecuteScalar(xiugai, CommandType.Text);
                    MessageBox.Show("确认成功！");
                    Reload3();

                }
                
            }
            catch (Exception ex)

            {
                MessageBox.Show("发生错误：" + ex.Message);

            }
        }

        private void 批复ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (gridView4.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "会议时间").ToString();
            string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();

            FrZhishixiangpifu form = new FrZhishixiangpifu();
            form.zerenren = zerenren;
            form.shijian = shijian;
            form.id = id;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {

                Reload3();

            }
        }

        private void 保存时间ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (yonghu == "庄卫星")
            {
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
                    string shiijandianjie = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "完成时间节点").ToString();
                    if (shiijandianjie != "")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' where id= '" + id + "'";

                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                    }

                }
                MessageBox.Show("修改成功！");
                Reload();
            }

            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string jiyaoshangchuanren = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "纪要上传人").ToString();
                string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
                string shiijandianjie = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "完成时间节点").ToString();

                if (shiijandianjie != "")
                {
                    
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' where id= '" + id + "'";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);                

                }
            }
            MessageBox.Show("修改成功！");
            Reload3();


        }

        private void 查看指示项附件ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "指示项附件名称")) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "指示项附件名称")) != "")
            {

                string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
                string aa = "Select 指示项附件类型 From tb_xiangxi Where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();



                string mingcheng = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "指示项附件名称"));
                byte[] mypdffile = null;
                
                string sql = "Select 指示项附件 From tb_xiangxi  Where id='" + id + "'";
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);

                try
                {
                    Random ran = new Random();

                    string aaaa = System.Environment.CurrentDirectory;
                    string lujing = aaaa + "\\" + mingcheng + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                    System.Diagnostics.Process.Start(lujing);
                }
                catch { }
            }
        }

       

       

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            string zerenren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "完成责任人"));
            string neirong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要内容"));
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "会议时间"));
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string jiyaoshangchuanren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "纪要上传人"));
            string sql = "select 关联责任人 from tb_xiangxi  where  id='" + id + "'";
            string shangchuanren = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            FrZhishixiangchakan1 form = new FrZhishixiangchakan1();
            form.jiyaoneirong = neirong;
            form.shijian = shijian;
            form.zerenren = zerenren;
            form.dingwei = id;
            form.yonghu = yonghu;
            form.jiyaoshangchuanren = jiyaoshangchuanren;
            form.ShowDialog();
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

        

        

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        
        private void 查看详情ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (gridView3.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "会议时间").ToString();
            string id = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();
            string jiyaoshangchuanren = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "纪要上传人").ToString();

            string sql = "select 关联责任人 from tb_xiangxi  where  id='" + id + "'";
            string shangchuanren = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));


            if (shangchuanren != "")
            {
                FrZhishixaingchakan form = new FrZhishixaingchakan();
                form.jiyaoneirong = neirong;
                form.shijian = shijian;
                form.zerenren = zerenren;
                form.dingwei = id;
                form.yonghu = yonghu;
                form.jiyaoshangchuanren = jiyaoshangchuanren;
                form.ShowDialog();

            }
            if (shangchuanren == "")
            {
                if (yonghu == "庄卫星")
                {
                    string sql12 = "update tb_xiangxi  set 更新 = '' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);

                    Reload();
                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;
                    form.dingwei = id;
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }


                if (yonghu != "庄卫星")
                {

                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;
                    form.dingwei = id;
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }

            }
        }

        private void 查看详情ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "会议时间").ToString();
            string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            string jiyaoshangchuanren = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "纪要上传人").ToString();

            string sql = "select 关联责任人 from tb_xiangxi  where  id='" + id + "'";
            string shangchuanren = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));


            if (shangchuanren != "")
            {
                FrZhishixaingchakan form = new FrZhishixaingchakan();
                form.jiyaoneirong = neirong;
                form.shijian = shijian;
                form.zerenren = zerenren;
                form.dingwei = id;
                form.yonghu = yonghu;
                form.jiyaoshangchuanren = jiyaoshangchuanren;
                form.ShowDialog();

            }
            if (shangchuanren == "")
            {
                if (yonghu == "庄卫星")
                {
                    string sql12 = "update tb_xiangxi  set 更新 = '' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);

                    Reload();
                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;
                    form.dingwei = id;
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }


                if (yonghu != "庄卫星")
                {

                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;
                    form.dingwei = id;
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }


            }
        }

        private void 查看详情ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "完成责任人").ToString();
            string neirong = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "纪要内容").ToString();
            string shijian = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "会议时间").ToString();
            string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            string jiyaoshangchuanren = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "纪要上传人").ToString();

            string sql = "select 关联责任人 from tb_xiangxi  where  id='" + id + "'";
            string shangchuanren = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));


            if (shangchuanren != "")
            {
                FrZhishixaingchakan form = new FrZhishixaingchakan();
                form.jiyaoneirong = neirong;
                form.shijian = shijian;
                form.zerenren = zerenren;
                form.dingwei = id;
                form.yonghu = yonghu;
                form.jiyaoshangchuanren = jiyaoshangchuanren;
                form.ShowDialog();

            }
            if (shangchuanren == "")
            {
                if (yonghu == "庄卫星")
                {
                    string sql12 = "update tb_xiangxi  set 更新 = '' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);

                    Reload();
                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;
                    form.dingwei = id;
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }
                if (yonghu != "庄卫星")
                {
                    FrZhishixaingchakan form = new FrZhishixaingchakan();
                    form.jiyaoneirong = neirong;
                    form.shijian = shijian;
                    form.zerenren = zerenren;
                    form.dingwei = id;
                    form.yonghu = yonghu;
                    form.jiyaoshangchuanren = jiyaoshangchuanren;
                    form.ShowDialog();
                }
            }
        }
    }
}
