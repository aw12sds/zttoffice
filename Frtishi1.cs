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
    public partial class Frtishi1 : DevExpress.XtraEditors.XtraForm
    {
        public string mac;
        public Frtishi1(string mac)
        {
            InitializeComponent();
            this.mac = mac;
        }

        private void Frtishi1_Load(object sender, EventArgs e)
        {
            textBox1.Text = mac;
            richTextBox1.Text = "新版经营管理系统为了信息安全考虑,只能用本公司电脑打开,外部电脑无法使用,请将设备号通过rtx发给信息部康湘苏,rtx只需发送\n" +
                "1.您的设备号(上方,直接复制)\n2.您的姓名\n3.一张截图(其中桌面截图需要能看到有腾讯通或者加密软件,只需证明此电脑为公司电脑,而不是个人电脑即可)\n发送完毕,关闭经营管理系统,等待审核,大概5分钟后再次打开既能正常访问";
        }
    }
}
