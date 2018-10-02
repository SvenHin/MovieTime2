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
        [RegularExpression(@"[A-Z][a-zA-Z][^#&<>\~;$^%{}?]{2,20}$", ErrorMessage = "Invalid First Name. No special characters allowed")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"[A-Z][a-zA-Z][^#&<>\~;$^%{}?]{2,20}$", ErrorMessage = "Invalid Last Name. No special characters allowed")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$", ErrorMessage = "Invalid Address. No special characters allowed")]
        public string Address { get; set; }

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
        [RegularExpression(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}", ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{3,9}$", ErrorMessage = "Invalid Username. No special characters allowed. Length must be between 3-10 characters")]

        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"[A-Z][a-zA-Z][^#&<>\~;$^%{}?]{2,20}$", ErrorMessage = "Invalid Last Name. No special characters allowed")]

        public string Password { get; set; }
        
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

    public class bankinfo
    {
        public int id { get; set; }
        public string cardnumber { get; set; }
        public string exdate { get; set; }
        public string cvc { get; set; }
        public string cardholdername { get; set; }
    }
}