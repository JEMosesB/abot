using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.BaseModels;
using Newtonsoft.Json.Linq;

namespace CryptoAlerts.ConsoleApp.Core
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

        public static async Task<string> GetHtml(string url)
        {
            string htmlContent;
            using (MyWebClient client = new MyWebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                htmlContent = await client.DownloadStringTaskAsync(new Uri(url));
            }

            return htmlContent;
        }

        public static async Task<dynamic> GetJson(string url)
        {
            dynamic responseJson;
            using (var httpClient = new HttpClient())
            {
                var uriToCheck = new Uri(url);
                responseJson = JObject.Parse(await httpClient.GetStringAsync(uriToCheck));
            }

            return responseJson;
        }

        public static async Task<dynamic> GetJsonArray(string url)
        {
            dynamic responseJson;
            using (var httpClient = new HttpClient())
            {
                var uriToCheck = new Uri(url);
                responseJson = JArray.Parse(await httpClient.GetStringAsync(uriToCheck));
            }

            return responseJson;
        }

    }
}
