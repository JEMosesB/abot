using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.BaseModels;
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

        public async Task StartMonitoring(IAlert alert, CancellationToken token = default(CancellationToken))
        {
            await alert.Init();
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(alert.IntervalInSeconds), token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }

                await alert.CheckWebsite();
            }
        }
    }
}