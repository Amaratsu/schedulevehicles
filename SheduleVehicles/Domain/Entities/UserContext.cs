using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain.Entities
{
    public class UserContext: DbContext
    {
        public UserContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Voyage> Voyages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

    
}
