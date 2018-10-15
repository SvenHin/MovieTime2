using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.DAL;
using MovieTime2.Models;

namespace MovieTime2.BLL
{
    public class SecurityBLL
    {
        public bool RegisterImplementation(Customer inCustomer)
        {
            var SecurityDAL = new SecurityDAL();
            return SecurityDAL.RegisterImplementation(inCustomer);
        }

        public bool User_in_DB(LoginCustomer User)
        {
            var SecurityDAL = new SecurityDAL();
            return SecurityDAL.User_in_DB(User);
        }

        public static byte[] CreateSalt()
        {
            var SecurityDAL = new SecurityDAL();
            return SecurityDAL.CreateSalt();
        }

        public static byte[] CreateHash(string inPassword, byte[] inSalt)
        {
            var SecurityDAL = new SecurityDAL();
            return SecurityDAL.CreateHash(inPassword, inSalt);
        }
    }
}
