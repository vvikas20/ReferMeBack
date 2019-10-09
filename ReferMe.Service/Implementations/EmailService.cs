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
            string FromMail = "admin@vsvikassingh.co.in";

            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;

            client.Host = "smtpout.secureserver.net";   //-- Donot change.
            client.Port = 465; //--- Donot change
            client.EnableSsl = false;//--- Donot change
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("admin@vsvikassingh.co.in", "Password@94");
            client.Send(mail);
        }
    }
}
