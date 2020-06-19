using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Book_aspC.Models
{
    public class Initialize_User_table : DropCreateDatabaseAlways<Book_aspC.Models.UserDBContext>
    {
        protected override void Seed(Book_aspC.Models.UserDBContext context)
        {
            var Users = new List<User>
            {
                new User
                {
                     ID = 1,
                     Username = "testuser_01",
                     Userpassword = "testuser_01",
                     ReleaseDate = DateTime.Parse("1984-3-13"),
                     UserFlg = 1
                },

                new User
                {
                     ID = 2,
                     Username = "testuser_02",
                     Userpassword = "testuser_02",
                     ReleaseDate = DateTime.Parse("1984-3-13"),
                     UserFlg = 1
                 },

                 new User
                 {
                     ID = 3,
                     Username = "administrator_01",
                     Userpassword = "administrator_01",
                     ReleaseDate = DateTime.Parse("1984-3-13"),
                     UserFlg = 2
                 },
            };

            Users.ForEach(m => context.Users.Add(m));
            context.SaveChanges();
        }
    }
}