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
    public class CoinMarketCapApi : BaseApiAlert
    {
        public override string Name { get; set; } = "CoinMarketCapApi";
        protected override string Url { get; set; } = "https://api.coinmarketcap.com/v1/ticker/?limit=0";

        protected override async Task<List<TradePair>> GetContent()
        {
            var result = new List<TradePair>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = await ContentGetter.GetJsonArray(Url);
                timer.Stop();
                Logger.Info($"Success. Getting [{Name}] currencies has taken [{timer.Elapsed}] seconds");

                result = ((IEnumerable)responseJson).Cast<dynamic>()
                    .Select(x => new TradePair
                    {
                        Name = (string)x.id
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