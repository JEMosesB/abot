using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Influencers;
using Newtonsoft.Json.Linq;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public class YoutubeChecker : IChecker
    {
        public Dictionary<string, string> GetContent(IInfluencer influencer)
        {
            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = GetJson(influencer);
                timer.Stop();
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Success. Crawling Youtube page of [{influencer.Name}] has succeeded");

                var titles = ((IEnumerable)responseJson.items).Cast<dynamic>()
                                .Select(x => new
                                {
                                    PublishedAt = (DateTime)x.snippet.publishedAt,
                                    Title = (string)x.snippet.title
                                }).ToList();

                var result = new Dictionary<string, string>
                { {
                    influencer.Content.First().Key,
                    titles.OrderByDescending(x => x.PublishedAt).First().Title
                } };
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Failed. Crawling Youtube page of [{influencer.Name}] page has failed. Error:\n{e.Message}");
            }

            return null;
        }

        private dynamic GetJson(IInfluencer influencer)
        {
            dynamic responseJson;
            using (var httpClient = new HttpClient())
            {
                var uriToCheck = new Uri(influencer.Url);
                responseJson = JObject.Parse(httpClient.GetStringAsync(uriToCheck).Result);
            }

            return responseJson;
        }
    }
}