using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace Infrastructure.Email
{
    public class EmailMessage
    {
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage(MailboxAddress to, string subject, string content)
        {
            To=to;
            Subject=subject;
            Content=content;
        }
    }
}
