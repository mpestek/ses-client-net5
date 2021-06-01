using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SESClient.EmailTemplates
{
    public interface IEmailTemplate
    {
        public string TemplateName { get; }

        public string PrepareTemplateData();
    }
}
