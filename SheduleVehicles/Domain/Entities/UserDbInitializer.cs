using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserDbInitializer: DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Users.Add(new User
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Alexov",
                Email = "alexov@gmail.com",
                Password = "alexov",
                BirthDate = new DateTime(1987, 2, 1),
                Tickets = new List<Ticket> { new Ticket {Id = 1, OrderId = 1, PassengerFirstName = "alex", PassengerLastName = "Alexeev", PassengerDocumentNumber = "112ghg212321", PassengerSeatNumber = 2}}
            });
            db.Users.Add(new User
            {
                Id = 2,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanov@gmail.com",
                Password = "ivanov",
                BirthDate = new DateTime(2000, 2, 10),
                Tickets = new List<Ticket> { new Ticket { Id = 1, OrderId = 1, PassengerFirstName = "x", PassengerLastName = "xx", PassengerDocumentNumber = "xxxxxxx", PassengerSeatNumber = 4 } }
            });
            db.Users.Add(new User
            {
                Id = 3,
                FirstName = "Admin",
                LastName = "SuperAdmin",
                Email = "admin@gmail.com",
                Password = "admin",
                BirthDate = new DateTime(1980, 4, 1),
                Tickets = new List<Ticket> { new Ticket { Id = 1, OrderId = 1, PassengerFirstName = "y", PassengerLastName = "yy", PassengerDocumentNumber = "yyyyyyyy", PassengerSeatNumber = 8 } }
            });

            db.BusStops.Add(new BusStop
            {
                Id = 1,
                Name = "Минск",
                Description = "Центральный вокзал",
            });
            db.BusStops.Add(new BusStop
            {
                Id = 2,
                Name = "Минск",
                Description = "Восточный вокзал закрыт"
            });
            db.BusStops.Add(new BusStop
            {
                Id = 3,
                Name = "Могилев",
                Description = "Центральный вокзал"
            });

            db.Voyages.Add(new Voyage
            {
                Id = 1,
                DepartureBusStopId = 1,
                ArrivalBusStopId = 1,
                DepartureDate = new DateTime(2017, 3, 15, 19, 0, 0),
                ArrivalDate = new DateTime(2017, 3, 15, 22, 34, 0),
                TravelTime = new TimeSpan(3, 34, 0),
                Number = 47,
                Name = "Минск-Могилев",
                NumberOfSeats = 40,
                OneTicketCost = 97.98m
            });

            base.Seed(db);
        }
    }
}
