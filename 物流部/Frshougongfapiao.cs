using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztoffice.物流部
{
    public partial class Frshougongfapiao : DevExpress.XtraEditors.XtraForm
    {
        public Frshougongfapiao()
        {
            InitializeComponent();
        }
        public string id;
        public string hetonghao;
        public string hetongzongjia;
        public string fapiaojia;
        public string gongfangmingcheng;
        public string caigouyuan;
        public string yonghu;
        private void Frshougongfapiao_Load(object sender, EventArgs e)
        {
            txthetonghao.Text = hetonghao;
            txthetongzongjia.Text = hetongzongjia;
            txtjine.Text = fapiaojia;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            float a = 0;
            if (float.TryParse(txtjine.Text, out a) == false)
            {             
                MessageBox.Show("发票金额必须是数字！");
                return;
            }
        
            
            string sql = "select * from tb_caigoutaizhang where id='" + id + "'";
            DataTable dtt = SQLhelp1.GetDataTable(sql, CommandType.Text);
            string fapiaohao = dtt.Rows[0]["发票编号"].ToString();
            string fapiaohao1 = fapiaohao + txtfapiaohao.Text + ";";
            string fapiaojine = dtt.Rows[0]["发票金额"].ToString();
            string fapiaojine1 = dtt.Rows[0]["发票金额"].ToString() + txtjine.Text + ";";
            string fapiaoriqi = dtt.Rows[0]["发票开具日期"].ToString();
            string fapiaoriqi1 = dtt.Rows[0]["发票开具日期"].ToString() + txtkaipiao.Text + ";";
            string dangqianriqi = dtt.Rows[0]["发票收到日期"].ToString();
            string dangqianriqi1 = dtt.Rows[0]["发票收到日期"].ToString() + DateTime.Now.ToString("yyyyMMdd") + ";";
            double hetongzongjia = Convert.ToDouble(dtt.Rows[0]["合同总价"]);


            string[] sArray = fapiaojine1.Split(new char[1] { ';' });
            double zongjia1 = 0;
            double zongjia=0;
            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i] != "")
                {
                    double c = Convert.ToDouble(sArray[i]);
                    zongjia1 += c;
                    string kn = (zongjia1).ToString("N2");
                    zongjia = Convert.ToDouble(kn);
                }
            }

            if (hetongzongjia == zongjia)
            {
                string sql3 = "update tb_caigoutaizhang set 发票状态='全到' where id='" + id + "' ";
                SQLhelp1.ExecuteScalar(sql3, CommandType.Text);
            }
            if (hetongzongjia > zongjia)
            {
                string sql3 = "update tb_caigoutaizhang set 发票状态='已到部分' where id='" + id + "' ";
                SQLhelp1.ExecuteScalar(sql3, CommandType.Text);
            }
            if (hetongzongjia < zongjia)
            {
                MessageBox.Show("发票金额大于合同金额！");
                return;
            }
            string sql2 = "update tb_caigoutaizhang set 发票编号='" + fapiaohao1 + "' ,发票金额='" + fapiaojine1 + "' ,发票开具日期='" + fapiaoriqi1 + "',发票收到日期='" + dangqianriqi1 + "' where id='" + id + "' ";
            SQLhelp1.ExecuteScalar(sql2, CommandType.Text);

            string sql1111 = "insert into tb_fapiaodengjibiao (收到发票日期,供方名称,发票编号,发票日期,发票金额,合同号,采购员,提交人,备注)  values('" + DateTime.Now.ToString("yyyyMMdd") + "' ,'" + gongfangmingcheng + "' ,'" + txtfapiaohao.Text + "' ,'" + txtkaipiao.Text + "' ,'" + txtjine.Text + "' ,'" + txthetonghao.Text + "' ,'" + caigouyuan + "','" + yonghu + "','" + txtbeizhu.Text + "')";
            SQLhelp1.ExecuteScalar(sql1111, CommandType.Text);

            MessageBox.Show("提交成功！");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}