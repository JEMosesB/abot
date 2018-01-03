﻿using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Bitfinex : BaseInfluencer
    {
        public override string Name { get; set; } = "Bitfinex";
        public override string Url { get; set; } = "https://www.bitfinex.com/posts";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "#posts-page div.change-log-section:first a:first",
                "Golem (GNT) Trading Live"
            }
        };

        public override int IntervalInSeconds { get; set; } = 60;
    }
}

/*
Analysis:
Bitfinex: (Descr: Pretty safe investment, although increase is not that large, generally around 20-25% within a day, with 80% chance)
 
(Exp.Raise: 20% safe, 30% risky), (Probab, 80%)
Reaction Time: a few minutes

Updates: Very rare, once a month on average.

OMG - 40-50% increase in a day, then stay
GNT - 20-25% increase in a day, then stay
SNT - 15% short increase, then fall and slow increase.
*/
