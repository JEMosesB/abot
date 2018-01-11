using System.Threading.Tasks;

namespace CryptoAlerts.ConsoleApp.BaseModels
{
    public interface IAlert
    {
        string Name { get; set; }
        string Description { get; set; }
        int IntervalInSeconds { get; set; }

        Task Init();
        Task CheckWebsite();
    }
}