using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpForumsArchiveCrawler.Objects
{
    public class Thread
    {
        public BreadCrumb BreadCrumb { get; }
        public string Title { get; }
        public DateTime PostTime { get; }
        public User PostCreator { get; }
        public int ThreadId { get; }
        public int postCount { get; }
        public IEnumerable<Post> Posts { get; }
       

        public Thread(BreadCrumb breadCrumb,string title, DateTime postTime, User postCreator, int threadId, int postCount, IEnumerable<Post> posts)
        {
            Title = title;
            PostTime = postTime;
            PostCreator = postCreator;
            ThreadId = threadId;
            this.postCount = postCount;
            Posts = posts;
            BreadCrumb = breadCrumb;
        }
    }
}
