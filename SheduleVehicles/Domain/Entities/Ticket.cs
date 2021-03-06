﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PassengerFirstName { get; set; }
        [Required]
        public string PassengerLastName { get; set; }
        [Required]
        public string PassengerDocumentNumber { get; set; }
        [Required]
        public int PassengerSeatNumber { get; set; }
        public OrderStatus Status { get; set; }
        public enum OrderStatus
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
