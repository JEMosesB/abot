using System;
using CryptoAlerts.ConsoleApp.Extensions;
using CsQuery;

namespace CryptoAlerts.ConsoleApp.Influencers.Exchanges
{
    public class EtherDelta : BaseInfluencer
    {
        public override string Name { get; set; } = "EtherDelta";
        public override string Url { get; set; } = "https://twitter.com/etherdelta";
        public override string LastAnnouncement { get; set; } = "New listings: DTR, WABI, RCT, YACHT, CRED, LGR, LNC, PXT, SHNZ, CMT, 1WO, WAND, BITC";
        public override string CssString { get; set; } = "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container";
        public override int IntervalInSeconds { get; set; } = 20;

        public override void ProcessHtml(string htmlContent)
        {
            CQ dom = htmlContent;

            var newAnnouncement = dom[CssString].Text().Trim();

            if (newAnnouncement.Contains("New listing", StringComparison.InvariantCultureIgnoreCase) && newAnnouncement != LastAnnouncement)
            {
                SmsSender.Send(GetSmsMessage(newAnnouncement));
                LastAnnouncement = newAnnouncement;
            }
        }
    }
}
