﻿using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Extensions;

namespace CryptoAlerts.ConsoleApp.Alerts.Exchanges
{
    public class EtherDelta : HtmlAlert
    {
        public override string Name { get; set; } = "EtherDelta";
        protected override string Url { get; set; } = "https://twitter.com/etherdelta";

        protected override Dictionary<string, string> Content { get; set; } =
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

/*
Analysis:
EtherDelta: 
(Descr: A very random market with almost everything trash, but possibly worth investing if there is listing somewhere else)

Reaction Time: a few minutes
Updates: Rarely, just a couple times a month, but in big spurts, 10ns of currencies at a time.

Once a week at most, but updates many coins at a time.
*/
