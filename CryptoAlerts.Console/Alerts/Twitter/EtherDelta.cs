using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Extensions;

namespace CryptoAlerts.ConsoleApp.Alerts.Twitter
{
    public class EtherDelta : TwitterAlert
    {
        public override string Name { get; set; } = "EtherDelta";
        protected override string Url { get; set; } = "https://twitter.com/etherdelta";

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
Daily Volume: $11,509,654

Reaction Time: a few minutes
Updates: Rarely, just a couple times a month, but in big spurts, 10ns of currencies at a time.

Once a week at most, but updates many coins at a time.
*/
