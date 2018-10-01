
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

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer inCustomer)
        {
			System.Diagnostics.Debug.WriteLine("In Register!");

			if (ModelState.IsValid)
            {
                using (var db = new DatabaseContext())
                {
                    
					var newUser = new DBCustomer();
                    byte[] salt = createSalt();
                    byte[] hash = createHash(inCustomer.Password, salt);
                    newUser.Password = hash;
                    newUser.FirstName = inCustomer.FirstName;
                    newUser.LastName = inCustomer.LastName;
                    newUser.Address = inCustomer.Address;
                    newUser.PhoneNumber = inCustomer.PhoneNumber;
                    newUser.Username = inCustomer.Username;
                    newUser.Email = inCustomer.Email;
                    newUser.Salt = salt;

					PostalCode foundPost = db.PostalCodes.Find(inCustomer.ZipCode);
					if (foundPost == null)
					{
						// lag poststedet
						var newPost = new PostalCode
						{
							ZipCode = inCustomer.ZipCode,
							Location = "Oslo"
						};
						newUser.PostalCode = newPost;

					}
					try
					{
						// legg det inn i den nye kunden
						db.DBCustomer.Add(newUser);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Write("Mistake!" + ex);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private static byte[] createSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        private static byte[] createHash(string inPassword, byte[] inSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(inPassword, inSalt, 1000);
            return pbkdf2.GetBytes(keyLength);
        }


















        // GET: Login
        public ActionResult Login()
        {
            if (Session["LoggedIn"] == null)
            {
                Session["LoggedIn"] = false;
                // ViewBag.InLogged = false;
            }
            else if(Session["LoggedIn"].Equals(true))
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
                if (user_in_DB(LoggedIn))
                {
                    // Username && Password correct
                    Session["LoggedIn"] = true;
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


        //To check whether the user exists, and if so, if the credentials are correct
        public static bool user_in_DB(LoginCustomer User)
        {
            using (var db = new DatabaseContext())
            {
                DBCustomer foundUser = db.DBCustomer.FirstOrDefault(b => b.Username == User.Username);
                if (foundUser != null)
                {
                    byte[] testPassword = createHash(User.Password, foundUser.Salt);
                    bool correctUser = foundUser.Password.SequenceEqual(testPassword);
                    return correctUser;
                }
                else
                {
                    return false;
                }
            }
        }

        //Logout
        public ActionResult LogOut()
        {
            Session["LoggedIn"] = false;
            return View("Login");
        }

    }
}