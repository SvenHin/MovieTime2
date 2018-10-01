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
                id = k.Id,
                title = k.Title,
                summary = k.Summary,
                price = k.Price,
                imageURL = k.ImageURL,
            }).ToList();
            return allMovies;
        }

        public List<genre> getAllGenres()
        {
            List<genre> allGenres = db.Genre.Select(k => new genre()
            {
                id = k.Id,
                title = k.Title,
            }).ToList();
            return allGenres;
        }

        public bool saveMovie()
        {
            var newMovie = new Movie
            {
                Id = 1,
                Title = "Lord",
                Summary = "Lord of the rings summary",
                Price = 150,
                ImageURL = ""
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
        public movie getAMovie(int Id)
        {
            Movie aDBMovie = db.Movie.Find(Id);

            var aMovie = new movie()
            {
                id = aDBMovie.Id,
                title = aDBMovie.Title,
                summary = aDBMovie.Summary,
                price = aDBMovie.Price,
                imageURL = aDBMovie.ImageURL,
            };
            return aMovie;
        }

        public List<imageMovie> getMoviesFromGenre(int Id)
        {
            var allMovies = db.Genre.Where(c => c.Id == Id).SelectMany(c => c.Movie).ToList();
            List<imageMovie> allmovies = new List<imageMovie>();

            foreach (Movie i in allMovies)
            {
                var movie = new imageMovie()
                {
                    id = i.Id,
                    imageURL = i.ImageURL
                };
                allmovies.Add(movie);
            }
            return allmovies;
        }
    }
}