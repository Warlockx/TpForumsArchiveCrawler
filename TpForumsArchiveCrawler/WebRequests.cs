using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TpForumsArchiveCrawler.Objects;

namespace TpForumsArchiveCrawler
{
    public class WebRequests
    {
        private WebRequestManager _requestManager = new WebRequestManager();
        public async Task<Thread> GetThread(int threadId)
        {
            HttpResponseMessage responseMessage = await _requestManager.Get(Link.TpForumsArchive.Replace("threadId", threadId.ToString()));

            if (!responseMessage.IsSuccessStatusCode) return null;

            return await ThreadParser.ParseThread(responseMessage, threadId);
        }
    }
}
