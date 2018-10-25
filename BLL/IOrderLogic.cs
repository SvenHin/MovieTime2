using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.BLL
{
    public interface IOrderLogic
    {
        List<ListOrder> getAllOrders();
        List<ListLineItem> getLineItemsFromId(int OrderId);
        bool removeOrder(int id);
        bool removeLineItem(int id);



    }
}
