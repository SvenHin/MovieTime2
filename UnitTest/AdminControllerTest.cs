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
using MvcContrib.TestHelper;

namespace MovieTime2.UnitTest
{
    [TestClass]
    public class AdminControllerTest
    {

        [TestMethod]
        public void test_adminLogin()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController();
            SessionMock.InitializeController(controller);
            controller.Session["AdminLoggedIn"] = null;

            var result = (ViewResult)controller.Login();

            Assert.AreEqual(result.ViewName, "Admin");
        }
        [TestMethod]
        public void test_adminLogin2()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController();
            SessionMock.InitializeController(controller);
            controller.Session["AdminLoggedIn"] = "true";

            var result = (ViewResult)controller.Login();

            Assert.AreEqual(result.ViewName, "AdminInterface");
        }
        [TestMethod]
        public void test_adminLogin3()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var admin = new Admin()
            {
                Username = "Admin",
                Password = "Admin123"
            };

            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["AdminLoggedIn"] = "true";
            controller.Session["Username"] = admin.Username;

            var result = (ViewResult)controller.Login(admin);

            Assert.AreEqual(result.ViewName, "AdminInterface");



        }
        [TestMethod]
        public void test_adminLogin4()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var admin = new Admin()
            {

            };

            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["AdminLoggedIn"] = "false";

            var result = (ViewResult)controller.Login(admin);

            Assert.AreEqual(result.ViewName, "LoginFailed");



        }


        [TestMethod]
        public void test_getAllMovies()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));

            var movieList = new List<movie>();
            var movie = new movie()
            {
                id = 1,
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
        public void test_editMovieNoiID()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));
            var movie = new movie()
            {
                id = 0,
                title = "Totoro",
                summary = "eowkgnåweg",
                price = 123,
                imageURL = "sdfghjklø",
                genre = "Action",
                genre2 = "Comedy"
            };

            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "[-1,-1,-1,-1,-1]");


        }
        [TestMethod]
        public void test_editMovieWithiID()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));
            var movie = new movie()
            {
                id = 1,
                title = "Totoro",
                summary = "eowkgnåweg",
                price = 123,
                imageURL = "sdfghjklø",
                genre = "Action",
                genre2 = "Comedy"
            };

            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "[1,1,1,1,1]");


        }
        [TestMethod]
        public void test_editMovieWithIDNoInput()
        {
            var controller = new AdminController(new AdminLogic(new AdminDALStub()));
            var movie = new movie()
            {
                id = 1,

            };

            string result = controller.editMovie(movie);

            Assert.AreEqual(result, "[0,0,0,0,0]");


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
        public void test_editCustomerNoiID()
        {
            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));
            var customer = new ListCustomer()
            {
                Id = 0,
                FirstName = "Gunnar",
                LastName = "Raggsson",
                Address = "Kjellandgata",
                Location = "Oslo",
                ZipCode = "1234",
                PhoneNumber = "46765643",
                Email = "Gunnar_Raggsson@gmail.com",
                Username = "Gusson"
            };
            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "[-1,-1,-1,-1,-1,-1,-1]");

        }
        [TestMethod]
        public void test_editCustomerWithiID()
        {
            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));
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
            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "[1,1,1,1,1,1,1]");

        }
        [TestMethod]
        public void test_editCustomerWithIDINoInput()
        {
            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));
            var customer = new ListCustomer()
            {
                Id = 1,
               
            };
            string result = controller.editCustomer(customer);

            Assert.AreEqual(result, "[0,0,0,0,0,0,0]");

        }

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
        [TestMethod]
        public void test_removeCustomerF()
        {

            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            string result = controller.removeCustomer(0);

            Assert.AreEqual(result, "false");
        }
        [TestMethod]
        public void test_removeCustomerT()
        {
            var controller = new AdminController(new CustomerLogic(new CustomerDALStub()));

            string result = controller.removeCustomer(1);

            Assert.AreEqual(result, "true");
        }



        [TestMethod]
        public void test_searchCustomer()
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

            string result = controller.searchCustomer("Gunnar");
            var jsonSerializer = new JavaScriptSerializer();
            string testResult = jsonSerializer.Serialize(customerList);

            Assert.AreEqual(result, testResult);

        }

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

