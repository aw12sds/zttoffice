using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.xuqiu
{
    public partial class FrXuqiu : Office2007Form
    {
    
        public FrXuqiu()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;
        public string bumen;
        private void FrXuqiu_Load(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='"+yonghu+"'";
            bumen= SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim() == "")
            {
                MessageBox.Show("请输入需求内容！");
                return;
            }
            if (MessageBox.Show("确认添加吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string sql = "INSERT INTO tb_xuqiu(需求部门,需求人,需求事宜,需求时间) VALUES ('" + bumen + "','" + yonghu + "','" + textBoxX1.Text + "','" + DateTime.Now + "')";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
