using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;

namespace CryptoAlerts.ConsoleApp.Alerts.Twitter
{
    public class Gate : TwitterAlert
    {
        public override string Name { get; set; } = "Gate.io";
        protected override string Url { get; set; } = "https://twitter.com/gate_io";

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
