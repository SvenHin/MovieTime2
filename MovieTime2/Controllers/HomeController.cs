using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTime2.Models;
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
            var db = new MovieDatabaseDB();
            List<genre> allGenres = db.getAllGenres();
            //var jsonSerializer = new JavaScriptSerializer();
            //string json = jsonSerializer.Serialize(allGenres);
            //return json;
            JsonResult ut = Json(allGenres, JsonRequestBehavior.AllowGet);
            return ut;
        }

        public string displayMovieInfo(int Id)
        {
            System.Diagnostics.Debug.WriteLine("In movieinfo");
            var db = new MovieDatabaseDB();
            var movie = db.getAMovie(Id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(movie);
            return json;
        }

        public JsonResult getMoviesFromGenre(int id)
        {
            var db = new MovieDatabaseDB();
            List<imageMovie> allMovies = db.getMoviesFromGenre(id);
            //var jsonSerializer = new JavaScriptSerializer();
            //string json = jsonSerializer.Serialize(allMovies);
            //return json;
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
            var db = new MovieDatabaseDB();
            movie aMovie = db.getAMovie(Id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(aMovie);
            return json;
        }
    }
}