using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.shixiang
{
    public partial class FrShedingshijian : Office2007Form
    {
        public FrShedingshijian()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string shijian;
        public string zerenren;
        public string jiyaoneirong;
        public string yonghu;
        public string jiyaoshangchuanren;
        
        private void FrShedingshijian_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交吗？一旦提交无法再次更改完成时间！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string sql3 = "update tb_xiangxi  set 完成时间节点='" + dateTimePicker1.Value + "'  where 会议时间= '" + shijian + "' and  纪要内容='" + jiyaoneirong + "' and  完成责任人='" + zerenren + "'  and  纪要上传人='" + jiyaoshangchuanren + "'";
                SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
