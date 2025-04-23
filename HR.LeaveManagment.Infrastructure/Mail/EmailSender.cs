using HR.LeaveManagment.Application.Contracts.Infrastructure;
using HR.LeaveManagment.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagment.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmailAsync(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var to = new EmailAddress(email.To);

            var from = new EmailAddress(
                _emailSettings.FromAddress,
                _emailSettings.FromName);

            var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

            var response = await client.SendEmailAsync(msg);

            return
                   response.StatusCode == System.Net.HttpStatusCode.OK ||
                   response.StatusCode == System.Net.HttpStatusCode.Created ||
                   response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
