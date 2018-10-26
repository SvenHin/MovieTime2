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
            if (OrderId == 1)
            {
                var lineList = new List<ListLineItem>();
                var lineItem = new ListLineItem()
                {
                    Id = 1,
                    OrderId = 1,
                    MovieTitle = "Totoro"
                };
                lineList.Add(lineItem);
                lineList.Add(lineItem);
                lineList.Add(lineItem);
                return lineList;
            }
            return null;
        }
        public bool removeLineItem(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool removeOrder(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<ListOrder> searchOrder(int id)
        {
            if (id == 1) { 
            var orderList = new List<ListOrder>();
            var order = new ListOrder()
            {
                Id = 1,
                Date = "24.12.2018",
                Customer = "Trond"

            };
            orderList.Add(order);
            return orderList;
        }
            return null;
        }

        public bool deleteOrdersFromCustomer(int id)
        {
            return true; //unfinished
        }

    }
}
