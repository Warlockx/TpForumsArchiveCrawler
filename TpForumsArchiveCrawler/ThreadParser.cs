using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using TpForumsArchiveCrawler.Objects;

namespace TpForumsArchiveCrawler
{
    public static class ThreadParser
    {
        public static async Task<Thread> ParseThread(HttpResponseMessage httpResponseMessage, int threadId)
        {
            string html = await httpResponseMessage.Content.ReadAsStringAsync();
            HtmlDocument htmlDocument = new HtmlDocument();
            if (string.IsNullOrWhiteSpace(html)) return null;
            htmlDocument.LoadHtml(html);

            string postTitle =
                HttpUtility.HtmlDecode(
                    htmlDocument.DocumentNode.SelectSingleNode("//div[@id='navbar']/text()[3]")?.InnerText)?.Remove(0, 4);

            HtmlNodeCollection navbarNodes = htmlDocument.DocumentNode.SelectNodes("//div[@id='navbar']/a");
            BreadCrumb breadCrumb = ParseNavbar(navbarNodes); 

            HtmlNodeCollection postNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='post']");
            List<Post> posts = ParsePosts(postNodes);
            Post firsPost = posts?.First();

            return new Thread(breadCrumb,postTitle, firsPost?.PostTime, firsPost?.User, threadId, posts?.Count, posts);
        }

        private static BreadCrumb ParseNavbar(HtmlNodeCollection htmlNodeCollection)
        {
            if (htmlNodeCollection == null) return null;

            if (htmlNodeCollection.Count == 3)
                return new BreadCrumb(htmlNodeCollection[1].InnerText, htmlNodeCollection[2].InnerText);

            Console.WriteLine("Found a different Navbar:");
            foreach (HtmlNode node in htmlNodeCollection)
            {
                Console.WriteLine($"Node html = {node.OuterHtml}");
            }

            return null;
        }

        private static List<Post> ParsePosts(HtmlNodeCollection htmlNodeCollection)
        {
            if (htmlNodeCollection == null || htmlNodeCollection.Count == 0) return null;

            List<Post> posts = new List<Post>();
            foreach (HtmlNode htmlNode in htmlNodeCollection)
            {
                string userName = htmlNode.ChildNodes[0]?.SelectSingleNode("div[@class='username']")?.InnerText;

                User user = UserCollection.Users.Any(n => n.UserName == userName) 
                    ? UserCollection.Users.First(n => n.UserName == userName)
                    : new User(userName);

                string postDate = htmlNode.ChildNodes[0]?.SelectSingleNode("div[@class='date']")?.InnerText;

                DateTime postTime = !string.IsNullOrWhiteSpace(postDate)
                    ? DateTime.ParseExact(postDate,"M-dd-yyyy, hh:mm tt", CultureInfo.InvariantCulture )
                    : DateTime.MinValue;

                string postContent = htmlNode.ChildNodes[1]?.InnerText;

                posts.Add(new Post(user,postTime,postContent));
            }
            return posts;
        }

    }
}
