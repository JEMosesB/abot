using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Core;
using NLog;

namespace CryptoAlerts.ConsoleApp.BaseModels
{
    public abstract class BaseAlert : IAlert
    {
        protected readonly ILogger Logger = LogManager.GetLogger("StandardLogging");

        protected virtual Dictionary<string, string> Content { get; set; }
        protected virtual string Url { get; set; }

        public virtual string Name { get; set; }
        public virtual int IntervalInSeconds { get; set; }

        protected abstract Task<Dictionary<string, string>> GetContent();

        public virtual async Task Init()
        {
            var newContent = await GetContent();

            foreach (var key in newContent.Keys.ToList())
            {
                Content[key] = newContent[key];
                Logger.Info($"  Initial value for [{Name}] alert is: [{Content[key]}]");
            }
        }

        public virtual async Task CheckWebsite()
        {
            try
            {
                var newContent = await GetContent();

                ProcessNewContent(newContent);
            }
            catch (Exception e)
            {
                Logger.Info($"Failed. Crawling [{Name}] page has failed. Url: {Url}\nError:\n{e.Message}");
            }
        }

        protected virtual string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new announcement!\n[{newAnnouncement}]\nHere is the link if you want to check it out: {Url}";
        }

        protected virtual bool ExtraConditions(string newContent)
        {
            return true;
        }

        protected virtual void ProcessNewContent(Dictionary<string, string> newContent)
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