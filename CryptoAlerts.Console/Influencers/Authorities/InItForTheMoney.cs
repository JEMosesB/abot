using System;
using CryptoAlerts.ConsoleApp.Extensions;
using CsQuery;

namespace CryptoAlerts.ConsoleApp.Influencers.Authorities
{
    public class InItForTheMoney : BaseInfluencer
    {
        public override string Name { get; set; } = "In it for the Money";
        // public override string Url { get; set; } = "https://www.youtube.com/channel/UCrn0rKrnYAme8fPa1HBWwbQ/videos";
        public override string Url { get; set; } = "https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=UCrn0rKrnYAme8fPa1HBWwbQ&order=date&type=video&videoSyndicated=true&key=AIzaSyDTZk1ee5OQifm_zx9P7en9H2kwIuuYRaY";
        public override string LastAnnouncement { get; set; } = "RISE (RISE) | On the Rise?";
        public override string CssString { get; set; } = "div#content ytd-browse[page-subtype='channels'] div#contents div#items div#dismissable div#details div#meta h3 a#video-title";
        public override int IntervalInSeconds { get; set; } = 60;

        public override string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new video!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {Url}";
        }
    }
}