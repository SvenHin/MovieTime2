using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.DAL
{
    public class AdminDALStub : DAL.IAdminDAL
    {
        
        public bool Admin_in_DB(Admin admin)
        {
            return true;
        }

        public List<movie> getAllMovies()
        {
            var movieList = new List<movie>();
            var movie = new movie()
            {
                id = 1,
                title = "Totoro",
                summary = "A weird looking bear that lives in the woods",
                price = 100,
                imageURL = "place/place.jpg",
                genre = "Action",
                genre2 = "Comedy"

            };
            movieList.Add(movie);
            movieList.Add(movie);
            movieList.Add(movie);
            return movieList;
        }
        public List<string> getAllMovieHeaders()
        {
            List<string> columns = new List<string>();
            columns.Add("Id");
            columns.Add("Title");
            columns.Add("Summary");
            columns.Add("Price");
            columns.Add("ImageURL");
            return columns;
        }


        public bool deleteCustomer (int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool removeMovie(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool addMovie(movie movie)
        {
            if (movie.title == "")
            {
                return false;
            }
            else
            {
                if (movie.genre != "" || movie.genre2 != "")
                {
                    return true;
                }
                return false;
            }
        }
        public bool editMovieName(int id, string changedDetail)
        {
            return true;
        }
        public bool editMovieGenre(int id, string genre1, string genre2)
        {

            return true;
        }

        public bool editMovieSummary(int id, string changedDetail)
        {
            return true;
        }
        public bool editMoviePrice(int id, int changedDetail)
        {
            return true;
        }
        public bool editMovieImageUrl(int id, string changedDetail)
        {
            return true;
        }
        public List<movie> searchMovie(string title)
        {
            var movieList = new List<movie>();
            var movie = new movie()
            {
                title = "Totoro",
                summary = "A weird looking bear that lives in the woods",
                price = 100,
                imageURL = "place/place.jpg",
                genre = "Action",
                genre2 = "Comedy",

            };
            movieList.Add(movie);
            return movieList;
        }
    }
    
}
