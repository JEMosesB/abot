using System;
using CryptoAlerts.ConsoleApp.Extensions;
using CsQuery;

namespace CryptoAlerts.ConsoleApp.Influencers.Authorities
{
    public class JohnMcAfee : BaseInfluencer
    {
        public override string Name { get; set; } = "John McAfee";
        public override string Url { get; set; } = "https://twitter.com/officialmcafee";
        public override string LastAnnouncement { get; set; } = "It has come to my attention that there are trolls on my page. I had not noticed, but it comes from highly trusted individuals.This is a serious page and this is not acceptable. All trolls will be blocked ... and also the faceless accounts with no followers  that they then create.";
        public string LastAnnouncement2 { get; set; } = "What an incredible journey for Sether! We disrupt social marketing and democratize social intelligence. We give it back to the people. From finding prospects to retaining customers, from Big Data to Blockchains and AI. We will pioneer a new way of doing things Togethersether.io1";
        public override string CssString { get; set; } = "div#timeline ol li:nth-child(1) div.tweet div.content > div.js-tweet-text-container";
        public override int IntervalInSeconds { get; set; } = 20;

        public override void ProcessHtml(string htmlContent)
        {
            CQ dom = htmlContent;

            var newAnnouncement1 = dom["div#timeline ol li:nth-child(1) div.tweet div.content > div.js-tweet-text-container"].Text().Trim();
            var newAnnouncement2 = dom["div#timeline ol li:nth-child(2) div.tweet div.content > div.js-tweet-text-container"].Text().Trim();

            if (newAnnouncement1.Contains("Coin of the", StringComparison.InvariantCultureIgnoreCase) && newAnnouncement1 != LastAnnouncement)
            {
                SmsSender.Send(GetSmsMessage(newAnnouncement1));
                LastAnnouncement = newAnnouncement1;
            }

            if (newAnnouncement2.Contains("Coin of the", StringComparison.InvariantCultureIgnoreCase) && newAnnouncement2 != LastAnnouncement2)
            {
                SmsSender.Send(GetSmsMessage(newAnnouncement2));
                LastAnnouncement2 = newAnnouncement2;
            }
        }
    }
}
