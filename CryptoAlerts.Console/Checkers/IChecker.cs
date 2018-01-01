using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.Influencers;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public interface IChecker
    {
        Dictionary<string, string> GetContent(IInfluencer influencer);
    }
}