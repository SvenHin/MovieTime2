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
    }

}
