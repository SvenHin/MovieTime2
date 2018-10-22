using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.DAL
{
    public interface IAdminDAL
    {
        bool Admin_in_DB(Admin admin);
        List<movie> getAllMovies();
        List<string> getAllMovieHeaders();
        bool removeMovie(int id);
        bool addMovie(movie movie);
        bool editMovieName(int id, string changedDetail);
        bool editMovieSummary(int id, string changedDetail);
        bool editMoviePrice(int id, int changedDetail);
        bool editMovieImageUrl(int id, string changedDetail);
        bool editMovieGenre(int id, string genre1, string genre2);
        List<movie> searchMovie(string title);





    }
}
