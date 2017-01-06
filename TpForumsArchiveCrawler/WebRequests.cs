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

        public async Task<ForumThread> GetThread(int threadId)
        {
            HttpResponseMessage responseMessage =
                await _requestManager.Get(Link.TpForumsArchive.Replace("threadId", threadId.ToString()));

            if (responseMessage == null || !responseMessage.IsSuccessStatusCode) return null;

            return await ThreadParser.ParseThread(responseMessage, threadId);
        }

        public async Task<List<ForumThread>> GetAllThreads()
        {
            List<ForumThread> threads = new List<ForumThread>();
            int threadId = 1;
            while (threads.Count < 1 || !string.IsNullOrWhiteSpace(threads.Last().Title))
            {
                try
                {
                    HttpResponseMessage responseMessage =
                        await _requestManager.Get(Link.TpForumsArchive.Replace("threadId", threadId.ToString()));

                    if (responseMessage == null || !responseMessage.IsSuccessStatusCode)
                        Console.WriteLine($"Failed to download forumThread {threadId--}\n");


                    ForumThread forumThread = await ThreadParser.ParseThread(responseMessage, threadId);

                    if (forumThread != null)
                    {
                        threads.Add(forumThread);
                        Console.WriteLine(
                            $"Last Crawled ForumThread:\nThread Title = {threads.Last()?.Title}\nThread Id = {threads.Last().ThreadId}\n");
                    }
                    else
                        Console.WriteLine($"ForumThread {threadId} seems to be a empty page\n");

                    threadId++;
                    System.Threading.Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }



            }

            return threads;
        }
    }
}
