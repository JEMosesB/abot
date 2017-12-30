namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Binance : BaseInfluencer
    {
        public override string Name { get; set; } = "Binance";
        public override string Url { get; set; } = "https://binance.zendesk.com/hc/en-us/categories/115000056351";
        public override string LastAnnouncement { get; set; } = "Binance Lists Triggers (TRIG)";
        public override string CssString { get; set; } = "li.article-list-item:first";
        public override int IntervalInSeconds { get; set; } = 60;
    }
}
