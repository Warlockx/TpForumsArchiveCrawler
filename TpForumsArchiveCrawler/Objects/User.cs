using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpForumsArchiveCrawler.Objects
{
    public class User
    {
        public int UserId { get; }
        public string UserName { get; }

        public User(string userName)
        {
            UserId = UserCollection.UserCount;
            UserName = userName;
            UserCollection.Users.Add(this);
        }
    }
}
