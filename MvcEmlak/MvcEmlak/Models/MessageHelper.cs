using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace MvcEmlak.Models
{
    public static class MessageHelper
    {
        public static bool SendMessage(string To, string Subject, string Message)
        {
            MailMessage _mm = new MailMessage();

            _mm.SubjectEncoding = Encoding.Default;
            _mm.Subject = Subject;

            _mm.BodyEncoding = Encoding.Default;
            _mm.IsBodyHtml = true;
            _mm.Body = Message;

            _mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            _mm.To.Add(To);

            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSSLEnable"]);

            try
            {
                _smtpClient.Send(_mm);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}