﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                genre2 = "Comedy"


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
                genre2 = "Comedy"


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
                id = 0

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
        [TestMethod]
        public void test_searchMovie()
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

            string result = controller.searchMovie("Totoro");
            var jsonSerializer = new JavaScriptSerializer();
            string testResult = jsonSerializer.Serialize(movieList);

            Assert.AreEqual(result, testResult);

        }
        //Customer Methods Below

        [TestMethod]
        public void test_getAllCustomers()
        {
            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customerList = new List<ListCustomer>();
            var customer = new ListCustomer()
            {
                Id = 1,
                FirstName = "Gunnar",
                LastName = "Raggsson",
                Address = "Kjellandgata",
                Location = "Oslo",
                ZipCode = "1234",
                PhoneNumber = "46765643",
                Email = "Gunnar_Raggsson@gmail.com",
                Username = "Gusson"


            };
            customerList.Add(customer);
            customerList.Add(customer);
            customerList.Add(customer);


            string result = controller.getAllCustomers();
            var jsonSerializer = new JavaScriptSerializer();
            string testResult = jsonSerializer.Serialize(customerList);

            Assert.AreEqual(result, testResult);

        }

        public void test_removeCustomerF(int id) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            string result = controller.removeCustomer(0);

            Assert.AreEqual(result, "false");
        }

        public void test_removeCustomerT(int id)
        {
            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            string result = controller.removeCustomer(1);

            Assert.AreEqual(result, "true");
        }

        public void test_editFirstNameF(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                FirstName = ""
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "false");


        }

        public void test_editFirstNameT(int id, string newDetail)
        {
            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                FirstName = "Firstname"
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "true");


        }

        public void test_editLastNameF(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                LastName = ""
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "false");
        }

        public void test_editLastNameT(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                LastName = "Lastname"
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "true");
        }

        public void test_editUsernameF(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                Username = ""
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "false");
        }

        public void test_editUsernameT(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                Username = "Username123"
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "true");
        }

        public void test_editAddressF(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                Address = ""
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "false");
        }

        public void test_editAddressT(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                Address = "Testveien 43"

            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "true");
        }

        public void test_editPhoneNumberF(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                PhoneNumber = ""
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "false");
        }

        public void test_editPhoneNumberT(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                PhoneNumber = "11223344"
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "true");
        }

        public void test_editEmailF(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                Email = ""
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "false");
        }

        public void test_editEmailT(int id, string newDetail) {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            var customer = new ListCustomer()
            {
                Id = 1,
                Email = "test@test.com"
            };

            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "true");
        }

        List<ListCustomer> searchCustomer(string username) { }
        List<ListCustomer> searchCustomer(string username) { }

        /*public List<ListCustomer> getAllCustomers() {

            var customerList = new List<ListCustomer>();
            var customer = new ListCustomer()
            {
                Id = 1,
                FirstName = "Gunnar",
                LastName = "Raggsson",
                Address = "Kjellandgata",
                Location = "Oslo",
                ZipCode = "1234",
                PhoneNumber = "46765643",
                Email = "Gunnar_Raggsson@gmail.com",
                Username = "Gusson"

            };*/
    }

}
