using MovieTime2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTime2.BLL;
using System.Web.Script.Serialization;


namespace MovieTime2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        private IAdminLogic _AdminBLL;
        private ICustomerLogic _CustomerBLL;
        private IOrderLogic _OrderBLL;

        public AdminController()
        {
            _AdminBLL = new AdminLogic();
            _CustomerBLL = new CustomerLogic();
            _OrderBLL = new OrderLogic();
        }
        public AdminController(IAdminLogic stub)
        {
            _AdminBLL = stub;
        }
        public AdminController(ICustomerLogic stub)
        {
            _CustomerBLL = stub;
        }


        public ActionResult Login()
        {
            if (Session["AdminLoggedIn"] == null)
            {
                Session["AdminLoggedIn"] = "false";
            }
            else if (Session["AdminLoggedIn"].ToString().Equals("true"))
            {
                return View("AdminInterface");
            }
            else
            {
                return View("Admin"); //Trengs denne?
            }
            return View("Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {

            if (ModelState.IsValid)
            {
                if (_AdminBLL.Admin_in_DB(admin))
                {
                    // Username && Password correct
                    Session["AdminLoggedIn"] = "true";
                    //Sesion to store username
                    Session["Username"] = admin.Username;
                    //  ViewBag.InLogged = true;
                    return View("AdminInterface");
                }
                else
                {
                    // Username && Password wrong
                    Session["AdminLoggedIn"] = "false";
                    // ViewBag.InLogged = false;
                    return View("LoginFailed");
                }
            }
            // Check to see if Login Credentials are OK
            return View("Admin");
        }
        // Movie methods under
        public string getAllMovies()
        {
            List<movie> movieList = _AdminBLL.getAllMovies();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(movieList);
            return json;
        }

        public string removeMovie(int id)
        {
            bool remove = _AdminBLL.removeMovie(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(remove);
            return json;
        }

        public string addMovie(movie movie)
        {
            bool add = _AdminBLL.addMovie(movie);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(add);
            return json;
        } 

       
        public string editMovie(movie movie)
        {
            bool result;
            var jsonSerializer = new JavaScriptSerializer();
            if (movie.id.Equals(0))
            {
                result = false;
            }
            else
            {
                if (movie.title != null)
                {
                    
                    bool editName = _AdminBLL.editMovieName(movie.id, movie.title);
                }
                if (movie.summary != null)
                {
                    bool editSummary = _AdminBLL.editMovieSummary(movie.id, movie.summary);
                }
                if (!movie.price.Equals(0))
                {
                    bool editPrice = _AdminBLL.editMoviePrice(movie.id, movie.price);
                }
                if (movie.imageURL != null)
                {
                    bool editImageUrl = _AdminBLL.editMovieImageUrl(movie.id, movie.imageURL);
                }
                if (movie.genre != "" || movie.genre2 != "")
                {
                    bool editGenre = _AdminBLL.editMovieGenre(movie.id, movie.genre, movie.genre2);
                }
                result = true;
            }
            
            string json = jsonSerializer.Serialize(result);
            return json;
        }
        public string searchMovie(string title)
        {
            List<movie> foundMovie = _AdminBLL.searchMovie(title);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(foundMovie);
            return json;
        }
        //Customer methods under
        public string getAllCustomers()
        {
            List<ListCustomer> customerList = _CustomerBLL.getAllCustomers();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(customerList);
            return json;
        }
        public string editCustomer(ListCustomer customer)
        {
            bool result;
            var jsonSerializer = new JavaScriptSerializer();
            if (customer.Id.Equals(0))
            {
                result = false;
            }
            else
            {
                if (customer.Username != null)
                {
                    bool editName = _CustomerBLL.editUsername(customer.Id, customer.Username);
                }
                if (customer.FirstName != null)
                {
                    bool editFirstName = _CustomerBLL.editFirstName(customer.Id, customer.FirstName);
                }
                if (customer.LastName != null)
                {
                    bool editLastName = _CustomerBLL.editLastName(customer.Id, customer.LastName);
                }
                if (customer.Address != null)
                {
                    bool editAddress = _CustomerBLL.editAddress(customer.Id, customer.Address);
                }
                if (customer.PhoneNumber != null)
                {
                    bool editPhoneNumber = _CustomerBLL.editPhoneNumber(customer.Id, customer.PhoneNumber);
                }
                if (customer.Email != null)
                {
                    bool editEmail = _CustomerBLL.editEmail(customer.Id, customer.Email);
                }
                if (customer.ZipCode != null && customer.Location != null)
                {
                    bool editZipLocation = _CustomerBLL.editZipCodeAndLocation(customer.Id, customer.ZipCode, customer.Location);
                }
                result = true;
            }

            string json = jsonSerializer.Serialize(result);
            return json;
        }
        public string searchCustomer(string username)
        {
            List<ListCustomer> foundCustomers = _CustomerBLL.searchCustomer(username);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(foundCustomers);
            return json;
        }

        public string removeCustomer(int id)
        {
            bool removeOrder = _OrderBLL.deleteOrdersFromCustomer(id);
            bool remove = _CustomerBLL.removeCustomer(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(remove);
            return json;
        }


        //Order methods under
        public string getAllOrders()
        {
            List<ListOrder> orderList = _OrderBLL.getAllOrders();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(orderList);
            return json;
        }
        public string getAllLineItems(int id)
        {
            List<ListLineItem> lineitems = _OrderBLL.getLineItemsFromId(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(lineitems);
            return json;
        }

        public string removeOrder(int id)
        {
            Console.WriteLine("Id is" + id);
            bool remove = _OrderBLL.removeOrder(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(remove);
            return json;
        }


        public string removeLineItem(int id)
        {
            bool remove = _OrderBLL.removeLineItem(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(remove);
            return json;
        }
        public string searchOrder(int id)
        {
            List<ListOrder> search = _OrderBLL.searchOrder(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(search);
            return json;
        }
    }
}