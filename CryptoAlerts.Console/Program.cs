using Abot.Crawler;
using Abot.Poco;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Exchanges;
using CsQuery;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CryptoAlerts.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press Enter to exit!");

            var cryptoAlerter = new CryptoAlerter();

            cryptoAlerter.StartMonitoringExchange(new Binance());
            cryptoAlerter.StartMonitoringExchange(new Bitfinex());

            Console.ReadLine();
        }
    }

    public class CryptoAlerter
    {
        public CryptoAlerter()
        {
            log4net.Config.XmlConfigurator.Configure();
            TwilioClient.Init("AC7b07eea0532bc8889257e22df4185fcd", "8eaf16a3cf44a49976e07ad1b78321f7");
        }

        public async Task StartMonitoringExchange(IExchange exchange, CancellationToken token = default(CancellationToken))
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

        private void ProcessPageCrawlCompletedEvent(object sender, PageCrawlCompletedArgs e, IExchange exchange)
        {
            //Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] exchange.Name: {exchange.Name}");
            CrawledPage crawledPage = e.CrawledPage;

            if (crawledPage.WebException != null || crawledPage.HttpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(
                    $"[{DateTime.Now.ToString("HH:mm:ss")}] Crawl of page failed {crawledPage.Uri.AbsoluteUri}");
                return;
            }

            Console.WriteLine(
                $"[{DateTime.Now.ToString("HH:mm:ss")}] Crawl of page succeeded {crawledPage.Uri.AbsoluteUri}");

            CQ dom = crawledPage.Content.Text; //raw html

            var newAnnouncedValue = dom[exchange.CssString].Text().Trim();

            if (newAnnouncedValue != exchange.LastValue)
            {
                SendSms(exchange, newAnnouncedValue);
                exchange.LastValue = newAnnouncedValue;
            }
        }

        private static void SendSms(IExchange exchange, string newNewsValue)
        {
            var smsMessage =
                $"[{DateTime.Now.ToString("HH:mm:ss")}] {exchange.Name} has a new listing!\nNew announcement: [{newNewsValue}]\nHere is the link if you want to check it out: {exchange.Url}";

            MessageResource.Create(
                to: new PhoneNumber("+447831917259"),
                from: new PhoneNumber("+441618507067"),
                body: smsMessage);
        }
    }
}