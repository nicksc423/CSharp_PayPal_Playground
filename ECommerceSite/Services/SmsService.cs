using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio;

namespace ECommerceSite.Services
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var Twilio = new TwilioRestClient(
               ConfigurationManager.AppSettings["TwilioSid"],
               ConfigurationManager.AppSettings["TwilioToken"]
           );
            var result = Twilio.SendMessage(
                ConfigurationManager.AppSettings["TwilioFromPhone"],
               message.Destination, message.Body);

            // Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
            Trace.TraceInformation(result.Status);

            // Twilio doesn't currently have an async API, so return success.
            return Task.FromResult(0);
        }
    }
}