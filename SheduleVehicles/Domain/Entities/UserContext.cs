using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
    }
}
