﻿using NLog;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CryptoAlerts.ConsoleApp.Core
{
    public static class SmsSender
    {
        private static readonly ILogger SmsLogger = LogManager.GetLogger("SentSMSLogger");

        public static void Send(string smsMessage)
        {
            MessageResource.Create(
                to: new PhoneNumber("+447831917259"),
                from: new PhoneNumber("+441618507067"),
                body: smsMessage);

            SmsLogger.Info($"Following SMS has just been sent:\n{smsMessage}");
        }
    }
}