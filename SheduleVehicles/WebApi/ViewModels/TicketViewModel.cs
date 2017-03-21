using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace WebApi.ViewModels
{
    public class TicketViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string PassengerFirstName { get; set; }
        [Required]
        public string PassengerLastName { get; set; }
        [Required]
        public string PassengerDocumentNumber { get; set; }
        public Ticket.OrderStatus Status { get; set; }
        public enum OrderStatus
        {
            Reserved,
            BoughtOut
        }
        public decimal TicketCost { get; set; }

        public int SelectSeatNumber { get; set; }

        public int Voyage { get; set; }
    }
}