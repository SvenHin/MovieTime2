using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieTime2.Models;
using System.Web.Script.Serialization;
using System.Web.Mvc;

namespace MovieTime2.Controllers
{
    public class AddToCartController : Controller
    {
        public ActionResult Cart()
        {
            return View();
        }
        public string Add(int Id)
        {
            var db = new MovieDatabaseDB();
            movie movie = db.getAMovie(Id);
            if (Session["cart"] == null)
            {
                List<movie> movies = new List<movie>();
                movies.Add(movie);
                Session["cart"] = movies;
                ViewBag.cart = movies.Count();
                Session["cartcount"] = 1;
            }
            else
            {
                List<movie> movies = (List<movie>)Session["cart"];
                bool containsMovie = movies.Any(i => i.id == Id);
                if (!containsMovie)
                {
                    movies.Add(movie);
                    Session["cart"] = movies;
                    ViewBag.cart = movies.Count();
                    Session["cartcount"] = Convert.ToInt32(Session["cartcount"]) + 1;
                }
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize("OK");
            return json;
        }

        public string getMoviesFromCart()
        {
            List<movie> movies = (List<movie>)Session["cart"];
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(movies);
            return json;
        }

        public ActionResult Buy()
        {
            if (Session["cart"] != null && Session["LoggedIn"] != null)
            {
                if (Session["LoggedIn"].ToString().Equals("true"))
                {
                    var db = new MovieDatabaseDB();
                    List<movie> movies = (List<movie>)Session["cart"];
                    List<Movie> Movies = db.convertMovies(movies);
                    var Username = (Session["username"]).ToString();
                    db.newOrder(Movies, Username);
                    Session["cart"] = null;
                    Session["cartcount"] = null;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Security");

                }
            }
            else
            {
                return RedirectToAction("Login", "Security");
            }
        }

        public string isLoggedIn()
        {
            var db = new MovieDatabaseDB();
            var jsonSerializer = new JavaScriptSerializer();
            if(Session["LoggedIn"] != null)
            {
                var loggedin = Session["LoggedIn"].ToString();
                if (db.isLoggedInModel(loggedin))
                {
                    return jsonSerializer.Serialize("YES");
                }
                else
                {
                    return jsonSerializer.Serialize("NO");

                }
            }
            return jsonSerializer.Serialize("NO");
        }

        public string getCartCount()
        {
            var db = new MovieDatabaseDB();
            var jsonSerializer = new JavaScriptSerializer();
            if (Session["cartcount"] != null)
            {
                var cartcount = Convert.ToInt32(Session["cartcount"]);
                return jsonSerializer.Serialize(cartcount);
            }
            else
            {
                return jsonSerializer.Serialize(0);
            }
        }

        public string RemoveFromCart(int id)
        {
            var jsonSerializer = new JavaScriptSerializer();
            if (Session["cart"] != null)
            {
                List<movie> movies = (List<movie>)Session["cart"];
                movies.RemoveAt(id);
                Session["cartcount"] = Convert.ToInt32(Session["cartcount"]) - 1;
                if (movies.Count() == 0)
                {
                    Session["cart"] = null;
                }
                else
                {
                    Session["cart"] = movies;
                }
                return jsonSerializer.Serialize("OK");

            }
            return jsonSerializer.Serialize("SessionNull");
        }

    }
}