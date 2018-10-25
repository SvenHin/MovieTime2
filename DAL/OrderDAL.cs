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
        public bool deleteOrdersFromCustomer(int id)
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                DBCustomer customer = db.DBCustomer.Find(id);
                foreach (var i in customer.Order)
                {
                    removeOrder(i.Id);
                }
                db.SaveChanges();
                //does not need log since method removeOrder is used in this method

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("In deleteordersfromcustomer "+ex);
                return false;
            }
        }
        public bool removeOrder(int id)
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                Order remove = db.Order.Find(id);
                var removeLineItems = db.LineItem.Where(k => k.Order.Id == id);
                foreach (var i in removeLineItems)
                {
                    db.LineItem.Remove(i);
                    LogOrderDB("removeOrder", "Remove", id, i.Id.ToString());

                }
                remove.LineItem.Clear();
                db.Order.Remove(remove);
                db.SaveChanges();
                LogOrderDB( "removeOrder", "Remove", id, " -- ");

                return true;
            }
            catch (Exception fail)
            {
                System.Diagnostics.Debug.WriteLine("In removeorder " + fail);
                return false;
            }
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
                LogOrderDB("removeOrder", "Remove", remove.Order.Id, id.ToString());
                return true;
            }
            catch (Exception fail)
            {
                System.Diagnostics.Debug.WriteLine(fail);
                return false;
            }
        }
        public List<ListOrder> searchOrder(int id)
        {
            DatabaseContext db = new DatabaseContext();
            Order foundOrder = db.Order.Find(id);
            List<ListOrder> returnOrders = new List<ListOrder>();
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
                    returnOrders.Add(returnOrder);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
            return returnOrders;
        }

        public void LogOrderDB(string method, string action, int orderid, string lineItemid)
        {
            DatabaseContext db = new DatabaseContext();
            string currentDate = DateTime.Today.ToShortDateString();
            string currentTime = DateTime.Now.ToShortTimeString();
            OrderLog log = new OrderLog()
            {
                Date = currentDate,
                Time = currentTime,
                DAL = "OrderDAL",
                Method = method,
                Action = action,
                OrderId = orderid,
                LineItemId = lineItemid
            };
            db.OrderLog.Add(log);
            db.SaveChanges();
        }

    }
}
