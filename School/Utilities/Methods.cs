using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace School.Utilities
{
    public class Methods
    {
        public static int GetUserType(string username)
        {
            var db = new DataClasses1DataContext();
            var user = db.Users.FirstOrDefault(u => u.username == username);

            switch(user.userType)
            {
                case (int)UserTypes.Admin:
                    return 0;
                case (int)UserTypes.Parrent:
                    return 2;
                case (int)UserTypes.Teacher:
                    return 1;
                default:
                    return -1;
            }
        }

        public static bool SendEmail(string address, string subject, string body)
        {
            if ((address != null) && (address.Trim().Length > 0))
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(Constants.SchoolEmail, "School App Team");
                mail.To.Add(address);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                try
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                    SmtpServer.Credentials = new NetworkCredential(Constants.SchoolEmail, Constants.SchoolPassword);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }         
    }
}