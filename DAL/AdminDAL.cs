using System;
using MovieTime2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using System.IO;

namespace MovieTime2.DAL
{
    public class AdminDAL : DAL.IAdminDAL
    {
        //To check whether the admin exists, and if so, if the credentials are correct
        public bool Admin_in_DB(Admin admin)
        {
            var SecurityDAL = new SecurityDAL();

            try
            {
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
            catch(Exception ex)
            {
                LogError(ex);
                return false;
            }
            
        }

        public List<movie> getAllMovies()
        {
            DatabaseContext db = new DatabaseContext();
            try
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
            catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public bool removeMovie(int id)
        {
            DatabaseContext db = new DatabaseContext();
            Movie remove = db.Movie.Find(id);

            try
            {
                var removedMovie = remove.Title;
                db.Movie.Remove(remove);
                db.SaveChanges();
                LogMovieDB(id, "removeMovie", "Remove", removedMovie, "-- Removed Movie --");

                return true;
            }
            catch (Exception ex)
            {
                LogError(ex);
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
            if (genre != null) genreList.Add(genre);
            if (genre2 != null) genreList.Add(genre2);
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
                    LogError(ex);
                    return false;
                }
            }
            return false;

        }

        public bool editMovieName(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            Movie changedMovie = db.Movie.Find(id);

            try
            {
                string title = changedMovie.Title;
                changedMovie.Title = newDetail;
                db.SaveChanges();
                LogMovieDB(id, "editMovieName", "Title", title, newDetail);
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }
        public bool editMovieSummary(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            Movie changedMovie = db.Movie.Find(id);

            try
            {
                string summmary = changedMovie.Summary;
                changedMovie.Summary = newDetail;
                db.SaveChanges();
                LogMovieDB(id, "editMovieSummary", "Summary", summmary, newDetail);
                return true;
            }
            catch (Exception ex)

            {
                LogError(ex);
                return false;
            }
        }

        public bool editMoviePrice(int id, int newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            Movie changedMovie = db.Movie.Find(id);
            try
            {
                string price = changedMovie.Price.ToString();
                changedMovie.Price = newDetail;
                db.SaveChanges();
                LogMovieDB(id, "editMovieSummary", "Price", price, newDetail.ToString());
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool editMovieImageUrl(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            Movie changedMovie = db.Movie.Find(id);
            try
            {
                string url = changedMovie.ImageURL;
                changedMovie.ImageURL = newDetail;
                db.SaveChanges();
                LogMovieDB(id, "editMovieSummary", "ImageUrl", url, newDetail);
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }
        public bool editMovieGenre(int id, string newgenre1, string newgenre2)
        {
            DatabaseContext db = new DatabaseContext();
            List<Genre> genreList = new List<Genre>();
            Movie changedMovie = db.Movie.Find(id);
            Genre foundGenre1 = db.Genre.Where(k => k.Title == newgenre1).FirstOrDefault();
            Genre foundGenre2 = db.Genre.Where(k => k.Title == newgenre2).FirstOrDefault();

            string genretitleold1 = "";
            string genretitleold2 = "";

            try
            {
                int size = changedMovie.Genre.Count();
                if(size == 2)
                {
                    if (changedMovie.Genre[0] != null) genretitleold1 = changedMovie.Genre[0].Title;
                    if (changedMovie.Genre[1] != null) genretitleold2 = changedMovie.Genre[1].Title;
                }
                else if(size == 1)
                {
                    if (changedMovie.Genre[0] != null) genretitleold1 = changedMovie.Genre[0].Title;

                }

                if (foundGenre1 != null && foundGenre2 != null)
                {
                    genreList.Add(foundGenre1);
                    genreList.Add(foundGenre2);
                    changedMovie.Genre.Clear();
                    changedMovie.Genre = genreList;
                    db.SaveChanges();
                    LogMovieDB(id, "editMovieGenre", "Genre1", genretitleold1, newgenre1);
                    LogMovieDB(id, "editMovieGenre", "Genre2", genretitleold2, newgenre2);
                    return true;
                }
                else if(foundGenre1 != null && foundGenre2 == null)
                {
                    genreList.Add(foundGenre1);
                    changedMovie.Genre.Clear();
                    changedMovie.Genre = genreList;
                    db.SaveChanges();
                    LogMovieDB(id, "editMovieGenre", "Genre1", genretitleold1, newgenre1);
                    if(genretitleold2 != "") LogMovieDB(id, "editMovieGenre", "Genre2", genretitleold2, "");
                    return true;

                }
                else if (foundGenre1 == null && foundGenre2 != null)
                {
                    genreList.Add(foundGenre2);
                    changedMovie.Genre.Clear();
                    changedMovie.Genre = genreList;
                    db.SaveChanges();
                    LogMovieDB(id, "editMovieGenre", "Genre1", genretitleold2, newgenre2);
                    if (genretitleold1 != "") LogMovieDB(id, "editMovieGenre", "Genre2", genretitleold1, "");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
            
        }

        public List<movie> searchMovie(string title)
        {
            DatabaseContext db = new DatabaseContext();
            Movie foundMovie = db.Movie.Where(k => k.Title == title).FirstOrDefault();
            List<movie> foundMovies = new List<movie>();
            try
            {
                if (foundMovie != null)
                {
                    movie returnMovie = new movie()
                    {
                        id = foundMovie.Id,
                        title = foundMovie.Title,
                        summary = foundMovie.Summary,
                        price = foundMovie.Price,
                        imageURL = foundMovie.ImageURL,
                    };
                    foundMovies.Add(returnMovie);

                }

            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
            return foundMovies;
        }
        public void LogMovieDB(int movieid, string method, string property, string original, string changes)
        {
            DatabaseContext db = new DatabaseContext();
            string currentDate = DateTime.Today.ToShortDateString();
            string currentTime = DateTime.Now.ToShortTimeString();
            MovieLog log = new MovieLog()
            {
                Date = currentDate,
                Time = currentTime,
                DAL = "AdminDAL",
                MovieId = movieid,
                Method = method,
                PropertyName = property,
                OldValue = original,
                NewValue = changes
            };
            db.MovieLog.Add(log);
            db.SaveChanges();
        }

        public void LogError(Exception ex)
        {
            //TODO all try/catches must be redirected to logError

            //Logfiles created under C:\Users\localuser\AppData\Local\Temp\CinemaCityLogs
            string temp = Path.Combine(Path.GetTempPath(), "CinemaCityLogs");
            string path = Path.Combine(temp, "logfile.txt");
            Directory.CreateDirectory(temp);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("Date: " + DateTime.Now.ToString() + Environment.NewLine + ex.ToString());
                writer.WriteLine(Environment.NewLine + "____________________________________________________________________" + Environment.NewLine);
            }
        }
    }


}


