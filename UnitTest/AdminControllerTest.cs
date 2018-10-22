using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.BLL;
using MovieTime2.DAL;
using MovieTime2.Controllers;
using MovieTime2.Models;
using System.Web.Script.Serialization;

namespace MovieTime2.UnitTest
{
    [TestClass]
    public class AdminControllerTest
    {
     /*   [TestMethod]
        public void List_Show_view()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var expectedResult = new List<Customer>();
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
            expectedResult.Add(customer);
            expectedResult.Add(customer);
            expectedResult.Add(customer);

            var actionResult = (ViewResult)controller.getAllCustomers();
            var 
        }*/

        [TestMethod]
        public void show_getAllMovies()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

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


            List<movie> JmovieList = _AdminBLL.getAllMovies();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(movieList);
            
        }
    }

}
