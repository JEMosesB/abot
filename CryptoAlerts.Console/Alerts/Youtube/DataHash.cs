using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Youtube
{
    public class DataHash : YoutubeAlert
    {
        public override string Name { get; set; } = "Data Hash";
        public string PublicUrl { get; set; } = "https://www.youtube.com/channel/UCCatR7nWbYrkVXdxXb4cGXw/videos";
        public override string Url { get; set; } = "https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=UCCatR7nWbYrkVXdxXb4cGXw&order=date&type=video&videoSyndicated=true&key=AIzaSyDTZk1ee5OQifm_zx9P7en9H2kwIuuYRaY";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "json",
                "Daily Update (1/10/2018) | Warren Buffett reaffirms his bearish views on crypto"
            }
        };

        public override int IntervalInSeconds { get; set; } = 60;

        protected override string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new video!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {PublicUrl}";
        }
    }
}

/*
Analysis: Has a very strong following. Primarily a news channel, however when he recommends a coin the effect is very strong. 

Updates: Every day.

RailBlocks - 150% increase.
*/
