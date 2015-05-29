using School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            var userType = Methods.GetUserType(username);
            ViewBag.UserType = userType;
            ViewBag.CurrentPage = "Home";

            return View();
        }

        public ActionResult Contact()
        {
            string username = User.Identity.Name;
            var userType = Methods.GetUserType(username);
            ViewBag.UserType = userType;
            ViewBag.CurrentPage = "Contact";

            return View();
        }

        public ActionResult AddParent()
        {
            string username = User.Identity.Name;
            var userType = Methods.GetUserType(username);
            ViewBag.UserType = userType;
            ViewBag.CurrentPage = "Home";

            return View();
        }

        public ActionResult Teacher()
        {
            string username = User.Identity.Name;
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "Home";

            return View();
        }
    }
}
