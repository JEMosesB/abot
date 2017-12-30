namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class Gate : BaseInfluencer
    {
        public override string Name { get; set; } = "Gate.io";
        public override string Url { get; set; } = "https://twitter.com/gate_io";
        public override string LastAnnouncement { get; set; } = "Monero(XMR) deposit and withdraw will be enabled soon at https://gate.io/myaccount/deposit/XMR …. Trade XMR at  https://gate.io/trade/XMR_USDT  and https://gate.io/trade/XMR_BTC";
        public override string CssString { get; set; } = "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container";
        public override int IntervalInSeconds { get; set; } = 20;
    }
}