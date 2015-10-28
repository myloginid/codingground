using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
using System.Net;
using System.IO;
					
public class Program
{
	//private const string URL = "https://sub.domain.com/objects.json";
	private const string URL = "http://x01tbipapp5a:50070/webhdfs/v1/user/dmsdrba/Extracted_Files/2015-03-13T080427-0000.11363651.Kok_Tong.B.150310-150311.xml";
    private const string DATA = @"{""object"":{""name"":""Name""}}";

	public static void Main()
	{
		Console.WriteLine("Hello World");
		  HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            Console.Out.WriteLine(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }

	}
}