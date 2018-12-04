using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Final
{
    public class Mail
    {
        public static string HostAdd { get; private set; }
        public static string FromEmailID { get; private set; }
        public static string Pass { get; private set; }

        static void Email(string ToMail, string Subject, string Message, string FromMail, string Password)
        {
            HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
            //FromEmailID = ConfigurationManager.AppSettings[FromMail].ToString();
            //Pass = ConfigurationManager.AppSettings[Password].ToString();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromMail);
            mailMessage.Subject = Subject;
            mailMessage.Body = Message;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(ToMail));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostAdd;

            smtp.EnableSsl = true;
            NetworkCredential networkCredential = new NetworkCredential();
            networkCredential.UserName = mailMessage.From.Address;
            networkCredential.Password = Password;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkCredential;
            smtp.Port = 587;
            smtp.Send(mailMessage);
        }
        internal void SendVIPMail(string Reciver,string Subject,string Message, string FromMail, string Password)
        {
            Mail.Email(Reciver, Subject, Message,FromMail, Password);
        }
        internal void SendToManager(string Reciver, string Subject, string Message, string FromMail, string Password)
        {
            Mail.Email(Reciver, Subject, Message,FromMail,Password);
        }
    }
}


