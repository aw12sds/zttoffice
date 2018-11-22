//using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ztoffice.Service
{
    public partial class Frgerengonggao : Form
    {
        public Frgerengonggao()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void gridControl1_Load(object sender, EventArgs e)
        {
            string sql1 = "select 公告标题,公告人,公告时间,公告接收人 from tb_gonggao where 公告类型='选择型'  order  by 公告时间 desc ";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            DataTable table = new DataTable();

            //创建table的第一列
            DataColumn priceColumn = new DataColumn();
            //该列的数据类型
            priceColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            priceColumn.ColumnName = "公告标题";
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn.ColumnName = "公告人";
            DataColumn taxColumn1 = new DataColumn();
            taxColumn1.DataType = System.Type.GetType("System.String");
            //列名
            taxColumn1.ColumnName = "公告时间";
            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(taxColumn1);


            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string str = dt1.Rows[i]["公告接收人"].ToString();
                //正则表达式

                System.Text.RegularExpressions.Match m;

                Regex r = new Regex(yonghu);

                m = r.Match(str);
                string panduan = m.ToString();

                if (panduan != "")
                {
                    DataRow dr = table.NewRow();
                    string a = dt1.Rows[i]["公告标题"].ToString();
                    dr["公告标题"] = dt1.Rows[i]["公告标题"].ToString();

                    dr["公告人"] = dt1.Rows[i]["公告人"].ToString();
                    dr["公告时间"] = dt1.Rows[i]["公告时间"].ToString();
                    table.Rows.Add(dr);

                }

            }

            //个人的绑定
            gridControl1.DataSource = table;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
