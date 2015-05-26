using School.Models;
using School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace School.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Login/
        public ActionResult Test()
        {
            return View();
        }


        // POST: /Login/
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool passwordCorrect = false;
                var user = db.Users.FirstOrDefault(u => u.username == model.Username && u.password == model.Password);

                if (user != null || model.Username == "admin" && model.Password == "password") //Simulate data store call where Username/Password
                {
                    passwordCorrect = true;
                }

                if (passwordCorrect && user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ViewBag.error = "Invalid username or password";
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View();
        }

        // GET: LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "login");
        }

        // POST: /Login/
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            return RedirectToAction("index", "login");
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
    }
}
