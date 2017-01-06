using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpForumsArchiveCrawler.Objects
{
    public class Post
    {
        public User User { get; }
        public DateTime PostTime { get;}
        public string PostContent { get; }

        public Post(User user, DateTime postTime, string postContent)
        {
            User = user;
            PostTime = postTime;
            PostContent = postContent;
        }
    }
}
