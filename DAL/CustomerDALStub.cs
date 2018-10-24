using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.DAL
{
    public class CustomerDALStub : DAL.ICustomerDAL
    {

        public List<ListCustomer> getAllCustomers() {

            var customerList = new List<ListCustomer>();
            var customer = new ListCustomer()
            {
                Id = 1,
                FirstName = "Gunnar",
                LastName = "Raggsson",
                Address = "Kjellandgata",
                Location = "Oslo",
                ZipCode = "1234",
                PhoneNumber = "46765643",
                Email = "Gunnar_Raggsson@gmail.com",
                Username = "Gusson"

            };
            customerList.Add(customer);
            customerList.Add(customer);
            customerList.Add(customer);
            return customerList;

        }
        public bool removeCustomer(int id) {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool editFirstName(int id, string newDetail) {
            return true;
        }
        public bool editLastName(int id, string newDetail) {
            return true;
        }
        public bool editUsername(int id, string newDetail) {
            return true;
        }
        public bool editAddress(int id, string newDetail) {
            return true;
        }
        public bool editPhoneNumber(int id, string newDetail) {
            return true;
        }
        public bool editEmail(int id, string newDetail) {
            return true;
        }
        public List<ListCustomer> searchCustomer(string newDetail)
        {
            return new List<ListCustomer>();//unfinished
        }
        public bool editZipCodeAndLocation(int id, string zipCode, string Location)
        {
            return true; //unfinished
        }
    }
}
