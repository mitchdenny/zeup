using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Zeup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostname = args[0];
            var username = args[1];
            var password = args[2];

            var request = CreateRequest(hostname, username, password);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            using (var reader = new StreamReader(stream))
            {
                var output = reader.ReadToEnd();
                Console.WriteLine(output);
            }
        }

        private static HttpWebRequest CreateRequest(string hostname, string username, string password)
        {
            var credentials = new NetworkCredential(username, password);
            var url = string.Format("http://dynamic.zoneedit.com/auth/dynamic.html?host={0}", hostname);
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Credentials = credentials;
            return request;
        }
    }
}
