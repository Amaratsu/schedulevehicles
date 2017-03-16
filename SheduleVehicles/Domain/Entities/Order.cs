using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        [ForeignKey("Ticket")]
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public enum OrderStatus
        {
            Reserved,
            BoughtOut
        }
        //
        public int VoyageId { get; set; }
        public Voyage Voyage { get; set; }
        //
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
