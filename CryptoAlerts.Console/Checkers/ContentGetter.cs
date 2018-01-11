using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Influencers;
using Newtonsoft.Json.Linq;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public static class ContentGetter
    {
        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 15 * 1000;
                return w;
            }
        }

        public static async Task<string> GetHtml(IInfluencer influencer)
        {
            string htmlContent;
            using (MyWebClient client = new MyWebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                htmlContent = await client.DownloadStringTaskAsync(new Uri(influencer.Url));
            }

            return htmlContent;
        }

        public static async Task<dynamic> GetJson(IInfluencer influencer)
        {
            dynamic responseJson;
            using (var httpClient = new HttpClient())
            {
                var uriToCheck = new Uri(influencer.Url);
                responseJson = JObject.Parse(await httpClient.GetStringAsync(uriToCheck));
            }

            return responseJson;
        }
    }
}
