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
        public bool removeLineItem(int id)
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                LineItem remove = db.LineItem.Find(id);
                db.LineItem.Remove(remove);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }
        public ListOrder searchOrder(int id)
        {
            DatabaseContext db = new DatabaseContext();
            Order foundOrder = db.Order.Find(id);

            try
            {
                if (foundOrder != null)
                {
                    ListOrder returnOrder = new ListOrder()
                    {
                        Id = foundOrder.Id,
                        Date = foundOrder.Date,
                        Customer = foundOrder.Customer.Username,
                    };
                    return returnOrder;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
            
        }

    }
}
