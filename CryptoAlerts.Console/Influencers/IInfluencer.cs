using System.Collections.Generic;

namespace CryptoAlerts.ConsoleApp.Influencers
{
    public interface IInfluencer
    {
        string Name { get; set; }
        string Url { get; set; }
        Dictionary<string, string> Content { get; set; }
        int IntervalInSeconds { get; set; }
        void ProcessNewContent(Dictionary<string, string> newContent);
        string GetSmsMessage(string newAnnouncement);
        void CheckWebsite();
    }
}