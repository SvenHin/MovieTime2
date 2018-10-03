
using MovieTime2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MovieTime2.Controllers
{
    public class SecurityController : Controller
    {
        //Registration Part
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer inCustomer)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DatabaseContext())
                {
                    SecurityImplementation.RegisterImplementation(inCustomer);
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        // Login Part
        public ActionResult Login()
        {
            if (Session["LoggedIn"] == null)
            {
                Session["LoggedIn"] = false;
                // ViewBag.InLogged = false;
            }
            else if (Session["LoggedIn"].Equals(true))
            {
                // ViewBag.InLogged = (bool)Session["LoggedIn"];
                return View("UserProfile"); //This will take the logged in user to their profile page
            }
            else
            {
                return View();
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginCustomer LoggedIn)
        {
            if (ModelState.IsValid)
            {
                if (SecurityImplementation.User_in_DB(LoggedIn))
                {
                    // Username && Password correct
                    Session["LoggedIn"] = true;
                    //Sesion to store username
                    Session["Username"] = LoggedIn.Username;
                    //  ViewBag.InLogged = true;
                    return View("UserProfile"); //This will take the logged in user to their profile page
                }
                else
                {
                    // Username && Password wrong
                    Session["LoggedIn"] = false;
                    // ViewBag.InLogged = false;
                    return View("LoginFailed");
                }
            }
            // Check to see if Login Credentials are OK
            return View();
        }




        //Logout
        public ActionResult LogOut()
        {
            Session["LoggedIn"] = false;
            return View("Login");
        }

    }
}