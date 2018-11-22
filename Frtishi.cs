using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztoffice
{
    public partial class Frtishi : DevExpress.XtraEditors.XtraForm
    {
        public Frtishi()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frtishi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frzhuyaojiemian aa = new Frzhuyaojiemian();
            aa.yonghu = yonghu;
            aa.Show();
            
        }

        private void Frtishi_Load(object sender, EventArgs e)
        {

        }
    }
}