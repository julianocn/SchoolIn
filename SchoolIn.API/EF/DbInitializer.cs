using System;
using System.Linq;

namespace SchoolIn.API.EF
{
    public static class DbInitializer
    {
        public static void Initializer(SchoolInContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user
            if (context.Users.Any()) return; // DB has been seeded

            var users = new User[]{
                new EF.User(){ ID = 1, Username = "juliano_cn", Email = "juliano_cn@hotmail.com", Password = "012345" },
                new EF.User() { ID = 2, Username = "orlando_cn", Email = "orlando_cn@hotmail.com", Password = "012345" },
                new EF.User() { ID = 3, Username = "thiag_nm", Email = "thiago_nm@hotmail.com", Password = "012345" }
            };

            foreach (var user in users){
                context.Users.Add(user);
            }
            context.SaveChanges();


        }
    }
}
