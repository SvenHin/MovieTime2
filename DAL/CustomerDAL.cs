using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;
using System.Data;



namespace MovieTime2.DAL
{
    public class CustomerDAL : DAL.ICustomerDAL
    {
        public List<ListCustomer> getAllCustomers()
        {
            DatabaseContext db = new DatabaseContext();
            List<ListCustomer> allCustomers = db.DBCustomer.Select(k => new ListCustomer()
            {
                Id = k.Id,
                FirstName = k.FirstName,
                LastName = k.LastName,
                Address = k.Address,
                Location = k.PostalCode.Location,
                ZipCode = k.ZipCode,
                PhoneNumber = k.PhoneNumber,
                Email = k.Email,
                Username = k.Username
                
            }).ToList();
            return allCustomers;
        }

        public bool removeCustomer(int id)
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                DBCustomer remove = db.DBCustomer.Find(id);
                db.DBCustomer.Remove(remove);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }

        public bool editFirstName(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);

            try
            {
                changedCustomer.FirstName = newDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool editLastName(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);

            try
            {
                changedCustomer.LastName = newDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool editUsername(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);

            try
            {
                changedCustomer.Username = newDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool editAddress(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);

            try
            {
                changedCustomer.Address = newDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool editPhoneNumber(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);

            try
            {
                changedCustomer.PhoneNumber = newDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool editEmail(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);

            try
            {
                changedCustomer.Email = newDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ListCustomer> searchCustomer(string username)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer foundCustomer = db.DBCustomer.Where(k => k.Username == username).FirstOrDefault();
            List<ListCustomer> foundCustomers = new List<ListCustomer>();

            try
            {
                if (foundCustomer != null)
                {
                    ListCustomer returnCustomer = new ListCustomer()
                    {
                        Id = foundCustomer.Id,
                        FirstName = foundCustomer.FirstName,
                        LastName = foundCustomer.LastName,
                        Address = foundCustomer.Address,
                        PhoneNumber = foundCustomer.PhoneNumber,
                        Email = foundCustomer.Email,
                        Username = foundCustomer.Username,
                        Location = foundCustomer.PostalCode.Location,
                        ZipCode = foundCustomer.ZipCode,
                    };
                    foundCustomers.Add(returnCustomer);
                }

            }
            catch (Exception ex)
            {

            }
            return foundCustomers;

        }


    }
}
