using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Index(string searchName)
        {
            if (searchName != null && !String.IsNullOrEmpty(searchName))
            {
                using (var d = new UserContext())
                {
                    var busStops = from busStop in d.BusStops select busStop;
                    return
                        View(
                            busStops.Where(b => b.Name == searchName)
                                .Include(bs => bs.CurrentBusStopIsDepartureForVoyages)
                                .Include(sb => sb.CurrentBusStopIsArrivalForVoyages)
                                .ToList());
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult SearchByDateAndTime(DateTime? searchByDateAndTime)

        {
            if (searchByDateAndTime != null)
            {
                using (var d = new UserContext())
                {
                    var voyages = from voyage in d.Voyages select voyage;
                    return View(voyages
                        .Where(v=>v.DepartureDate == searchByDateAndTime.Value)
                        .ToList());
                }
            }
            return View("SearchByDateAndTime");
        }

        public ActionResult SearchBusStopsOfArrivalAndDeparture(string searchForDepartureStops, string searchForArrivalStops)
        {
            if (searchForDepartureStops != null && !String.IsNullOrEmpty(searchForDepartureStops))
            {
                
                using (var d = new UserContext())
                {
                    var busStops = from busStop in d.BusStops select busStop;
                        
                    return View(busStops
                            .Include(bs => bs.CurrentBusStopIsDepartureForVoyages)
                            .Where(x => x.Name == searchForDepartureStops)
                            .ToList());
                }
            }

            if (searchForArrivalStops != null && !String.IsNullOrEmpty(searchForArrivalStops))
            {
                using (var d = new UserContext())
                {
                    var busStops = from busStop in d.BusStops select busStop;
                        
                    return View(busStops.Include(bs => bs.CurrentBusStopIsArrivalForVoyages)
                            .Where(x => x.Name == searchForArrivalStops).ToList());
                }
            }
            return View("SearchBusStopsOfArrivalAndDeparture");
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
    }
}