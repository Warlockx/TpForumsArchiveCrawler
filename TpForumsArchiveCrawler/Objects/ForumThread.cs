using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpForumsArchiveCrawler.Objects
{
    public class ForumThread
    {
        public BreadCrumb BreadCrumb { get; }
        public string Title { get; }
        public DateTime? PostTime { get; }
        public User PostCreator { get; }
        public int ThreadId { get; }
        public int? PostCount { get; }
        public List<Post> Posts { get; }


        public ForumThread(BreadCrumb breadCrumb, string title, DateTime? postTime, User postCreator, int threadId, int? postCount, List<Post> posts)
        {
            BreadCrumb = breadCrumb;
            Title = title;
            PostTime = postTime;
            PostCreator = postCreator;
            ThreadId = threadId;
            PostCount = postCount;
            Posts = posts;
        }
    }
}
