using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTime2.Models;
using MovieTime2.BLL;
using System.Web.Script.Serialization;

namespace MovieTime2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult getAllGenresController()
        {
            var db = new MovieTimeBLL();
            List<genre> allGenres = db.getAllGenres();
            JsonResult ut = Json(allGenres, JsonRequestBehavior.AllowGet);
            return ut;
        }

        public string displayMovieInfo(int Id)
        {
            var db = new MovieTimeBLL();
            var movie = db.getAMovie(Id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(movie);
            return json;
        }

        public JsonResult getMoviesFromGenre(int id)
        {
            var db = new MovieTimeBLL();
            List<imageMovie> allMovies = db.getMoviesFromGenre(id);
            JsonResult ut = Json(allMovies, JsonRequestBehavior.AllowGet);
            return ut;

        }

        

        /*public string getAllMovieURLs()
        {
            var db = new MovieDatabaseDB();
            List<movie> allMovies = db.getAllMovies();
            var allURLs = new List<imageMovie>();
            foreach (movie k in allMovies)
            {
                var movieURL = new imageMovie();
                movieURL.id = k.id;
                movieURL.imageURL = k.imageURL;
                allURLs.Add(movieURL);
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(allURLs);
            return json;
        }*/
        public string getMovieInfo(int Id)
        {
            var db = new MovieTimeBLL();
            movie aMovie = db.getAMovie(Id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(aMovie);
            return json;
        }

        public string getIfBought(int Id)
        {
            var db = new MovieTimeBLL();
            if(Session["username"] != null)
            {
                var username = Session["username"].ToString();
                string bought = "";
                if (db.checkIfBought(Id, username))
                {
                    bought = "YES";
                }
                else
                {
                    bought = "NO";
                }
                var jsonSerializer = new JavaScriptSerializer();
                string json = jsonSerializer.Serialize(bought);
                return json;
            }
            else
            {
                var jsonSerializer = new JavaScriptSerializer();
                string json = jsonSerializer.Serialize("NO");
                return json;
            }
            
        }

        
    }
}