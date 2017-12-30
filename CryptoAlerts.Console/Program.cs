using System;
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

            // ------------- Exchanges ------------
            cryptoAlerter.StartMonitoringExchange(new Binance());
            cryptoAlerter.StartMonitoringExchange(new Bitfinex());
            cryptoAlerter.StartMonitoringExchange(new Poloniex());
            cryptoAlerter.StartMonitoringExchange(new Cryptopia());

            // ------------- Authorities ------------
            cryptoAlerter.StartMonitoringExchange(new JohnMcAfee());

            Console.ReadLine();
        }
    }
}