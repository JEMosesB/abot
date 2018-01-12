using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Twitter
{
    public class Binance_Twitter : TwitterAlert
    {
        public override string Name { get; set; } = "Binance Twitter";

        protected override string Url { get; set; } = "https://twitter.com/binance_2017";
    }
}
