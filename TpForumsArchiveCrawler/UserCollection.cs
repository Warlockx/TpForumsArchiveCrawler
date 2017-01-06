using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpForumsArchiveCrawler.Objects;

namespace TpForumsArchiveCrawler
{
    public static class UserCollection
    {
        public static List<User> Users = new List<User>();
        public static int UserCount => Users.Count;
    }
}
