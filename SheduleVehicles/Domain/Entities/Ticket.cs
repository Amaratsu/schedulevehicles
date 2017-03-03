using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int OrderId { get; set; }
        public string FirstNamePassenger { get; set; }
        public string LastNamePassenger { get; set; }
        public string DocumentNumberPassenger { get; set; }
        public int NumberPassenger { get; set; }
        public string Status { get; set; }
    }
}
