using System;
using MovieTime2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;

namespace MovieTime2.DAL
{
    public class AdminDAL : DAL.IAdminDAL 
    {
        //To check whether the admin exists, and if so, if the credentials are correct
        public bool Admin_in_DB(Admin admin)
        {
            var SecurityDAL = new SecurityDAL();

            using (var db = new DatabaseContext())
            {
                DBAdmin foundAdmin = db.DBAdmin.FirstOrDefault(b => b.Username == admin.Username);
                if (foundAdmin != null)
                {
                    byte[] testPassword = SecurityDAL.CreateHash(admin.Password, foundAdmin.Salt);
                    bool correctAdmin = foundAdmin.Password.SequenceEqual(testPassword);
                    return correctAdmin;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<movie> getAllMovies()
        {
            DatabaseContext db = new DatabaseContext();
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

        public List<string> getAllMovieHeaders()
        {
            DatabaseContext db = new DatabaseContext();
            /*List<string> columnNames = db.Movie.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToList();*/
            List<string> columns = new List<string>();
            columns.Add("Id");
            columns.Add("Title");
            columns.Add("Summary");
            columns.Add("Price");
            columns.Add("ImageURL");
            return columns;
        }
        public bool removeMovie(int id)
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                Movie remove = db.Movie.Find(id);
                db.Movie.Remove(remove);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }

        public bool addMovie(movie movie)
        {
            var newMovie = new Movie()
            {
                Title = movie.title,
                Summary = movie.summary,
                Price = movie.price,
                ImageURL = movie.imageURL
            };
            DatabaseContext db = new DatabaseContext();
            List<Genre> genreList = new List<Genre>();
            Genre genre = db.Genre.Where(k => k.Title == movie.genre).FirstOrDefault();
            Genre genre2 = db.Genre.Where(k => k.Title == movie.genre2).FirstOrDefault();
            if (genre != null)genreList.Add(genre);
            if (genre2 != null)genreList.Add(genre2);
            if (genre != null || genre2 != null)
            {
                newMovie.Genre = genreList;
                try
                {
                    db.Movie.Add(newMovie);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
            
        }

      /*  public bool editMovies(int id, movie newDetails)
        {
            DatabaseContext db = new DatabaseContext();
            Movie changedMovie = db.Movie.Find(id);
            changedMovie.Title = newDetails.title;
            changedMovie.Summary = newDetails.summary;
            changedMovie.Price = newDetails.price;
            changedMovie.ImageURL = newDetails.imageURL;
            List<Genre> genreList = new List<Genre>();
            Genre genre = db.Genre.Where(k => k.Title == newDetails.genre).FirstOrDefault();
            Genre genre2 = db.Genre.Where(k => k.Title == newDetails.genre2).FirstOrDefault();
            if (genre != null) genreList.Add(genre);
            if (genre2 != null) genreList.Add(genre2);
            changedMovie.Genre = genreList;
            
   

        }*/

        public bool editMovieName(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            Movie changedMovie = db.Movie.Find(id);
            
            try
            {
                changedMovie.Title = newDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

}
