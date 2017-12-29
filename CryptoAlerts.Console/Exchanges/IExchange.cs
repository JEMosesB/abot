namespace CryptoAlerts.ConsoleApp.Exchanges
{
    public interface IExchange
    {
        string Name { get; set; }
        string Url { get; set; }
        string LastValue { get; set; }
        // string SmsMessage { get; set; }
        string CssString { get; set; }
        int IntervalInSeconds { get; set; }
    }
}