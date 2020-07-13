using System.Net;
using System.Net.Mail;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;

namespace Falcon.App.Infrastructure.Communication
{
    public class NotificationEmailSender : INotificationEmailSender
    {
        public delegate SmtpClient GetSmtpClient();

        private readonly GetSmtpClient _getSmtpClient;
        private readonly ISmtpCredentials _smtpCredentials;

        public NotificationEmailSender(ISmtpCredentials smtpCredentials)
        {
            _smtpCredentials = smtpCredentials;
            _getSmtpClient = () => new SmtpClient(_smtpCredentials.Host, _smtpCredentials.Port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpCredentials.SmtpUserName, smtpCredentials.SmtpPassword)
            };
            //_smtpClient.EnableSsl = true;
        }

        public void SendEmail(EmailMessage emailMessage)
        {
            using (var message = new MailMessage())
            {
                message.IsBodyHtml = true;
                message.Body = emailMessage.Body;
                message.Subject = emailMessage.Subject;
                message.From = new MailAddress(emailMessage.FromEmail, emailMessage.FromName);
                message.To.Add(emailMessage.ToEmail);

                using (var client = _getSmtpClient())
                {
                    client.Send(message);
                }
            }
        }
    }
}