using System;
using System.Net;
using Abot.Crawler;
using Abot.Poco;
using CryptoAlerts.ConsoleApp.Core;
using CsQuery;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Checkers;
using CsQuery.ExtensionMethods;

namespace CryptoAlerts.ConsoleApp.Influencers
{
    public abstract class BaseInfluencer : IInfluencer
    {
        protected virtual IChecker Checker { get; set; } = new GenericChecker();
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual Dictionary<string, string> Content { get; set; }
        public virtual string CssString { get; set; }
        public virtual int IntervalInSeconds { get; set; }

        public virtual async Task Init()
        {
            var newContent = await Checker.GetContent(this);

            foreach (var key in newContent.Keys.ToList())
            {
                Content[key] = newContent[key];
            }
        }

        public virtual string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new announcement!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {Url}";
        }

        public virtual async Task CheckWebsite()
        {
            var newContent = await Checker.GetContent(this);

            ProcessNewContent(newContent);
        }

        protected virtual bool ExtraConditions(string newContent)
        {
            return true;
        }

        public virtual void ProcessNewContent(Dictionary<string, string> newContent)
        {
            foreach (var newItem in newContent)
            {
                if (newItem.Value != "" && Content[newItem.Key] != newItem.Value && ExtraConditions(newItem.Value))
                { 
                    SmsSender.Send(GetSmsMessage(newItem.Value));
                    Content[newItem.Key] = newItem.Value;
                }
            }
        }
    }
}