using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Exchanges
{
    public class CoinExchange : HtmlAlert
    {
        public override string Name { get; set; } = "CoinExchange";
        protected override string Url { get; set; } = "https://twitter.com/CoinExchangeio";

        protected override Dictionary<string, string> Content { get; set; } =
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
