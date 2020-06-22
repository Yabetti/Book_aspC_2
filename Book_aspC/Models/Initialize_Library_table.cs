using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Book_aspC.Models
{
    public class Initialize_Library_table : DropCreateDatabaseAlways<Book_aspC.Models.LibraryDBContext>
    {
        protected override void Seed(Book_aspC.Models.LibraryDBContext context)
        {
            var Libraries = new List<Library>
            {
                new Library
                {
                     ID = 1,
                     Title = "sample_book_01",
                     Publisher = "A社",
                     Price = "2000",
                     Isbn = "1"
                },

                new Library
                {
                     ID = 2,
                     Title = "sample_book_02",
                     Publisher = "B社",
                     Price = "3000",
                     Isbn = "2"
                 },

                new Library
                {
                     ID = 3,
                     Title = "sample_book_03",
                     Publisher = "C社",
                     Price = "4000",
                     Isbn = "3"
                 },
            };

            Libraries.ForEach(m => context.Libraries.Add(m));
            context.SaveChanges();
        }
    }
}