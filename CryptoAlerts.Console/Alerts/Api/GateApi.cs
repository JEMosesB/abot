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
    public class GateApi : BaseApiAlert
    {
        public override string Name { get; set; } = "GateApi";
        protected override string Url { get; set; } = "http://data.gate.io/api2/1/pairs";

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
                        Name = ((string)x).ToUpper()
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