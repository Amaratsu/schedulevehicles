using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserDbInitializer: DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Users.Add(new User
            {
                UserId = 1,
                FirstName = "Alex",
                LastName = "Alexov",
                Email = "alexov@gmail.com",
                Password = "alexov",
                BirthData = new DateTime(1987, 2, 1),
                Tickets = new List<Ticket> { new Ticket {TicketId = 1, OrderId = 1, FirstNamePassenger = "alex", LastNamePassenger = "Alexeev", DocumentNumberPassenger = "112ghg212321", NumberPassenger = 2}}
            });
            db.Users.Add(new User
            {
                UserId = 2,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanov@gmail.com",
                Password = "ivanov",
                BirthData = new DateTime(2000, 2, 10),
                Tickets = new List<Ticket> { new Ticket { TicketId = 1, OrderId = 1, FirstNamePassenger = "x", LastNamePassenger = "xx", DocumentNumberPassenger = "xxxxxxx", NumberPassenger = 4 } }
            });
            db.Users.Add(new User
            {
                UserId = 3,
                FirstName = "Admin",
                LastName = "SuperAdmin",
                Email = "admin@gmail.com",
                Password = "admin",
                BirthData = new DateTime(1980, 4, 1),
                Tickets = new List<Ticket> { new Ticket { TicketId = 1, OrderId = 1, FirstNamePassenger = "y", LastNamePassenger = "yy", DocumentNumberPassenger = "yyyyyyyy", NumberPassenger = 8 } }
            });

            base.Seed(db);
        }
    }
}
