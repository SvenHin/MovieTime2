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

        public List<genre> getAllGenres()
        {
            List<genre> allGenres = db.Genre.Select(k => new genre()
            {
                id = k.id,
                title = k.title,
            }).ToList();
            return allGenres;
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

        public List<imageMovie> getMoviesFromGenre(int id)
        {
            var allMovies = db.Genre.Where(c => c.id == id).SelectMany(c => c.movies).ToList();
            List<imageMovie> allmovies = new List<imageMovie>();

            foreach (Movie i in allMovies)
            {
                var movie = new imageMovie()
                {
                    id = i.id,
                    imageURL = i.imageURL
                };
                allmovies.Add(movie);
            }
            return allmovies;
        }
    }
}