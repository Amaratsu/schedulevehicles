using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Voyage
    {
        public int VoyageId { get; set; }
        public int DepartureId { get; set; }
        public int ArrivalId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDataDateTime { get; set; }
        public string TravelTime { get; set; }
        public int VoyageNumber { get; set; }
        public string VoyageName { get; set; }
        public int NumberSeats { get; set; }
        public decimal TicketCost { get; set; }


    }
}
