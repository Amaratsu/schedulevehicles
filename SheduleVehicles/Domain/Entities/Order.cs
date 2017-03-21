using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order
    {
        [ForeignKey("Ticket")]
        public int Id { get; set; }
        //
        public int VoyageId { get; set; }
        public Voyage Voyage { get; set; }
        //
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
