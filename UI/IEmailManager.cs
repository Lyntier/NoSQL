using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL.UI
{
    public interface IEmailManager
    {
        void AppSettings(out string UserID, out string Password, out string SMTPPort, out string Host);

        void SendEmail(string From, string Subject, string Body, string To, string UserID, string Password, string SMTPPort, string Host);
    }
}
