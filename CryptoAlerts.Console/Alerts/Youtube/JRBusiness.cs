using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Youtube
{
    public class JRBusiness : YoutubeAlert
    {
        public override string Name { get; set; } = "JR Business";
        public string PublicUrl { get; set; } = "https://www.youtube.com/channel/UCmA06PHZc6O--2Yw4Vt4Wug/videos";
        protected override string Url { get; set; } = "https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=UCmA06PHZc6O--2Yw4Vt4Wug&order=date&type=video&videoSyndicated=true&key=AIzaSyDTZk1ee5OQifm_zx9P7en9H2kwIuuYRaY";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "json",
                "I Bought 1,000,000 More Crypto Coins! The Next PAC Coins?!"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;

        protected override string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new video!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {PublicUrl}";
        }
    }
}


/*
Analysis: New videos good for pump and dump, some maybe worth to hold off for a while. 
Be careful of his hype, his predictions are usually taking a while to take off.

A very good influencer, some of his predictions are reaally good, some of the others are not so much. 
Use your head using this indicator. Unless you know better at least its good for a pump and dump, although some of his predictions might could be very good (dark horse anyone?)
The poroblem though is that almost all of his signals pays off over periods of days, sometimes weeks, locking your money in.

Updates: Few times a week

PRE(2nd) - instant 100% increase then stay (I played some role in it, could have dumped after a pump), then delcine.
SNOV - stayed for 4 days, then rose 400% in the next 3 days, then stayed (declined a little) for the next 7 days, then it joined new exchange and it exploded 4 times in the next 1,5 half days, and then a sharp decline.
Pre(1) - Rose by 30% within 2 days of report, then stayed for 10 days until his next video.
DLT(long term) - stayed until 5 days later, then up 50%, then decline, then a week later started to grow +100% in a week
QASH (long term) - stayed, without change
RISE - 10% increase and then decline
ELECTRA - 100 % in 2 days, then stay on the spot for 5 days, then shoot to the moon. within next week x 25 times increase. (overall 2 weeks)
Blackmoon - stayed for about 2 days, then 100% in a day, then stayed then droppped

*/
