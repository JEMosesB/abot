using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Abot.Crawler;
using Abot.Poco;
using CryptoAlerts.ConsoleApp.Influencers;
using CsQuery;
using Twilio;

namespace CryptoAlerts.ConsoleApp
{
    public class CryptoAlerter
    {
        public CryptoAlerter()
        {
            log4net.Config.XmlConfigurator.Configure();
            TwilioClient.Init("AC7b07eea0532bc8889257e22df4185fcd", "8eaf16a3cf44a49976e07ad1b78321f7");
        }

        public async Task StartMonitoringExchange(IInfluencer exchange, CancellationToken token = default(CancellationToken))
        {
            Uri uriToCrawl = new Uri(exchange.Url);

            IWebCrawler crawler;

            while (!token.IsCancellationRequested)
            {
                using (crawler = new PoliteWebCrawler()) { 
                    crawler.PageCrawlCompletedAsync += (sender, eventArgs) => ProcessPageCrawlCompletedEvent(sender, eventArgs, exchange);
                    crawler.Crawl(uriToCrawl);
                }

                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(exchange.IntervalInSeconds), token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
        }

        private void ProcessPageCrawlCompletedEvent(object sender, PageCrawlCompletedArgs e, IInfluencer exchange)
        {
            CrawledPage crawledPage = e.CrawledPage;

            if (crawledPage.WebException != null || crawledPage.HttpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(
                    $"[{DateTime.Now.ToString("HH:mm:ss")}] Crawling {exchange.Name} page has failed {crawledPage.Uri.AbsoluteUri}");
                return;
            }

            Console.WriteLine(
                $"[{DateTime.Now.ToString("HH:mm:ss")}] Crawling {exchange.Name} page has succeeded {crawledPage.Uri.AbsoluteUri}");

            exchange.ProcessHtml(crawledPage.Content.Text);
        }
    }
}