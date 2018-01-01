using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Cryptopia : BaseInfluencer
    {
        public override string Name { get; set; } = "Cryptopia";
        public override string Url { get; set; } = "https://twitter.com/Cryptopia_NZ";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                "OysterPearl(PRL) is now live on Cryptopia\nhttps://www.cryptopia.co.nz   \nExchange, Marketplace & Forums\n\nWelcome to the family :)"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;
    }
}
