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
    public class PoloniexApi : BaseApiAlert
    {
        public override string Name { get; set; } = "PoloniexApi";
        protected override string Url { get; set; } = "https://poloniex.com/public?command=returnTicker";
        public override int IntervalInSeconds { get; set; } = 300; //the changes are so rare, no need to waste much resources on this

        protected override async Task<List<TradePair>> GetContent()
        {
            var result = new List<TradePair>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = await ContentGetter.GetJson(Url);
                timer.Stop();
                Logger.Info($"Success. Getting [{Name}] currencies has taken [{timer.Elapsed}] seconds");

                result = ((IEnumerable)responseJson).Cast<dynamic>()
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