using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.Data.Entity.Core.EntityClient;
using System.Data.Common;

namespace MovieTime2.DAL
{
    public class DBCustomer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public virtual PostalCode PostalCode { get; set; }
        public virtual List<Order> Order { get; set; }

    }

    public class DBAdmin
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

    }

    public class PostalCode
    {
        [Key]
        public string ZipCode { get; set; }
        public string Location { get; set; }
        public virtual List<DBCustomer> DBCustomer { get; set; }
    }

    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Genre> Genre { get; set; }
        public virtual List<LineItem> LineItem { get; set; }

    }

    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Movie> Movie { get; set; }
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public virtual DBCustomer Customer { get; set; }
        public virtual List<LineItem> LineItem { get; set; }
    }

    public class LineItem
    {
        [Key]
        public int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
    public class CustomerLog
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DAL {get; set;}
        public string Method { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
    public class MovieLog
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DAL { get; set; }
        public string Method { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

    }
    public class OrderLog
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DAL { get; set; }
        public string Method { get; set; }
        public string Action { get; set; }
        public int OrderId { get; set; }
        public string LineItemId { get; set; }

    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() 
            : base("name=MovieDatabase")
        {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBInit());
        }

        public DbSet<DBCustomer> DBCustomer { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<DBAdmin> DBAdmin { get; set; }
        public DbSet<CustomerLog> CustomerLog { get; set; }
        public DbSet<MovieLog> MovieLog { get; set; }
        public DbSet<OrderLog> OrderLog { get; set; }

    }

}