using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Influencers;

namespace CryptoAlerts.ConsoleApp.Checkers
{
    public interface IChecker
    {
        Task<Dictionary<string, string>> GetContent(IInfluencer influencer);
    }
}