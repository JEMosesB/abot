﻿using System;
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
            // cryptoAlerter.StartMonitoring(new CryptoCalendar()); - Alerts too late! 
            cryptoAlerter.StartMonitoring(new Kucoin());
            cryptoAlerter.StartMonitoring(new JRBusiness());
            cryptoAlerter.StartMonitoring(new DataHash());

            // ------------- APIs -------------------
            cryptoAlerter.StartMonitoring(new BinanceApi());
            cryptoAlerter.StartMonitoring(new CryptopiaApi());

            Console.ReadLine();
        }
    }
}