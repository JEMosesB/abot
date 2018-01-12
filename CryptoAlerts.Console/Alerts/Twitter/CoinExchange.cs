using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Twitter
{
    public class CoinExchange : TwitterAlert
    {
        public override string Name { get; set; } = "CoinExchange";
        protected override string Url { get; set; } = "https://twitter.com/CoinExchangeio";
    }
}

/*
Analysis:
 !!! Unreliable alert !!!

    None...
*/
