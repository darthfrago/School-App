using School.Models;
using School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            }

            return View();
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

                lrvm.Learner = c.surname + ", " + c.name;                
                lrvm.Marks = marks;
                lrvm.Concerns = concerns;
                reports.Add(lrvm);
            }

            return View(reports);
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
    }
}
