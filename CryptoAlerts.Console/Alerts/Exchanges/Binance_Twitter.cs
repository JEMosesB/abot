using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Exchanges
{
    public class Binance_Twitter : HtmlAlert
    {
        public override string Name { get; set; } = "Binance Twitter";

        public override string Url { get; set; } = "https://twitter.com/binance_2017";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                    "#Binance Lists #AppCoins (APPC): @AppCoinsProject"
                }
            };

        public override int IntervalInSeconds { get; set; } = 20;
    }
}
