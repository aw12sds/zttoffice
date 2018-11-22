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
    public partial class FrSearch1 : Office2007Form
    {
        public FrSearch1()
        {
            this.EnableGlass = false;//关键,
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
            if (yonghu == "桑甜")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='集团指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);

            }
            if (yonghu == "聂燕")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='集团指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "庄卫星")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='集团指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "赵蕾蕾")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='集团指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "徐魏魏")
            {
                 string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='集团指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "蔡红兵")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='集团指示项' ";
                dataGridViewX1.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "钱陆亦")
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
                dataGridViewX1.DataSource = dt;
            }




        }
        public void Reload4()
        {
            if (yonghu == "桑甜")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "聂燕")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "庄卫星")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "赵蕾蕾")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "徐魏巍")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "蔡红兵")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "钱陆亦")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,完成时间,已完成,完成时间节点,考核绩效点 from tb_xiangxi  where  已完成=1 and 纪要类型!='集团会议' and 纪要类型!='会议' and 纪要类型!='部门会议'";
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }

            
        }
        public void Reload2()
        {
            if (yonghu == "桑甜")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);

            }
            if (yonghu == "聂燕")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "庄卫星")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "赵蕾蕾")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "徐魏巍")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "蔡红兵")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='指示项' ";
                dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
            }
            if (yonghu == "钱陆亦")
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
                dataGridViewX2.DataSource = dt;
            }
            
        }
        public void Reload3()
        {
            if (yonghu != "钱陆亦")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='其他指示项' ";
                dataGridViewX3.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);

            }
            if (yonghu == "钱陆亦")
            {
                string strsql1 = "select id,会议时间,纪要内容,批复,纪要上传人,完成责任人,更新,是否有回复,完成时间节点,考核绩效点,关联责任人,指示项附件名称 from tb_xiangxi  where  已完成=0 and 纪要类型='其他指示项' ";
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
                dataGridViewX3.DataSource = dt;
            }
            
        }


        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认上传集团指示项吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                FrShangchuanzhishixiang form = new FrShangchuanzhishixiang();
                form.yonghu = yonghu;
                form.zhonglei = "集团指示项";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload();

                }
            }
          
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认上传总经理指示项吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                FrShangchuanzhishixiang form = new FrShangchuanzhishixiang();
                form.yonghu = yonghu;
                form.zhonglei = "指示项";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload2();

                }
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认上传其他指示项吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                FrShangchuanzhishixiang form = new FrShangchuanzhishixiang();
                form.yonghu = yonghu;
                form.zhonglei = "其他指示项";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload3();

                }
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人1"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["纪要内容1"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id1"].Value.ToString();
            string jiyaoshangchuanren = dataGridViewX1.CurrentRow.Cells["纪要上传人1"].Value.ToString();

            string sql = "select 关联责任人 from tb_xiangxi  where  id='"+id+"'";
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
                    string sql12 = "update tb_xiangxi  set 更新 = '' where id='"+id+"'";
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

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人2"].Value.ToString();
            string neirong = dataGridViewX2.CurrentRow.Cells["纪要内容2"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["会议时间2"].Value.ToString();
            string id = dataGridViewX2.CurrentRow.Cells["id2"].Value.ToString();
            string jiyaoshangchuanren = dataGridViewX2.CurrentRow.Cells["纪要上传人2"].Value.ToString();

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

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void dataGridViewX3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void dataGridViewX4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人1"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["纪要内容1"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            string id= dataGridViewX1.CurrentRow.Cells["id1"].Value.ToString();

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
                string jiedian = dataGridViewX1.CurrentRow.Cells["完成时间节点1"].Value.ToString();
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

            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人1"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["纪要内容1"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            string id1 = dataGridViewX1.CurrentRow.Cells["id1"].Value.ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='"+id1+"'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = dataGridViewX1.Rows[i].Cells["id1"].Value.ToString();
                    string shiijandianjie = dataGridViewX1.Rows[i].Cells["完成时间节点1"].Value.ToString();
                    if (shiijandianjie != "")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' where id= '" + id + "'";

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

            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX1.CurrentRow.Cells["完成责任人1"].Value.ToString();
            string neirong = dataGridViewX1.CurrentRow.Cells["纪要内容1"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id1"].Value.ToString();

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
            if (dataGridViewX1.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(dataGridViewX1.CurrentRow.Cells["指示项附件名称1"].Value) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(dataGridViewX1.CurrentRow.Cells["指示项附件名称1"].Value) != "")
            {
                //string zerenren = dataGridViewX1.CurrentRow.Cells["纪要内容1"].Value.ToString();
                //string shijian = dataGridViewX1.CurrentRow.Cells["会议时间1"].Value.ToString();
                string id = dataGridViewX1.CurrentRow.Cells["id1"].Value.ToString();
                string aa = "Select 指示项附件类型 From tb_xiangxi Where id='"+id+"'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();



                string mingcheng = Convert.ToString(dataGridViewX1.CurrentRow.Cells["指示项附件名称1"].Value);
                byte[] mypdffile = null;
                string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

                SqlConnection con = new SqlConnection(ConStr);
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "Select 指示项附件 From tb_xiangxi  Where id='" + id + "'";
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mypdffile = (byte[])dr.GetValue(0);
                }
                con.Close();
                //this.Cursor = Cursors.WaitCursor;

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
            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人2"].Value.ToString();
            string neirong = dataGridViewX2.CurrentRow.Cells["纪要内容2"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["会议时间2"].Value.ToString();
            string id = dataGridViewX2.CurrentRow.Cells["id2"].Value.ToString();

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
                string jiedian = dataGridViewX2.CurrentRow.Cells["完成时间节点2"].Value.ToString();
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

            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人2"].Value.ToString();
            string neirong = dataGridViewX2.CurrentRow.Cells["纪要内容2"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["会议时间2"].Value.ToString();
            string id = dataGridViewX2.CurrentRow.Cells["id2"].Value.ToString();

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

            string zerenren = dataGridViewX2.CurrentRow.Cells["完成责任人2"].Value.ToString();
            string neirong = dataGridViewX2.CurrentRow.Cells["纪要内容2"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["会议时间2"].Value.ToString();
            string id1 = dataGridViewX2.CurrentRow.Cells["id2"].Value.ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='" + id1 + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = dataGridViewX2.Rows[i].Cells["id2"].Value.ToString();
                    string shiijandianjie = dataGridViewX2.Rows[i].Cells["完成时间节点2"].Value.ToString();
                    if (shiijandianjie != "")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' where id= '" + id + "'";

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
            if (dataGridViewX2.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(dataGridViewX2.CurrentRow.Cells["指示项附件名称2"].Value) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(dataGridViewX2.CurrentRow.Cells["指示项附件名称2"].Value) != "")
            {
              
                string id = dataGridViewX2.CurrentRow.Cells["id2"].Value.ToString();
                string aa = "Select 指示项附件类型 From tb_xiangxi Where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();



                string mingcheng = Convert.ToString(dataGridViewX2.CurrentRow.Cells["指示项附件名称2"].Value);
                byte[] mypdffile = null;
                string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

                SqlConnection con = new SqlConnection(ConStr);
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "Select 指示项附件 From tb_xiangxi  Where id='" + id + "'";
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mypdffile = (byte[])dr.GetValue(0);
                }
                con.Close();
                //this.Cursor = Cursors.WaitCursor;

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
            if (dataGridViewX3.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string zerenren = dataGridViewX3.CurrentRow.Cells["完成责任人3"].Value.ToString();
            string neirong = dataGridViewX3.CurrentRow.Cells["纪要内容3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["会议时间3"].Value.ToString();

            string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='" + id + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != ren)
            {

                MessageBox.Show("无权限！");
                return;
            }

            try
            {
                string wanchengshijian = DateTime.Now.ToString();
                DateTime zuizhong = DateTime.Now;
                string jiedian = dataGridViewX3.CurrentRow.Cells["完成时间节点3"].Value.ToString();
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

        private void 批复ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (dataGridViewX3.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX3.CurrentRow.Cells["完成责任人3"].Value.ToString();
            string neirong = dataGridViewX3.CurrentRow.Cells["纪要内容3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["会议时间3"].Value.ToString();
            string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();

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

                Reload();

            }
        }

        private void 保存时间ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            string zerenren = dataGridViewX3.CurrentRow.Cells["完成责任人3"].Value.ToString();
            string neirong = dataGridViewX3.CurrentRow.Cells["纪要内容3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["会议时间3"].Value.ToString();
            string id1 = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();

            string chaxun = "select 纪要上传人 from tb_xiangxi  Where id='" + id1 + "'";
            string ren = SQLhelp.ExecuteScalar(chaxun, CommandType.Text).ToString();
            if (yonghu != "庄卫星")
            {

                MessageBox.Show("无权限！");
                return;
            }
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = dataGridViewX3.Rows[i].Cells["id3"].Value.ToString();
                    string shiijandianjie = dataGridViewX3.Rows[i].Cells["完成时间节点3"].Value.ToString();
                    if (shiijandianjie != "")
                    {
                        string sql2 = "update tb_xiangxi  set 完成时间节点= '" + Convert.ToDateTime(shiijandianjie) + "' where id= '" + id + "'";

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

        private void 查看指示项附件ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX3.Rows.Count <= 0)
            {
                MessageBox.Show("请选中行！");
                return;
            }
            if (Convert.ToString(dataGridViewX3.CurrentRow.Cells["指示项附件名称3"].Value) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(dataGridViewX3.CurrentRow.Cells["指示项附件名称3"].Value) != "")
            {

                string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();
                string aa = "Select 指示项附件类型 From tb_xiangxi Where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(aa, CommandType.Text).ToString();



                string mingcheng = Convert.ToString(dataGridViewX3.CurrentRow.Cells["指示项附件名称3"].Value);
                byte[] mypdffile = null;
                string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_office;user id=sa;password=zttZTT123";

                SqlConnection con = new SqlConnection(ConStr);
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "Select 指示项附件 From tb_xiangxi  Where id='" + id + "'";
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mypdffile = (byte[])dr.GetValue(0);
                }
                con.Close();
                
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

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX3.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX3.CurrentRow.Cells["完成责任人3"].Value.ToString();
            string neirong = dataGridViewX3.CurrentRow.Cells["纪要内容3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["会议时间3"].Value.ToString();
            string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();
            string jiyaoshangchuanren = dataGridViewX3.CurrentRow.Cells["纪要上传人3"].Value.ToString();

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

        private void dataGridViewX4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX4.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }

            string zerenren = dataGridViewX4.CurrentRow.Cells["完成责任人4"].Value.ToString();
            string neirong = dataGridViewX4.CurrentRow.Cells["纪要内容4"].Value.ToString();
            string shijian = dataGridViewX4.CurrentRow.Cells["会议时间4"].Value.ToString();
            string id = dataGridViewX4.CurrentRow.Cells["id4"].Value.ToString();
            string jiyaoshangchuanren = dataGridViewX4.CurrentRow.Cells["纪要上传人4"].Value.ToString();

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
    }
}
