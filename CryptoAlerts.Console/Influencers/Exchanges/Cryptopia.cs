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

/*
Analysis:
Cryptopia: (Descr: Very lucrative investments, usualy prices rise by quite a lot (50-70%) and usually keep increasing, but need to react fast.)

Reaction Time: a few minutes
Updates: Once a week at most, but updates many coins at a time.

UFR - 100% increase in a day, then steady increase overtime
CAPP - 60-80% increase in a day, then fall back to original price
WISH - 20-30% increase in a afew hours, then stay
SPANK - no change at all, slow increase over time
CRC - 50-70% increase, then stay
...
XVG - 100% increase in a day, then slow decline, then rise again
...
BWK - increase by 200% over few days
...
ELLA - actually decline over time until much later
*/
