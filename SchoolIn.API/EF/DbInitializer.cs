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
                new EF.User(){ UserID = 1, Username = "juliano_cn", Email = "juliano_cn@hotmail.com", Password = "012345" },
                new EF.User() { UserID = 2, Username = "orlando_cn", Email = "orlando_cn@hotmail.com", Password = "012345" },
                new EF.User() { UserID = 3, Username = "thiag_nm", Email = "thiago_nm@hotmail.com", Password = "012345" }
            };

            foreach (var item in users){
                context.Users.Add(item);
            }
            context.SaveChanges();

            int x = 0;
            foreach (var user in context.Users)
            {
                x++;
                context.Permissions.Add(new Permission(){ PermissionID = x, UserID = user.UserID, Key = "Key" + user.UserID, Value="Value" + user.UserID  });
            }
            context.SaveChanges();

            var posts = new Post[]{
                new Post(){ PostID = 1, Title = "Post 1", Link = "https://docs.microsoft.com/en-us/aspnet/core/tutorials/", Description = "Ipsum Lorum Ipsum Lorum Ipsum Lorum Ipsum Lorum ", NumberOfRate1 = 2, NumberOfRate2 = 3, NumberOfRate3 = 20, NumberOfRate4 = 12, NumberOfRate5 = 1 },
                new Post(){ PostID = 2, Title = "Post 2", Link = "https://docs.microsoft.com/en-us/aspnet/core/tutorials/", Description = "Ipsum Lorum Ipsum Lorum Ipsum Lorum Ipsum Lorum ", NumberOfRate1 = 2, NumberOfRate2 = 3, NumberOfRate3 = 20, NumberOfRate4 = 12, NumberOfRate5 = 1 },
                new Post(){ PostID = 3, Title = "Post 3", Link = "https://docs.microsoft.com/en-us/aspnet/core/tutorials/", Description = "Ipsum Lorum Ipsum Lorum Ipsum Lorum Ipsum Lorum ", NumberOfRate1 = 2, NumberOfRate2 = 3, NumberOfRate3 = 20, NumberOfRate4 = 12, NumberOfRate5 = 1 },
                new Post(){ PostID = 4, Title = "Post 4", Link = "https://docs.microsoft.com/en-us/aspnet/core/tutorials/", Description = "Ipsum Lorum Ipsum Lorum Ipsum Lorum Ipsum Lorum ", NumberOfRate1 = 2, NumberOfRate2 = 3, NumberOfRate3 = 20, NumberOfRate4 = 12, NumberOfRate5 = 1 }
            };
            foreach (var item in posts){
                context.Posts.Add(item);
            }
            context.SaveChanges();
        }
    }
}
