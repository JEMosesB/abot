using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class TwitterTest : BaseInfluencer
    {
        public override string Name { get; set; } = "Twitter Test";
        public override string Url { get; set; } = "https://twitter.com/Astral_100";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                    "Twitter Test"
                }
            };

        public override int IntervalInSeconds { get; set; } = 20;
    }
}

/*
Analysis: The most influencial twitter crypto Alerter!!! this guy will make you rich! Follow as your relogion!

Updates: Few times a week atm. Whenever the test needs to be done.
*/
