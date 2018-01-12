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
    public class CryptopiaApi : BaseApiAlert
    {
        public override string Name { get; set; } = "CryptopiaApi";
        protected override string Url { get; set; } = "https://www.cryptopia.co.nz/api/GetTradePairs";

        protected override async Task<List<TradePair>> GetContent()
        {
            var result = new List<TradePair>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = await ContentGetter.GetJson(Url);
                timer.Stop();
                Logger.Info($"Success. Getting [{Name}] currencies has taken [{timer.Elapsed}] seconds");

                result = ((IEnumerable)responseJson.Data).Cast<dynamic>()
                    .Select(x => new TradePair
                    {
                        Name = (string)x.Label
                    }).OrderBy(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                Logger.Info($"Failed.  Getting [{Name}] currencies has failed. Error:\n{e.Message}");
            }

            return result;
        }
    }
}