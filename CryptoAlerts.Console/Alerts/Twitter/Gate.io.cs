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
Update: Unless its a new token, price increase is almost guaranteed in 1 day - 2 max.
Daily Volume: $119,169,097

Reaction Time: a few minutes
Updates: Few times a month.

OST - +30% in half a day.
GNX - 80% in 3/4 day
MDT - NewToken - Decline.
DBC - after a day started to increase, 350% in 5 days, then decline
QLink - +50% in 1 day and a half
GTC - ???
DRGN - 100% over 1.5 days, then small decline
XMR - slight decline (because after big pump)
ICX - almost no increase, stable
LEND - 100% next 1.5 days, then small decline
BNTY - 100% next day, then small decline
GNT - 30% increase in next 1.5 days, then decline

*/
