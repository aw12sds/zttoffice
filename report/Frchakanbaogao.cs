using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Aspose.Words;
using DevExpress.Spreadsheet;

namespace ztoffice.report
{
    public partial class Frchakanbaogao : DevExpress.XtraEditors.XtraForm
    {
        public Frchakanbaogao()
        {
            InitializeComponent();
         
        }

    
        public string lujing;
        private void Frchakanbaogao_Load(object sender, EventArgs e)
        {

            Document doc = new Document(lujing);
            string aa = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            Random rd = new Random();
            string a = rd.Next(10, 1000000).ToString();
            string aaa = aa + a;
            doc.Save(System.Environment.CurrentDirectory + "\\" + aa + ".pdf", Aspose.Words.SaveFormat.Pdf);
            this.pdfViewer1.LoadDocument(System.Environment.CurrentDirectory + "\\" + aa + ".pdf");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "报告";
            //IWorkbook workbook = spreadsheetControl1.Document;
            //workbook.LoadDocument(System.Environment.CurrentDirectory + "\\" + "收料报告单模板" + ".xlsx");
        }
    }
}