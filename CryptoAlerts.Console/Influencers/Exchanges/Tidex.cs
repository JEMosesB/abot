using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Tidex : BaseInfluencer
    {
        public override string Name { get; set; } = "Tidex";
        public override string Url { get; set; } = "https://twitter.com/Tidex_Exchange";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                "We wanted to wish you Merry Christmas and Happy New Year! We have airdropped a little present on all WTC holders today. Waves holders will receive TDX tokens soon, too. How you can use TDX tokens you can learn here - https://tidex.com/loyalty . Also Trades are open now!"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;
    }
}
