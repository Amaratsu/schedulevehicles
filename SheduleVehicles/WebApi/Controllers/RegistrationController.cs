using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace WebApi.Controllers
{
    public class RegistrationController : Controller
    {
        private UserContext db = new UserContext();

        [HttpPost]
        public ActionResult ValidateRegistration(User user)
        {
            bool alreadyExists = db.Users.Any(usr => usr.Email.ToLower() == user.Email.ToLower());
            if (alreadyExists == false)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return View();
            }
            return View();
        }
    }
}