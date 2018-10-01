using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.Data.Entity.Core.EntityClient;
using System.Data.Common;

namespace MovieTime2.Models
{
    public class DBCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public virtual Post post { get; set; }
    }

    public class Post
    {
        [Key]
        public string postnr { get; set; }
        public string postlocation { get; set; }
        public virtual List<DBCustomer> DBCustomer { get; set; }
    }

    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public int price { get; set; }
        public string imageURL { get; set; }
        public virtual List<Genre> genres { get; set; }
    }

    public class Genre
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public virtual List<Movie> movies { get; set; }
    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() 
            : base("name=MovieDatabase")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<DBCustomer> DBCustomer { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }

    }

}