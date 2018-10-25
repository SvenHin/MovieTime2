using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;


namespace MovieTime2.DAL
{
    public class OrderDALStub : DAL.IOrderDAL
    {
        public List<ListOrder> getAllOrders()
        {
            var orderList = new List<ListOrder>();
            var order = new ListOrder()
            {
                Id = 1,
                Date = "24.12.2018",
                Customer = "Trond"
            };
            orderList.Add(order);
            orderList.Add(order);
            orderList.Add(order);
            return orderList;
        }
        public List<ListLineItem> getLineItemsFromId(int OrderId)
        {
            return new List<ListLineItem>(); //unfinished
        }
        public bool removeLineItem(int id)
        {
            return true; //unfinished
        }

    }
}
