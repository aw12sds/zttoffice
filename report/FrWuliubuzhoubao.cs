﻿using Aspose.Words;
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

namespace ztoffice.report
{
    public partial class FrWuliubuzhoubao : DevExpress.XtraEditors.XtraForm
    {
        public FrWuliubuzhoubao()
        {
            //this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        public string bumen;
        public string bianhao;


        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string lujing2;
        private void FrWuliubuzhoubao_Load(object sender, EventArgs e)
        {
            string sql = "select 用户名,部门,序号 from tb_operator where 用户名='" + yonghu + "'";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);

            bumen = jieguo.Rows[0]["部门"].ToString();
            bianhao = jieguo.Rows[0]["序号"].ToString();

            string sql1 = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql1, CommandType.Text);

            string sql2 = "select 申请日期,申请部门 from workflow ";
            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);
            gridControl1.DataSource = dt2;

            string sql4 = "select 调休原因,总计时数,加班日期 from workflow ";
            DataTable dt4 = SQLhelp.GetDataTable(sql4, CommandType.Text);
            gridControl2.DataSource = dt4;


            string sql6 = "select 请假类型 from workflow ";
            DataTable dt6 = SQLhelp.GetDataTable(sql6, CommandType.Text);
            gridControl3.DataSource = dt6;

            string sql7 = "select 是否为补假 from workflow ";
            DataTable dt7 = SQLhelp.GetDataTable(sql7, CommandType.Text);
            gridControl4.DataSource = dt7;

            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {
                string n = aaaa.Rows[i]["部门"].ToString();
                spaceminute.Add(n);
            }


            //foreach (string s in spaceminute)
            //{
            //    comboBoxEx1.Items.Add(s);
            //}

            string sql12 = "Select 序号 from tb_operator where 用户名='" + yonghu + "'";
            bianhao = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
        }

       

        
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxEx2.Items.Clear();
            //string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEx1.Text + "'";
            //DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            //List<string> spaceminute = new List<string>();
            //for (int i = 0; i < aaaa.Rows.Count; i++)
            //{

            //    string n = aaaa.Rows[i]["用户名"].ToString();
            //    spaceminute.Add(n);
            //}


            //foreach (string s in spaceminute)
            //{
            //    comboBoxEx2.Items.Add(s);
            //}
        }

       

        

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView3.DeleteRow(gridView3.FocusedRowHandle);
            }
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView4.DeleteRow(gridView4.FocusedRowHandle);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtName.Text);
                    //获得文件大小
                    fileSize2 = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName2 = info.FullName.Remove(index);
                    fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);

                    //获得文件扩展名
                    fileType2 = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files2 = new byte[Convert.ToInt32(fileSize2)];
                    FileStream file1 = new FileStream(txtName.Text, FileMode.Open, FileAccess.Read);
                    read2 = new BinaryReader(file1);
                    read2.Read(files2, 0, Convert.ToInt32(fileSize2));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //if (comboBoxEx1.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请先选择部门！");
            //    return;
            //}
            //string sql = "select 用户名 from tb_operator where 部门='" + comboBoxEx1.Text + "'";
            //DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);
            //List<string> spaceminute = new List<string>();
            //for (int i = 0; i < aaaa.Rows.Count; i++)
            //{

            //    string n = aaaa.Rows[i]["用户名"].ToString();
            //    spaceminute.Add(n);
            //}
            //foreach (string s in spaceminute)
            //{
            //    textBox7.Text += s + ";";
            //}
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //if (comboBoxEx2.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请先选择人员！");
            //    return;
            //}

            //textBox7.Text += comboBoxEx2.Text + ";";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string strSql11 = "select 接收人分组 from tb_operator  where  用户名='" + yonghu + "' ";
            string fenzu = SQLhelp.ExecuteScalar(strSql11, CommandType.Text).ToString();
            if (fenzu == "")
            {
                MessageBox.Show("请先设置接收人分组！");
                return;
            }

            textBox7.Text = fenzu;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("请选择接收人！");
                return;
            }
            if (txthetongqianding.Text == "")
            {
                MessageBox.Show("请填写合同签订情况！");
                return;
            }
            if (txtfukuanqinguang.Text == "")
            {
                MessageBox.Show("请填写付款情况！");
                return;
            }
            if (txtgongyingshangkaifa.Text == "")
            {
                MessageBox.Show("请填写供应商开发数量！");
                return;
            }
            if (txtgongyingshangqiatan.Text == "")
            {
                MessageBox.Show("请填写供应商洽谈数量！");
                return;
            }
            if (txtzongxiangmu.Text == "")
            {
                MessageBox.Show("请填写总项目数！");
                return;
            }
            if (txtzhengchangkaizhanxiangmu.Text == "")
            {
                MessageBox.Show("请填写正常开展项目数！");
                return;
            }

            if (txtyiwanchengxiangmu.Text == "")
            {
                MessageBox.Show("请填写已完成项目数！");
                return;
            }
            if (txtuyanqixiangmu.Text == "")
            {
                MessageBox.Show("请填写延期项目数！");
                return;
            }
            if (txtxiajieduanhetongqianding.Text == "")
            {
                MessageBox.Show("请填写下阶段合同签订情况！");
                return;

            }
            if (txtxiajieduangongyingshangkaifa.Text == "")
            {
                MessageBox.Show("请填写下阶段供应商开发情况！");
                return;

            }
            if (txtxiajieduangongyingshangqiatan.Text == "")
            {
                MessageBox.Show("请填写下阶段供应商洽谈情况！");
                return;

            }

            if (txtxiajieduanfukuan.Text == "")
            {
                MessageBox.Show("请填写下阶段付款情况！");
                return;

            }


            if (gridView1.RowCount > 11)
            {
                MessageBox.Show("项目管理分析不得超过十条,请酌情压缩！");
                return;

            }
            if (gridView2.RowCount > 11)
            {
                MessageBox.Show("管理情况不得超过十条,请酌情压缩！");
                return;

            }
            if (gridView3.RowCount > 11)
            {
                MessageBox.Show("项目推进计划不得超过十条,请酌情压缩！");
                return;

            }
            if (gridView4.RowCount > 11)
            {
                MessageBox.Show("管理工作规划不得超过十条,请酌情压缩！");
                return;

            }

            if (gridView1.RowCount == 1)
            {
                MessageBox.Show("必须写项目管理分析！");
                return;

            }
            if (gridView2.RowCount == 1)
            {
                MessageBox.Show("必须写管理情况！");
                return;

            }
            if (gridView3.RowCount == 1)
            {
                MessageBox.Show("必须写项目推进计划！");
                return;

            }
            if (gridView4.RowCount == 1)
            {
                MessageBox.Show("必须写管理工作规划！");
                return;

            }


            if (gridView1.RowCount > 1 && gridView1.RowCount < 12)
            {

                if (gridView1.GetRowCellValue(0, "申请日期").ToString() == "")
                {
                    MessageBox.Show("第一条存在问题必须输入！");
                    return;
                }

                if (gridView1.GetRowCellValue(0, "申请部门").ToString() == "")
                {
                    MessageBox.Show("第一条改善措施必须输入！");
                    return;
                }

                string a = gridView1.GetRowCellValue(0, "申请日期").ToString();
                int changdu = a.Length;

                if (a.Trim() == "")
                {
                    MessageBox.Show("不准投机取巧，必须输入真实文字！");
                    return;

                }

                string b = gridView1.GetRowCellValue(0, "申请部门").ToString();
                int changdub = b.Length;

                if (b.Trim() == "")
                {
                    MessageBox.Show("不准投机取巧，必须输入真实文字！");
                    return;

                }

            }


            if (gridView2.RowCount > 1 && gridView2.RowCount < 12)
            {

                if (gridView2.GetRowCellValue(0, "调休原因").ToString() == "")
                {
                    MessageBox.Show("第一条事件描述必须输入！");
                    return;
                }

                if (gridView2.GetRowCellValue(0, "总计时数").ToString() == "")
                {
                    MessageBox.Show("第一条事件描述必须输入！");
                    return;
                }

                if (gridView2.GetRowCellValue(0, "加班日期").ToString() == "")
                {
                    MessageBox.Show("第一条事件描述必须输入！");
                    return;
                }

                string a = gridView2.GetRowCellValue(0, "调休原因").ToString();


                if (a.Trim() == "")
                {
                    MessageBox.Show("不准投机取巧，必须输入真实文字！");
                    return;
                }

                string b = gridView2.GetRowCellValue(0, "总计时数").ToString();


                if (b.Trim() == "")
                {
                    MessageBox.Show("不准投机取巧，必须输入真实文字！");
                    return;

                }

                string c = gridView2.GetRowCellValue(0, "加班日期").ToString();


                if (c.Trim() == "")
                {
                    MessageBox.Show("不准投机取巧，必须输入真实文字！");
                    return;

                }

            }

            if (gridView3.RowCount > 1 && gridView3.RowCount < 12)
            {

                if (gridView3.GetRowCellValue(0, "请假类型").ToString() == "")
                {
                    MessageBox.Show("第一条项目推进计划必须输入！");
                    return;
                }

                string a = gridView3.GetRowCellValue(0, "请假类型").ToString();

                if (a.Trim() == "")
                {
                    MessageBox.Show("不准投机取巧，必须输入真实文字！");
                    return;
                }


            }
            if (gridView4.RowCount > 1 && gridView4.RowCount < 12)
            {

                if (gridView4.GetRowCellValue(0, "是否为补假").ToString() == "")
                {
                    MessageBox.Show("第一条管理工作规划必须输入！");
                    return;
                }
                string a = gridView4.GetRowCellValue(0, "是否为补假").ToString();

                if (a.Trim() == "")
                {
                    MessageBox.Show("不准投机取巧，必须输入真实文字！");
                    return;
                }

            }

            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("经营合同签订情况", typeof(string));
                dt1.Columns.Add("经营供应商开发数量", typeof(string));
                dt1.Columns.Add("经营供应商洽谈数量", typeof(string));
                dt1.Columns.Add("已完成项目数", typeof(string));
                dt1.Columns.Add("延期项目数", typeof(string));
                dt1.Columns.Add("正常开展项目数", typeof(string));
                dt1.Columns.Add("总项目数", typeof(string));
                dt1.Columns.Add("经营付款情况", typeof(string));
                dt1.Columns.Add("下阶段合同签订情况", typeof(string));
                dt1.Columns.Add("下阶段供应商洽谈数量", typeof(string));
                dt1.Columns.Add("下阶段供应商开发数量", typeof(string));
                dt1.Columns.Add("下阶段付款情况", typeof(string));



                dt1.Columns.Add("存在问题1", typeof(string));
                dt1.Columns.Add("存在问题2", typeof(string));
                dt1.Columns.Add("存在问题3", typeof(string));
                dt1.Columns.Add("存在问题4", typeof(string));
                dt1.Columns.Add("存在问题5", typeof(string));
                dt1.Columns.Add("存在问题6", typeof(string));
                dt1.Columns.Add("存在问题7", typeof(string));
                dt1.Columns.Add("存在问题8", typeof(string));
                dt1.Columns.Add("存在问题9", typeof(string));
                dt1.Columns.Add("存在问题10", typeof(string));


                dt1.Columns.Add("改善措施1", typeof(string));
                dt1.Columns.Add("改善措施2", typeof(string));
                dt1.Columns.Add("改善措施3", typeof(string));
                dt1.Columns.Add("改善措施4", typeof(string));
                dt1.Columns.Add("改善措施5", typeof(string));
                dt1.Columns.Add("改善措施6", typeof(string));
                dt1.Columns.Add("改善措施7", typeof(string));
                dt1.Columns.Add("改善措施8", typeof(string));
                dt1.Columns.Add("改善措施9", typeof(string));
                dt1.Columns.Add("改善措施10", typeof(string));



                dt1.Columns.Add("序号1", typeof(string));
                dt1.Columns.Add("序号2", typeof(string));
                dt1.Columns.Add("序号3", typeof(string));
                dt1.Columns.Add("序号4", typeof(string));
                dt1.Columns.Add("序号5", typeof(string));
                dt1.Columns.Add("序号6", typeof(string));
                dt1.Columns.Add("序号7", typeof(string));
                dt1.Columns.Add("序号8", typeof(string));
                dt1.Columns.Add("序号9", typeof(string));
                dt1.Columns.Add("序号10", typeof(string));



                dt1.Columns.Add("事件描述1", typeof(string));
                dt1.Columns.Add("事件描述2", typeof(string));
                dt1.Columns.Add("事件描述3", typeof(string));
                dt1.Columns.Add("事件描述4", typeof(string));
                dt1.Columns.Add("事件描述5", typeof(string));
                dt1.Columns.Add("事件描述6", typeof(string));
                dt1.Columns.Add("事件描述7", typeof(string));
                dt1.Columns.Add("事件描述8", typeof(string));
                dt1.Columns.Add("事件描述9", typeof(string));
                dt1.Columns.Add("事件描述10", typeof(string));



                dt1.Columns.Add("管理存在问题1", typeof(string));
                dt1.Columns.Add("管理存在问题2", typeof(string));
                dt1.Columns.Add("管理存在问题3", typeof(string));
                dt1.Columns.Add("管理存在问题4", typeof(string));
                dt1.Columns.Add("管理存在问题5", typeof(string));
                dt1.Columns.Add("管理存在问题6", typeof(string));
                dt1.Columns.Add("管理存在问题7", typeof(string));
                dt1.Columns.Add("管理存在问题8", typeof(string));
                dt1.Columns.Add("管理存在问题9", typeof(string));
                dt1.Columns.Add("管理存在问题10", typeof(string));


                dt1.Columns.Add("管理改善措施1", typeof(string));
                dt1.Columns.Add("管理改善措施2", typeof(string));
                dt1.Columns.Add("管理改善措施3", typeof(string));
                dt1.Columns.Add("管理改善措施4", typeof(string));
                dt1.Columns.Add("管理改善措施5", typeof(string));
                dt1.Columns.Add("管理改善措施6", typeof(string));
                dt1.Columns.Add("管理改善措施7", typeof(string));
                dt1.Columns.Add("管理改善措施8", typeof(string));
                dt1.Columns.Add("管理改善措施9", typeof(string));
                dt1.Columns.Add("管理改善措施10", typeof(string));

                dt1.Columns.Add("项目推进计划1", typeof(string));
                dt1.Columns.Add("项目推进计划2", typeof(string));
                dt1.Columns.Add("项目推进计划3", typeof(string));
                dt1.Columns.Add("项目推进计划4", typeof(string));
                dt1.Columns.Add("项目推进计划5", typeof(string));
                dt1.Columns.Add("项目推进计划6", typeof(string));
                dt1.Columns.Add("项目推进计划7", typeof(string));
                dt1.Columns.Add("项目推进计划8", typeof(string));
                dt1.Columns.Add("项目推进计划9", typeof(string));
                dt1.Columns.Add("项目推进计划10", typeof(string));



                dt1.Columns.Add("管理工作规划1", typeof(string));
                dt1.Columns.Add("管理工作规划2", typeof(string));
                dt1.Columns.Add("管理工作规划3", typeof(string));
                dt1.Columns.Add("管理工作规划4", typeof(string));
                dt1.Columns.Add("管理工作规划5", typeof(string));
                dt1.Columns.Add("管理工作规划6", typeof(string));
                dt1.Columns.Add("管理工作规划7", typeof(string));
                dt1.Columns.Add("管理工作规划8", typeof(string));
                dt1.Columns.Add("管理工作规划9", typeof(string));
                dt1.Columns.Add("管理工作规划10", typeof(string));

                DataRow dr1 = dt1.NewRow();


                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "申请日期").ToString() == "")
                    {
                        dr1["存在问题" + (i + 1)] = "";
                    }
                    if (gridView1.GetRowCellValue(i, "申请日期").ToString() != "")
                    {
                        dr1["存在问题" + (i + 1)] = gridView1.GetRowCellValue(i, "申请日期").ToString();
                    }
                    if (gridView1.GetRowCellValue(i, "申请部门").ToString() == "")
                    {
                        dr1["改善措施" + (i + 1)] = "";
                    }
                    if (gridView1.GetRowCellValue(i, "申请部门").ToString() != "")
                    {
                        dr1["改善措施" + (i + 1)] = gridView1.GetRowCellValue(i, "申请部门").ToString();
                    }

                }
                for (int i = 0; i < gridView2.RowCount - 1; i++)
                {

                    if (gridView2.GetRowCellValue(i, "调休原因").ToString() == "")
                    {
                        dr1["事件描述" + (i + 1)] = "";
                    }


                    if (gridView2.GetRowCellValue(i, "调休原因").ToString() != "")
                    {
                        dr1["事件描述" + (i + 1)] = gridView2.GetRowCellValue(i, "调休原因").ToString();
                        dr1["序号" + (i + 1)] = i + 1;
                    }

                    if (gridView2.GetRowCellValue(i, "总计时数").ToString() == "")
                    {
                        dr1["管理存在问题" + (i + 1)] = "";
                    }


                    if (gridView2.GetRowCellValue(i, "总计时数").ToString() != "")
                    {
                        dr1["管理存在问题" + (i + 1)] = gridView2.GetRowCellValue(i, "总计时数").ToString();
                    }


                    if (gridView2.GetRowCellValue(i, "加班日期").ToString() == "")
                    {
                        dr1["管理改善措施" + (i + 1)] = "";
                    }


                    if (gridView2.GetRowCellValue(i, "加班日期").ToString() != "")
                    {
                        dr1["管理改善措施" + (i + 1)] = gridView2.GetRowCellValue(i, "加班日期").ToString();
                    }

                }


                for (int i = 0; i < gridView3.RowCount - 1; i++)
                {
                    if (gridView3.GetRowCellValue(i, "请假类型").ToString() == "")
                    {
                        dr1["项目推进计划" + (i + 1)] = "";
                    }
                    if (gridView3.GetRowCellValue(i, "请假类型").ToString() != "")
                    {
                        dr1["项目推进计划" + (i + 1)] = gridView3.GetRowCellValue(i, "请假类型").ToString();
                    }


                }
                for (int i = 0; i < gridView4.RowCount - 1; i++)
                {
                    if (gridView4.GetRowCellValue(i, "是否为补假").ToString() == "")
                    {
                        dr1["管理工作规划" + (i + 1)] = "";
                    }

                    if (gridView4.GetRowCellValue(i, "是否为补假").ToString() != "")
                    {
                        dr1["管理工作规划" + (i + 1)] = gridView4.GetRowCellValue(i, "是否为补假").ToString();
                    }

                }



                dr1["经营合同签订情况"] = txthetongqianding.Text;
                dr1["经营供应商开发数量"] = txtgongyingshangkaifa.Text;
                dr1["经营供应商洽谈数量"] = txtgongyingshangqiatan.Text;
                dr1["经营付款情况"] = txtfukuanqinguang.Text;
                dr1["下阶段合同签订情况"] = txtxiajieduanhetongqianding.Text;
                dr1["下阶段供应商洽谈数量"] = txtxiajieduangongyingshangqiatan.Text;
                dr1["下阶段供应商开发数量"] = txtxiajieduangongyingshangkaifa.Text;
                dr1["下阶段付款情况"] = txtxiajieduanfukuan.Text;

                dr1["总项目数"] = txtzongxiangmu.Text;
                dr1["延期项目数"] = txtuyanqixiangmu.Text;
                dr1["已完成项目数"] = txtyiwanchengxiangmu.Text;
                dr1["正常开展项目数"] = txtzhengchangkaizhanxiangmu.Text;



                dt1.Rows.Add(dr1);

                string tempFile = Application.StartupPath + "\\物流部周报模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];


                dic.Add("经营合同签订情况", dr["经营合同签订情况"].ToString());
                dic.Add("总项目数", dr["总项目数"].ToString());
                dic.Add("已完成项目数", dr["已完成项目数"].ToString());
                dic.Add("延期项目数", dr["延期项目数"].ToString());
                dic.Add("正常开展项目数", dr["正常开展项目数"].ToString());
                dic.Add("经营供应商开发数量", dr["经营供应商开发数量"].ToString());
                dic.Add("经营供应商洽谈数量", dr["经营供应商洽谈数量"].ToString());
                dic.Add("经营付款情况", dr["经营付款情况"].ToString());
                dic.Add("下阶段合同签订情况", dr["下阶段合同签订情况"].ToString());
                dic.Add("下阶段供应商洽谈数量", dr["下阶段供应商洽谈数量"].ToString());
                dic.Add("下阶段供应商开发数量", dr["下阶段供应商开发数量"].ToString());
                dic.Add("下阶段付款情况", dr["下阶段付款情况"].ToString());


                dic.Add("序号1", dr["序号1"].ToString());
                dic.Add("序号2", dr["序号2"].ToString());
                dic.Add("序号3", dr["序号3"].ToString());
                dic.Add("序号4", dr["序号4"].ToString());
                dic.Add("序号5", dr["序号5"].ToString());
                dic.Add("序号6", dr["序号6"].ToString());
                dic.Add("序号7", dr["序号7"].ToString());
                dic.Add("序号8", dr["序号8"].ToString());
                dic.Add("序号9", dr["序号9"].ToString());
                dic.Add("序号10", dr["序号10"].ToString());



                dic.Add("存在问题1", dr["存在问题1"].ToString());
                dic.Add("存在问题2", dr["存在问题2"].ToString());
                dic.Add("存在问题3", dr["存在问题3"].ToString());
                dic.Add("存在问题4", dr["存在问题4"].ToString());
                dic.Add("存在问题5", dr["存在问题5"].ToString());
                dic.Add("存在问题6", dr["存在问题6"].ToString());
                dic.Add("存在问题7", dr["存在问题7"].ToString());
                dic.Add("存在问题8", dr["存在问题8"].ToString());
                dic.Add("存在问题9", dr["存在问题9"].ToString());
                dic.Add("存在问题10", dr["存在问题10"].ToString());


                dic.Add("改善措施1", dr["改善措施1"].ToString());
                dic.Add("改善措施2", dr["改善措施2"].ToString());
                dic.Add("改善措施3", dr["改善措施3"].ToString());
                dic.Add("改善措施4", dr["改善措施4"].ToString());
                dic.Add("改善措施5", dr["改善措施5"].ToString());
                dic.Add("改善措施6", dr["改善措施6"].ToString());
                dic.Add("改善措施7", dr["改善措施7"].ToString());
                dic.Add("改善措施8", dr["改善措施8"].ToString());
                dic.Add("改善措施9", dr["改善措施9"].ToString());
                dic.Add("改善措施10", dr["改善措施10"].ToString());



                dic.Add("事件描述1", dr["事件描述1"].ToString());
                dic.Add("事件描述2", dr["事件描述2"].ToString());
                dic.Add("事件描述3", dr["事件描述3"].ToString());
                dic.Add("事件描述4", dr["事件描述4"].ToString());
                dic.Add("事件描述5", dr["事件描述5"].ToString());
                dic.Add("事件描述6", dr["事件描述6"].ToString());
                dic.Add("事件描述7", dr["事件描述7"].ToString());
                dic.Add("事件描述8", dr["事件描述8"].ToString());
                dic.Add("事件描述9", dr["事件描述9"].ToString());
                dic.Add("事件描述10", dr["事件描述10"].ToString());



                dic.Add("管理存在问题1", dr["管理存在问题1"].ToString());
                dic.Add("管理存在问题2", dr["管理存在问题2"].ToString());
                dic.Add("管理存在问题3", dr["管理存在问题3"].ToString());
                dic.Add("管理存在问题4", dr["管理存在问题4"].ToString());
                dic.Add("管理存在问题5", dr["管理存在问题5"].ToString());
                dic.Add("管理存在问题6", dr["管理存在问题6"].ToString());
                dic.Add("管理存在问题7", dr["管理存在问题7"].ToString());
                dic.Add("管理存在问题8", dr["管理存在问题8"].ToString());
                dic.Add("管理存在问题9", dr["管理存在问题9"].ToString());
                dic.Add("管理存在问题10", dr["管理存在问题10"].ToString());






                dic.Add("管理改善措施1", dr["管理改善措施1"].ToString());
                dic.Add("管理改善措施2", dr["管理改善措施2"].ToString());
                dic.Add("管理改善措施3", dr["管理改善措施3"].ToString());
                dic.Add("管理改善措施4", dr["管理改善措施4"].ToString());
                dic.Add("管理改善措施5", dr["管理改善措施5"].ToString());
                dic.Add("管理改善措施6", dr["管理改善措施6"].ToString());
                dic.Add("管理改善措施7", dr["管理改善措施7"].ToString());
                dic.Add("管理改善措施8", dr["管理改善措施8"].ToString());
                dic.Add("管理改善措施9", dr["管理改善措施9"].ToString());
                dic.Add("管理改善措施10", dr["管理改善措施10"].ToString());


                dic.Add("项目推进计划1", dr["项目推进计划1"].ToString());
                dic.Add("项目推进计划2", dr["项目推进计划2"].ToString());
                dic.Add("项目推进计划3", dr["项目推进计划3"].ToString());
                dic.Add("项目推进计划4", dr["项目推进计划4"].ToString());
                dic.Add("项目推进计划5", dr["项目推进计划5"].ToString());
                dic.Add("项目推进计划6", dr["项目推进计划6"].ToString());
                dic.Add("项目推进计划7", dr["项目推进计划7"].ToString());
                dic.Add("项目推进计划8", dr["项目推进计划8"].ToString());
                dic.Add("项目推进计划9", dr["项目推进计划9"].ToString());
                dic.Add("项目推进计划10", dr["项目推进计划10"].ToString());


                dic.Add("管理工作规划1", dr["管理工作规划1"].ToString());
                dic.Add("管理工作规划2", dr["管理工作规划2"].ToString());
                dic.Add("管理工作规划3", dr["管理工作规划3"].ToString());
                dic.Add("管理工作规划4", dr["管理工作规划4"].ToString());
                dic.Add("管理工作规划5", dr["管理工作规划5"].ToString());
                dic.Add("管理工作规划6", dr["管理工作规划6"].ToString());
                dic.Add("管理工作规划7", dr["管理工作规划7"].ToString());
                dic.Add("管理工作规划8", dr["管理工作规划8"].ToString());
                dic.Add("管理工作规划9", dr["管理工作规划9"].ToString());
                dic.Add("管理工作规划10", dr["管理工作规划10"].ToString());

                foreach (var key in dic.Keys)
                {
                    builder.MoveToBookmark(key);
                    builder.Write(dic[key]);
                }
                string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "周报" + ".doc";
                FileInfo info1 = new FileInfo(Application.StartupPath + "\\" + mingcheng);
                string fileName11 = info1.Name.ToString();
                string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();

                doc.Save(info1.DirectoryName + "\\" + fileName11);


                FileInfo info = new FileInfo(info1.DirectoryName + "\\" + fileName11);
                //获得文件大小
                long fileSize12 = info.Length;
                //提取文件名,三步走
                int index = info.FullName.LastIndexOf(".");
                string fileName12 = info.FullName.Remove(index);
                fileName12 = fileName12.Substring(fileName12.LastIndexOf(@"\") + 1);
                //txtMingcheng.Text = fileName;
                //获得文件扩展名
                string fileType12 = info.Extension.Replace(".", "");
                //把文件转换成二进制流
                byte[] files12 = new byte[Convert.ToInt32(fileSize12)];
                FileStream file = new FileStream(info1.DirectoryName + "\\" + fileName11, FileMode.Open, FileAccess.Read);
                BinaryReader read = new BinaryReader(file);
                read.Read(files12, 0, Convert.ToInt32(fileSize12));

                DateTime shijian1 = DateTime.Now;
                string sql1 = "INSERT INTO tb_wenjian(文件,提交时间,员工姓名) VALUES (@pic,'" + shijian1 + "','" + yonghu + "')";
                SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files12);

                string sql = "update tb_wenjian set 报告类型='周报',提交时间='" + shijian1 + "',文件类型='doc',部门='" + bumen + "',日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ,报告标题='" + DateTime.Now.ToString("yyyy-MM-dd") + yonghu + "周报" + "',接收人='" + textBox7.Text + "',编号='" + bianhao + "'  where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";

                int g = SQLhelp.innn(sql, CommandType.Text);

                if (txtName.Text != "")
                {
                    string sql2 = "update tb_wenjian  set 附件=@pic where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";
                    SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files2);

                    string sql3 = "update tb_wenjian  set 附件名称='" + fileName2 + "',附件类型='" + fileType2 + "'  where 员工姓名='" + yonghu + "' and 提交时间='" + shijian1 + "' ";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                }
                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}
