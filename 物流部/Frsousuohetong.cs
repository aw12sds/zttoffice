using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统;

namespace ztoffice.物流部
{
    public partial class Frsousuohetong : DevExpress.XtraEditors.XtraForm
    {
        public Frsousuohetong()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("合同总价");
            dt.Columns.Add("采购员");

            dt1.Columns.Add("id");
            dt1.Columns.Add("供方名称");
            dt1.Columns.Add("合同号");
            dt1.Columns.Add("合同总价");
            dt1.Columns.Add("采购员");

            string sql = "select 采购员,供方名称,合同号,合同总价 from tb_caigoutaizhang where 合同登记时间>='"+dtkaishi.Text+"' and 合同登记时间<='"+dtjieshu.Text+"' and 采购员='"+ comboBoxEdit1 .Text+ "'";
            dt = SQLhelp.GetDataTablexiangmuguanli(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            Frhetongxianshi form = new Frhetongxianshi();
            form.dt = dt1;
            form.ShowDialog();
        }

        private void Frsousuohetong_Load(object sender, EventArgs e)
        {
            string sql1 = "select 用户名 from tb_operator  where 部门='物流部' ";
            DataTable mingdan = sqlhelp111.GetDataTable(sql1, CommandType.Text);
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < mingdan.Rows.Count; i++)
            {
                string n = mingdan.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);
            }
            foreach (string s in spaceminute1)
            {
                comboBoxEdit1.Properties.Items.Add(s);                
            }
        }
    }
}
