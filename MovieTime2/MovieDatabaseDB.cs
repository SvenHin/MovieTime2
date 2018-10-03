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
            var newMovie = new Movie()
            {
                Title = "Lord",
                Summary = "Lord of the rings summary",
                Price = 150,
                ImageURL = "/Images/lotr.jpg"
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

        public void newOrder(List<Movie> shoppedMovies, string Username)
        {
            var newLineItems = new List<LineItem>();

            foreach (Movie i in shoppedMovies)
            {
                var dbMovie = db.Movie.Find(i.Id);
                var lineItem = new LineItem()
                {
                    Movie = dbMovie
                };
                newLineItems.Add(lineItem);
            }

            var newOrder = new Order()
            {
                Dato = "Today",
                LineItem = newLineItems,
            };
            
            //TODO: Create If test to check if customer already has a list of Orders, currently something is wrong
            var newOrderList = new List<Order>();
            newOrderList.Add(newOrder);


            DBCustomer Customer = db.DBCustomer.Find(7);
            Customer.Order.Add(newOrder);
            db.SaveChanges();
        }

        public void getOrders(int Id)
        {
            DBCustomer customer = db.DBCustomer.Find(Id);
            var orders = customer.Order;
            foreach(var i in orders)
            {
                System.Diagnostics.Debug.Write(Id + " OrderIDs: "+ i.Id);
                foreach (var e in i.LineItem)
                {
                    System.Diagnostics.Debug.Write(" Ordre nr " + i.Id + " LineItem " + e.Id + " inneholder dienne filmen " + e.Movie.Id);
                }
            }
        }

        public List<Movie> convertMovies(List<movie> movies)
        {
            var Movies = new List<Movie>();
            foreach(movie i in movies)
            {
                var Movie = new Movie()
                {
                    Id = i.id,
                    Title = i.title,
                    Summary = i.summary,
                    Price = i.price,
                    ImageURL = i.imageURL,
                };
                Movies.Add(Movie);
            }
            return Movies;
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