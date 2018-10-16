using MovieTime2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTime2.BLL;

namespace MovieTime2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View("Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {
            var db = new AdminBLL();

            if (ModelState.IsValid)
            {
                if (db.Admin_in_DB(admin))
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

    }
}