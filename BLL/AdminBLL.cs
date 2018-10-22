using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.DAL;
using MovieTime2.Models;



namespace MovieTime2.BLL
{
    public class AdminLogic : BLL.IAdminLogic 
    {
        private IAdminDAL _adminDAL;
        public AdminLogic()
        {
            _adminDAL = new AdminDAL();
        }
        public AdminLogic(IAdminDAL stub)
        {
            _adminDAL = stub;
        }
        public List<string> getAllMovieHeaders()
        {
            List<string> columnNames = _adminDAL.getAllMovieHeaders();
            return columnNames;
        }
        public bool Admin_in_DB(Admin admin)
        {
            return _adminDAL.Admin_in_DB(admin);
        }
        public List<movie> getAllMovies()
        {
            List<movie> allMovies = _adminDAL.getAllMovies();
            return allMovies;
        }
        public bool removeMovie(int id)
        {
            bool remove = _adminDAL.removeMovie(id);
            return remove;
        }
        public bool addMovie(movie movie)
        {
            bool add = _adminDAL.addMovie(movie);
            return add;
        }
        public bool editMovieName(int id, string changedDetail)
        {
            bool editName = _adminDAL.editMovieName(id, changedDetail);
            return editName;
        }
        public bool editMovieSummary(int id, string changedDetail)
        {
            bool editSummary = _adminDAL.editMovieSummary(id, changedDetail);
            return editSummary;
        }
        public bool editMoviePrice(int id, int changedDetail)
        {
            bool editPrice = _adminDAL.editMoviePrice(id, changedDetail);
            return editPrice;
        }
        public bool editMovieImageUrl(int id, string changedDetail)
        {
            bool editUrl = _adminDAL.editMovieImageUrl(id, changedDetail);
            return editUrl;
        }
        public bool editMovieGenre(int id, string genre1, string genre2)
        {
            bool editGenre = _adminDAL.editMovieGenre(id, genre1, genre2);
            return editGenre;
        }
        public List<movie> searchMovie(string title)
        {
            List<movie> foundMovies = _adminDAL.searchMovie(title);
            return foundMovies;
        }


    }
}
