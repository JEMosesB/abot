using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Core;

namespace CryptoAlerts.ConsoleApp.BaseModels
{
    public class YoutubeAlert : BaseAlert
    {
        protected override async Task<Dictionary<string, string>> GetContent()
        {
            var result = new Dictionary<string, string>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = await ContentGetter.GetJson(Url);
                timer.Stop();
                Logger.Info($"Success. Crawling Youtube page of [{Name}] has taken [{timer.Elapsed}] seconds");

                var titles = ((IEnumerable)responseJson.items).Cast<dynamic>()
                    .Select(x => new
                    {
                        PublishedAt = (DateTime)x.snippet.publishedAt,
                        Title = (string)x.snippet.title
                    }).Where(x => (DateTime.Now - x.PublishedAt).TotalHours < 5).ToList();

                if (titles.Count > 0)
                {
                    result.Add(Content.First().Key,
                        titles.OrderByDescending(x => x.PublishedAt).First().Title);
                }
            }
            catch (Exception e)
            {
                Logger.Info($"Failed. Crawling Youtube page of [{Name}] page has failed. Error:\n{e.Message}");
            }

            return result;
        }
    }
}
