using System;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Influencers.Authorities;
using CryptoAlerts.ConsoleApp.Influencers.Exchanges;
using System.Net;
using CsQuery;

namespace CryptoAlerts.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press Enter to exit!");

            var cryptoAlerter = new CryptoAlerter();

            // -------------Exchanges------------
            cryptoAlerter.StartMonitoring(new Binance());
            cryptoAlerter.StartMonitoring(new Bitfinex());
            cryptoAlerter.StartMonitoring(new Poloniex());
            cryptoAlerter.StartMonitoring(new Cryptopia());
            cryptoAlerter.StartMonitoring(new Gate());
            cryptoAlerter.StartMonitoring(new EtherDelta());
            cryptoAlerter.StartMonitoring(new Tidex());

            // -------------Authorities------------
            cryptoAlerter.StartMonitoring(new JohnMcAfee());
            cryptoAlerter.StartMonitoring(new InItForTheMoney());

            Console.ReadLine();
        }
    }
}