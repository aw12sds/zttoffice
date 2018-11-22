﻿using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ztoffice
{
    public partial class FrOperator : Office2007Form
    {
        public FrOperator()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrOperator_Load(object sender, EventArgs e)
        {
            Reload();
            
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrOperatorEdit a = new FrOperatorEdit();
            a.code = "Add";
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }
        public void Reload()

        {
            string strsql = "select 用户名,权限管理,部门,序号,报告组 from tb_operator ";
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(strsql, CommandType.Text);

        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            FrOperatorEdit a = new FrOperatorEdit();
            a.code = "Edit";
            a.yonghu = dataGridViewX2.CurrentRow.Cells["用户名"].Value.ToString();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            //弹出确认删除对话框
            if (dataGridViewX2.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确实要删除吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //删除选定行
                    DataGridViewRow dgvr = dataGridViewX2.CurrentRow;//获取当前选中行
                    string code = dgvr.Cells["用户名"].Value.ToString();

                    string strSql1 = "delete from tb_operator where  用户名= '" + code + "' ";

                    string result1 = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));

                    
                    MessageBox.Show("删除成功！", "软件提示");
                }

               
                Reload();
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            FrOperatorEdit a = new FrOperatorEdit();
            a.code = "Add";
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            FrOperatorEdit a = new FrOperatorEdit();
            a.code = "Edit";
            a.yonghu = dataGridViewX2.CurrentRow.Cells["用户名"].Value.ToString();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            //弹出确认删除对话框
            if (dataGridViewX2.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确实要删除吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //删除选定行
                    DataGridViewRow dgvr = dataGridViewX2.CurrentRow;//获取当前选中行
                    string code = dgvr.Cells["用户名"].Value.ToString();

                    string strSql1 = "delete from tb_operator where  用户名= '" + code + "' ";

                    string result1 = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));


                    MessageBox.Show("删除成功！", "软件提示");
                }


                Reload();
            }
        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }
    }
}
