using System;
using System.Net;
using Abot.Crawler;
using Abot.Poco;
using CryptoAlerts.ConsoleApp.Core;
using CsQuery;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.Checkers;

namespace CryptoAlerts.ConsoleApp.Influencers
{
    public abstract class BaseInfluencer : IInfluencer
    {
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual Dictionary<string, string> Content { get; set; }
        public virtual string CssString { get; set; }
        public virtual int IntervalInSeconds { get; set; }

        public virtual string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new announcement!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {Url}";
        }

        public virtual void CheckWebsite()
        {
            CheckWebsiteWithChecker(new GenericChecker());
        }

        protected virtual void CheckWebsiteWithChecker(IChecker checker)
        {
            var newContent = checker.GetContent(this);

            ProcessNewContent(newContent);
        }

        public virtual bool ExtraConditions(string newContent)
        {
            return true;
        }

        public virtual void ProcessNewContent(Dictionary<string, string> newContent)
        {
            foreach (var newItem in newContent)
            {
                if (Content[newItem.Key] != newItem.Value && ExtraConditions(newItem.Value))
                { 
                    SmsSender.Send(GetSmsMessage(newItem.Value));
                    Content[newItem.Key] = newItem.Value;
                }
            }
        }
    }
}