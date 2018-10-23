using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.DAL;
using MovieTime2.Models;


namespace MovieTime2.BLL
{
    public class OrderLogic : BLL.IOrderLogic
    {
        private IOrderDAL _orderDAL;

        public OrderLogic()
        {
            _orderDAL = new OrderDAL();
        }
        public List<ListOrder> getAllOrders()
        {
            List<ListOrder> allOrders = _orderDAL.getAllOrders();
            return allOrders;
        }


    }
}
