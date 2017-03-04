using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        //public List<User>Users = new List<User>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            return View("RegistrationComplited");
        }
    }
}