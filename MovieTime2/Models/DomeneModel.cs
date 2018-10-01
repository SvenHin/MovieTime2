using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieTime2.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCustomer
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class jsCustomer
    {
        public int id { get; set; }
        public string navn { get; set; }
    }

    public class movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public int price { get; set; }
        public string imageURL { get; set; }
        public string genre { get; set; }
    }

    public class jsMovie
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class imageMovie
    {
        public int id { get; set; }
        public string imageURL { get; set; }
    }
    public class genre
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}