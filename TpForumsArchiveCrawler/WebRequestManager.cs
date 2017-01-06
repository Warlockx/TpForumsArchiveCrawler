using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TpForumsArchiveCrawler
{
    public class WebRequestManager
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> Get(string url)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}