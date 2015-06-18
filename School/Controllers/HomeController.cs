using School.Models;
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

        [HttpPost]
        public ActionResult Contact(ContactModel contactMessage)
        {
            string username = User.Identity.Name;
            var userType = Methods.GetUserType(username);
            ViewBag.UserType = userType;
            ViewBag.CurrentPage = "Contact";

            if(ModelState.IsValid)
            {
                var message = "Hey there, you have a new message<br/>"
                + "<b>From: </b>" + contactMessage.Name + "<br/>"
                + "<b>Contact: </b>" + contactMessage.PhoneNumber + "<br/>"
                + "<b>Message: </b>" + contactMessage.Message
                + "<br/><br/>School App Team";

                var subject = "School App Message";
                string body = "<p>" + message + "</p>";

                var sent = Methods.SendEmail(Constants.AdminEmail, subject, body);

               if(sent)
                    ViewBag.success = "Message sent successfully.";
                else
                    ViewBag.error = "Something went wrong, please try again";
            }
            else
                ViewBag.error = "Something went wrong, please try again";

            return View(contactMessage);
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
