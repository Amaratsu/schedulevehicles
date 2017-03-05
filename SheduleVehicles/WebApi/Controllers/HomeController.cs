using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        public string Registration(User user)
        {
            bool alreadyExists = db.Users.Any(usr => usr.Email.ToLower() == user.Email.ToLower());
            if (alreadyExists == false)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return "saveSuccess";
            }
            return "saveError";
        }
    }
}