using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Influencers;
using CsQuery;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public class GenericChecker : IChecker
    {
        public Dictionary<string, string> GetContent(IInfluencer influencer)
        {
            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                CQ html = GetHtml(influencer);
                timer.Stop();
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Success. Crawling [{influencer.Name}] page has taken [{timer.Elapsed}] seconds");

                var results = new Dictionary<string, string>();
                foreach (var check in influencer.Content)
                {
                    results.Add(check.Key, html[check.Key].Text().Trim());
                }

                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Failed. Crawling [{influencer.Name}] page has failed. Url: {influencer.Url}\nError:\n{e.Message}");
            }

            return null;
        }

        private string GetHtml(IInfluencer influencer)
        {
            string htmlContent;
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                htmlContent = client.DownloadString(influencer.Url);
            }

            return htmlContent;
        }
    }
}