using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Book_aspC.Models
{ 
    public class Library
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Price { get; set; }
        public string Isbn { get; set; }
    }

    public class LibraryDBContext : DbContext
    {
        public DbSet<Library> Librarys { get; set; }
    }
}