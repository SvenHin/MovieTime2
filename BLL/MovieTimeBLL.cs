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
        public List<movie> getAllMovies()
        {
            var MovieTimeDAL = new MovieTimeDAL();
            List<movie> allMovies = MovieTimeDAL.getAllMovies();
            return allMovies;
        }

    }
}
