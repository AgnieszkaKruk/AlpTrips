using AlpsTrips.MVC.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AlpsTrips.MVC.Services
{
    public class EmailService : IEmailService
    {


        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _options;

        public EmailService(IOptions<SMTPConfigModel> options)
        {
            _options = options.Value;
        }


        public async Task SendTestEmail(UserEmailOptions emailOptions)
        {
            emailOptions.Subject = "Przykładowy tytuł e-maila";
            emailOptions.Body = GetEmailBody("TestEmail");
            await SendEmail(emailOptions);

        }


        private async Task SendEmail(UserEmailOptions emailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = emailOptions.Subject,
                Body = emailOptions.Body,
                From = new MailAddress(_options.SenderAddress, _options.SenderDisplayName),
                IsBodyHtml = _options.IsBodyHTML
            };

            foreach (var email in emailOptions.ToEmails)
            {
                mail.To.Add(email);
            }

            NetworkCredential networkCredential = new NetworkCredential(_options.UserName, _options.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Port = _options.Port,
                Host = _options.Host,
                EnableSsl = _options.EnableSSL,
                UseDefaultCredentials = _options.UseDefaultCredentials,
                Credentials = networkCredential

            };
            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }

    }
}


