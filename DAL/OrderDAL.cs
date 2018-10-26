using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;
using System.Data;
using System.IO;

namespace MovieTime2.DAL
{
    public class OrderDAL : DAL.IOrderDAL
    {
        public List<ListOrder> getAllOrders()
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                List<ListOrder> allOrders = db.Order.Select(k => new ListOrder()
                {
                    Id = k.Id,
                    Date = k.Date,
                    Customer = k.Customer.Username

                }).ToList();
                return allOrders;
            }
            catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        public bool deleteOrdersFromCustomer(int id)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer customer = db.DBCustomer.Find(id);

            try
            {
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
                LogError(ex);
                return false;
            }
        }
        public bool removeOrder(int id)
        {
            DatabaseContext db = new DatabaseContext();
            Order remove = db.Order.Find(id);

            try
            {
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
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }
        public List<ListLineItem> getLineItemsFromId(int OrderId)
        {
            DatabaseContext db = new DatabaseContext();

            try
            {
                List<ListLineItem> allLineitems = db.LineItem.Where(e => e.Order.Id == OrderId).Select(k => new ListLineItem()
                {
                    Id = k.Id,
                    OrderId = k.Order.Id,
                    MovieTitle = k.Movie.Title

                }).ToList();
                return allLineitems;
            }
            catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        public bool removeLineItem(int id)
        {
            DatabaseContext db = new DatabaseContext();
            LineItem remove = db.LineItem.Find(id);

            try
            {
                int orderid = remove.Order.Id;
                string liid = id.ToString();
                db.LineItem.Remove(remove);
                db.SaveChanges();
                LogOrderDB("removeOrder", "Remove", orderid, liid);
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex);
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
                LogError(ex);
                return null;
            }
            return returnOrders;
        }

        private void LogOrderDB(string method, string action, int orderid, string lineItemid)
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
        private void LogError(Exception ex)
        {
            //Logfiles created under C:\Users\localuser\AppData\Local\Temp\CinemaCityLogs
            string temp = Path.Combine(Path.GetTempPath(), "CinemaCityLogs");
            string path = Path.Combine(temp, "logfile.txt");
            Directory.CreateDirectory(temp);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("Date: " + DateTime.Now.ToString() + Environment.NewLine + ex.ToString());
                writer.WriteLine(Environment.NewLine + "____________________________________________________________________" + Environment.NewLine);
            }
        }

    }
}
