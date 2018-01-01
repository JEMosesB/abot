using System;
using System.Net;
using Abot.Crawler;
using Abot.Poco;
using CryptoAlerts.ConsoleApp.Influencers;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public static class CrawlChecker
    {

        public static void CheckWebsite(IInfluencer exchange)
        {
            var uriToCrawl = new Uri(exchange.Url);

            using (var crawler = new PoliteWebCrawler())
            {
                crawler.PageCrawlCompletedAsync += (sender, eventArgs) => ProcessPageCrawlCompletedEvent(sender, eventArgs, exchange);
                crawler.Crawl(uriToCrawl);
            }
        }

        private static void ProcessPageCrawlCompletedEvent(object sender, PageCrawlCompletedArgs e, IInfluencer exchange)
        {
            CrawledPage crawledPage = e.CrawledPage;

            if (crawledPage.WebException != null || crawledPage.HttpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Failed. Crawling [{exchange.Name}] page has failed. {crawledPage.Uri.AbsoluteUri}");
                return;
            }

            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Succeeded. Crawling [{exchange.Name}] page has succeeded. {crawledPage.Uri.AbsoluteUri}");

            // exchange.ProcessHtml(crawledPage.Content.Text);
        }
    }
}
