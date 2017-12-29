using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAlerts.ConsoleApp.Exchanges
{
    public class Cryptopia : IExchange
    {
        public string Name { get; set; } = "Cryptopia";
        public string Url { get; set; } = "https://twitter.com/Cryptopia_NZ";
        public string LastValue { get; set; } = "OysterPearl(PRL) is now live on Cryptopia\nhttps://www.cryptopia.co.nz   \nExchange, Marketplace & Forums\n\nWelcome to the family :)";
        public string CssString { get; set; } = "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container";
        public int IntervalInSeconds { get; set; } = 20;
    }
}
