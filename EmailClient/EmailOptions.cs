using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SESClient.EmailTemplates;

namespace SESClient.EmailClient
{
    public abstract class BaseEmailOptions
    {
        public string From { get; set; }
    }

    public class EmailOptions : BaseEmailOptions
    {
        public string Subject { get; set; }
        public string Content { get; set; }
    }

    public class TemplatedEmailOptions : BaseEmailOptions
    {
        public IEmailTemplate EmailTemplate { get; set; }
    }
}
