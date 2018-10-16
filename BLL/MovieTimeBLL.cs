using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.DAL;
using MovieTime2.Models;

namespace MovieTime2.BLL
{
    public class MovieTimeBLL
    {
        

        public List<genre> getAllGenres()
        {
            var MovieTimeDAL = new MovieTimeDAL();
            List<genre> allGenres = MovieTimeDAL.getAllGenres();
            return allGenres;
        }

        public movie getAMovie(int Id)
        {
            var MovieTimeDAL = new MovieTimeDAL();
            return MovieTimeDAL.getAMovie(Id);
        }

        public bool newOrder(List<movie> shoppedMovies, string Username)
        {
            var MovieTimeDAL = new MovieTimeDAL();
            return MovieTimeDAL.newOrder(shoppedMovies, Username);
        }

        public bool checkIfBought(int movieId, string username)
        {
            var MovieTimeDAL = new MovieTimeDAL();
            return MovieTimeDAL.checkIfBought(movieId, username);
        }

        public List<Movie> convertMovies(List<movie> movies)
        {
            var MovieTimeDAL = new MovieTimeDAL();
            return MovieTimeDAL.convertMovies(movies);
        }

        public List<imageMovie> getMoviesFromGenre(int Id)
        {
            var MovieTimeDAL = new MovieTimeDAL();
            return MovieTimeDAL.getMoviesFromGenre(Id);
        }

        public bool isLoggedInModel(string loggedin)
        {
            var MovieTimeDAL = new MovieTimeDAL();
            return MovieTimeDAL.isLoggedInModel(loggedin);
        }

    }
}
