using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ztoffice.serviceImpl;

namespace ztoffice.view
{
    public partial class downloadexe : Office2007Form
    {
        public downloadexe()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        string pathfilesave = "";
        private void downloadexe_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            version version = new version();
            String versionnum = version.getversion();
            pathfilesave = System.Environment.CurrentDirectory + "\\zttoffice" + versionnum + ".exe";
            client.DownloadFileAsync(new Uri("http://10.15.1.252:8080/ZttErp/zttCodeversionController/getZttCodeversion?fileName=zttoffice"), pathfilesave);

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
