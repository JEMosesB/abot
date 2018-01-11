using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Exchanges
{
    public class Gate : HtmlAlert
    {
        public override string Name { get; set; } = "Gate.io";
        public override string Url { get; set; } = "https://twitter.com/gate_io";

        protected override Dictionary<string, string> Content { get; set; } =
            new Dictionary<string, string> { {
                "div#timeline ol li:first div.tweet div.content > div.js-tweet-text-container",
                "Monero(XMR) deposit and withdraw will be enabled soon at https://gate.io/myaccount/deposit/XMR …. Trade XMR at  https://gate.io/trade/XMR_USDT  and https://gate.io/trade/XMR_BTC"
            }
        };

        public override int IntervalInSeconds { get; set; } = 20;
    }
}

/*
Analysis:
Gate.io: Very volatile. Wait up to a day (1.5 max) and take what you can. Avg. increase is ether v. small or 80-100%

Reaction Time: a few minutes
Updates: Few times a month.

GTC - 1st time curr, small incr.
DRGN - 100% over 1.5 days, then small decline
XMR - slight decline (because after big pump)
ICX - almost no increase, stable
LEND - 100% next 1.5 days, then small decline
BNTY - 100% next day, then small decline
GNT - 30% increase in next 1.5 days, then decline

*/
