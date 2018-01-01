﻿using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Binance : BaseInfluencer
    {
        public override string Name { get; set; } = "Binance";
        public override string Url { get; set; } = "https://binance.zendesk.com/hc/en-us/categories/115000056351";

        public override Dictionary<string, string> Content { get; set; } = 
            new Dictionary<string, string> { {
                "li.article-list-item:first",
                "Binance Lists Triggers (TRIG)"
            }
        };

        public override int IntervalInSeconds { get; set; } = 60;
    }
}
