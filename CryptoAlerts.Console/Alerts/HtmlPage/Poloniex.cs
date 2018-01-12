using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.HtmlPage
{
    public class Poloniex : HtmlAlert
    {
        public override string Name { get; set; } = "Poloniex";
        protected override string Url { get; set; } = "https://poloniex.com/exchange#btc_storj";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#noticesBoard div.info:first",
                "Notice to Our Legacy Account Holders: https://poloniex.com/press-releases/2017.12.27-Notice-to-legacy-account-holders/"
            }
        };
    }
}

/*
Analysis:
Poloniex: No idea. Very rare updates so no past history.

Reaction Time: a few minutes
Updates: Extremely rare updates.

STORJ - No change.

*/
