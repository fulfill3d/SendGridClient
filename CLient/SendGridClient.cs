using System.Net;
using Client.Interfaces;
using Client.Models;
using Client.Options;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Client
{
    public class SendGridClient(IOptions<SendGridOptions> options) : ISendGridClient
    {
        private readonly SendGridOptions _options = options.Value;
        private readonly RestClient _client = new RestClient("https://api.sendgrid.com/v3");
        
        public async Task<bool> SendEmailAsync(EmailMessage message)
        {
            var request = new RestRequest("mail/send", Method.Post);
            request.AddHeader("Authorization", $"Bearer {_options.ApiKey}");
            request.AddJsonBody(new
            {
                personalizations = new[]
                {
                    new
                    {
                        to = new[] { new { email = message.To } },
                        subject = message.Subject
                    }
                },
                from = new { email = message.From },
                content = new[]
                {
                    new
                    {
                        type = message.IsHtml ? "text/html" : "text/plain",
                        value = message.Body
                    }
                }
            });

            var response = await _client.ExecuteAsync(request);
            return response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}