using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AgreementManagement.Web.Service
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email, email));
                message.From = new MailAddress("agreement.management.mvc@gmail.com", "Agreement Management");
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("agreement.management.mvc@gmail.com", "agreement.management.mvc123");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
            return Task.CompletedTask;
        }
    }
}
