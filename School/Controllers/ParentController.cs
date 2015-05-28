using School.Models;
using School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class ParentController : Controller
    {
        //
        // GET: /Parent/
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            var userType = Methods.GetUserType(username);
            ViewBag.UserType = userType;
            ViewBag.CurrentPage = "Parent";

            return View();
        }

        //
        // GET: /Parent/Add
        public ActionResult Add()
        {            
            string username = User.Identity.Name;
            var userType = Methods.GetUserType(username);
            ViewBag.UserType = userType;
            ViewBag.CurrentPage = "Parent";

            return View();
        }

        //
        // GET: /Parent/Add
        [HttpPost]
        public ActionResult Add(User newUser)
        {
            string username = User.Identity.Name;
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "Parent";

            if (ModelState.IsValid)
            {
                db.Users.InsertOnSubmit(newUser);
                db.SubmitChanges();
                ViewBag.success = "Parent registered successfully.";

                if(newUser.email != null)
                {
                    var message = "Hello there, <br/>You have been registered on our school's application. Your account details are as follows:<br/><br/>"
                        + "<b>Username:</b> " + newUser.username + "<br/><b>Password: </b> " + newUser.password + "<br/><br/>Thank you for registering.<br/>School App Team";
                    var subject = "Welcome the School App";
                    string body = "<p>" + message + "</p>";

                    var sent = SendEmail(newUser.email, subject, body);
                }
            }
            else
                ViewBag.error = "Something went wrong, please try again";

            return View();
        }

        public bool SendEmail(string address, string subject, string body)
        {
            if ((address != null) && (address.Trim().Length > 0))
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("fl.hanyane@gmail.com", "School App Team");
                mail.To.Add(address);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                try
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                    SmtpServer.Credentials = new NetworkCredential("fl.hanyane@gmail.com", "9104145571");
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

        //
        // GET: /Parent/Report
        public ActionResult Report()
        {
            string username = User.Identity.Name;
            var userType = Methods.GetUserType(username);
            ViewBag.UserType = userType;
            ViewBag.CurrentPage = "Report";

            var parent = db.Users.FirstOrDefault(u => u.username == username);
            var children = (from c in db.Learners where c.user_id == parent.user_id select c).ToList();
            var reports = new List<LearnerReportViewModel>();

            foreach(var c in children)
            {
                var lrvm = new LearnerReportViewModel();

                var marks = (from m in db.Marks
                             where m.learner_id == c.learner_id
                             select new MarksReportViewModel { Marks = m.marks.GetValueOrDefault(0).ToString(), 
                                 Subject = m.Subject.name, Description = m.description }).ToList();

                var concerns = (from x in db.Concerns
                                where x.learner_id == c.learner_id
                                select new ConcernsReportViewModel { Date = x.timestamp.GetValueOrDefault(DateTime.MaxValue), 
                                    Message = x.message, Teacher = x.User.surname +" "+ x.User.name.Substring(0,1) + "." }).ToList();

                var absents = (from x in db.Registers
                                   where x.learner_id == c.learner_id && !x.isPresent.Value
                                   select new AbsenceReportViewModel { Date = x.timeStamp.GetValueOrDefault(DateTime.MaxValue),
                                   Subjet = x.Subject.name, Teacher =  x.User.surname +" "+ x.User.name.Substring(0,1) + "."}).ToList();                                   

                lrvm.Learner = c.surname + ", " + c.name;                
                lrvm.Marks = marks;
                lrvm.Concerns = concerns;
                lrvm.Absents = absents;
                reports.Add(lrvm);
            }

            return View(reports);
        }

        // GET: Parent/Exists
        public JsonResult Exists(string username)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.username == username);

                if (user != null)
                    return Json(true, JsonRequestBehavior.AllowGet);
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
    }
}
