namespace CryptoAlerts.ConsoleApp.Exchanges
{
    public class Poloniex : IExchange
    {
        public string Name { get; set; } = "Poloniex";
        public string Url { get; set; } = "https://poloniex.com/exchange#btc_storj";
        public string LastValue { get; set; } = "Notice to Our Legacy Account Holders: https://poloniex.com/press-releases/2017.12.27-Notice-to-legacy-account-holders/";
        public string CssString { get; set; } = "div#noticesBoard div.info:first";
        public int IntervalInSeconds { get; set; } = 60;
    }
}
