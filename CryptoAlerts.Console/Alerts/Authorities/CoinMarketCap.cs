using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Authorities
{
    public class CoinMarketCap : HtmlAlert
    {
        public override string Name { get; set; } = "CoinMarketCap";
        public override string Url { get; set; } = "https://coinmarketcap.com/new/";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "table#trending-recently-added tr:first-child td.currency-name a",
                    "Escroco"
                }
            };

        public override int IntervalInSeconds { get; set; } = 60;

        protected override string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new listing: [{newAnnouncement}]\nHere is the link if you want to check it out: {Url}";
        }
    }
}

/*
Analysis: A VERY nice indicator, almast always the price rises by 50-80% with about 80% chance, but very fast. 

Updates: Few times a month.

ESC - 220% immediately in 5 hours, then raise
GTC - 20% increase in 5 hrs, 30% in a day. 
CAT - 60% in a few hours, then a bit down and stay.
SNOV - Dont see on charts, but 2 days later rose to 200%. volume is low.
FDX - 100% in an hour
STAK - 50% increase and stay
ENT - steady decrease by 30 %
PYLNT - 30% icnrease, very low volume.

*/
