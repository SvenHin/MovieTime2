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
    }
}
