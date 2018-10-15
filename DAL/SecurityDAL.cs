using MovieTime2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MovieTime2.DAL
{
    public class SecurityDAL
    {
        
        public static DBCustomer RegisterImplementation(Customer inCustomer)
        {
            DatabaseContext db = new DatabaseContext();
            var newUser = new DBCustomer();
            byte[] salt = CreateSalt();
            byte[] hash = CreateHash(inCustomer.Password, salt);
            newUser.Password = hash;
            newUser.FirstName = inCustomer.FirstName;
            newUser.LastName = inCustomer.LastName;
            newUser.Address = inCustomer.Address;
            newUser.PhoneNumber = inCustomer.PhoneNumber;
            newUser.Username = inCustomer.Username;
            newUser.Email = inCustomer.Email;
            newUser.Salt = salt;

            PostalCode foundPost = db.PostalCodes.Find(inCustomer.ZipCode);
            if (foundPost == null)
            {
                // Create PostLocation
                var newPost = new PostalCode
                {
                    ZipCode = inCustomer.ZipCode,
                    Location = inCustomer.Location
                };
                newUser.PostalCode = newPost;
            }
            else
            {
                newUser.PostalCode = foundPost;
            }
            try
            {
                // Add it to the new customer
                db.DBCustomer.Add(newUser);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception!" + ex);
            }
            return newUser;
        }

        //To check whether the user exists, and if so, if the credentials are correct
        public static bool User_in_DB(LoginCustomer User)
        {
            using (var db = new DatabaseContext())
            {
                DBCustomer foundUser = db.DBCustomer.FirstOrDefault(b => b.Username == User.Username);
                if (foundUser != null)
                {
                    byte[] testPassword = CreateHash(User.Password, foundUser.Salt);
                    bool correctUser = foundUser.Password.SequenceEqual(testPassword);
                    return correctUser;
                }
                else
                {
                    return false;
                }
            }
        }

        private static byte[] CreateSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        private static byte[] CreateHash(string inPassword, byte[] inSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(inPassword, inSalt, 1000);
            return pbkdf2.GetBytes(keyLength);
        }
    }
}