using School.Models;
using School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/Add
        public ActionResult Add()
        {
            string username = User.Identity.Name;
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "News";
            return View();
        }

        // POST: /News/Add
        [HttpPost]
        public ActionResult Add(NewsEntry newsEntry)
        {
            string username = User.Identity.Name;
            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "News";

            try
            {
                if (ModelState.IsValid)
                {
                    var user = db.Users.FirstOrDefault(u => u.username == username);
                    newsEntry.user_id = user.user_id;
                    newsEntry.timestamp = DateTime.UtcNow.AddHours(2);

                    db.NewsEntries.InsertOnSubmit(newsEntry);
                    db.SubmitChanges();

                    ViewBag.success = "News saved successfully";
                }
                else
                    ViewBag.error = "Something went wrong, please try again";

                return View();
            }
            catch
            {
                ViewBag.error = "Something went wrong, please try again";
                return View();
            }       
        }

        //
        // GET: /News/View
        public ActionResult See()
        {
            string username = User.Identity.Name;
            var news = (from n in db.NewsEntries select n).ToList();

            ViewBag.UserType = Methods.GetUserType(username);
            ViewBag.CurrentPage = "News";

            return View(news);
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
    }
}
