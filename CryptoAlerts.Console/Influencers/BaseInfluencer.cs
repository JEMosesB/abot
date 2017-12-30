using System;
using CsQuery;

namespace CryptoAlerts.ConsoleApp.Influencers
{
    public abstract class BaseInfluencer : IInfluencer
    {
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual string LastAnnouncement { get; set; }
        public virtual string CssString { get; set; }
        public virtual int IntervalInSeconds { get; set; }

        public virtual string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] {Name} has a new announcement!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {Url}";
        }

        public virtual void ProcessHtml(string htmlContent)
        {
            CQ dom = htmlContent;

            var newAnnouncement = dom[CssString].Text().Trim();

            if (newAnnouncement != LastAnnouncement)
            {
                SmsSender.Send(GetSmsMessage(newAnnouncement));
                LastAnnouncement = newAnnouncement;
            }
        }
    }
}
