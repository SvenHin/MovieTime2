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

        public string getAllMovieNames()
        {
            var db = new MovieDatabaseDB();
            List<movie> allMovies = db.getAllMovies();
            var allNames = new List<jsMovie>();
            foreach (movie k in allMovies)
            {
                var ettNavn = new jsMovie();
                ettNavn.id = k.id;
                ettNavn.title = k.title;
                allNames.Add(ettNavn);
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(allNames);
            return json;
        }
        public string getAllMovieURLs()
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
        }
        public string getMovieInfo(int id)
        {
            //System.Diagnostics.Debug.WriteLine(id.ToString());
            var db = new MovieDatabaseDB();
            movie aMovie = db.getAMovie(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(aMovie);
            return json;
        }
    }
}