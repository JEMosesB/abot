namespace CryptoAlerts.ConsoleApp.Exchanges
{
    public class Bitfinex : IExchange
    {
        public string Name { get; set; } = "Bitfinex";
        public string Url { get; set; } = "https://www.bitfinex.com/posts";
        // public string LastValue { get; set; } = "Binance Lists Triggers (TRIG)";
        public string LastValue { get; set; } = "Golem (GNT) Trading Live";
        // public string SmsMessage { get; set; } = "Binance has a new listing!\nNew announcement:";
        public string CssString { get; set; } = "#posts-page div.change-log-section:first a:first";
        public int IntervalInSeconds { get; set; } = 60;
    }
}
