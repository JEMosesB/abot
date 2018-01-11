using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Core;
using CsQuery;

namespace CryptoAlerts.ConsoleApp.BaseModels
{
    public class HtmlAlert : BaseAlert
    {
        protected override async Task<Dictionary<string, string>> GetContent()
        {
            var results = new Dictionary<string, string>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                CQ html = await ContentGetter.GetHtml(Url);
                timer.Stop();
                Logger.Info($"Success. Crawling [{Name}] page has taken [{timer.Elapsed}] seconds");

                foreach (var check in Content)
                {
                    results.Add(check.Key, html[check.Key].Text().Trim());
                }

                return results;
            }
            catch (Exception e)
            {
                Logger.Info($"Failed. Crawling [{Name}] page has failed. Url: {Url}\nError:\n{e.Message}");
            }

            return results;
        }
    }
}
