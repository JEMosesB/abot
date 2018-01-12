using System;
using System.Collections.Generic;
using CryptoAlerts.ConsoleApp.BaseModels;
using CryptoAlerts.ConsoleApp.Extensions;

namespace CryptoAlerts.ConsoleApp.Alerts.Twitter
{
    public class JohnMcAfee : TwitterAlert
    {
        public override string Name { get; set; } = "John McAfee";
        protected override string Url { get; set; } = "https://twitter.com/officialmcafee";

        protected override bool ExtraConditions(string newContent)
        {
            return newContent.Contains("Coin of the", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

/*
Analysis: Worth it for his coin of the week Pump and Dump, otherwise do not bother. 20% raise max.
Atm Coin of the week is on 2pm Monday (Sunday?)

Updates: Once a week atm.
*/
