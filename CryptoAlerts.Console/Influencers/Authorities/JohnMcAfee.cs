using System;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Extensions;
using CsQuery;
using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers.Authorities
{
    public class JohnMcAfee : BaseInfluencer
    {
        public override string Name { get; set; } = "John McAfee";
        public override string Url { get; set; } = "https://twitter.com/officialmcafee";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#timeline ol li:nth-child(1) div.tweet div.content > div.js-tweet-text-container",
                "It has come to my attention that there are trolls on my page. I had not noticed, but it comes from highly trusted individuals.This is a serious page and this is not acceptable. All trolls will be blocked ... and also the faceless accounts with no followers  that they then create."
            }, {
                "div#timeline ol li:nth-child(2) div.tweet div.content > div.js-tweet-text-container",
                "What an incredible journey for Sether! We disrupt social marketing and democratize social intelligence. We give it back to the people. From finding prospects to retaining customers, from Big Data to Blockchains and AI. We will pioneer a new way of doing things Togethersether.io"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;

        protected override bool ExtraConditions(string newContent)
        {
            return newContent.Contains("Coin of the", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

/*
Analysis: Worth it for his coin of the week Pump and Dump, otherwise do not bother. 20% raise max.
Atm Coin of the week is on 2pm Monday (Sunday?)

Updates: Once a week atm.
*/
