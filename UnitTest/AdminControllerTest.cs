using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
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
        public void test_getAllMovies()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movieList = new List<movie>();
            var movie = new movie()
            {
                title = "Totoro",
                summary = "A weird looking bear that lives in the woods",
                price = 100,
                imageURL = "place/place.jpg",
                genre = "Action",
                genre2 = "Comedy",


            };
            movieList.Add(movie);
            movieList.Add(movie);
            movieList.Add(movie);


            string result = controller.getAllMovies();
            var jsonSerializer = new JavaScriptSerializer();
            string testResult = jsonSerializer.Serialize(movieList);

            Assert.AreEqual(result, testResult);
            
        }

        [TestMethod]
        public void test_removeMovieF()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            string result = controller.removeMovie(0);

            Assert.AreEqual(result, "false");
        }
        [TestMethod]
        public void test_removeMovieT()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            string result = controller.removeMovie(1);

            Assert.AreEqual(result, "true");
        }
        [TestMethod]
        public void test_addMovieF()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                title = ""
            };
            
            string result = controller.addMovie(movie);

            Assert.AreEqual(result,"false");

        }
        [TestMethod]
        public void test_addMovieT()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                title = "Totoro",
                summary = "A weird looking bear that lives in the woods",
                price = 100,
                imageURL = "place/place.jpg",
                genre = "Action",
                genre2 = "Comedy",


            };

            string result = controller.addMovie(movie);

            Assert.AreEqual(result,"true");

        }
        [TestMethod]
        public void test_addMovieF2()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                genre = "",
                genre2 = "",
            };

            string result = controller.addMovie(movie);

            Assert.AreEqual(result,"false");

        }
        [TestMethod]
        public void test_editMovieT()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
               genre = "",
               genre2= ""
            };
            

            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }
        [TestMethod]
        public void test_editMovieF()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 0,

            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "false");

        }
        [TestMethod]
        public void test_editMovieTgenre()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
                genre = "Action",
                genre2 = "Comedy"
            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }
        [TestMethod]
        public void test_editMovieTgenre2()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
                genre = "Action",
                genre2 = ""
            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }
        [TestMethod]
        public void test_editMovieTgenre3()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
                genre = "",
                genre2 = "Comedy"
            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }
        [TestMethod]
        public void test_editMovieTTitle()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
                title = "Something"
            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }
        [TestMethod]
        public void test_editMovieTSummary()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
                summary = "something something"
            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }
        [TestMethod]
        public void test_editMovieTPrice()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
                price = 100
            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }
        [TestMethod]
        public void test_editMovieTImageURL()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movie = new movie()
            {
                id = 1,
                imageURL = "sdfghjkl"
            };


            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "true");

        }


    }

}
