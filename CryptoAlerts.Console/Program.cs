using System;
using CryptoAlerts.ConsoleApp.Alerts;
using CryptoAlerts.ConsoleApp.Alerts.Api;
using CryptoAlerts.ConsoleApp.Alerts.HtmlPage;
using CryptoAlerts.ConsoleApp.Alerts.Twitter;
using CryptoAlerts.ConsoleApp.Alerts.Youtube;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Core;

namespace CryptoAlerts.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press Enter to exit!");

            var cryptoAlerter = new CryptoAlerter();
            var cmcExtractor = new CoinMarketCapExtractor();

            // -------------Exchanges------------
            //cryptoAlerter.StartMonitoring(new Binance());
            //cryptoAlerter.StartMonitoring(new Binance_Twitter());
            //cryptoAlerter.StartMonitoring(new Bitfinex());
            //cryptoAlerter.StartMonitoring(new Poloniex());
            //cryptoAlerter.StartMonitoring(new Cryptopia());
            //cryptoAlerter.StartMonitoring(new Gate());
            //cryptoAlerter.StartMonitoring(new EtherDelta());
            //// cryptoAlerter.StartMonitoring(new Tidex()); <- Bad alert, doesnt cause increases anymore. Lost money on it.
            //// cryptoAlerter.StartMonitoring(new CoinExchange()); - Unreliable alert

            //// -------------Authorities------------
            //cryptoAlerter.StartMonitoring(new JohnMcAfee());
            //cryptoAlerter.StartMonitoring(new InItForTheMoney());
            //cryptoAlerter.StartMonitoring(new TwitterTest());
            //// cryptoAlerter.StartMonitoring(new CoinMarketCap());
            //// cryptoAlerter.StartMonitoring(new CryptoCalendar()); - Alerts too late! 
            //cryptoAlerter.StartMonitoring(new Kucoin());
            //cryptoAlerter.StartMonitoring(new JRBusiness());
            //cryptoAlerter.StartMonitoring(new DataHash());

            //// ------------- APIs -------------------
            //cryptoAlerter.StartMonitoring(new BinanceApi());
            //cryptoAlerter.StartMonitoring(new BitfinexApi());
            //cryptoAlerter.StartMonitoring(new CoinExchangeApi());
            //cryptoAlerter.StartMonitoring(new CryptopiaApi());
            //cryptoAlerter.StartMonitoring(new GateApi());
            //cryptoAlerter.StartMonitoring(new KucoinApi());
            //cryptoAlerter.StartMonitoring(new PoloniexApi());
            //cryptoAlerter.StartMonitoring(new TidexApi());
            //cryptoAlerter.StartMonitoring(new CoinMarketCapApi());

            cmcExtractor.StartMonitoring();

            Console.ReadLine();
        }
    }
}
// Total alerts count: 24