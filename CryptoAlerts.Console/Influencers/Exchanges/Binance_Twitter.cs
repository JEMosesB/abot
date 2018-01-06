using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Binance_Twitter : BaseInfluencer
    {
        public override string Name { get; set; } = "Binance Twitter";

        public override string Url { get; set; } = "https://twitter.com/binance_2017";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                    "#Binance Lists #AppCoins (APPC): @AppCoinsProject"
                }
            };

        public override int IntervalInSeconds { get; set; } = 20;
    }
}
