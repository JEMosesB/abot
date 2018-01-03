using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Influencers;
using Newtonsoft.Json.Linq;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public class YoutubeChecker : IChecker
    {
        public async Task<Dictionary<string, string>> GetContent(IInfluencer influencer)
        {
            var result = new Dictionary<string, string>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = await GetJson(influencer);
                timer.Stop();
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Success. Crawling Youtube page of [{influencer.Name}] has taken [{timer.Elapsed}] seconds");

                var titles = ((IEnumerable)responseJson.items).Cast<dynamic>()
                                .Select(x => new
                                {
                                    PublishedAt = (DateTime)x.snippet.publishedAt,
                                    Title = (string)x.snippet.title
                                }).Where(x => (DateTime.Now - x.PublishedAt).TotalHours < 5).ToList();

                if (titles.Count > 0)
                {
                    result.Add(influencer.Content.First().Key,
                        titles.OrderByDescending(x => x.PublishedAt).First().Title);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Failed. Crawling Youtube page of [{influencer.Name}] page has failed. Error:\n{e.Message}");
            }

            return result;
        }

        private async Task<dynamic> GetJson(IInfluencer influencer)
        {
            dynamic responseJson;
            using (var httpClient = new HttpClient())
            {
                var uriToCheck = new Uri(influencer.Url);
                responseJson = JObject.Parse(await httpClient.GetStringAsync(uriToCheck));
            }

            return responseJson;
        }
    }
}