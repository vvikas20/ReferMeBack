using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Implementations
{
    public class EmailService : IEmailService
    {
        public void sendEmail(string emailTo, string subject, string body)
        {
            string FromMail = "vsvikassingh49alt@gmail.com";

            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("vsvikassingh49alt@gmail.com", "Password@94");
            client.EnableSsl = true;

            client.Send(mail);
        }
    }
}
