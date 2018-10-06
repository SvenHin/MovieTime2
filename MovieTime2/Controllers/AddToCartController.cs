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

        [HttpPost]
        public ActionResult Cart(bankinfo info)
        {
            if (Session["cart"] != null)
            {
                var db = new MovieDatabaseDB();
                List<movie> movies = (List<movie>)Session["cart"];
                List<Movie> Movies = db.convertMovies(movies);
                var Username = (Session["username"]).ToString();
                db.newOrder(Movies, Username);
                Session["cart"] = null;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}