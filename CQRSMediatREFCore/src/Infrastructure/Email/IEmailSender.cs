using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace Infrastructure.Email
{
    public interface IEmailSender
    {
        Task SendEmail(EmailMessage Email);
    }
}
