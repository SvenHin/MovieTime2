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
                }
                remove.LineItem.Clear();
                db.Order.Remove(remove);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                System.Diagnostics.Debug.WriteLine(fail);
                return false;
            }
        }
    }
}
