using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Kucoin : BaseInfluencer
    {
        public override string Name { get; set; } = "Kucoin";
        public override string Url { get; set; } = "https://twitter.com/kucoincom";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                    "@canyacoin (CAN) token will join our list of tradable tokens...."
                }
            };

        public override int IntervalInSeconds { get; set; } = 20;
    }
}

/*
Analysis: Kukoin only works if there are no larger exchanges in play already. 
Usually I would say its safe to assume 50% increase if you get in early.

CAN - ?
POE - No change
XRB - Went down immediately, but that is because of the obvious soike just before
Snov - 300% times in a day.
UTK - 2 times in 2 days and kept growing
LAToken - Kept slowly growing for 5 days to 100% before declining

 */
