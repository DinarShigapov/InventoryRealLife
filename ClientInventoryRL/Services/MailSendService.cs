using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClientInventoryRL.Services
{
    public class MailSendService
    {
        public MailMessage CreateMail(string name, string emailFrom, string emailTo, string subject, string body)
        {
            var from = new MailAddress(emailFrom, name);
            var to = new MailAddress(emailTo);
            var mail = new MailMessage(from, to) 
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            return mail;
        }

        public void SendMail(string host, int smtpPort, string emailFrom, string pass, MailMessage mail)
        {
            SmtpClient smtp = new SmtpClient(host, smtpPort);
            smtp.Credentials = new NetworkCredential(emailFrom, pass);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

    }
}
