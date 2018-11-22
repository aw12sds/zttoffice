using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ztoffice.util
{
    class httputil
    {
        public Hashtable Httpwconnection(String url, String param)
        {

            Hashtable ht = new Hashtable();
            String postdata = "";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/html; charset=UTF-8";
                request.ContentLength = data.Length;
                Stream newStream = request.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                ht.Add("status", "success");
                ht.Add("content", content);
            }
            catch 

            {
                ht.Add( "status", "fail");
                
            }
            return ht;
        }

       
    }
}
