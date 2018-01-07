using System;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Influencers.Authorities;
using CryptoAlerts.ConsoleApp.Influencers.Exchanges;

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
            cryptoAlerter.StartMonitoring(new Binance_Twitter());
            cryptoAlerter.StartMonitoring(new Bitfinex());
            cryptoAlerter.StartMonitoring(new Poloniex());
            cryptoAlerter.StartMonitoring(new Cryptopia());
            cryptoAlerter.StartMonitoring(new Gate());
            cryptoAlerter.StartMonitoring(new EtherDelta());
            cryptoAlerter.StartMonitoring(new Tidex());
            // cryptoAlerter.StartMonitoring(new CoinExchange()); - Unreliable alert

            // -------------Authorities------------
            cryptoAlerter.StartMonitoring(new JohnMcAfee());
            cryptoAlerter.StartMonitoring(new InItForTheMoney());
            cryptoAlerter.StartMonitoring(new TwitterTest());
            cryptoAlerter.StartMonitoring(new CoinMarketCap());
            cryptoAlerter.StartMonitoring(new CryptoCalendar());
            cryptoAlerter.StartMonitoring(new Kucoin());

            Console.ReadLine();
        }
    }
}