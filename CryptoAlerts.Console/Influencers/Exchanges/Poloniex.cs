namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Poloniex : BaseInfluencer
    {
        public override string Name { get; set; } = "Poloniex";
        public override string Url { get; set; } = "https://poloniex.com/exchange#btc_storj";
        public override string LastAnnouncement { get; set; } = "Notice to Our Legacy Account Holders: https://poloniex.com/press-releases/2017.12.27-Notice-to-legacy-account-holders/";
        public override string CssString { get; set; } = "div#noticesBoard div.info:first";
        public override int IntervalInSeconds { get; set; } = 60;
    }
}
