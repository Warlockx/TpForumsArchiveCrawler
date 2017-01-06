using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TpForumsArchiveCrawler.Objects;

namespace TpForumsArchiveCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
           Test().Wait();
            Console.ReadKey();
        }

        private static async Task Test()
        {
            WebRequests requests = new WebRequests();

            Thread t = await requests.GetThread(1);


            string json = JsonConvert.SerializeObject(t,Formatting.Indented);

            Console.WriteLine(json);
        }

    }
}
