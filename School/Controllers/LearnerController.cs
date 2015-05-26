using School.Models;
using School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class LearnerController : Controller
    {
        //
        // GET: /Learner/

        public ActionResult Index()
        {
            string username = User.Identity.Name;
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "Learner";
            return View();
        }

        //
        // GET: /Learner/Add

        public ActionResult Add()
        {
            string username = User.Identity.Name;
            var parents = (from p in db.Users where p.userType == (int)UserTypes.Parrent select p).ToList();
            var classes = (from c in db.Classes select c).ToList();
            ViewBag.Parents = parents.Select(x => new SelectListItem { Value = x.user_id.ToString(), Text = x.surname + " " + x.name });
            ViewBag.Classes = classes.Select(x => new SelectListItem { Value = x.class_id.ToString(), Text = x.className });
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "Learner";
            return View();
        }

        //
        // GET: /Learner/Add
        [HttpPost]
        public ActionResult Add(Learner newLearner)
        {
            string username = User.Identity.Name;
            var parents = (from p in db.Users where p.userType == (int)UserTypes.Parrent select p).ToList();
            var classes = (from c in db.Classes select c).ToList();
            ViewBag.Parents = parents.Select(x => new SelectListItem { Value = x.user_id.ToString(), Text = x.surname + " " + x.name });
            ViewBag.Classes = classes.Select(x => new SelectListItem { Value = x.class_id.ToString(), Text = x.className });
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "Learner";

            if (ModelState.IsValid)
            {
                db.Learners.InsertOnSubmit(newLearner);
                db.SubmitChanges();
            }

            return View();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

    }
}
