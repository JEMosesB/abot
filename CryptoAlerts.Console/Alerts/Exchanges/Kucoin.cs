using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Exchanges
{
    public class Kucoin : HtmlAlert
    {
        public override string Name { get; set; } = "Kucoin";
        public override string Url { get; set; } = "https://twitter.com/kucoincom";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div#timeline ol li:nth-child(1) div.tweet div.content > div.js-tweet-text-container",
                    "Retweet this tweet to win 100,000 RPX！"
                }, {
                    "div#timeline ol li:nth-child(2) div.tweet div.content > div.js-tweet-text-container",
                    "AIgang will start trading at 22.00 UTC+8"
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
