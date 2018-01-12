using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Core;

namespace CryptoAlerts.ConsoleApp.Alerts.Api
{
    public class KucoinApi : BaseApiAlert
    {
        public override string Name { get; set; } = "KucoinApi";
        protected override string Url { get; set; } = "https://api.kucoin.com/v1/market/open/symbols";

        protected override async Task<List<TradePair>> GetContent()
        {
            var result = new List<TradePair>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = await ContentGetter.GetJson(Url);
                timer.Stop();
                Logger.Info($"Success. Getting [{Name}] currencies has taken [{timer.Elapsed}] seconds");

                result = ((IEnumerable)responseJson.data).Cast<dynamic>()
                    .Select(x => new
                    {
                        Name = (string)x.symbol,
                        IsActive = (bool)x.trading
                    })
                    .Where(x => x.IsActive)
                    .Select(x => new TradePair
                    {
                        Name = x.Name
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