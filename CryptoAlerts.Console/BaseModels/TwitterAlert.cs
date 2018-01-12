using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Core;
using CryptoAlerts.ConsoleApp.Extensions;

namespace CryptoAlerts.ConsoleApp.BaseModels
{
    public class TwitterAlert : HtmlAlert
    {
        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                    "div#timeline ol li:nth-child(1) div.tweet div.content > div.js-tweet-text-container",
                    "content 1"
                }, {
                    "div#timeline ol li:nth-child(2) div.tweet div.content > div.js-tweet-text-container",
                    "content 2"
                }
            };

        public override int IntervalInSeconds { get; set; } = 20;

        protected override void ProcessNewContent(Dictionary<string, string> newContent)
        {
            var sendList = new List<string>();

            //find new unique tweets
            foreach (var newItem in newContent)
            {
                if (newItem.Value != "" && Content[newItem.Key] != newItem.Value && ExtraConditions(newItem.Value))
                {
                    if (!Content.Any(c => c.Value == newItem.Value))
                    {
                        sendList.Add(GetSmsMessage(newItem.Value));
                    }
                }
            }

            // old dictionary = new dictionary
            foreach (var key in newContent.Keys.ToList())
            {
                Content[key] = newContent[key];
            }

            // send messages about unique tweets
            foreach (var sendMessage in sendList)
            {
                SmsSender.Send(sendMessage);
            }
        }
    }
}
