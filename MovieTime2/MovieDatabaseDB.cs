using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using MovieTime2.Models;

namespace MovieTime2
{
    public class MovieDatabaseDB
    {
        DatabaseContext db = new DatabaseContext();

        public List<movie> getAllMovies()
        {
            List<movie> allMovies = db.Movie.Select(k => new movie()
            {
                id = k.id,
                title = k.title,
                summary = k.summary,
                price = k.price,
                imageURL = k.imageURL,
            }).ToList();
            return allMovies;
        }

        public bool saveMovie()
        {
            var newMovie = new Movie
            {
                id = 1,
                title = "Lord",
                summary = "Lord of the rings summary",
                price = 150,
                imageURL = ""
            };

            try
            {
                db.Movie.Add(newMovie);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                return false;
            }
            return true;
        }
        public movie getAMovie(int id)
        {
            Movie aDBMovie = db.Movie.Find(id);

            var aMovie = new movie()
            {
                id = aDBMovie.id,
                title = aDBMovie.title,
                summary = aDBMovie.summary,
                price = aDBMovie.price,
                imageURL = aDBMovie.imageURL,
            };
            return aMovie;
        }
    }
}