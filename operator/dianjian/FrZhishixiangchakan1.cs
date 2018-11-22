using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.dianjian
{
    public partial class FrZhishixiangchakan1 : Office2007Form
    {
        public FrZhishixiangchakan1()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string shijian;
        public string zerenren;
        public string jiyaoneirong;
        public string yonghu;
        public string jiyaoshangchuanren;

        public string dingwei;

        public string lujing;
        public string leixing;
        private void FrZhishixiangchakan_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string strsql1 = "select 创建时间,会议时间,纪要内容,落实措施,落实情况,纪要上传人,附件格式,附件名称,批复,完成责任人 from tb_zhishixiang  where 完成责任人='" + zerenren + "' and 会议时间='" + shijian + "' ";
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql1, CommandType.Text);
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }


            string fujiangeshi = dataGridViewX2.CurrentRow.Cells["附件格式"].Value.ToString();

            if (fujiangeshi == "")
            {
                MessageBox.Show("没有附件！");
                return;

            }

            string fujianmingcheng = dataGridViewX2.CurrentRow.Cells["附件名称"].Value.ToString();

            string chuangjianshijian = dataGridViewX2.CurrentRow.Cells["创建时间"].Value.ToString();
            string wanchengzerenren = dataGridViewX2.CurrentRow.Cells["完成责任人"].Value.ToString();

            string sql = "Select 附件 From tb_zhishixiang  Where 创建时间='" + chuangjianshijian + "' and  完成责任人='" + wanchengzerenren + "' ";

            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);


            string aaaa = System.Environment.CurrentDirectory;
            string lujing = aaaa + "\\" + fujianmingcheng + "." + fujiangeshi;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }
    }
}
