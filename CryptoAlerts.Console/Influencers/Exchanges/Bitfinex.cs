namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Bitfinex : BaseInfluencer
    {
        public override string Name { get; set; } = "Bitfinex";
        public override string Url { get; set; } = "https://www.bitfinex.com/posts";
        public override string LastAnnouncement { get; set; } = "Golem (GNT) Trading Live";
        public override string CssString { get; set; } = "#posts-page div.change-log-section:first a:first";
        public override int IntervalInSeconds { get; set; } = 60;
    }
}
