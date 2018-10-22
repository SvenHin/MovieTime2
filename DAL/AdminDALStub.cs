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
            return true;
        }

        public List<movie> getAllMovies()
        {
            return new List<movie>();
        }
        public List<string> getAllMovieHeaders()
        {
            return new List<string>();
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
            return true; //unfinished
        }
        public bool addMovie(movie movie)
        {
            return true; //unfinished
        }
        public bool editMovieName(int id, string changedDetail)
        {
            return true; //unfinished
        }
        public bool editMovieSummary(int id, string changedDetail)
        {
            return true; //unfinished
        }
        public bool editMoviePrice(int id, int changedDetail)
        {
            return true; //unfinished
        }
        public bool editMovieImageUrl(int id, string changedDetail)
        {
            return true; //unfinished
        }
        public bool editMovieGenre(int id, string genre1, string genre2)
        {
            return true; //unfinished
        }
    }
}
