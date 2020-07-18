using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace HttpClientTest
{
    class Program
    {
        //https://rextester.com/discussion/XPKY90132/async-example-with-HttpClient

        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Test(); //async, passes through immediately
            }
            Console.WriteLine("FIRST"); //prints sooner than pages
            Thread.Sleep(5000); //just to get the output from Test()
        }

        static async void Test()
        {
            var r = await DownloadPage("http://stackoverflow.com");
            Console.WriteLine(r.Substring(0, 50));
        }

        static async Task<string> DownloadPage(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}
