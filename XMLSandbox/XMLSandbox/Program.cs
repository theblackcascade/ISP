using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace XMLSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (o, s) =>
            {
            //    var document = XDocument.Parse(s.Result);
            var document = XDocument.Load("search.atom");
                XNamespace ns = "http://www.w3.org/2005/Atom";
                var items = from item in document.Descendants(ns + "entry")
                            select new
               
                            {
                                           title = item.Element(ns + "title").Value,
                                           updated = item.Element(ns + "updated").Value,
                                           authorName = (from XElement sub in item.Descendants(ns + "author") select sub.Element(ns + "name").Value).First(),
                                           authorLink = (from XElement sub in item.Descendants(ns + "author") select sub.Element(ns + "uri").Value).First()
                                       };
                foreach (var item in items)
                    Console.Write("Tweet\n\n {0}\n ,\n {1},\n {2},\n {3}\n\n", item.title, item.updated, item.authorName, item.authorLink);
            };
            Console.WriteLine("Enter Your Search Request");
            webClient.DownloadStringAsync(new Uri("http://search.twitter.com/search.atom?q="+Console.ReadLine()));
            
            Console.ReadKey();
        }
    }
}
