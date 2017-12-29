namespace CryptoAlerts.ConsoleApp.Exchanges
{
    public class Binance : IExchange
    {
        public string Name { get; set; } = "Binance";
        public string Url { get; set; } = "https://binance.zendesk.com/hc/en-us/categories/115000056351";
        // public string LastValue { get; set; } = "Binance Lists Triggers (TRIG)";
        public string LastValue { get; set; } = "Binance Lists Triggers (TRIG)";
        // public string SmsMessage { get; set; } = "Binance has a new listing!\nNew announcement:";
        public string CssString { get; set; } = "li.article-list-item:first";
        public int IntervalInSeconds { get; set; } = 60;
    }
}
