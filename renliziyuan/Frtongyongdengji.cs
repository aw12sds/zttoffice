using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztoffice.renliziyuan
{
    public partial class Frtongyongdengji : DevExpress.XtraEditors.XtraForm
    {
        public Frtongyongdengji()
        {
            InitializeComponent();
        }
        public string yonghu;
       
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认新增通用培训信息吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string sql = "select * from tb_operator where 类别='大学生'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    
                    string sql1 = " insert into tb_Stutypeixun (时间,培训课程,考核方式,考核时间,负责人,命题人,被培训人 ) values ('"+dateEdit1.Text+ "','" + txtpeixunkecheng.Text + "','"+ comboBoxMethod.Text+ "','"+datetest.Text+"','"+ textEditfuze.Text+ "','"+ textEditmingti.Text+ "','"+dt.Rows[i]["用户名"].ToString()+"')";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                    
                }
                MessageBox.Show("插入成功！");
                this.Close();


            }



            }

        private void Frtongyongdengji_Load(object sender, EventArgs e)
        {

        }
        public  void Reload()
        {

          

        }
    }
}