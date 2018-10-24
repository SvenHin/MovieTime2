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

    }
}
