using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Bitfinex : BaseInfluencer
    {
        public override string Name { get; set; } = "Bitfinex";
        public override string Url { get; set; } = "https://www.bitfinex.com/posts";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "#posts-page div.change-log-section:first a:first",
                "Golem (GNT) Trading Live"
            }
        };

        public override int IntervalInSeconds { get; set; } = 60;
    }
}
