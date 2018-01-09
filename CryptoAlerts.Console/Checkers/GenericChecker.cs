using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Influencers;
using CsQuery;
using NLog;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public class GenericChecker : IChecker
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public async Task<Dictionary<string, string>> GetContent(IInfluencer influencer)
        {
            var results = new Dictionary<string, string>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                CQ html = await GetHtml(influencer);
                timer.Stop();
                _logger.Info($"Success. Crawling [{influencer.Name}] page has taken [{timer.Elapsed}] seconds");

                foreach (var check in influencer.Content)
                {
                    results.Add(check.Key, html[check.Key].Text().Trim());
                }

                return results;
            }
            catch (Exception e)
            {
                _logger.Info($"Failed. Crawling [{influencer.Name}] page has failed. Url: {influencer.Url}\nError:\n{e.Message}");
            }

            return results;
        }

        private async Task<string> GetHtml(IInfluencer influencer)
        {
            string htmlContent;
            using (MyWebClient client = new MyWebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                htmlContent = await client.DownloadStringTaskAsync(new Uri(influencer.Url));
            }

            return htmlContent;
        }

        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 15 * 1000;
                return w;
            }
        }
    }
}