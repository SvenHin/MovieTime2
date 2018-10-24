using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieTime2.Models
{
    public class Customer
    {
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First Name is required")]
        [RegularExpression(@"[A-Z][a-zA-Z][^#&<>\~;$^%{}?]{0,20}$", ErrorMessage = "Invalid First Name. No special characters allowed")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"[A-Z][a-zA-Z][^#&<>\~;$^%{}?]{0,20}$", ErrorMessage = "Invalid Last Name. No special characters allowed")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$", ErrorMessage = "Invalid Address. Address must have 1 word and 2 numbers")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$", ErrorMessage = "Invalid City name")]
        public string Location { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "ZipCode must be 4 numbers in length")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"[0-9]{8}", ErrorMessage = "Phone Number must be 8 numbers in length")]

        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage ="Invalid Email. Follow Email format")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{2,9}$", ErrorMessage = "Invalid Username. No special characters allowed. Length must be between 3-10 characters")]

        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Invalid Password. Minumum 8 length. No special characters. 1 Capital letter, 1 small letter and 1 number is a must")]

        public string Password { get; set; }
        
    }

    public class movieCustomer
    {
        public int CustomerId;
        public int MovieId;
    }

    public class LoginCustomer
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }

    public class Admin
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
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
        public string genre2 { get; set; }
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

    public class ListCustomer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Address { get; set; }

        public string Location { get; set; }

        public string ZipCode { get; set; }
       
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

    }

    public class ListOrder
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Customer { get; set; }

    }
}