using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
namespace LogicUniversityStationeryStore.Helper
{
    public class NotificationHelper
    {

        public bool sendEmailbyClerk(string to, string Email, string subject)
        {
            string from = "logicrusselclerk@gmail.com";
            string password = "LogicRusselClerk345";
            string To = to;
            string Subject = subject;
            string Body =Email ;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from);
            msg.To.Add(new MailAddress(To));
            msg.Subject = Subject;
            msg.Body = Body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            //	    smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(msg);
                return true;
            }
            catch (SmtpException err)
            {
                Console.WriteLine(err);
                Console.Read();
                return false;
            }
        }


    }
}