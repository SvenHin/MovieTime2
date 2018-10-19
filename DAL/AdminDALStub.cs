using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.DAL
{
    public class AdminDALStub : DAL.IAdminDAL
    {
        public List<Customer> getAllCustomers()
        {
            var customerList = new List<Customer>();
            var customer = new Customer()
            {
                FirstName = "Gunnar",
                LastName = "Raggsson",
                Address = "Kjellandgata",
                Location = "Oslo",
                ZipCode = "1234",
                PhoneNumber = "46765643",
                Email = "Gunnar_Raggsson@gmail.com",
                Username = "Gusson",
                Password = "Password123",

            };
            customerList.Add(customer);
            customerList.Add(customer);
            customerList.Add(customer);
            return customerList;
        }
        public bool Admin_in_DB(Admin admin)
        {
            if (admin.Username == "")
            {
                return false;
            }
            else
            {
                return true;
            }
            
           
        }

        public List<movie> getAllMovies()
        {
            var movieList = new List<movie>();
            var movie = new movie()
            {
                title = "Django",
                summary = "Once upon a time.",
                price = 100,
                imageURL = "whatever/whatever.jpg",
                genre = "Action",


            };
            movieList.Add(movie);
            movieList.Add(movie);
            movieList.Add(movie);
            return movieList;
        }


        public List<string> getAllMovieHeaders()
        {
            var headerList = new List<string>();
            headerList.Add("Id");
            headerList.Add("Title");
            headerList.Add("Summary");
            headerList.Add("Price");
            headerList.Add("ImageURL");
            return headerList;
        }


        public bool deleteCustomer (int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool removeMovie(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool addMovie(movie movie)
        {
            if(movie.title == "")
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
