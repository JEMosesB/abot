using System;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CryptoAlerts.ConsoleApp.Core
{
    public static class SmsSender
    {
        public static void Send(string smsMessage)
        {
            MessageResource.Create(
                to: new PhoneNumber("+447831917259"),
                @from: new PhoneNumber("+441618507067"),
                body: smsMessage);

            Console.WriteLine($"Following SMS has just been sent:\n{smsMessage}"); 
        }
    }
}