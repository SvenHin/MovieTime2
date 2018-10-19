using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.BLL
{
    public interface IAdminLogic
    {
        bool Admin_in_DB(Admin admin);
        List<movie> getAllMovies();
        List<string> getAllMovieHeaders();
        bool removeMovie(int id);
        bool addMovie(movie movie);
        bool editMovieName(int id, string changedDetail); 
    }
}
