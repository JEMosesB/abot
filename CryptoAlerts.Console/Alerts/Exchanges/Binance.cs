using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Exchanges
{
    public class Binance : HtmlAlert
    {
        public override string Name { get; set; } = "Binance";

        public override string Description { get; set; } = "Descr: Very safe investment, generally raises by 30-60% within a day with 80% chance";

        protected override string Url { get; set; } = "https://binance.zendesk.com/hc/en-us/categories/115000056351";

        protected override Dictionary<string, string> Content { get; set; } = 
            new Dictionary<string, string> { {
                "li.article-list-item:first",
                "Binance Lists Triggers (TRIG)"
            }, {
                "section.section:nth-child(2) li.article-list-item:first",
                "The Fifth Session of “Community Coin per Month"
            }
        };

        public override int IntervalInSeconds { get; set; } = 60;
    }
}

/*
Analysis:
Binance: (Descr: Very safe investment, generally raises by 30-60% within a day, with 80% chance)
 
(Exp.Raise: 40% safe, 60% risky), (Probab, 80%)
Description: Very safe investment, generally raises by 30-60% within a day.
Expected Raise: 40% safe, 60% risky
Probability of raise: 80-90%
Reaction Time: a few minutes
Recommendation: hold for 3/4 - 5/4 of a day.
Updates: Few times a week a week.

TNB - Rose to 60% within 3/4 of a day
Waves - No change, however rose by 20% in a 2 days
ICX - No change, but started to raise in 2 days by 50%
AION - instantly rose toby 80% and then stayed
NEBL - instantly rose toby 80% and then stayed
MCO/BNB Pair - No change and then fell a day later
EDO - Instantly rose by 40%, then stayed a day, then fell
WINGS - Instantly Rose and Fall 20%
NAV - Instantly Rose by 60%, and slowly went down to 30%
LUN - Increase by 30% and then another 20 in a couple hours.
TRIG - Binance 1st, increase by 20% and stayed. The only 1 out of 7-8 1st time coins that increased.
*/
