using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;

namespace MovieTime2.DAL
{
    public interface IOrderDAL
    {
        List<ListOrder> getAllOrders();

    }
}
