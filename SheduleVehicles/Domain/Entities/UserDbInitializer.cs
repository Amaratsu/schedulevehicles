using System;
using System.Collections.Generic;
using System.Data.Entity;

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
                BirthDate = new DateTime(1987, 2, 1)
            });
            db.Users.Add(new User
            {
                Id = 2,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanov@gmail.com",
                Password = "ivanov",
                BirthDate = new DateTime(2000, 2, 10)
            });
            db.Users.Add(new User
            {
                Id = 3,
                FirstName = "Admin",
                LastName = "SuperAdmin",
                Email = "admin@gmail.com",
                Password = "admin",
                BirthDate = new DateTime(1980, 4, 1)
            });

            Voyage v1 = new Voyage
            {
                Id = 1,
                DepartureBusStopId = 4,
                ArrivalBusStopId = 1,
                DepartureDate = new DateTime(2017, 3, 23, 19, 0, 0),
                ArrivalDate = new DateTime(2017, 3, 23, 22, 34, 0),
                TravelTime = new TimeSpan(3, 34, 0),
                Number = 22,
                Name = "Могилев-Минск",
                NumberOfSeats = 10,
                OfAllPlaces = 10,
                OneTicketCost = 97.98m
            };
            Voyage v2 = new Voyage
            {
                Id = 2,
                DepartureBusStopId = 1,
                ArrivalBusStopId = 4,
                DepartureDate = new DateTime(2017, 3, 22, 20, 30, 0),
                ArrivalDate = new DateTime(2017, 3, 23, 0, 4, 0),
                TravelTime = new TimeSpan(3, 34, 0),
                Number = 22,
                Name = "Минск-Могилев",
                NumberOfSeats = 0,
                OfAllPlaces = 0,
                OneTicketCost = 97.98m
            };
            Voyage v3 = new Voyage
            {
                Id = 3,
                DepartureBusStopId = 4,
                ArrivalBusStopId = 3,
                DepartureDate = new DateTime(2017, 3, 23, 14, 22, 0),
                ArrivalDate = new DateTime(2017, 3, 23, 15, 57, 0),
                TravelTime = new TimeSpan(1, 35, 0),
                Number = 23,
                Name = "Могилев-Хотимск",
                NumberOfSeats = 10,
                OfAllPlaces = 10,
                OneTicketCost = 48.80m
            };
            Voyage v4 = new Voyage
            {
                Id = 4,
                DepartureBusStopId = 3,
                ArrivalBusStopId = 4,
                DepartureDate = new DateTime(2017, 3, 23, 17, 30, 0),
                ArrivalDate = new DateTime(2017, 3, 23, 19, 5, 0),
                TravelTime = new TimeSpan(1, 35, 0),
                Number = 23,
                Name = "Хотимск-Могилев",
                NumberOfSeats = 10,
                OfAllPlaces = 10,
                OneTicketCost = 48.80m
            };
            Voyage v5 = new Voyage
            {
                Id = 5,
                DepartureBusStopId = 1,
                ArrivalBusStopId = 2,
                DepartureDate = new DateTime(2017, 3, 23, 14, 22, 0),
                ArrivalDate = new DateTime(2017, 3, 23, 15, 57, 0),
                TravelTime = new TimeSpan(1, 35, 0),
                Number = 24,
                Name = "Минск-Брест",
                NumberOfSeats = 4,
                OfAllPlaces = 4,
                OneTicketCost = 55.42m
            };
            Voyage v6 = new Voyage
            {
                Id = 6,
                DepartureBusStopId = 2,
                ArrivalBusStopId = 1,
                DepartureDate = new DateTime(2017, 3, 23, 17, 30, 0),
                ArrivalDate = new DateTime(2017, 3, 23, 19, 5, 0),
                TravelTime = new TimeSpan(1, 35, 0),
                Number = 24,
                Name = "Брест-Минск",
                NumberOfSeats = 10,
                OfAllPlaces = 10,
                OneTicketCost = 55.42m
            };

            BusStop b1 = new BusStop
            {
                Id = 1,
                Name = "Минск",
                Description = "Центральный вокзал",
                CurrentBusStopIsDepartureForVoyages = new List<Voyage> {v2, v5},
                CurrentBusStopIsArrivalForVoyages = new List<Voyage> {v1, v6}
            };
            BusStop b2 = new BusStop
            {
                Id = 2,
                Name = "Брест",
                Description = "Центральный вокзал",
                CurrentBusStopIsDepartureForVoyages = new List<Voyage> {v6},
                CurrentBusStopIsArrivalForVoyages = new List<Voyage> {v5}
            };
            BusStop b3 = new BusStop
            {
                Id = 3,
                Name = "Хотимск",
                Description = "Центральный вокзал",
                CurrentBusStopIsDepartureForVoyages = new List<Voyage> {v4},
                CurrentBusStopIsArrivalForVoyages = new List<Voyage> {v3}
            };
            BusStop b4 = new BusStop
            {
                Id = 4,
                Name = "Могилев",
                Description = "Центральный вокзал",
                CurrentBusStopIsDepartureForVoyages = new List<Voyage> {v1, v3},
                CurrentBusStopIsArrivalForVoyages = new List<Voyage> {v2, v4}
            };

            db.BusStops.Add(b1);
            db.BusStops.Add(b2);
            db.BusStops.Add(b3);
            db.BusStops.Add(b4);

            base.Seed(db);
        }
    }
}
