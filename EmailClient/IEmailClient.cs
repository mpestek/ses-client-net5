using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SESClient.EmailClient
{
    public interface IEmailClient
    {
        Task SendEmailAsync(List<string> recipientEmails, EmailOptions emailOptions);
        Task SendTemplatedEmailAsync(List<string> recipientEmails, TemplatedEmailOptions emailOptions);
    }
}
