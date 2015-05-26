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
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/

        public ActionResult Index()
        {
            string username = User.Identity.Name;
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "Teacher";
            return View();
        }

        //
        // GET: /Teacher/Add

        public ActionResult Add()
        {
            string username = User.Identity.Name;
            ViewBag.CurrentPage = "Teacher";
            ViewBag.UserType = Methods.GetUserType(username);
            return View();
        }

        //
        // GET: /Teacher/Add
        [HttpPost]
        public ActionResult Add(User newUser)
        {
            string username = User.Identity.Name;
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "Teacher";

            if(ModelState.IsValid)
            {
                db.Users.InsertOnSubmit(newUser);
                db.SubmitChanges();
            }

            return View();
        }

        //
        // GET: /Teacher/ViewLearners
        public ActionResult ViewLearners()
        {
            string username = User.Identity.Name;
            var learners = (from l in db.Learners select new LearnersViewModel { Name = l.name, Surname = l.surname, Presence = true, LearnerID = l.learner_id, ClassID = l.class_id.Value }).ToList();
            var classes = (from c in db.Classes select c).ToList();
            var subjects = (from s in db.Subjects select s).ToList();

            ViewBag.CurrentPage = "Teacher";
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.Classes = classes.Select(x => new SelectListItem { Value = x.class_id.ToString(), Text = x.className });
            ViewBag.Subjects = subjects.Select(x => new SelectListItem { Value = x.subject_id.ToString(), Text = x.name});

            return View(learners);
        }

        //
        // GET: /Teacher/Concerns
        public ActionResult Concerns()
        {
            string username = User.Identity.Name;
            var learners = (from l in db.Learners select new LearnersViewModel { Name = l.name, Surname = l.surname, Presence = true, LearnerID = l.learner_id, ClassID = l.class_id.Value }).ToList();

            ViewBag.CurrentPage = "Concerns";
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.Learners = learners.Select(x => new SelectListItem { Value = x.LearnerID.ToString(), Text = x.Surname + " " + x.Name });

            return View(learners);
        }

        //
        // GET: /Teacher/ViewLearners
        public ActionResult EnterMarks()
        {
            string username = User.Identity.Name;
            var learners = (from l in db.Learners select new LearnerMarksViewModel { Name = l.name, Surname = l.surname, Mark = 0, LearnerID = l.learner_id, ClassID = l.class_id.Value }).ToList();
            var classes = (from c in db.Classes select c).ToList();
            var subjects = (from s in db.Subjects select s).ToList();

            ViewBag.CurrentPage = "Marks";
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.Classes = classes.Select(x => new SelectListItem { Value = x.class_id.ToString(), Text = x.className });
            ViewBag.Subjects = subjects.Select(x => new SelectListItem { Value = x.subject_id.ToString(), Text = x.name });

            return View(learners);
        }

        [HttpPost]
        // POST: Teacher/SaveRegister
        public JsonResult SaveRegister(IEnumerable<LearnersViewModel> entries, int classID, int subjectID)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                var user = db.Users.FirstOrDefault(u => u.username == username);

                foreach(var e in entries)
                {
                    var existingRegister = db.Registers.FirstOrDefault(r => r.learner_id == e.LearnerID
                        && r.subject_id == subjectID && r.user_id == user.user_id &&
                        r.timeStamp.Value > DateTime.UtcNow.AddHours(1) && r.timeStamp.Value < DateTime.UtcNow.AddHours(2));
                    
                    if(existingRegister == null)
                    {
                        var register = new Register
                        {
                            learner_id = e.LearnerID,
                            subject_id = subjectID,
                            user_id = user.user_id,
                            timeStamp = DateTime.UtcNow.AddHours(2),
                            isPresent = e.Presence
                        };

                        db.Registers.InsertOnSubmit(register);
                    }
                    else
                    {
                        existingRegister.isPresent = e.Presence;
                        existingRegister.timeStamp = DateTime.UtcNow.AddHours(2);
                    }
                    
                    db.SubmitChanges();  
                }
                            
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        // POST: Teacher/SaveMarks
        public JsonResult SaveMarks(IEnumerable<LearnerMarksViewModel> marks, int classID, int subjectID, string description)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                var user = db.Users.FirstOrDefault(u => u.username == username);

                foreach (var m in marks)
                {
                    var existingMark = db.Marks.FirstOrDefault(r => r.learner_id == m.LearnerID
                        && r.subject_id == subjectID && r.user_id == user.user_id &&
                        r.description == description);

                    if (existingMark == null)
                    {
                        var mark = new Mark
                        {
                            learner_id = m.LearnerID,
                            subject_id = subjectID,
                            user_id = user.user_id,
                            marks = m.Mark,
                            description = description                           
                        };

                        db.Marks.InsertOnSubmit(mark);
                    }
                    else
                    {
                        existingMark.marks = m.Mark;
                    }

                    db.SubmitChanges();
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        // POST: Teacher/SendConcern
        public JsonResult SendConcern(int learnerID, string message)
        {
            try
            {
                string username = User.Identity.Name;
                var learner = db.Learners.FirstOrDefault(l => l.learner_id == learnerID);
                var teacher = db.Users.FirstOrDefault(u => u.username == username);
                string subject = "Teacher Concern";
                var concern = new Concern
                {
                    learner_id = learnerID,
                    message = message,
                    user_id = teacher.user_id,
                    timestamp = DateTime.UtcNow.AddHours(2)
                };
                
                message = message.Replace("\n", "<br/>");
                string greetings = "To the parent of <b>" + learner.name + " " + learner.surname + "</b><br/><br/>";
                string body = greetings + "<p>"+ message +"</p>";

                var sent = SendEmail(learner.User.email, subject, body);

                if(sent)
                {
                    db.Concerns.InsertOnSubmit(concern);
                    db.SubmitChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);   
                }                    
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }               
        }

        public bool SendEmail(string address, string subject, string body)
        {
            if ((address != null) && (address.Trim().Length > 0))
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("fl.hanyane@gmail.com", "School Team");
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

        DataClasses1DataContext db = new DataClasses1DataContext();
    }
}
