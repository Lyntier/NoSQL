using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NoSQL.UI
{
    public class EmailManager : IEmailManager
    {
        IConfiguration _config;

        public EmailManager(IConfiguration config)
        {
            _config = config;
        }
        public void AppSettings(out string UserID, out string Password, out string SMTPPort, out string Host)
        {
            UserID = _config.GetValue<string> ("UserID");
            Password = _config.GetValue<string>("Password");
            SMTPPort = _config.GetValue<string>("SMTPPort");
            Host = _config.GetValue<string>("Host");
        }

        public void SendEmail(string From, string Subject, string Body, string To, string UserID, string Password, string SMTPPort, string Host)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(From);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(UserID, Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
