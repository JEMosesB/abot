using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Poloniex : BaseInfluencer
    {
        public override string Name { get; set; } = "Poloniex";
        public override string Url { get; set; } = "https://poloniex.com/exchange#btc_storj";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#noticesBoard div.info:first",
                "Notice to Our Legacy Account Holders: https://poloniex.com/press-releases/2017.12.27-Notice-to-legacy-account-holders/"
            }
        };

        public override int IntervalInSeconds { get; set; } = 60;
    }
}

/*
Analysis:
Poloniex: No idea. Very rare updates so no past history.

Reaction Time: a few minutes
Updates: Extremely rare updates.

STORJ - No change.

*/
