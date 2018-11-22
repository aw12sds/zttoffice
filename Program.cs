using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.UserSkins;
using NetWork.util;
using NetWorkLib.Net;
using System;
using System.Windows.Forms;
using ztoffice.view;
using System.Drawing;
namespace ztoffice
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            String versionlocal = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version version = new version();
            getData.getiprouter();
            if (getData.ifping("10.15.1.252"))
            {
                DevExpress.UserSkins.BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");  // 设置皮肤样式
                
                //DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("宋体", 12);
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont=new Font("宋体", 12);
                Application.Run(new FrLogin());             
            }
            else if (getData.ifping("47.97.210.239"))
            {
                DevExpress.UserSkins.BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");  // 设置皮肤样式
                //DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("宋体", 12);
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = new Font("宋体", 12);
                Application.Run(new FrLogin());                          
            }
            else
            {
                DevExpress.UserSkins.BonusSkins.Register();               
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");  // 设置皮肤样式
                //DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("宋体", 12);
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = new Font("宋体", 12);
                Application.Run(new FrLogin());
            }
        }
    }
}
