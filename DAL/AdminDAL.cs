using System;
using MovieTime2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace MovieTime2.DAL
{
    public class AdminDAL
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
    }

}
