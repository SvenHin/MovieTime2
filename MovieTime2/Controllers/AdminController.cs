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
                return View("Admin");
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
        public string getAllMovieHeaders()
        {
            List<string> headerList = _AdminBLL.getAllMovieHeaders();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(headerList);
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
        //Customer methods under
        public string getAllCustomers()
        {
            List<ListCustomer> customerList = _CustomerBLL.getAllCustomers();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(customerList);
            return json;
        }
        public string searchMovie(string title)
        {
            List<movie> foundMovies = _AdminBLL.searchMovie(title);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(foundMovies);
            return json;
        }

        public string removeCustomer(int id)
        {
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


    }
}