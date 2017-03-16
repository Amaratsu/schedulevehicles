using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public string PassengerDocumentNumber { get; set; }
        public int PassengerSeatNumber { get; set; }
        public TicketStatus Status { get; set; }
        public enum TicketStatus
        {
            Reserved,
            BoughtOut
        }
        //
        public int UserId { get; set; }
        public User User { get; set; }
        //
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
