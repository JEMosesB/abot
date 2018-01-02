using System;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Extensions;
using CsQuery;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.Checkers;

namespace CryptoAlerts.ConsoleApp.Influencers.Authorities
{
    public class InItForTheMoney : BaseInfluencer
    {
        protected override IChecker Checker { get; set; } = new YoutubeChecker();
        public override string Name { get; set; } = "In it for the Money";
        public string PublicUrl { get; set; } = "https://www.youtube.com/channel/UCrn0rKrnYAme8fPa1HBWwbQ/videos";
        public override string Url { get; set; } = "https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=UCrn0rKrnYAme8fPa1HBWwbQ&order=date&type=video&videoSyndicated=true&key=AIzaSyDTZk1ee5OQifm_zx9P7en9H2kwIuuYRaY";

        public override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "json",
                "RISE (RISE) | On the Rise?"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;

        public override string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new video!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {PublicUrl}";
        }
    }
}