using System;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Extensions;
using CsQuery;
using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class EtherDelta : BaseInfluencer
    {
        public override string Name { get; set; } = "EtherDelta";
        public override string Url { get; set; } = "https://twitter.com/etherdelta";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                "New listings: DTR, WABI, RCT, YACHT, CRED, LGR, LNC, PXT, SHNZ, CMT, 1WO, WAND, BITC"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;

        protected override bool ExtraConditions(string newContent)
        {
            return newContent.Contains("New listing", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
