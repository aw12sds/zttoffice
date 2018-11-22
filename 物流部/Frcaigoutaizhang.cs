using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ztoffice.物流部
{
    public partial class Frcaigoutaizhang : DevExpress.XtraEditors.XtraForm
    {
        public Frcaigoutaizhang()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string qingdan1 = "";
        private void Frcaigoutaizhang_Load(object sender, EventArgs e)
        {
            string sql1 = "select 付款 from tb_fukuan  ";
            DataTable mingdan = SQLhelp1.GetDataTable(sql1, CommandType.Text);
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < mingdan.Rows.Count; i++)
            {
                string n = mingdan.Rows[i]["付款"].ToString();
                spaceminute1.Add(n);
            }
            foreach (string s in spaceminute1)
            {
                repositoryItemComboBox2.Items.Add(s);             
            }            
            gridView4.Columns.ColumnByName("采购员").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView4.Columns.ColumnByName("供方名称").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView4.Columns.ColumnByName("合同号").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView4.Columns.ColumnByName("合同总价").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView4.Columns.ColumnByName("付款方式").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView4.Columns.ColumnByName("合同登记时间").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView4.Columns.ColumnByName("付款状态").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView4.Columns.ColumnByName("发票状态").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            Reload();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (txthetonghao.Text.Trim() == "")
            {

                MessageBox.Show("请先输入合同号！");
                return;
            }
            string sql = "select * from tb_caigoutaizhang where 合同号  like '%" + txthetonghao.Text + "%'";
            gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);
        }
        public void Reload()
        {
            string sql = "select * from tb_caigoutaizhang ";
            gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);


        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string zhuangtai1 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度1"));
                string zhuangtai2 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度2"));
                string zhuangtai3 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度3"));
                string zhuangtai4 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度4"));
                string jine1 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额1"));
                string jine2 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额2"));
                string jine3 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额3"));
                string jine4 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额4"));
                string fukuanfangshi = Convert.ToString(gridView4.GetRowCellValue(i, "付款方式"));
                string fapiaozhuangtai = Convert.ToString(gridView4.GetRowCellValue(i, "发票状态"));
                string zhibaoqi = Convert.ToString(gridView4.GetRowCellValue(i, "质保期"));
                string zhibaojin = Convert.ToString(gridView4.GetRowCellValue(i, "质保金"));

                string tijiaoshijian = DateTime.Now.ToString();
                string sql11 = "update tb_caigoutaizhang set 付款方式='" + fukuanfangshi + "' ,质保期='" + zhibaoqi + "',质保金='" + zhibaojin + "' ,合同登记时间='"+ tijiaoshijian + "' where id='" + id + "' ";
                SQLhelp1.ExecuteScalar(sql11, CommandType.Text);

                if (zhuangtai1 == "")
                {
                    if (jine1 != "")
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额1='" + jine1 + "' where id='" + id + "' ";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);

                    }
                }

                if (zhuangtai1 != "" && zhuangtai2 == "")
                {
                    if (jine2 != "")
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额2='" + jine2 + "' where id='" + id + "' ";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);

                    }

                }
                if (zhuangtai2 != "" && zhuangtai3 == "")
                {
                    if (jine3 != "")
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额3='" + jine3 + "' where id='" + id + "' ";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);

                    }

                }
                if (zhuangtai3 != "" && zhuangtai4 == "")
                {
                    if (jine4 != "")
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额4='" + jine4 + "' where id='" + id + "' ";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);

                    }

                }

            }
            MessageBox.Show("已保存！");
            Reload();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (txtgongyingshang.Text.Trim() == "")
            {

                MessageBox.Show("请先输入供方名称！");
                return;
            }
            string sql = "select * from tb_caigoutaizhang where 供方名称  like '%" + txtgongyingshang.Text + "%'";
            gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            string sql = "select * from tb_caigoutaizhang ";
            gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);
        }

        private void 录入发票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frfapiaoluru form1 = new Frfapiaoluru();
            string id = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            if (id == "")
            {
                MessageBox.Show("请选择对应行！");
                return;
            }
            form1.yonghu = yonghu;
            form1.id = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            form1.hetonghao = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "合同号"));
            form1.hetongzongjia = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "合同总价"));
            form1.caigouyuan = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "采购员"));
            form1.gongfangmingcheng = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "供方名称"));
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string sql = "select * from tb_caigoutaizhang ";
                gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);
            }
        }

        private void 提交审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                qingdan1 += id + "|";
            }

            if (qingdan1 == "")
            {
                MessageBox.Show("没有选中，请选中！");
                return;
            }
            bool b = false;
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                double zongji = Convert.ToDouble(gridView4.GetRowCellValue(i, "合同总价"));
                string zhuangtai1 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度1"));
                string zhuangtai2 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度2"));
                string zhuangtai3 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度3"));
                string zhuangtai4 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度4"));
                string jine1 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额1"));
                string jine2 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额2"));
                string jine3 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额3"));
                string jine4 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额4"));



                
                if (zhuangtai1 == "")
                {
                    if (jine1 == "")
                    {
                        MessageBox.Show("请填写申请付款金额1的金额！");
                        return;

                    }
                    string[] strArray = jine1.Split(new char[1] { ';' });
                    double jinge11 = 0;
                    double qian = 0;
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j] != "")
                        {
                            double c = Convert.ToDouble(strArray[j]);
                            qian += c;
                            string kn = (qian).ToString("N2");
                            jinge11 = Convert.ToDouble(kn);
                            
                        }
                    }

                    if (zongji < jinge11)
                    {
                        MessageBox.Show("付款金额大于合同总价！请重新填写！");
                    }
                    else
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额1='" + jine1 + "',申请付款日期1='" + DateTime.Now + "',申请付款进度1='已提交'  where id='" + id + "'";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);
                        b = true;
                    }
                }
                if (zhuangtai1 != "" && zhuangtai2 == "")
                {
                    if (jine2 == "")
                    {
                        MessageBox.Show("请填写申请付款金额2的金额！");
                        return;

                    }
                    string[] strArray2 = jine2.Split(new char[1] { ';' });
                    string[] strArray = jine1.Split(new char[1] { ';' });
                    double jinge11 = 0;
                    double qian = 0;
                    double zongjia1 = 0;
                    double qian2 = 0;
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j] != "")
                        {
                            double c = Convert.ToDouble(strArray[j]);
                            qian += c;
                            string kn = (qian).ToString("N2");
                            jinge11 = Convert.ToDouble(kn);
                            
                        }
                    }
                    for (int z = 0; z < strArray2.Length; z++)
                    {
                        if (strArray2[z] != "")
                        {

                            double d = Convert.ToDouble(strArray2[z]);
                            qian2 += d;
                            string kn2 = (jinge11 + qian2).ToString("N2");
                            zongjia1 = Convert.ToDouble(kn2);
                        }
                    }
                    if (zongji < zongjia1)
                    {
                        MessageBox.Show("付款金额大于合同总价！请重新填写！");
                    }
                    else
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额2='" + jine2 + "',申请付款日期2='" + DateTime.Now + "' ,申请付款进度2='已提交' where id='" + id + "'";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);
                        b = true;
                    }


                }
                if (zhuangtai2 != "" && zhuangtai3 == "")
                {
                    if (jine3 == "")
                    {
                        MessageBox.Show("请填写申请付款金额3的金额！");
                        return;

                    }
                    string[] strArray3 = jine3.Split(new char[1] { ';' });
                    string[] strArray2 = jine2.Split(new char[1] { ';' });
                    string[] strArray = jine1.Split(new char[1] { ';' });
                    double jinge11 = 0;
                    double qian = 0;
                    double zongjia1 = 0;
                    double qian2 = 0;
                    double zongjia2 = 0;
                    double qian3 = 0;
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j] != "")
                        {
                            double c = Convert.ToDouble(strArray[j]);
                            qian += c;
                            string kn = (qian).ToString("N2");
                            jinge11 = Convert.ToDouble(kn);

                        }
                    }
                    for (int z = 0; z < strArray2.Length; z++)
                    {
                        if (strArray2[z] != "")
                        {

                            double d = Convert.ToDouble(strArray2[z]);
                            qian2 += d;
                            string kn2 = (jinge11 + qian2).ToString("N2");
                            zongjia1 = Convert.ToDouble(kn2);
                        }
                    }
                    for (int j = 0; j < strArray3.Length; j++)
                    {
                        if (strArray3[j] != "")
                        {
                            
                            double c= Convert.ToDouble(strArray3[j]);
                            
                            qian3 += c;
                            string kn = (zongjia1 + qian3).ToString("N2");
                            zongjia2 = Convert.ToDouble(kn);
                        }
                    }


                    if (zongji < zongjia2)
                    {
                        MessageBox.Show("付款金额大于合同总价！请重新填写！");
                    }

                    else
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额3='" + jine3 + "',申请付款日期3='" + DateTime.Now + "',申请付款进度3='已提交'  where id='" + id + "'";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);
                        b = true;
                    }

                }
                if (zhuangtai3 != "" && zhuangtai4 == "")
                {
                    if (jine4 == "")
                    {
                        MessageBox.Show("请填写申请付款金额4的金额！");
                        return;

                    }
                    string[] strArray4 = jine4.Split(new char[1] { ';' });
                    string[] strArray3 = jine3.Split(new char[1] { ';' });
                    string[] strArray2 = jine2.Split(new char[1] { ';' });
                    string[] strArray = jine1.Split(new char[1] { ';' });
                    double jinge11 = 0;
                    double qian = 0;
                    double zongjia1 = 0;
                    double qian2 = 0;
                    double zongjia2 = 0;
                    double qian3 = 0;
                    double zongjia3 = 0;
                    double qian4 = 0;
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j] != "")
                        {
                            double c = Convert.ToDouble(strArray[j]);
                            qian += c;
                            string kn = (qian).ToString("N2");
                            jinge11 = Convert.ToDouble(kn);

                        }
                    }
                    for (int z = 0; z < strArray2.Length; z++)
                    {
                        if (strArray2[z] != "")
                        {

                            double d = Convert.ToDouble(strArray2[z]);
                            qian2 += d;
                            string kn2 = (jinge11 + qian2).ToString("N2");
                            zongjia1 = Convert.ToDouble(kn2);
                        }
                    }
                    for (int j = 0; j < strArray3.Length; j++)
                    {
                        if (strArray3[j] != "")
                        {

                            double c = Convert.ToDouble(strArray3[j]);

                            qian3 += c;
                            string kn = (zongjia1 + qian3).ToString("N2");
                            zongjia2 = Convert.ToDouble(kn);
                        }
                    }
                    for (int j = 0; j < strArray4.Length; j++)
                    {
                        if (strArray4[j] != "")
                        {
                            double c = Convert.ToDouble(strArray4[j]);
                            qian4 += c;
                            string kn = (zongjia2 + qian4).ToString("N2");
                            zongjia3 = Convert.ToDouble(kn);
                        }
                    }

                    if (zongji < zongjia3)
                    {
                        MessageBox.Show("付款金额大于合同总价！请重新填写！");
                    }
                    else
                    {
                        string sql = "update tb_caigoutaizhang set 申请付款金额4='" + jine4 + "',申请付款日期4='" + DateTime.Now + "',申请付款进度4='已提交' where id='" + id + "'";
                        SQLhelp1.ExecuteScalar(sql, CommandType.Text);
                        b = true;
                    }
                    
                }
            }
            if (b)
            {
                MessageBox.Show("已提交！");
                Reload();
            }
            
            //foreach (int i in a)
            //{
            //    string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
            //    string zhuangtai1 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度1"));
            //    string zhuangtai2 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度2"));
            //    string zhuangtai3 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度3"));
            //    string zhuangtai4 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款进度4"));
            //    string jine1 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额1"));
            //    string jine2 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额2"));
            //    string jine3 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额3"));
            //    string jine4 = Convert.ToString(gridView4.GetRowCellValue(i, "申请付款金额4"));
            //    if (zhuangtai1 == "")
            //    {
            //        string sql = "update tb_caigoutaizhang set 申请付款金额1='" + jine1 + "',申请付款日期1='" + DateTime.Now + "',申请付款进度1='已提交'  where id='" + id + "'";
            //        SQLhelp1.ExecuteScalar(sql, CommandType.Text);

            //    }
            //    if (zhuangtai1 != "" && zhuangtai2 == "")
            //    {
            //        string sql = "update tb_caigoutaizhang set 申请付款金额2='" + jine2 + "',申请付款日期2='" + DateTime.Now + "' ,申请付款进度2='已提交' where id='" + id + "'";
            //        SQLhelp1.ExecuteScalar(sql, CommandType.Text);

            //    }

            //    if (zhuangtai2 != "" && zhuangtai3 == "")
            //    {
            //        string sql = "update tb_caigoutaizhang set 申请付款金额3='" + jine3 + "',申请付款日期3='" + DateTime.Now + "',申请付款进度3='已提交'  where id='" + id + "'";
            //        SQLhelp1.ExecuteScalar(sql, CommandType.Text);

            //    }
            //    if (zhuangtai3 != "" && zhuangtai4 == "")
            //    {
            //        string sql = "update tb_caigoutaizhang set 申请付款金额4='" + jine4 + "',申请付款日期4='" + DateTime.Now + "',申请付款进度4='已提交' where id='" + id + "'";
            //        SQLhelp1.ExecuteScalar(sql, CommandType.Text);
            //    }

            //}
            //MessageBox.Show("已提交！");
            //Reload();
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void 录入发票手工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frshougongfapiao form1 = new Frshougongfapiao();
            string id = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            if (id == "")
            {
                MessageBox.Show("请选择对应行！");
                return;
            }
            form1.yonghu = yonghu;
            form1.id = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            form1.hetonghao = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "合同号"));
            form1.hetongzongjia = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "合同总价"));
            form1.fapiaojia = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "合同总价"));
            form1.caigouyuan = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "采购员"));
            form1.gongfangmingcheng = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "供方名称"));
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string sql = "select * from tb_caigoutaizhang ";
                gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);
            }
        }

        private void 查看合同料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frhetongliaodan form1 = new Frhetongliaodan();
            form1.hetonghao = Convert.ToString(gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "合同号"));
            form1.Show();
        }

        private void txthetonghao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txthetonghao.Text.Trim() == "")
                {

                    MessageBox.Show("请先输入合同号！");
                    return;
                }
                string sql = "select * from tb_caigoutaizhang where 合同号  like '%" + txthetonghao.Text + "%'";
                gridControl4.DataSource = SQLhelp1.GetDataTable(sql, CommandType.Text);

            }
        }

        private void 计算合同总价ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double a = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                a+= Convert.ToDouble(gridView4.GetRowCellValue(i, "合同总价"));
                
            }
            MessageBox.Show("合同总价是："+a.ToString());
        }

        private void 计算发票总价ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double a = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string[] sArray = Convert.ToString(gridView4.GetRowCellValue(i, "发票金额")).Split(new char[1] { ';' });
                for (int j = 0; j < sArray.Length; j++)
                {
                    if(sArray[j]!="")
                    {
                        a += Convert.ToDouble(sArray[j]);
                    }

                }

            }
            MessageBox.Show("合同总价是：" + a.ToString());
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "付款状态")
            {
                GridCellInfo GridCellInfo = e.Cell as GridCellInfo;
                if (GridCellInfo.CellValue.ToString() == "")
                {
                    e.Appearance.BackColor = Color.Red;
                }
           
            }
            if (e.Column.FieldName == "发票状态")
            {
                GridCellInfo GridCellInfo = e.Cell as GridCellInfo;
                if (GridCellInfo.CellValue.ToString() == ""|| GridCellInfo.CellValue.ToString() == "已到部分")
                {
                    e.Appearance.BackColor = Color.Red;
                }

            }
        }

        private void 查看发票流转表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frfapiaoliuzhuanbiao form1 = new Frfapiaoliuzhuanbiao();
            form1.ShowDialog();
            if(form1.DialogResult==DialogResult.OK)
            {
                Reload();
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void 搜索合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frsousuohetong form1 = new Frsousuohetong();
            form1.ShowDialog();

        }
    }
}