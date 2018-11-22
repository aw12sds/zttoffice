using DevComponents.DotNetBar;
using NetWorkLib;
using NetWorkLib.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.view
{
    public partial class downloadexe : DevExpress.XtraEditors.XtraForm
    {
        public downloadexe()
        {
           
            InitializeComponent();
        }
        string pathfilesave = "";
        private void downloadexe_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            version version = new version();
            String versionnum = version.getversion("zttoffice");
            pathfilesave = System.Environment.CurrentDirectory + "\\zttoffice" + versionnum + ".exe";
            String url = "http://" + MyGlobal.ip + ":8080/ZttErp/zttCodeversionController/getZttCodeversion?fileName=zttoffice";
            client.DownloadFileAsync(new Uri(url), pathfilesave);

        }
        public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("下载已完成,请稍等会自动安装");
            Application.Exit();
            System.Diagnostics.Process.Start(pathfilesave);
        }
        public void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarX1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBarX1.Value = (int)e.BytesReceived / 100;
             progressBarX1.Text=e.ProgressPercentage.ToString()+"%";

        }
    }
}
