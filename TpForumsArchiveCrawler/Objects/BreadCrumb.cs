using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TpForumsArchiveCrawler.Objects
{
    public class BreadCrumb
    {
        public string ForumSection { get; }
        public string SubForum { get; }


        public BreadCrumb(string forumSection, string subForum)
        {
            ForumSection = forumSection;
            SubForum = subForum;
        }
    }
}
