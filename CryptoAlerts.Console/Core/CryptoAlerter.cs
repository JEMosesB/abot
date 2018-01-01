using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.Influencers;
using Twilio;

namespace CryptoAlerts.ConsoleApp.Core
{
    public class CryptoAlerter
    {
        public CryptoAlerter()
        {
            log4net.Config.XmlConfigurator.Configure();
            TwilioClient.Init("AC7b07eea0532bc8889257e22df4185fcd", "8eaf16a3cf44a49976e07ad1b78321f7");
        }

        public async Task StartMonitoring(IInfluencer influencer, CancellationToken token = default(CancellationToken))
        {
            while (!token.IsCancellationRequested)
            {
                influencer.CheckWebsite();

                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(influencer.IntervalInSeconds), token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
        }
    }
}