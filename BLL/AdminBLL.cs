using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.DAL;
using MovieTime2.Models;



namespace MovieTime2.BLL
{
    public class AdminBLL
    {
        public List<movie> getAllMovies()
        {
            var AdminDAL = new AdminDAL();
            List<movie> allMovies = AdminDAL.getAllMovies();
            return allMovies;
        }
        public bool Admin_in_DB(Admin admin)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.Admin_in_DB(admin);
        }
    }
}
