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
    public partial class Frxinzengdangan : DevExpress.XtraEditors.XtraForm
    {
        public Frxinzengdangan()
        {
            InitializeComponent();
        }

        private void Frxinzengdangan_Load(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_zuzhibumen";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                combumen.Properties.Items.Add(dt.Rows[i]["部门"].ToString());
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("确认添加员工档案吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (txtxingming.Text.Trim() == "")
                {
                    MessageBox.Show("请填写姓名！");
                    return;
                }

                if (txtkaoqinhao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写考勤号！");
                    return;
                }
                if (txtjituanyuangongbianhao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写集团员工编号！");
                    return;
                }
                if (txtgongsizibianhao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写公司子编号！");
                    return;
                }
                if (combumen.Text.Trim() == "")
                {
                    MessageBox.Show("请选择部门！");
                    return;
                }
                if (txtzhiwu.Text.Trim() == "")
                {
                    MessageBox.Show("请填写职务！");
                    return;

                }
                if (comxingbie.Text.Trim() == "")
                {
                    MessageBox.Show("请选择性别！");
                    return;
                }
                if (txtshenfenzhenghao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写身份证号！");
                    return;
                }
                if (txtshenfenzhenghao.Text.Length != 18)
                {
                    MessageBox.Show("身份证号18位。");
                    return;
                }
                if (txtxianjvzhudizhi.Text.Trim() == "")
                {
                    MessageBox.Show("请填写现居住地址！");
                    return;
                }
                if (comhukouxingzhi.Text.Trim() == "")
                {
                    MessageBox.Show("请选择户口性质！");
                    return;
                }
                if (txtjiguan.Text.Trim() == "")
                {
                    MessageBox.Show("请填写籍贯！");
                    return;

                }
                if (comquanrizhixueli.Text.Trim() == "")
                {
                    MessageBox.Show("请选择全日制学历！");
                    return;
                }
                if (txtquanrizhibiyexuexiao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写全日制毕业学校！");
                    return;
                }
                if (txtquanrizhizhuanye.Text.Trim() == "")
                {
                    MessageBox.Show("请填写全日制专业！");
                    return;
                }

                if (comzhengzhimianmao.Text.Trim() == "")
                {
                    MessageBox.Show("请选择政治面貌！");
                    return;
                }
                if (txtlianxifangshi.Text.Trim() == "")
                {
                    MessageBox.Show("请填写联系方式！");
                    return;
                }
                if (txtlianxifangshi.Text.Length!=11)
                {
                    MessageBox.Show("电话号码11位。");
                    return;
                }
                if (txtjinjilianxiren.Text.Trim() == "")
                {
                    MessageBox.Show("请填写紧急联系人电话！");
                    return;
                }
                if (txtjinjilianxiren.Text.Length != 11)
                {
                    MessageBox.Show("电话号码11位。");
                    return;
                }
                if (dateruzhi.Text.Trim() == "")
                {
                    MessageBox.Show("请填写入职日期！");
                    return;
                }
                if (datezhuanzheng.Text.Trim() == "")
                {
                    MessageBox.Show("请填写转正日期！");
                    return;
                }
                if (txthetongqiandingqixian1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同签订期限Ⅰ！");
                    return;
                }
                if (datedaoqi1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到期时间Ⅰ！");
                    return;
                }
                if (txthetongqiandingdanwei1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同签订单位Ⅰ！");
                    return;
                }

                if (txtanquanxieyi.Text.Trim() == "")
                {
                    MessageBox.Show("请填写安全协议！");
                    return;
                }
                if (txtlianjiezilvchengnuoshu.Text.Trim() == "")
                {
                    MessageBox.Show("请填写廉洁自律承诺书！");
                    return;
                }
                if (comgongjijin.Text.Trim() == "")
                {
                    MessageBox.Show("请填写公积金状态！");
                    return;
                }
                if (txtgongjijinjiaonajishu.Text.Trim() == "")
                {
                    MessageBox.Show("请填写公积金缴纳基数！");
                    return;
                }
                if (txtyinhangkahao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写银行卡号！");
                    return;
                }
                if (txtyinhangkahao.Text.Length!=19)
                {
                    MessageBox.Show("工商银行卡号19位");
                    return;
                }

                string sql2 = "select * from tb_danganbiao";
                DataTable dt = SQLhelp.GetDataTable(sql2, CommandType.Text);

                string 年份 = datechushengriqi.Text;
                DateTime dt1 = Convert.ToDateTime(年份);
                string yy = dt1.Year.ToString();
                string mm = dt1.Month.ToString();
                string age = DateTime.Now.Year.ToString();
                int age1 = int.Parse(age);
                int age2 = int.Parse(yy);
                int age3 = age1 - age2;
                string age4 = Convert.ToString(age3);
                string sql1 = "insert into tb_danganbiao (姓名,考勤号,集团员工编号,公司子编号,部门,职务,性别,身份证号,出生日期,出生年,出生月,年龄,户籍地址,现居住地址,户口性质,籍贯,全日制学历,全日制毕业学校,全日制专业,第二学历,毕业学校,专业,政治面貌,入党时间,联系方式,集团短号,座机号,紧急联系人电话,集团邮箱地址,入职日期,计划转正日期,转岗日期,合同签订期限1,合同到期时间1,合同签订单位1,合同签订期限2,合同到期时间2,合同签订单位2,合同签订期限3,合同到期时间3,合同签订单位3,安全协议,廉洁自律承诺书,作业证书,初领日期,初审日期,复审日期,外部职称1,获得证书时间1,外部职称2,获得证书时间2,集团聘职称,车牌号,宿舍号,入住日期,退宿日期,合同发放,公积金状态,公积金缴纳基数,银行卡号,备注 ) values ('" + txtxingming.Text + "','" + txtkaoqinhao.Text + "','" + txtjituanyuangongbianhao.Text + "','" + txtgongsizibianhao.Text + "','" + combumen.Text + "','" + txtzhiwu.Text + "','" + comxingbie.Text + "','" + txtshenfenzhenghao.Text + "','" + datechushengriqi.Text + "','" + yy + "','" + mm + "','" + age4 + "','" + txthujidizhi.Text + "','" + txtxianjvzhudizhi.Text + "','" + comhukouxingzhi.Text + "','" + txtjiguan.Text + "','" + comquanrizhixueli.Text + "','" + txtquanrizhibiyexuexiao.Text + "','" + txtquanrizhizhuanye.Text + "','" + comdierxueli.Text + "','" + txtbiyeyuanxiao.Text + "','" + txtzhuanye.Text + "','" + comzhengzhimianmao.Text + "','" + daterudang.Text + "','" + txtlianxifangshi.Text + "','" + txtjituanduahao.Text + "','" + txtzuojihao.Text + "','" + txtjinjilianxiren.Text + "','" + txtjituanyouxiangdizhi.Text + "','" + dateruzhi.Text + "','" + datezhuanzheng.Text + "','" + datezhuangang.Text + "','" + txthetongqiandingqixian1.Text + "','" + datedaoqi1.Text + "','" + txthetongqiandingdanwei1.Text + "','" + txthetongqiandingqixian2.Text + "','" + datedaoqi2.Text + "','" +txthetongqiandingdanwei2.Text + "','" + txthetongqiandingqixian3.Text + "','" + datedaoqi3.Text + "','" + txthetongqiandingdanwei3.Text + "','" + txtanquanxieyi.Text + "','" + txtlianjiezilvchengnuoshu.Text + "','" + combozhengshu.Text + "','" + datechulingriqi.Text + "','" + datechushenriqi.Text + "','" + datefushenriqi.Text + "','" + txtwaibuzhichen1.Text + "','" + datehuodezhengshushijian1.Text + "','" + txtwaibuzhichen2.Text + "','" + datehuodezhengshushijian2.Text + "','" + txtjituanpinzhichen.Text + "','" + txtchepaihao.Text + "','" + txtsushehao.Text + "','" + dateriuzhu.Text + "','" + datetuisu.Text + "','" + txthetongfafang.Text + "','" + comgongjijin.Text + "','" + txtgongjijinjiaonajishu.Text + "','" + txtyinhangkahao.Text + "','" + txtbeizhu.Text + "')";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                MessageBox.Show("提交成功！");
                this.Close();
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}