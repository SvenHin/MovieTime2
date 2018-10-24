using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.BLL
{
    public interface ICustomerLogic
    {
        List<ListCustomer> getAllCustomers();
        bool removeCustomer(int id);
        bool editFirstName(int id, string newDetail);
        bool editLastName(int id, string newDetail);
        bool editUsername(int id, string newDetail);
        bool editAddress(int id, string newDetail);
        bool editPhoneNumber(int id, string newDetail);
        bool editEmail(int id, string newDetail);
        List<ListCustomer> searchCustomer(string username);
        bool editZipCodeAndLocation(int id, string newZip, string Location);


    }
}
