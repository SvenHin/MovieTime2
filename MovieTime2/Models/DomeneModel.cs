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
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is required")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
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