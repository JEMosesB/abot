using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class CoinExchange : BaseInfluencer
    {
        public override string Name { get; set; } = "CoinExchange";
        public override string Url { get; set; } = "https://twitter.com/CoinExchangeio";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div#latest-currencies table tr:nth-child(2) td:first",
                    "DragonChain"
                }
            };

        public override int IntervalInSeconds { get; set; } = 60;
    }
}

/*
Analysis:
 !!! Unreliable alert !!!

    None...
*/
