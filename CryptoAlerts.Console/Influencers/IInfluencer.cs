using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoAlerts.ConsoleApp.Influencers
{
    public interface IInfluencer
    {
        string Name { get; set; }
        string Url { get; set; }
        Dictionary<string, string> Content { get; set; }
        int IntervalInSeconds { get; set; }

        Task Init();
        void ProcessNewContent(Dictionary<string, string> newContent);
        string GetSmsMessage(string newAnnouncement);
        Task CheckWebsite();
    }
}