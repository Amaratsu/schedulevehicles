using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult RegistrationSuccess()
        {
            return View("RegistrationSuccess");
        }

        public ActionResult RegistrationError()
        {
            return View("RegistrationError");
        }
    }
}