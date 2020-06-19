using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Book_aspC.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Userpassword { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public int UserFlg { get; set; }

    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Book_aspC.Models.Library> Libraries { get; set; }
    }
}