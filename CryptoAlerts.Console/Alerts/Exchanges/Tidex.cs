using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Extensions;

namespace CryptoAlerts.ConsoleApp.Alerts.Exchanges
{
    public class Tidex : HtmlAlert
    {
        public override string Name { get; set; } = "Tidex";
        public override string Url { get; set; } = "https://twitter.com/Tidex_Exchange";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                "We wanted to wish you Merry Christmas and Happy New Year! We have airdropped a little present on all WTC holders today. Waves holders will receive TDX tokens soon, too. How you can use TDX tokens you can learn here - https://tidex.com/loyalty . Also Trades are open now!"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;

        protected override bool ExtraConditions(string newContent)
        {
            return newContent.Contains("added", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

/*
Analysis: Ads new markets quite rarely, the result is usually an increase by 50-100% within a day. The volume is low though.

Updates: Few times a month.

TIES - Was so low in volume it was inconsequential
DRGN - 50% increase instantly and then kept growing to 300% over next few days
SNOV - Dont see on charts, but 2 days later rose to 200%. volume is low.
CAT - ???
B2B - ???
*/

