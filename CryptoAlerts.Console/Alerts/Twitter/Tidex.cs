using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Extensions;

namespace CryptoAlerts.ConsoleApp.Alerts.Twitter
{
    public class Tidex : TwitterAlert
    {
        public override string Name { get; set; } = "Tidex";
        protected override string Url { get; set; } = "https://twitter.com/Tidex_Exchange";

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

