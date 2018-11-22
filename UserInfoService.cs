using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ztoffice
{
    class UserInfoService
    {
        public static string Username()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string Username = config.AppSettings.Settings["Username"].Value;
            return Username;

        }
        public static string Password()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string Password = config.AppSettings.Settings["Password"].Value;
            return Password;

        }
        public static string Administrators()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string Username = config.AppSettings.Settings["Administrators"].Value;
            return Username;

        }
        public static string AdministratorsPassword()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string Password = config.AppSettings.Settings["AdministratorsPassword"].Value;
            return Password;

        }
    }
}
