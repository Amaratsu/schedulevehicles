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
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return "fieldError";
            }
            bool alreadyExists = db.Users.Any(usr => usr.Email.ToLower() == user.Email.ToLower());
            if (alreadyExists == false)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return "saveSuccess";
            }
            return "saveError";
        }

        [HttpPost]
        public string Authorization(User user)
        {
            if (user.Email == null || user.Password == null || string.IsNullOrEmpty(user.Email.Replace(" ", string.Empty)) || string.IsNullOrEmpty(user.Password.Replace(" ", string.Empty)))
            {
                return "fieldError";
            }
            bool email = db.Users.Any(usr => usr.Email.ToLower() == user.Email.ToLower() && usr.Password.ToLower() == user.Password.ToLower());
            if (email == false)
            {
                return "errorAthorization";
            }
            User userAuth = db.Users.FirstOrDefault(usr => usr.Email == user.Email);
            return userAuth.FirstName + " " + userAuth.LastName;
        }

        public string UpdateSession()
        {
            return "";
        }

    }
}