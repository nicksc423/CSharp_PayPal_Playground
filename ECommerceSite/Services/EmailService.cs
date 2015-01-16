using Microsoft.AspNet.Identity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ECommerceSite.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            EmailService.sendRegistrationMessage(message);
            return Task.FromResult(0);
        }

        public static IRestResponse sendRegistrationMessage(IdentityMessage message)
        {
            RestClient client = new RestClient();
            var mailAPI = ConfigurationManager.AppSettings["mailGunAPI"];
            var mailKey = ConfigurationManager.AppSettings["mailGunKey"];
            var fromName = ConfigurationManager.AppSettings["mailGunFromName"];
            var fromEmail = ConfigurationManager.AppSettings["mailGunFromEmail"];

            client.BaseUrl = new Uri("https://api.mailgun.net/v2");
            client.Authenticator = new HttpBasicAuthenticator("api", mailKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", mailAPI, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", fromName);
            request.AddParameter("to", message.Destination);
            request.AddParameter("subject", message.Subject);
            request.AddParameter("text", message.Body);
            request.AddParameter("html", message.Body);
            request.Method = Method.POST;
            IRestResponse executor = client.Execute(request);
            return executor as RestResponse;
        }
    }
}