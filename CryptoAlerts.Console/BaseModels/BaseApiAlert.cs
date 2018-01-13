using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Core;
using NLog;

namespace CryptoAlerts.ConsoleApp.BaseModels
{
    public abstract class BaseApiAlert : IAlert
    {
        protected readonly ILogger Logger = LogManager.GetLogger("StandardLogging");

        public virtual string Name { get; set; }
        public virtual int IntervalInSeconds { get; set; } = 20;

        protected virtual List<TradePair> Content { get; set; }
        protected virtual string Url { get; set; }

        protected abstract Task<List<TradePair>> GetContent();

        public virtual async Task Init()
        {
            Content = await GetContent();
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

        protected virtual void ProcessNewContent(List<TradePair> newContent)
        {
            var newTradePairs = newContent.Select(x => x.Name).Except(Content.Select(x => x.Name)).ToList();

            if (newTradePairs.Count > 0)
            {
                var tradePairStr = string.Join(", ", newTradePairs);
                SmsSender.Send(GetSmsMessage(tradePairStr));
                Content = newContent;
            }
        }

        protected virtual string GetSmsMessage(string newAnnouncement)
        {
            return $"[{DateTime.Now.ToString("HH:mm:ss")}] \"{Name}\" has a new Trading Pair!\nHere is the list: [{newAnnouncement}]\nLink: {Url}";
        }
    }
}
