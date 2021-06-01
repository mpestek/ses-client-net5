using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SESClient.EmailClient;
using SESClient.EmailTemplates.GreetingsTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SESClient.Controllers
{
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmailClient _emailClient;

        public EmailController(IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        [HttpGet("health")]
        public string GetHealthStatus()
        {
            return "API Works!";
        }
        
        [HttpGet("test-json-serialization")]
        public string TestJsonSerialization()
        {
            return new GreetingsTemplate
            {
                Name = "Test Name",
                FavoriteAnimal = "Test Animal"
            }.PrepareTemplateData();
        }

        [HttpPost("test-email")]
        public async Task TestEmail()
        {
            await _emailClient.SendEmailAsync(
                new List<string> { "recipient@domain.com" },
                new EmailOptions
                {
                    From = "Sender <sender@domain.com>",
                    Subject = "Subject",
                    Content = "Content"
                });
        }
        
        [HttpPost("test-templated-email")]
        public async Task TestTemplatedEmail(string name, string animal)
        {
            await _emailClient.SendTemplatedEmailAsync(
                new List<string> { "recipientone@domain.com", "recipienttwo@domain.com" },
                new TemplatedEmailOptions
                {
                    From = "Sender <sender@domain.com>",
                    EmailTemplate = new GreetingsTemplate
                    {
                        Name = name,
                        FavoriteAnimal = animal
                    }
                });
        }
    }
}
