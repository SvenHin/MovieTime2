using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;
using System.Data;


namespace MovieTime2.DAL
{
    public class OrderDAL : DAL.IOrderDAL
    {
        public List<ListOrder> getAllOrders()
        {
            DatabaseContext db = new DatabaseContext();
            List<ListOrder> allOrders = db.Order.Select(k => new ListOrder()
            {
                Id = k.Id,
                Date = k.Date,
                Customer = k.Customer.Username

            }).ToList();
            return allOrders;
        }
        public List<ListLineItem> getLineItemsFromId(int OrderId)
        {
            DatabaseContext db = new DatabaseContext();
            List<ListLineItem> allLineitems = db.LineItem.Where(e => e.Order.Id == OrderId).Select(k => new ListLineItem()
            {
                Id = k.Id,
                OrderId = k.Order.Id,
                MovieTitle = k.Movie.Title

            }).ToList();
            return allLineitems;
        }
    }
}
