using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Aspose.Cells;

namespace ztoffice.renliziyuan
{
    public partial class Frdangan : DevExpress.XtraEditors.XtraForm
    {
        public Frdangan()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frdangan_Load(object sender, EventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
           
            
            

            if (yonghu == "桑甜"||yonghu=="齐景景")
            {
                string sql1 = "select * from tb_danganbiao where 离职=''or 离职 is null";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
                this.gridView1.IndicatorWidth = 40;
                gridView1.Columns.ColumnByName("姓名").Fixed =DevExpress.XtraGrid.Columns.FixedStyle.Left;

                string sql2 = "select 部门 from tb_operator where 用户名='" + yonghu + "'";

                DataTable dtt = SQLhelp.GetDataTable(sql2, CommandType.Text);
                离职ToolStripMenuItem.Visible = false;
                转正ToolStripMenuItem.Visible = false;
                确认合同签订ToolStripMenuItem.Visible = false;
                确认复审ToolStripMenuItem.Visible = false;
                确认水电费ToolStripMenuItem.Visible = false;
                gridView1.Columns["考勤号"].Visible = false;
                gridView1.Columns["集团员工编号"].Visible = false;
                gridView1.Columns["公司子编号"].Visible = false;
                gridView1.Columns["部门"].Visible = true;
                gridView1.Columns["职务"].Visible = true;
                gridView1.Columns["性别"].Visible = false;
                gridView1.Columns["身份证号"].Visible = false;
                gridView1.Columns["出生日期"].Visible = false;
                gridView1.Columns["出生年"].Visible = false;
                gridView1.Columns["出生月"].Visible = false;
                gridView1.Columns["年龄"].Visible = false;
                gridView1.Columns["户籍地址"].Visible = false;
                gridView1.Columns["现居住地址"].Visible = false;
                gridView1.Columns["户口性质"].Visible = false;
                gridView1.Columns["籍贯"].Visible = false;
                gridView1.Columns["全日制学历"].Visible = false;
                gridView1.Columns["全日制毕业学校"].Visible = false;
                gridView1.Columns["全日制专业"].Visible = false;
                gridView1.Columns["第二学历"].Visible = false;
                gridView1.Columns["毕业学校"].Visible = false;
                gridView1.Columns["专业"].Visible = false;
                gridView1.Columns["政治面貌"].Visible = false;
                gridView1.Columns["入党时间"].Visible = false;
                gridView1.Columns["入职日期"].Visible = false;
                gridView1.Columns["计划转正日期"].Visible = false;
                gridView1.Columns["转岗日期"].Visible = false;
                gridView1.Columns["合同签订期限1"].Visible = false;
                gridView1.Columns["合同到期时间1"].Visible = false;
                gridView1.Columns["合同签订单位1"].Visible = false;
                gridView1.Columns["合同签订期限2"].Visible = false;
                gridView1.Columns["合同到期时间2"].Visible = false;
                gridView1.Columns["合同到期时间2"].Visible = false;
                gridView1.Columns["合同签订期限3"].Visible = false;
                gridView1.Columns["合同到期时间3"].Visible = false;
                gridView1.Columns["合同签订单位3"].Visible = false;
                gridView1.Columns["安全协议"].Visible = false;
                gridView1.Columns["廉洁自律承诺书"].Visible = false;
                gridView1.Columns["特种作业证书"].Visible = false;
                gridView1.Columns["初领日期"].Visible = false;
                gridView1.Columns["复审日期"].Visible = false;
                gridView1.Columns["外部职称1"].Visible = false;
                gridView1.Columns["获得证书时间1"].Visible = false;
                gridView1.Columns["外部职称2"].Visible = false;
                gridView1.Columns["获得证书时间2"].Visible = false;
                gridView1.Columns["集团聘职称"].Visible = false;
                gridView1.Columns["宿舍号"].Visible = false;

                gridView1.Columns["入住日期"].Visible = false;
                gridView1.Columns["退宿日期"].Visible = false;
                gridView1.Columns["员工手册"].Visible = false;
                gridView1.Columns["合同发放"].Visible = false;
                gridView1.Columns["安全教育卡"].Visible = false;
                gridView1.Columns["公积金状态"].Visible = false;
                gridView1.Columns["保险缴纳基数"].Visible = false;
                gridView1.Columns["银行卡号"].Visible = false;
                gridView1.Columns["实际转正日期"].Visible = false;
                gridView1.Columns["是否转正"].Visible = false;
                gridView1.Columns["是否签订合同1"].Visible = false;
                gridView1.Columns["合同签订单位2"].Visible = false;
                gridView1.Columns["是否签订合同2"].Visible = false;
                gridView1.Columns["是否签订合同3"].Visible = false;
                gridView1.Columns["是否已复审"].Visible = false;
                gridView1.Columns["水电费是否结清"].Visible = false;
                gridView1.Columns["是否发放合同1"].Visible = false;
                gridView1.Columns["是否发放合同2"].Visible = false;
                gridView1.Columns["是否发放合同3"].Visible = false;

            }
            if (yonghu == "王茜" )
            {
                string sql1 = "select * from tb_danganbiao where 离职=''or 离职 is null";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
                this.gridView1.IndicatorWidth = 40;
                gridView1.Columns.ColumnByName("姓名").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                string sql2 = "select 部门 from tb_operator where 用户名='" + yonghu + "'";

                DataTable dtt = SQLhelp.GetDataTable(sql2, CommandType.Text);
                离职ToolStripMenuItem.Visible = false;
                转正ToolStripMenuItem.Visible = false;
                确认合同签订ToolStripMenuItem.Visible = false;
                确认复审ToolStripMenuItem.Visible = false;
                确认水电费ToolStripMenuItem.Visible = false;
                gridView1.Columns["考勤号"].Visible = false;
                gridView1.Columns["集团员工编号"].Visible = false;
                gridView1.Columns["公司子编号"].Visible = false;
                gridView1.Columns["部门"].Visible = true;
                gridView1.Columns["职务"].Visible = true;
                gridView1.Columns["性别"].Visible = true;
                gridView1.Columns["身份证号"].Visible = true;
                gridView1.Columns["出生日期"].Visible = true;
                gridView1.Columns["出生年"].Visible = false;
                gridView1.Columns["出生月"].Visible = false;
                gridView1.Columns["年龄"].Visible = false;
                gridView1.Columns["户籍地址"].Visible = false;
                gridView1.Columns["现居住地址"].Visible = false;
                gridView1.Columns["户口性质"].Visible = false;
                gridView1.Columns["籍贯"].Visible = false;
                gridView1.Columns["全日制学历"].Visible = false;
                gridView1.Columns["全日制毕业学校"].Visible = false;
                gridView1.Columns["全日制专业"].Visible = false;
                gridView1.Columns["第二学历"].Visible = false;
                gridView1.Columns["毕业学校"].Visible = false;
                gridView1.Columns["专业"].Visible = false;
                gridView1.Columns["政治面貌"].Visible = false;
                gridView1.Columns["入党时间"].Visible = false;
                gridView1.Columns["入职时间1"].Visible = true;
                gridView1.Columns["计划转正日期"].Visible = false;
                gridView1.Columns["转岗日期"].Visible = false;
                gridView1.Columns["合同签订期限1"].Visible = false;
                gridView1.Columns["合同到期时间1"].Visible = false;
                gridView1.Columns["合同签订单位1"].Visible = false;
                gridView1.Columns["合同签订期限2"].Visible = false;
                gridView1.Columns["合同到期时间2"].Visible = false;
                gridView1.Columns["合同到期时间2"].Visible = false;
                gridView1.Columns["合同签订期限3"].Visible = false;
                gridView1.Columns["合同到期时间3"].Visible = false;
                gridView1.Columns["合同签订单位3"].Visible = false;
                gridView1.Columns["安全协议"].Visible = false;
                gridView1.Columns["廉洁自律承诺书"].Visible = false;
                gridView1.Columns["特种作业证书"].Visible = false;
                gridView1.Columns["初领日期"].Visible = false;
                gridView1.Columns["复审日期"].Visible = false;
                gridView1.Columns["外部职称1"].Visible = false;
                gridView1.Columns["获得证书时间1"].Visible = false;
                gridView1.Columns["外部职称2"].Visible = false;
                gridView1.Columns["获得证书时间2"].Visible = false;
                gridView1.Columns["集团聘职称"].Visible = false;
                gridView1.Columns["宿舍号"].Visible = false;

                gridView1.Columns["入住日期"].Visible = false;
                gridView1.Columns["退宿日期"].Visible = false;
                gridView1.Columns["员工手册"].Visible = false;
                gridView1.Columns["合同发放"].Visible = false;
                gridView1.Columns["安全教育卡"].Visible = false;
                gridView1.Columns["公积金状态"].Visible = false;
                gridView1.Columns["保险缴纳基数"].Visible = false;
                gridView1.Columns["银行卡号"].Visible = true;
                gridView1.Columns["实际转正日期"].Visible = false;
                gridView1.Columns["是否转正"].Visible = false;
                gridView1.Columns["是否签订合同1"].Visible = false;
                gridView1.Columns["合同签订单位2"].Visible = false;
                gridView1.Columns["是否签订合同2"].Visible = false;
                gridView1.Columns["是否签订合同3"].Visible = false;
                gridView1.Columns["是否已复审"].Visible = false;
                gridView1.Columns["水电费是否结清"].Visible = false;
                gridView1.Columns["是否发放合同1"].Visible = false;
                gridView1.Columns["是否发放合同2"].Visible = false;
                gridView1.Columns["是否发放合同3"].Visible = false;

            }
            if (yonghu=="赵蕾蕾"||yonghu=="郑坤"||yonghu=="李野然"||yonghu=="庄卫星")
            {
                string sql1 = "select * from tb_danganbiao where 离职=''or 离职 is null";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
                this.gridView1.IndicatorWidth = 40;
                gridView1.Columns.ColumnByName("姓名").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            if (yonghu!="赵蕾蕾"&&yonghu!="郑坤"&&yonghu!="李野然"&&yonghu!="庄卫星"&&yonghu!="桑甜"&&yonghu!="齐景景" && yonghu != "王茜")
            {
                //string sql2 = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
                //DataTable dtt = SQLhelp.GetDataTable(sql2, CommandType.Text);
                string sql1 = "select * from tb_danganbiao where 姓名='" + yonghu + "' and 离职 =''or 离职 is null";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridView1.Columns["id"].Visible = false;
                this.gridView1.IndicatorWidth = 40;
                gridView1.Columns.ColumnByName("姓名").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                buttonItem1.Visible = false;
                保存ToolStripMenuItem.Visible = false;
                离职ToolStripMenuItem.Visible = false;
                转正ToolStripMenuItem.Visible = false;
                确认合同签订ToolStripMenuItem.Visible = false;
                确认复审ToolStripMenuItem.Visible = false;
                确认水电费ToolStripMenuItem.Visible = false;


                gridView1.Columns["考勤号"].Visible = false;
                gridView1.Columns["集团员工编号"].Visible = false;
                gridView1.Columns["公司子编号"].Visible = false;
                gridView1.Columns["部门"].Visible = true;
                gridView1.Columns["职务"].Visible = true;
                gridView1.Columns["性别"].Visible = false;
                gridView1.Columns["身份证号"].Visible = false;
                gridView1.Columns["出生日期"].Visible = false;
                gridView1.Columns["出生年"].Visible = false;
                gridView1.Columns["出生月"].Visible = false;
                gridView1.Columns["年龄"].Visible = false;
                gridView1.Columns["户籍地址"].Visible = true;
                gridView1.Columns["现居住地址"].Visible = true;
                gridView1.Columns["户口性质"].Visible = false;
                gridView1.Columns["籍贯"].Visible = false;
                gridView1.Columns["全日制学历"].Visible = false;
                gridView1.Columns["全日制毕业学校"].Visible = false;
                gridView1.Columns["全日制专业"].Visible = false;
                gridView1.Columns["第二学历"].Visible = false;
                gridView1.Columns["毕业学校"].Visible = false;
                gridView1.Columns["专业"].Visible = false;
                gridView1.Columns["政治面貌"].Visible = false;
                gridView1.Columns["入党时间"].Visible = false;
                gridView1.Columns["入职日期"].Visible = false;
                gridView1.Columns["计划转正日期"].Visible = false;
                gridView1.Columns["实际转正日期"].Visible = false;
                gridView1.Columns["转岗日期"].Visible = false;
                gridView1.Columns["合同签订期限1"].Visible = false;
                gridView1.Columns["合同到期时间1"].Visible = false;
                gridView1.Columns["合同签订单位1"].Visible = false;
                gridView1.Columns["合同签订期限2"].Visible = false;
                gridView1.Columns["合同到期时间2"].Visible = false;
                gridView1.Columns["合同到期时间2"].Visible = false;
                gridView1.Columns["合同签订期限3"].Visible = false;
                gridView1.Columns["合同到期时间3"].Visible = false;
                gridView1.Columns["合同签订单位3"].Visible = false;
                gridView1.Columns["安全协议"].Visible = false;
                gridView1.Columns["廉洁自律承诺书"].Visible = false;
                gridView1.Columns["特种作业证书"].Visible = false;
                gridView1.Columns["初领日期"].Visible = false;
                gridView1.Columns["复审日期"].Visible = false;
                gridView1.Columns["外部职称1"].Visible = false;
                gridView1.Columns["获得证书时间1"].Visible = false;
                gridView1.Columns["外部职称2"].Visible = false;
                gridView1.Columns["获得证书时间2"].Visible = false;
                gridView1.Columns["集团聘职称"].Visible = false;
                gridView1.Columns["宿舍号"].Visible = false;
                gridView1.Columns["入住日期"].Visible = false;
                gridView1.Columns["退宿日期"].Visible = false;
                gridView1.Columns["员工手册"].Visible = false;
                gridView1.Columns["合同发放"].Visible = false;
                gridView1.Columns["安全教育卡"].Visible = false;
                gridView1.Columns["公积金状态"].Visible = false;
                gridView1.Columns["保险缴纳基数"].Visible = false;
                gridView1.Columns["银行卡号"].Visible = true;
                gridView1.Columns["实际转正日期"].Visible = false;
                gridView1.Columns["是否转正"].Visible = false;
                gridView1.Columns["是否签订合同1"].Visible = false;
                gridView1.Columns["合同签订单位2"].Visible = false;
                gridView1.Columns["是否签订合同2"].Visible = false;
                gridView1.Columns["是否签订合同3"].Visible = false;
                gridView1.Columns["是否已复审"].Visible = false;
                gridView1.Columns["水电费是否结清"].Visible = false;
                gridView1.Columns["车牌号"].Visible = false;
                gridView1.Columns["是否发放合同1"].Visible = false;
                gridView1.Columns["是否发放合同2"].Visible = false;
                gridView1.Columns["是否发放合同3"].Visible = false;
            }
        }
        
        private void buttonItem2_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            dt = null;
            int hangshu = Convert.ToInt32(264);

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string b = dialog.FileName;
                Workbook book = new Workbook(b);
                Worksheet sheet = book.Worksheets["Sheet1"];
                dt = sheet.Cells.ExportDataTableAsString(1, 1, 264, 63);
                dt.Columns["Column1"].ColumnName = "姓名";
                dt.Columns["Column2"].ColumnName = "考勤号";
                dt.Columns["Column3"].ColumnName = "集团员工编号";
                dt.Columns["Column4"].ColumnName = "公司子编号";
                dt.Columns["Column5"].ColumnName = "部门";
                dt.Columns["Column6"].ColumnName = "职务";
                dt.Columns["Column7"].ColumnName = "性别";
                dt.Columns["Column8"].ColumnName = "身份证号";
                dt.Columns["Column9"].ColumnName = "出生日期";
                dt.Columns["Column10"].ColumnName = "出生年";
                dt.Columns["Column11"].ColumnName = "出生月";
                dt.Columns["Column12"].ColumnName = "年龄";
                dt.Columns["Column13"].ColumnName = "户籍地址";
                dt.Columns["Column14"].ColumnName = "现居住地址";
                dt.Columns["Column15"].ColumnName = "户口性质";
                dt.Columns["Column16"].ColumnName = "籍贯";
                dt.Columns["Column17"].ColumnName = "全日制学历";
                dt.Columns["Column18"].ColumnName = "全日制毕业学校";
                dt.Columns["Column19"].ColumnName = "全日制专业";
                dt.Columns["Column20"].ColumnName = "第二学历";
                dt.Columns["Column21"].ColumnName = "毕业学校";
                dt.Columns["Column22"].ColumnName = "专业";
                dt.Columns["Column23"].ColumnName = "政治面貌";
                dt.Columns["Column24"].ColumnName = "入党时间";
                dt.Columns["Column25"].ColumnName = "联系方式";
                dt.Columns["Column26"].ColumnName = "集团短号";
                dt.Columns["Column27"].ColumnName = "座机号";
                dt.Columns["Column28"].ColumnName = "紧急联系人电话";
                dt.Columns["Column29"].ColumnName = "集团邮箱地址";
                dt.Columns["Column30"].ColumnName = "入职日期";
                dt.Columns["Column31"].ColumnName = "转正日期";
                dt.Columns["Column32"].ColumnName = "转岗日期";
                dt.Columns["Column33"].ColumnName = "合同签订期限1";
                dt.Columns["Column34"].ColumnName = "合同到期时间1";
                dt.Columns["Column35"].ColumnName = "合同签订单位1";
                dt.Columns["Column36"].ColumnName = "合同签订期限2";
                dt.Columns["Column37"].ColumnName = "合同到期时间2";
                dt.Columns["Column38"].ColumnName = "合同签订单位2";
                dt.Columns["Column39"].ColumnName = "合同签订期限3";
              
                dt.Columns["Column41"].ColumnName = "合同签订单位3";
                dt.Columns["Column42"].ColumnName = "安全协议";
                dt.Columns["Column43"].ColumnName = "廉洁自律承诺书";
                dt.Columns["Column44"].ColumnName = "特种作业证书";
                dt.Columns["Column45"].ColumnName = "初领日期";
                dt.Columns["Column46"].ColumnName = "复审日期";
                dt.Columns["Column47"].ColumnName = "外部职称1";
                dt.Columns["Column48"].ColumnName = "获得证书时间1";
                dt.Columns["Column49"].ColumnName = "外部职称2";
                dt.Columns["Column50"].ColumnName = "获得证书时间2";
                dt.Columns["Column51"].ColumnName = "集团聘职称";
                dt.Columns["Column52"].ColumnName = "车牌号";
                dt.Columns["Column53"].ColumnName = "宿舍号";
                dt.Columns["Column54"].ColumnName = "入住日期";
                dt.Columns["Column55"].ColumnName = "退宿日期";
                dt.Columns["Column56"].ColumnName = "员工手册";
                dt.Columns["Column57"].ColumnName = "合同发放";
                dt.Columns["Column58"].ColumnName = "安全教育卡";
                dt.Columns["Column59"].ColumnName = "公积金";
                dt.Columns["Column60"].ColumnName = "保险缴纳基数";
                dt.Columns["Column61"].ColumnName = "银行卡号";
                dt.Columns["Column62"].ColumnName = "备注";
                dt.Columns["Column63"].ColumnName = "黑名单";
                dt.Columns["Column64"].ColumnName = "离职";
                dt.Columns["Column65"].ColumnName = "离职日期";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = "insert into tb_danganbiao  (姓名,考勤号,集团员工编号,公司子编号,部门,职务,性别,身份证号,出生日期,出生年,出生月,年龄,户籍地址,现居住地址,户口性质,籍贯,全日制学历,全日制毕业学校,全日制专业,第二学历,毕业学校,专业,政治面貌,入党时间,联系方式,集团短号,座机号,紧急联系人电话,集团邮箱地址,入职日期,转正日期,转岗日期,合同签订期限1,合同到期时间1,合同签订单位1,合同签订期限2,合同到期时间2,合同签订单位2,合同签订期限3,合同签订单位3,安全协议,廉洁自律承诺书,作业证书,初领日期,复审日期,外部职称1,获得证书时间1,外部职称2,获得证书时间2,集团聘职称,车牌号,宿舍号,入住日期,退宿日期,员工手册,合同发放,公积金,保险缴纳基数,银行卡号,备注,黑名单,离职,离职日期)  values ('" + dt.Rows[i]["姓名"].ToString() + "','" + dt.Rows[i]["考勤号"].ToString() + "','" + dt.Rows[i]["集团员工编号"].ToString() + "','" + dt.Rows[i]["公司子编号"].ToString() + "','" + dt.Rows[i]["部门"].ToString() + "','" + dt.Rows[i]["职务"].ToString() + "','" + dt.Rows[i]["性别"].ToString() + "','" + dt.Rows[i]["身份证号"].ToString() + "','" + dt.Rows[i]["出生日期"].ToString() + "','" + dt.Rows[i]["出生年"].ToString() + "','" + dt.Rows[i]["出生月"].ToString() + "','" + dt.Rows[i]["年龄"].ToString() + "','" + dt.Rows[i]["户籍地址"].ToString() + "','" + dt.Rows[i]["现居住地址"].ToString() + "','" + dt.Rows[i]["户口性质"].ToString() + "','" + dt.Rows[i]["籍贯"].ToString() + "','" + dt.Rows[i]["全日制学历"].ToString() + "','" + dt.Rows[i]["全日制毕业学校"].ToString() + "','" + dt.Rows[i]["全日制专业"].ToString() + "','" + dt.Rows[i]["第二学历"].ToString() + "','" + dt.Rows[i]["毕业学校"].ToString() + "','" + dt.Rows[i]["专业"].ToString() + "','" + dt.Rows[i]["政治面貌"].ToString() + "','" + dt.Rows[i]["入党时间"].ToString() + "','" + dt.Rows[i]["联系方式"].ToString() + "','" + dt.Rows[i]["集团短号"].ToString() + "','" + dt.Rows[i]["座机号"].ToString() + "','" + dt.Rows[i]["紧急联系人电话"].ToString() + "','" + dt.Rows[i]["集团邮箱地址"].ToString() + "','" + dt.Rows[i]["入职日期"].ToString() + "','" + dt.Rows[i]["转正日期"].ToString() + "','" + dt.Rows[i]["转岗日期"].ToString() + "','" + dt.Rows[i]["合同签订期限1"].ToString() + "','" + dt.Rows[i]["合同到期时间1"].ToString() + "','" + dt.Rows[i]["合同签订单位1"].ToString() + "','" + dt.Rows[i]["合同签订期限2"].ToString() + "','" + dt.Rows[i]["合同到期时间2"].ToString() + "','" + dt.Rows[i]["合同签订单位2"].ToString() + "','" + dt.Rows[i]["合同签订期限3"].ToString() + "','" + dt.Rows[i]["合同签订单位3"].ToString() + "','" + dt.Rows[i]["安全协议"].ToString() + "','" + dt.Rows[i]["廉洁自律承诺书"].ToString() + "','" + dt.Rows[i]["作业证书"].ToString() + "','" + dt.Rows[i]["初领日期"].ToString() + "','" + dt.Rows[i]["复审日期"].ToString() + "','" + dt.Rows[i]["外部职称1"].ToString() + "','" + dt.Rows[i]["获得证书时间1"].ToString() + "','" + dt.Rows[i]["外部职称2"].ToString() + "','" + dt.Rows[i]["获得证书时间2"].ToString() + "','" + dt.Rows[i]["集团聘职称"].ToString() + "','" + dt.Rows[i]["车牌号"].ToString() + "','" + dt.Rows[i]["宿舍号"].ToString() + "','" + dt.Rows[i]["入住日期"].ToString() + "','" + dt.Rows[i]["退宿日期"].ToString() + "','" + dt.Rows[i]["员工手册"].ToString() + "','" + dt.Rows[i]["合同发放"].ToString() + "','" + dt.Rows[i]["公积金"].ToString() + "','" + dt.Rows[i]["保险缴纳基数"].ToString() + "','" + dt.Rows[i]["银行卡号"].ToString() + "','" + dt.Rows[i]["备注"].ToString() + "','" + dt.Rows[i]["黑名单"].ToString() + "','" + dt.Rows[i]["离职"].ToString() + "','" + dt.Rows[i]["离职日期"].ToString() + "')";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                }
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frxinzengdangan form1 = new Frxinzengdangan();
            form1.ShowDialog();
        }

        private void 离职ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 离职ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string  sql = "update tb_danganbiao  set 离职='1' where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("保存成功！");
            Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = null;
            int hangshu = Convert.ToInt32(264);

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string b = dialog.FileName;
                Workbook book = new Workbook(b);
                Worksheet sheet = book.Worksheets["Sheet1"];
                dt = sheet.Cells.ExportDataTableAsString(1, 1, 264, 64);
                dt.Columns["Column1"].ColumnName = "姓名";
                dt.Columns["Column2"].ColumnName = "考勤号";
                dt.Columns["Column3"].ColumnName = "集团员工编号";
                dt.Columns["Column4"].ColumnName = "公司子编号";
                dt.Columns["Column5"].ColumnName = "部门";
                dt.Columns["Column6"].ColumnName = "职务";
                dt.Columns["Column7"].ColumnName = "性别";
                dt.Columns["Column8"].ColumnName = "身份证号";
                dt.Columns["Column9"].ColumnName = "出生日期";
                dt.Columns["Column10"].ColumnName = "出生年";
                dt.Columns["Column11"].ColumnName = "出生月";
                dt.Columns["Column12"].ColumnName = "年龄";
                dt.Columns["Column13"].ColumnName = "户籍地址";
                dt.Columns["Column14"].ColumnName = "现居住地址";
                dt.Columns["Column15"].ColumnName = "户口性质";
                dt.Columns["Column16"].ColumnName = "籍贯";
                dt.Columns["Column17"].ColumnName = "全日制学历";
                dt.Columns["Column18"].ColumnName = "全日制毕业学校";
                dt.Columns["Column19"].ColumnName = "全日制专业";
                dt.Columns["Column20"].ColumnName = "第二学历";
                dt.Columns["Column21"].ColumnName = "毕业学校";
                dt.Columns["Column22"].ColumnName = "专业";
                dt.Columns["Column23"].ColumnName = "政治面貌";
                dt.Columns["Column24"].ColumnName = "入党时间";
                dt.Columns["Column25"].ColumnName = "联系方式";
                dt.Columns["Column26"].ColumnName = "集团短号";
                dt.Columns["Column27"].ColumnName = "座机号";
                dt.Columns["Column28"].ColumnName = "紧急联系人电话";
                dt.Columns["Column29"].ColumnName = "集团邮箱地址";
                dt.Columns["Column30"].ColumnName = "入职日期";
                dt.Columns["Column31"].ColumnName = "转正日期";
                dt.Columns["Column32"].ColumnName = "转岗日期";
                dt.Columns["Column33"].ColumnName = "合同签订期限1";
                dt.Columns["Column34"].ColumnName = "合同到期时间1";
                dt.Columns["Column35"].ColumnName = "合同签订单位1";
                dt.Columns["Column36"].ColumnName = "合同签订期限2";
                dt.Columns["Column37"].ColumnName = "合同到期时间2";
                dt.Columns["Column38"].ColumnName = "合同签订单位2";
                dt.Columns["Column39"].ColumnName = "合同签订期限3";
                dt.Columns["Column40"].ColumnName = "合同签订单位3";
                dt.Columns["Column41"].ColumnName = "安全协议";
                dt.Columns["Column42"].ColumnName = "廉洁自律承诺书";
                dt.Columns["Column43"].ColumnName = "保密协议";
                dt.Columns["Column44"].ColumnName = "录用条件说明";
                dt.Columns["Column45"].ColumnName = "职业危害告知书";
                dt.Columns["Column46"].ColumnName = "特种作业证书";
                dt.Columns["Column47"].ColumnName = "初领日期";
                dt.Columns["Column48"].ColumnName = "复审日期";
                dt.Columns["Column49"].ColumnName = "外部职称1";
                dt.Columns["Column50"].ColumnName = "获得证书时间1";
                dt.Columns["Column51"].ColumnName = "外部职称2";
                dt.Columns["Column52"].ColumnName = "获得证书时间2";
                dt.Columns["Column53"].ColumnName = "集团聘职称";
                dt.Columns["Column54"].ColumnName = "车牌号";
                dt.Columns["Column55"].ColumnName = "宿舍号";
                dt.Columns["Column56"].ColumnName = "入住日期";
                dt.Columns["Column57"].ColumnName = "退宿日期";
                dt.Columns["Column58"].ColumnName = "员工手册";
                dt.Columns["Column59"].ColumnName = "合同发放";
                dt.Columns["Column60"].ColumnName = "安全教育卡";
                dt.Columns["Column61"].ColumnName = "公积金";
                dt.Columns["Column62"].ColumnName = "保险缴纳基数";
                dt.Columns["Column63"].ColumnName = "银行卡号";
                dt.Columns["Column64"].ColumnName = "备注";
               

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = "insert into tb_danganbiao  (姓名,考勤号,集团员工编号,公司子编号,部门,职务,性别,身份证号,出生日期,出生年,出生月,年龄,户籍地址,现居住地址,户口性质,籍贯,全日制学历,全日制毕业学校,全日制专业,第二学历,毕业学校,专业,政治面貌,入党时间,联系方式,集团短号,座机号,紧急联系人电话,集团邮箱地址,入职日期,计划转正日期,转岗日期,合同签订期限1,合同到期时间1,合同签订单位1,合同签订期限2,合同到期时间2,合同签订单位2,合同签订期限3,合同签订单位3,安全协议,廉洁自律承诺书,保密协议,录用条件说明,职业危害告知书,作业证书,初领日期,复审日期,外部职称1,获得证书时间1,外部职称2,获得证书时间2,集团聘职称,车牌号,宿舍号,入住日期,退宿日期,员工手册,合同发放,安全教育卡,公积金,保险缴纳基数,银行卡号,备注)  values ('" + dt.Rows[i]["姓名"].ToString() + "','" + dt.Rows[i]["考勤号"].ToString() + "','" + dt.Rows[i]["集团员工编号"].ToString() + "','" + dt.Rows[i]["公司子编号"].ToString() + "','" + dt.Rows[i]["部门"].ToString() + "','" + dt.Rows[i]["职务"].ToString() + "','" + dt.Rows[i]["性别"].ToString() + "','" + dt.Rows[i]["身份证号"].ToString() + "','" + dt.Rows[i]["出生日期"].ToString() + "','" + dt.Rows[i]["出生年"].ToString() + "','" + dt.Rows[i]["出生月"].ToString() + "','" + dt.Rows[i]["年龄"].ToString() + "','" + dt.Rows[i]["户籍地址"].ToString() + "','" + dt.Rows[i]["现居住地址"].ToString() + "','" + dt.Rows[i]["户口性质"].ToString() + "','" + dt.Rows[i]["籍贯"].ToString() + "','" + dt.Rows[i]["全日制学历"].ToString() + "','" + dt.Rows[i]["全日制毕业学校"].ToString() + "','" + dt.Rows[i]["全日制专业"].ToString() + "','" + dt.Rows[i]["第二学历"].ToString() + "','" + dt.Rows[i]["毕业学校"].ToString() + "','" + dt.Rows[i]["专业"].ToString() + "','" + dt.Rows[i]["政治面貌"].ToString() + "','" + dt.Rows[i]["入党时间"].ToString() + "','" + dt.Rows[i]["联系方式"].ToString() + "','" + dt.Rows[i]["集团短号"].ToString() + "','" + dt.Rows[i]["座机号"].ToString() + "','" + dt.Rows[i]["紧急联系人电话"].ToString() + "','" + dt.Rows[i]["集团邮箱地址"].ToString() + "','" + dt.Rows[i]["入职日期"].ToString() + "','" + dt.Rows[i]["转正日期"].ToString() + "','" + dt.Rows[i]["转岗日期"].ToString() + "','" + dt.Rows[i]["合同签订期限1"].ToString() + "','" + dt.Rows[i]["合同到期时间1"].ToString() + "','" + dt.Rows[i]["合同签订单位1"].ToString() + "','" + dt.Rows[i]["合同签订期限2"].ToString() + "','" + dt.Rows[i]["合同到期时间2"].ToString() + "','" + dt.Rows[i]["合同签订单位2"].ToString() + "','" + dt.Rows[i]["合同签订期限3"].ToString() + "','" + dt.Rows[i]["合同签订单位3"].ToString() + "','" + dt.Rows[i]["安全协议"].ToString() + "','" + dt.Rows[i]["廉洁自律承诺书"].ToString() + "','" + dt.Rows[i]["保密协议"].ToString() + "','" + dt.Rows[i]["录用条件说明"].ToString() + "','" + dt.Rows[i]["职业危害告知书"].ToString() + "','" + dt.Rows[i]["特种作业证书"].ToString() + "','" + dt.Rows[i]["初领日期"].ToString() + "','" + dt.Rows[i]["复审日期"].ToString() + "','" + dt.Rows[i]["外部职称1"].ToString() + "','" + dt.Rows[i]["获得证书时间1"].ToString() + "','" + dt.Rows[i]["外部职称2"].ToString() + "','" + dt.Rows[i]["获得证书时间2"].ToString() + "','" + dt.Rows[i]["集团聘职称"].ToString() + "','" + dt.Rows[i]["车牌号"].ToString() + "','" + dt.Rows[i]["宿舍号"].ToString() + "','" + dt.Rows[i]["入住日期"].ToString() + "','" + dt.Rows[i]["退宿日期"].ToString() + "','" + dt.Rows[i]["员工手册"].ToString() + "','" + dt.Rows[i]["合同发放"].ToString() + "','" + dt.Rows[i]["安全教育卡"].ToString() + "','" + dt.Rows[i]["公积金"].ToString() + "','" + dt.Rows[i]["保险缴纳基数"].ToString() + "','" + dt.Rows[i]["银行卡号"].ToString() + "','" + dt.Rows[i]["备注"].ToString() + "')";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                }
            }
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = null;
            int hangshu = Convert.ToInt32(264);

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string b = dialog.FileName;
                Workbook book = new Workbook(b);
                Worksheet sheet = book.Worksheets["Sheet1"];
                dt = sheet.Cells.ExportDataTableAsString(1,1, 264, 63);
                dt.Columns["Column1"].ColumnName = "姓名";
                dt.Columns["Column2"].ColumnName = "考勤号";
                dt.Columns["Column3"].ColumnName = "集团员工编号";
                dt.Columns["Column4"].ColumnName = "公司子编号";
                dt.Columns["Column5"].ColumnName = "部门";
                dt.Columns["Column6"].ColumnName = "职务";
                dt.Columns["Column7"].ColumnName = "性别";
                dt.Columns["Column8"].ColumnName = "身份证号";
                dt.Columns["Column9"].ColumnName = "出生日期";
                dt.Columns["Column10"].ColumnName = "出生年";
                dt.Columns["Column11"].ColumnName = "出生月";
                dt.Columns["Column12"].ColumnName = "年龄";
                dt.Columns["Column13"].ColumnName = "户籍地址";
                dt.Columns["Column14"].ColumnName = "现居住地址";
                dt.Columns["Column15"].ColumnName = "户口性质";
                dt.Columns["Column16"].ColumnName = "籍贯";
                dt.Columns["Column17"].ColumnName = "全日制学历";
                dt.Columns["Column18"].ColumnName = "全日制毕业学校";
                dt.Columns["Column19"].ColumnName = "全日制专业";
                dt.Columns["Column20"].ColumnName = "第二学历";
                dt.Columns["Column21"].ColumnName = "毕业学校";
                dt.Columns["Column22"].ColumnName = "专业";
                dt.Columns["Column23"].ColumnName = "政治面貌";
                dt.Columns["Column24"].ColumnName = "入党时间";
                dt.Columns["Column25"].ColumnName = "联系方式";
                dt.Columns["Column26"].ColumnName = "集团短号";
                dt.Columns["Column27"].ColumnName = "座机号";
                dt.Columns["Column28"].ColumnName = "紧急联系人电话";
                dt.Columns["Column29"].ColumnName = "集团邮箱地址";
                dt.Columns["Column30"].ColumnName = "入职日期";
                dt.Columns["Column31"].ColumnName = "转正日期";
                dt.Columns["Column32"].ColumnName = "转岗日期";
                dt.Columns["Column33"].ColumnName = "合同签订期限1";
                dt.Columns["Column34"].ColumnName = "合同到期时间1";
                dt.Columns["Column35"].ColumnName = "合同签订单位1";
                dt.Columns["Column36"].ColumnName = "合同签订期限2";
                dt.Columns["Column37"].ColumnName = "合同到期时间2";
                dt.Columns["Column38"].ColumnName = "合同签订单位2";
                dt.Columns["Column39"].ColumnName = "合同签订期限3";
                
                dt.Columns["Column40"].ColumnName = "合同签订单位3";
                dt.Columns["Column41"].ColumnName = "安全协议";
                dt.Columns["Column42"].ColumnName = "廉洁自律承诺书";
                dt.Columns["Column43"].ColumnName = "特种作业证书";
                dt.Columns["Column44"].ColumnName = "初领日期";
                dt.Columns["Column45"].ColumnName = "复审日期";
                dt.Columns["Column46"].ColumnName = "外部职称1";
                dt.Columns["Column47"].ColumnName = "获得证书时间1";
                dt.Columns["Column48"].ColumnName = "外部职称2";
                dt.Columns["Column49"].ColumnName = "获得证书时间2";
                dt.Columns["Column50"].ColumnName = "集团聘职称";
                dt.Columns["Column51"].ColumnName = "车牌号";
                dt.Columns["Column52"].ColumnName = "宿舍号";
                dt.Columns["Column53"].ColumnName = "入住日期";
                dt.Columns["Column54"].ColumnName = "退宿日期";
                dt.Columns["Column55"].ColumnName = "员工手册";
                dt.Columns["Column56"].ColumnName = "合同发放";

                dt.Columns["Column57"].ColumnName = "公积金";
                dt.Columns["Column58"].ColumnName = "保险缴纳基数";
                dt.Columns["Column59"].ColumnName = "银行卡号";
                dt.Columns["Column60"].ColumnName = "备注";
                ;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = "insert into tb_danganbiao  (姓名,考勤号,集团员工编号,公司子编号,部门,职务,性别,身份证号,出生日期,出生年,出生月,年龄,户籍地址,现居住地址,户口性质,籍贯,全日制学历,全日制毕业学校,全日制专业,第二学历,毕业学校,专业,政治面貌,入党时间,联系方式,集团短号,座机号,紧急联系人电话,集团邮箱地址,入职日期,计划转正日期,转岗日期,合同签订期限1,合同到期时间1,合同签订单位1,合同签订期限2,合同到期时间2,合同签订单位2,合同签订期限3,合同签订单位3,安全协议,廉洁自律承诺书,作业证书,初领日期,复审日期,外部职称1,获得证书时间1,外部职称2,获得证书时间2,集团聘职称,车牌号,宿舍号,入住日期,退宿日期,员工手册,合同发放,公积金,保险缴纳基数,银行卡号,备注)  values ('" + dt.Rows[i]["姓名"].ToString() + "','" + dt.Rows[i]["考勤号"].ToString() + "','" + dt.Rows[i]["集团员工编号"].ToString() + "','" + dt.Rows[i]["公司子编号"].ToString() + "','" + dt.Rows[i]["部门"].ToString() + "','" + dt.Rows[i]["职务"].ToString() + "','" + dt.Rows[i]["性别"].ToString() + "','" + dt.Rows[i]["身份证号"].ToString() + "','" + dt.Rows[i]["出生日期"].ToString() + "','" + dt.Rows[i]["出生年"].ToString() + "','" + dt.Rows[i]["出生月"].ToString() + "','" + dt.Rows[i]["年龄"].ToString() + "','" + dt.Rows[i]["户籍地址"].ToString() + "','" + dt.Rows[i]["现居住地址"].ToString() + "','" + dt.Rows[i]["户口性质"].ToString() + "','" + dt.Rows[i]["籍贯"].ToString() + "','" + dt.Rows[i]["全日制学历"].ToString() + "','" + dt.Rows[i]["全日制毕业学校"].ToString() + "','" + dt.Rows[i]["全日制专业"].ToString() + "','" + dt.Rows[i]["第二学历"].ToString() + "','" + dt.Rows[i]["毕业学校"].ToString() + "','" + dt.Rows[i]["专业"].ToString() + "','" + dt.Rows[i]["政治面貌"].ToString() + "','" + dt.Rows[i]["入党时间"].ToString() + "','" + dt.Rows[i]["联系方式"].ToString() + "','" + dt.Rows[i]["集团短号"].ToString() + "','" + dt.Rows[i]["座机号"].ToString() + "','" + dt.Rows[i]["紧急联系人电话"].ToString() + "','" + dt.Rows[i]["集团邮箱地址"].ToString() + "','" + dt.Rows[i]["入职日期"].ToString() + "','" + dt.Rows[i]["转正日期"].ToString() + "','" + dt.Rows[i]["转岗日期"].ToString() + "','" + dt.Rows[i]["合同签订期限1"].ToString() + "','" + dt.Rows[i]["合同到期时间1"].ToString() + "','" + dt.Rows[i]["合同签订单位1"].ToString() + "','" + dt.Rows[i]["合同签订期限2"].ToString() + "','" + dt.Rows[i]["合同到期时间2"].ToString() + "','" + dt.Rows[i]["合同签订单位2"].ToString() + "','" + dt.Rows[i]["合同签订期限3"].ToString() + "','" + dt.Rows[i]["合同签订单位3"].ToString() + "','" + dt.Rows[i]["安全协议"].ToString() + "','" + dt.Rows[i]["廉洁自律承诺书"].ToString() + "','" + dt.Rows[i]["特种作业证书"].ToString() + "','" + dt.Rows[i]["初领日期"].ToString() + "','" + dt.Rows[i]["复审日期"].ToString() + "','" + dt.Rows[i]["外部职称1"].ToString() + "','" + dt.Rows[i]["获得证书时间1"].ToString() + "','" + dt.Rows[i]["外部职称2"].ToString() + "','" + dt.Rows[i]["获得证书时间2"].ToString() + "','" + dt.Rows[i]["集团聘职称"].ToString() + "','" + dt.Rows[i]["车牌号"].ToString() + "','" + dt.Rows[i]["宿舍号"].ToString() + "','" + dt.Rows[i]["入住日期"].ToString() + "','" + dt.Rows[i]["退宿日期"].ToString() + "','" + dt.Rows[i]["员工手册"].ToString() + "','" + dt.Rows[i]["合同发放"].ToString() + "','" + dt.Rows[i]["公积金"].ToString() + "','" + dt.Rows[i]["保险缴纳基数"].ToString() + "','" + dt.Rows[i]["银行卡号"].ToString() + "','" + dt.Rows[i]["备注"].ToString() + "')";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                }
            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sql = "update tb_danganbiao  set 实际转正日期='" + gridView1.GetRowCellValue(i, "实际转正日期").ToString() + "',车牌号='" + gridView1.GetRowCellValue(i, "车牌号").ToString() + "',工作服尺寸='"+gridView1.GetRowCellValue(i,"工作服尺寸").ToString()+"',劳保鞋尺寸='"+gridView1.GetRowCellValue(i,"劳保鞋尺寸").ToString()+"',姓名='" + gridView1.GetRowCellValue(i, "姓名").ToString() + "' ,考勤号='" + gridView1.GetRowCellValue(i, "考勤号").ToString() + "',集团员工编号='" + gridView1.GetRowCellValue(i, "集团员工编号").ToString() + "',公司子编号='" + gridView1.GetRowCellValue(i, "公司子编号").ToString() + "',部门='" + gridView1.GetRowCellValue(i, "部门").ToString() + "',职务='" + gridView1.GetRowCellValue(i, "职务").ToString() + "',性别='" + gridView1.GetRowCellValue(i, "性别").ToString() + "',身份证号='" + gridView1.GetRowCellValue(i, "身份证号").ToString() + "',出生日期='" + gridView1.GetRowCellValue(i, "出生日期").ToString() + "',出生年='" + gridView1.GetRowCellValue(i, "出生年").ToString() + "',户籍地址='" + gridView1.GetRowCellValue(i, "户籍地址").ToString() + "',现居住地址='" + gridView1.GetRowCellValue(i, "现居住地址").ToString() + "',户口性质='" + gridView1.GetRowCellValue(i, "户口性质").ToString() + "',籍贯='" + gridView1.GetRowCellValue(i, "籍贯").ToString() + "',全日制学历='" + gridView1.GetRowCellValue(i, "全日制学历").ToString() + "',全日制毕业学校='" + gridView1.GetRowCellValue(i, "全日制毕业学校").ToString() + "',全日制专业='" + gridView1.GetRowCellValue(i, "全日制专业").ToString() + "',第二学历='" + gridView1.GetRowCellValue(i, "第二学历").ToString() + "',毕业学校='" + gridView1.GetRowCellValue(i, "毕业学校").ToString() + "',专业='" + gridView1.GetRowCellValue(i, "专业").ToString() + "',政治面貌='" + gridView1.GetRowCellValue(i, "政治面貌").ToString() + "',入党时间='" + gridView1.GetRowCellValue(i, "入党时间").ToString() + "',联系方式='" + gridView1.GetRowCellValue(i, "联系方式").ToString() + "',集团短号='" + gridView1.GetRowCellValue(i, "集团短号").ToString() + "',座机号='" + gridView1.GetRowCellValue(i, "座机号").ToString() + "',紧急联系人电话='" + gridView1.GetRowCellValue(i, "紧急联系人电话").ToString() + "',集团邮箱地址='" + gridView1.GetRowCellValue(i, "集团邮箱地址").ToString() + "',入职日期='" + gridView1.GetRowCellValue(i, "入职日期").ToString() + "',计划转正日期='" + gridView1.GetRowCellValue(i, "计划转正日期").ToString() + "',转岗日期='" + gridView1.GetRowCellValue(i, "转岗日期").ToString() + "',合同签订期限1='" + gridView1.GetRowCellValue(i, "合同签订期限1").ToString() + "',合同到期时间1='" + gridView1.GetRowCellValue(i, "合同到期时间1").ToString() + "',合同签订单位1='" + gridView1.GetRowCellValue(i, "合同签订单位1").ToString() + "',合同签订期限2='" + gridView1.GetRowCellValue(i, "合同签订期限2").ToString() + "',合同到期时间2='" + gridView1.GetRowCellValue(i, "合同到期时间2").ToString() + "',合同签订期限3='" + gridView1.GetRowCellValue(i, "合同签订期限3").ToString() + "',合同签订单位3='" + gridView1.GetRowCellValue(i, "合同签订单位3").ToString() + "',作业证书='" + gridView1.GetRowCellValue(i, "作业证书").ToString() + "',初领日期='" + gridView1.GetRowCellValue(i, "初领日期").ToString() + "',初审日期='" + gridView1.GetRowCellValue(i, "初审日期").ToString() + "',复审日期='" + gridView1.GetRowCellValue(i, "复审日期").ToString() + "',外部职称1='" + gridView1.GetRowCellValue(i, "外部职称1").ToString() + "',获得证书时间1='" + gridView1.GetRowCellValue(i, "获得证书时间1").ToString() + "',外部职称2='" + gridView1.GetRowCellValue(i, "外部职称2").ToString() + "',获得证书时间2='" + gridView1.GetRowCellValue(i, "获得证书时间2").ToString() + "',集团聘职称='" + gridView1.GetRowCellValue(i, "集团聘职称").ToString() + "',宿舍号='" + gridView1.GetRowCellValue(i, "宿舍号").ToString() + "',入住日期='" + gridView1.GetRowCellValue(i, "入住日期").ToString() + "',退宿日期='" + gridView1.GetRowCellValue(i, "退宿日期").ToString() + "',公积金状态='" + gridView1.GetRowCellValue(i, "保险状态").ToString() + "',保险缴纳基数='" + gridView1.GetRowCellValue(i, "保险缴纳基数").ToString() + "',银行卡号='" + gridView1.GetRowCellValue(i, "银行卡号").ToString() + "',备注='" + gridView1.GetRowCellValue(i, "备注").ToString() + "'where id='" + gridView1.GetRowCellValue(i, "id").ToString() + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
          
           
            MessageBox.Show("保存成功！");
            Reload();
        }


        private void 转正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string zhuanzheng = Convert.ToString(gridView1.GetRowCellValue(i, "是否转正"));

                string time = DateTime.Now.ToString();
                if (zhuanzheng == "")
                {
                    string sql4 = "update tb_danganbiao  set  是否转正=1    where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                }
            }

            MessageBox.Show("转正成功！");
            Reload();
        }

        private void 确认合同签订ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void 确认复审ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string fushen = Convert.ToString(gridView1.GetRowCellValue(i, "是否已复审"));

                string time = DateTime.Now.ToString();
                if (fushen == "")
                {
                    string sqlfs = "update tb_danganbiao  set  是否已复审=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlfs, CommandType.Text);

                }
            }

            MessageBox.Show("确认已复审！");
            Reload();
        }

        private void 确认水电费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string shuidianfei = Convert.ToString(gridView1.GetRowCellValue(i, "水电费是否结清"));

                string time = DateTime.Now.ToString();
                if (shuidianfei == "")
                {
                    string sqlht = "update tb_danganbiao  set  水电费是否结清=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlht, CommandType.Text);

                }
            }

            MessageBox.Show("确认水电费已结清！");

            Reload();
        }

        private void 合同签订1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string hetongqianding = Convert.ToString(gridView1.GetRowCellValue(i, "是否签订合同1"));

                string time = DateTime.Now.ToString();
                if (hetongqianding == "")
                {
                    string sqlht = "update tb_danganbiao  set  是否签订合同1=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlht, CommandType.Text);

                }
            }

            MessageBox.Show("合同签订确认！");
            Reload();
        }

        private void 合同签订2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string hetongqianding = Convert.ToString(gridView1.GetRowCellValue(i, "是否签订合同2"));

                string time = DateTime.Now.ToString();
                if (hetongqianding == "")
                {
                    string sqlht = "update tb_danganbiao  set  是否签订合同2=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlht, CommandType.Text);

                }
            }

            MessageBox.Show("合同签订确认！");
            Reload();
        }

        private void 合同签订3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string hetongqianding = Convert.ToString(gridView1.GetRowCellValue(i, "是否签订合同3"));

                string time = DateTime.Now.ToString();
                if (hetongqianding == "")
                {
                    string sqlht = "update tb_danganbiao  set  是否签订合同3=1   where id='" + Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id")) + "' ";
                    SQLhelp.ExecuteScalar(sqlht, CommandType.Text);

                }
            }

            MessageBox.Show("合同签订确认！");
            Reload();
        }

        private void 生成excel表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("请先选择列");
                return;
            }
            if (gridView1.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl1.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
    
