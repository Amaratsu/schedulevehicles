using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using WebApi.ViewModels;

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
                            busStops.Where(
                                    b => b.Name == searchName 
                                    &&
                                    b.CurrentBusStopIsDepartureForVoyages.Any(v => v.DepartureDate >= DateTime.Now) 
                                    &&
                                    b.CurrentBusStopIsArrivalForVoyages.Any(v => v.ArrivalDate >= DateTime.Now))
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
                        .Where(v => v.DepartureDate == searchByDateAndTime.Value)
                        .ToList());
                }
            }
            return View("SearchByDateAndTime");
        }

        public ActionResult SearchBusStopsOfArrivalAndDeparture(string searchForDepartureStops,
            string searchForArrivalStops)
        {
            if (searchForDepartureStops != null && !String.IsNullOrEmpty(searchForDepartureStops))
            {
                using (var d = new UserContext())
                {
                    var busStops = from busStop in d.BusStops select busStop;

                    return View(busStops
                        .Where(x => x.Name == searchForDepartureStops && x.CurrentBusStopIsDepartureForVoyages.Any(y=>y.DepartureDate >= DateTime.Now))
                        .Include(bs => bs.CurrentBusStopIsDepartureForVoyages)
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
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) ||
                string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
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
            if (user.Email == null || user.Password == null ||
                string.IsNullOrEmpty(user.Email.Replace(" ", string.Empty)) ||
                string.IsNullOrEmpty(user.Password.Replace(" ", string.Empty)))
            {
                return "fieldError";
            }
            bool email =
                db.Users.Any(
                    usr =>
                        usr.Email.ToLower() == user.Email.ToLower() && usr.Password.ToLower() == user.Password.ToLower());
            if (email == false)
            {
                return "errorAthorization";
            }
            User userAuth = db.Users.FirstOrDefault(usr => usr.Email == user.Email);
            return userAuth.FirstName + " " + userAuth.LastName;
        }

        [HttpGet]
        public ActionResult TicketСlearance(int? id)
        {
            if (id == null || id == 0)
            {
                return View("Error");
            }
                Voyage voyage = db.Voyages.FirstOrDefault(v => v.Id == id);

            if (voyage != null)
            {
                var allnumberOfSeats = Enumerable.Range(1, voyage.NumberOfSeats).ToList();

                var freeSeats =
                    allnumberOfSeats.Except(db.Voyages.Where(v=> v.Id == id).SelectMany( v=> v.Orders.Select(order => order.Ticket.PassengerSeatNumber).ToList()));
                ViewBag.Voyage = id;
                ViewBag.Name = voyage.Name;
                ViewBag.Number = voyage.Number;
                ViewBag.TicketCost = voyage.OneTicketCost;
                var selectListItems = freeSeats.Select(i => new SelectListItem {Value = i.ToString(), Text = i.ToString()}).ToList();
                ViewBag.SelectSeatNumber = selectListItems;
            }
            return View("TicketСlearance");
        }

        [HttpPost]
        public ActionResult TicketСlearance(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                if (ticketViewModel.Status.ToString() == "Reserved")
                {
                    Ticket ticket = new Ticket
                    {
                        PassengerFirstName = ticketViewModel.PassengerFirstName,
                        PassengerLastName = ticketViewModel.PassengerLastName,
                        PassengerDocumentNumber = ticketViewModel.PassengerDocumentNumber,
                        PassengerSeatNumber = ticketViewModel.SelectSeatNumber,
                        Status = ticketViewModel.Status,
                        Order = new Order { VoyageId = ticketViewModel.Voyage, TicketId = ticketViewModel.Id }
                    };
                    var hardcodedUser = db.Users.FirstOrDefault(usr => usr.Id == 1);
                    if (hardcodedUser != null) hardcodedUser.Tickets = new List<Ticket> { ticket };
                    Voyage voyage = db.Voyages.FirstOrDefault(v => v.Id == ticketViewModel.Voyage);
                    if (voyage != null) voyage.OfAllPlaces -= 1;
                    db.SaveChanges();
                    return View("TicketIsReserved");
                }
                 if (ticketViewModel.Status.ToString() == "BoughtOut")
                {
                    Ticket ticket = new Ticket
                    {
                        PassengerFirstName = ticketViewModel.PassengerFirstName,
                        PassengerLastName = ticketViewModel.PassengerLastName,
                        PassengerDocumentNumber = ticketViewModel.PassengerDocumentNumber,
                        PassengerSeatNumber = ticketViewModel.SelectSeatNumber,
                        Status = ticketViewModel.Status,
                        Order = new Order { VoyageId = ticketViewModel.Voyage, TicketId = ticketViewModel.Id }
                    };
                    var hardcodedUser = db.Users.FirstOrDefault(usr => usr.Id == 1);
                    if (hardcodedUser != null) hardcodedUser.Tickets = new List<Ticket> { ticket };
                    Voyage voyage = db.Voyages.FirstOrDefault(v => v.Id == ticketViewModel.Voyage);
                    if (voyage != null) voyage.OfAllPlaces -= 1;
                    db.SaveChanges();
                    return View("TicketPurchased");
                }
                return View("Error");
            }
            return View("Error");
        }

        //Need to finish
        [HttpGet]
        public ActionResult GetAListOfTickets(string email = "alexov@gmail.com")
        {
            User user = db.Users.FirstOrDefault(usr=>usr.Email == email);
            List<Ticket> tickets = db.Tickets.Where(t => t.UserId == user.Id).ToList();
            var orders = from order in db.Orders select order;
            return View(orders
                .Include(tk => tk.Ticket)
                .Include(vg => vg.Voyage).ToList());
        }
    }
}