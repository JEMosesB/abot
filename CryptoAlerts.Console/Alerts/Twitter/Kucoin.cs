using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Twitter
{
    public class Kucoin : TwitterAlert
    {
        public override string Name { get; set; } = "Kucoin";
        protected override string Url { get; set; } = "https://twitter.com/kucoincom";
    }
}

/*
Analysis: Kukoin only works if there are no larger exchanges in play already. 
Usually I would say its safe to assume 50% increase if you get in early.
Daily Volume: $181,684,696

CAN - ?
POE - No change
XRB - Went down immediately, but that is because of the obvious soike just before
Snov - 300% times in a day.
UTK - 2 times in 2 days and kept growing
LAToken - Kept slowly growing for 5 days to 100% before declining

 */
