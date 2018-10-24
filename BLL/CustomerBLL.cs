using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.DAL;
using MovieTime2.Models;


namespace MovieTime2.BLL
{
    public class CustomerLogic : BLL.ICustomerLogic
    {
        private ICustomerDAL _customerDAL;


        public CustomerLogic()
        {
            _customerDAL = new CustomerDAL();
        }
        public CustomerLogic(ICustomerDAL stub)
        {
            _customerDAL = stub;
        }
        public List<ListCustomer> getAllCustomers()
        {
            List<ListCustomer> allCustomers = _customerDAL.getAllCustomers();
            return allCustomers;
        }

        public bool removeCustomer(int id)
        {
            bool remove = _customerDAL.removeCustomer(id);
            return remove;
        }
        public bool editFirstName(int id, string newDetail)
        {
            bool editFirstName = _customerDAL.editFirstName(id, newDetail);
            return editFirstName;
        }

        public bool editLastName(int id, string newDetail)
        {
            bool editLastName = _customerDAL.editLastName(id, newDetail);
            return editLastName;
        }
        public bool editUsername(int id, string newDetail)
        {
            bool editUsername = _customerDAL.editUsername(id, newDetail);
            return editUsername;
        }
        public bool editAddress(int id, string newDetail)
        {
            bool editAddress = _customerDAL.editAddress(id, newDetail);
            return editAddress;
        }
        public bool editEmail(int id, string newDetail)
        {
            bool editEmail = _customerDAL.editEmail(id, newDetail);
            return editEmail;
        }
        public bool editPhoneNumber(int id, string newDetail)
        {
            bool editPhoneNumber = _customerDAL.editPhoneNumber(id, newDetail);
            return editPhoneNumber;
        }
        public List<ListCustomer> searchCustomer(string username)
        {
            List<ListCustomer> customerList = _customerDAL.searchCustomer(username);
            return customerList;
        }

    }
}
