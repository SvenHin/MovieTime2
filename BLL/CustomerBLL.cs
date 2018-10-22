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
    }
}
