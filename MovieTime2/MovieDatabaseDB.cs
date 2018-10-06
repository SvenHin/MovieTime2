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

            DateTime currentDate = DateTime.Today;
            var currentDateString = currentDate.ToShortDateString();

            var newOrder = new Order()
            {
                Dato = currentDateString,
                LineItem = newLineItems,
            };
            
            DBCustomer Customer = db.DBCustomer.Where(k => k.Username == Username).FirstOrDefault();

            if (Customer.Order.Equals(null))
            {
                var newOrderList = new List<Order>();
                newOrderList.Add(newOrder);
                Customer.Order = newOrderList;
            }
            else
            {
                Customer.Order.Add(newOrder);
            }
            try {
                db.SaveChanges();
            }
            catch ( Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception!" + ex);
            }
        }

        public bool checkIfBought(int movieId, string username)
        {
            IQueryable<movieCustomer> aMovieCustomer = db.Order.Join(db.LineItem,
                            o => o.Id,
                            li => li.Order.Id,
                            (o, li) => new movieCustomer
                            {
                                CustomerId = o.Customer.Id,
                                MovieId = li.Movie.Id
                            })
                            .Where(x => x.MovieId == movieId);

  


            DBCustomer Customer = db.DBCustomer.Where(k => k.Username == username).FirstOrDefault();

            foreach(var i in aMovieCustomer)
            {
                //System.Diagnostics.Debug.Write(" CustomerID: " + i.CustomerId + " MovieID: " + i.MovieId);

                if (i.CustomerId.Equals(Customer.Id))
                {
                    return true;
                }
            }
            return false;
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

        public bool isLoggedInModel(string loggedin)
        {
            if (loggedin.Equals("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}