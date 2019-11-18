using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Implementations
{
    public class EmailService : IEmailService
    {
        public void SendAsyncMail(string emailFrom, string emailTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            bool emailEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["EmailEnabled"]);
            if (emailEnabled)
            {
                client.Host = ConfigurationManager.AppSettings["Host"];
                client.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        client.SendMailAsync(mail);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                    return true;
                });
            }
        }
    }
}
