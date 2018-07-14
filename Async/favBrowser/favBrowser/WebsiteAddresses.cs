using System;
using System.Collections.Generic;

namespace favBrowser
{
    public static class WebsiteAddresses
    {
        public static List<string> Websites = new List<string>
        {
            "google.com",
            "bing.com",
            "oreilly.com",
            "microsoft.com",
            "twitter.com",
            "reddit.com",
            "baidu.com",
            "bbc.co.uk",
            "bitbucket.org",
            "pinterest.com",
            "fastcompany.com",
            "behance.net",
            "netflix.com",
            "hackaday.com",
            "monocle.com",
            "getbootstrap.com",
            "cnn.com",
            "ebay.com",
            "amazon.com",
            "apple.com",
            "youtube.com"
        };

        public static Uri CreateUri (string domain)
        {
            return new Uri("http://" + domain + "/favicon.ico");
        }
    }
}
