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
                FirstName = "Alex",
                LastName = "Alexov",
                Email = "alexov@gmail.com",
                Password = "alexov",
                BirthData = new DateTime(1987, 2, 1)
            });
            db.Users.Add(new User
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanov@gmail.com",
                Password = "ivanov",
                BirthData = new DateTime(2000, 2, 10)
            });
            db.Users.Add(new User
            {
                FirstName = "Admin",
                LastName = "SuperAdmin",
                Email = "admin@gmail.com",
                Password = "admin",
                BirthData = new DateTime(1980, 4, 1)
            });

            base.Seed(db);
        }
    }
}
