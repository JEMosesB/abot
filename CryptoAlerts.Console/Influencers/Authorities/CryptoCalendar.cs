using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.Extensions;

namespace CryptoAlerts.ConsoleApp.Influencers.Authorities
{
    public class CryptoCalendar : BaseInfluencer
    {
        public override string Name { get; set; } = "Crypto Calendar";
        public override string Url { get; set; } = "http://coinmarketcal.com/?form%5Bmonth%5D=&form%5Byear%5D=&form%5Bsort_by%5D=created_desc&form%5Bsubmit%5D=";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div.content-box-general:first h5:nth-child(3)",
                    "Barterdex Core Finished"
                }
            };

        public override int IntervalInSeconds { get; set; } = 60;

        protected override bool ExtraConditions(string newContent)
        {
            return newContent.Contains("list", StringComparison.InvariantCultureIgnoreCase) ||
                   newContent.Contains("exchange", StringComparison.InvariantCultureIgnoreCase) ||
                   newContent.Contains("burn", StringComparison.InvariantCultureIgnoreCase) ||
                   newContent.Contains("trad", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
/*
Analysis: A nice place for news, howerver they are quite delayed and rarely relevant.
Only partnerships and listings are usually interesting. 

Updates: Couple times a day.


LEND:
Added Annoucement: nothing.
Event Happened: 30% increase in a day.

TRX:
Added Annoucement: 30% in a day, 60% in 2
Event happpened: slight decline

UKG:
Added: +60% in a day
Happened: same day

ADA:
Partnership announcements:
ETN: 100% in 2 days.

*/
