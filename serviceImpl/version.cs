using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ztoffice.util;

namespace ztoffice.serviceImpl
{
    class version
    {
        httputil httputil = new httputil();

        public bool judgeversion()
        {
            //flag为true,则需下载
            bool flag = false;
            String param = "zttoffice";
            String url = "http://10.15.1.252:8080/ZttErp/zttCodeversionController/getversion?param=" + param;
            httputil httputil = new httputil();
            Hashtable ht = httputil.Httpwconnection(url, param);
            if (ht["status"].Equals("fail"))
            {
                flag = false;
            }
            if (ht["status"].Equals("success"))
            {
                String content = ht["content"].ToString();
                String versionlocal = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                if (!content.Equals(versionlocal))
                {
                    return true;
                }
            }

            else
            {

                return false;
            }
            return flag;
        }

        public String getversion()
        {
            //flag为true,则需下载
            String param = "zttoffice";
            
            String url = "http://10.15.1.252:8080/ZttErp/zttCodeversionController/getversion?param=" + param;
            httputil httputil = new httputil();
            Hashtable ht = httputil.Httpwconnection(url, param);
            String content = null;
            if (ht["status"].Equals("success"))
            {
                 content = ht["content"].ToString();

            }
            return content;
        }
    }
}
