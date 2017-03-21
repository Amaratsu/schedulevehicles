using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Voyage
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan TravelTime { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int OfAllPlaces { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal OneTicketCost { get; set; }
        //
        public int DepartureBusStopId { get; set; }
        //
        public int ArrivalBusStopId { get; set; }
        //
        public virtual ICollection<Order> Orders { get; set; }
        //
        public virtual BusStop DepartureBusStop { get; set; }
        public virtual BusStop ArrivalBusStop { get; set; }

    }
}
