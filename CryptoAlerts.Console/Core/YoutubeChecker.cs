using System;
using System.Net.Http;
using CryptoAlerts.ConsoleApp.Influencers;
using Newtonsoft.Json.Linq;

namespace CryptoAlerts.ConsoleApp.Core
{
    public static class YoutubeChecker
    {
        public static void CheckWebsite(IInfluencer influencer)
        {
            try
            {
                dynamic responseJson;
                using (var httpClient = new HttpClient())
                {
                    var uriToCheck = new Uri(influencer.Url);
                    responseJson = JObject.Parse(httpClient.GetStringAsync(uriToCheck).Result);
                }
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Crawling Youtube page of [{influencer.Name}] has succeeded");

                string newVideoTitle = responseJson.items[0].snippet.title;

                if (newVideoTitle != influencer.LastAnnouncement)
                {
                    SmsSender.Send(influencer.GetSmsMessage(newVideoTitle));
                    influencer.LastAnnouncement = newVideoTitle;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Crawling Youtube page of [{influencer.Name}] page has failed");
            }
        }
    }
}