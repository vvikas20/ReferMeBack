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
        public void SendEmail(string emailFrom, string emailTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("refermecommunity@gmail.com", "Password@94");
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception)
            {


            }
        }

        public void SendAsyncMail(string emailFrom, string emailTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("refermecommunity@gmail.com", "Password@94");
            client.EnableSsl = true;

            //event handler for asynchronous call
            client.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            try
            {
                client.SendAsync(mail, mail);
            }
            catch (Exception ex) { /* exception handling code here */ }
        }

        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage mail = e.UserState as MailMessage;

            if (!e.Cancelled && e.Error != null)
            {

            }
        }
    }
}
