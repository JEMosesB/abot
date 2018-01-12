using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Core;
using Newtonsoft.Json.Linq;

namespace CryptoAlerts.ConsoleApp.Alerts.Api
{
    public class TidexApi : BaseApiAlert
    {
        public override string Name { get; set; } = "TidexApi";
        protected override string Url { get; set; } = "https://api.tidex.com/api/3/info";

        protected override async Task<List<TradePair>> GetContent()
        {
            var result = new List<TradePair>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                var responseJson = await ContentGetter.GetJson(Url);
                timer.Stop();
                Logger.Info($"Success. Getting [{Name}] currencies has taken [{timer.Elapsed}] seconds");

                result = ((IEnumerable)responseJson.pairs).Cast<dynamic>()
                    .Select(x => new TradePair
                    {
                        Name = ((JProperty)x).Name.ToUpper()
                    }).OrderBy(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                Logger.Info($"Failed. Getting [{Name}] currencies has failed. Error:\n{e.Message}");
            }

            return result;
        }
    }
}