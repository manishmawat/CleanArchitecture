using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;
using Domain;
using Microsoft.Extensions.Logging;
using MailKit.Security;

namespace Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(EmailConfiguration emailConfiguration,ILogger<EmailSender> logger)
        {
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }

        public async Task SendEmail(EmailMessage email)
        {
            var emailMessage = CreateEmailMessage(email);

            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage emailMessage)
        {
            var emailMimeMessage = new MimeMessage();

            emailMimeMessage.From.Add(new MailboxAddress("email",_emailConfiguration.From));
            emailMimeMessage.To.Add(emailMessage.To);

            emailMimeMessage.Subject=emailMessage.Subject;
            emailMimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = emailMessage.Content };

            return emailMimeMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

                await client.SendAsync(mailMessage);
                _logger.LogInformation("Email sent successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Email send failed. Error: {ex}");
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
