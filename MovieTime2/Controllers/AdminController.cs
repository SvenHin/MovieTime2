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

        public AdminController()
        {
            _AdminBLL = new AdminLogic();
        }
        public AdminController(IAdminLogic stub)
        {
            _AdminBLL = stub;
        }


        public ActionResult Index()
        {
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
                    Session["LoggedIn"] = "true";
                    //Sesion to store username
                    Session["Username"] = admin.Username;
                    //  ViewBag.InLogged = true;
                    return View("AdminInterface");
                }
                else
                {
                    // Username && Password wrong
                    Session["LoggedIn"] = "false";
                    // ViewBag.InLogged = false;
                    return View("LoginFailed");
                }
            }
            // Check to see if Login Credentials are OK
            return View();
        }

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

    }
}