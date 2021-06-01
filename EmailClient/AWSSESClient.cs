using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace SESClient.EmailClient
{
    public class AWSSESClient : IEmailClient
    {
        AmazonSimpleEmailServiceClient _sesClient;

        public AWSSESClient(IOptions<AWSSESConfig> awsSesConfigOptions)  
        {
            var awsSesConfig = awsSesConfigOptions.Value;

            _sesClient = new AmazonSimpleEmailServiceClient(
                awsSesConfig.AccessKey,
                awsSesConfig.SecretKey,
                RegionEndpoint.GetBySystemName(awsSesConfig.Region)
            );
        }
        
        public async Task SendEmailAsync(List<string> recipientEmails, EmailOptions emailOptions)
        {
            await this._sesClient.SendEmailAsync(new SendEmailRequest
            {
                Source = emailOptions.From,
                Destination = new Destination(recipientEmails),
                Message = new Message(
                    new Content(emailOptions.Subject),
                    new Body(new Content(emailOptions.Content))
                )
            });
        }
        
        public async Task SendTemplatedEmailAsync(List<string> recipientEmails, TemplatedEmailOptions emailOptions)
        {
            var test = emailOptions.EmailTemplate.PrepareTemplateData();

            await this._sesClient.SendTemplatedEmailAsync(new SendTemplatedEmailRequest
            {
                Source = emailOptions.From,
                Destination = new Destination(recipientEmails),
                Template = emailOptions.EmailTemplate.TemplateName,
                TemplateData = emailOptions.EmailTemplate.PrepareTemplateData()
            });
        }
    }
}
