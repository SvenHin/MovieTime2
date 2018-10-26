﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.DAL;
using MovieTime2.Models;


namespace MovieTime2.BLL
{
    public class OrderLogic : BLL.IOrderLogic
    {
        private IOrderDAL _orderDAL;

        public OrderLogic()
        {
            _orderDAL = new OrderDAL();
        }
        public OrderLogic(IOrderDAL stub)
        {
            _orderDAL = stub;
        }
        public List<ListOrder> getAllOrders()
        {
            List<ListOrder> allOrders = _orderDAL.getAllOrders();
            return allOrders;
        }
        public List<ListLineItem> getLineItemsFromId(int OrderId)
        {
            List<ListLineItem> allLineItems = _orderDAL.getLineItemsFromId(OrderId);
            return allLineItems;
        }

        public bool removeOrder(int id)
        {
            bool remove = _orderDAL.removeOrder(id);
            return remove;
        }

        public bool removeLineItem(int id)
        {
            bool remove = _orderDAL.removeLineItem(id);
            return remove;
        }
        public List<ListOrder> searchOrder(int id)
        {
            List<ListOrder> search = _orderDAL.searchOrder(id);
            return search;
        }
        public bool deleteOrdersFromCustomer(int id)
        {
            bool remove = _orderDAL.deleteOrdersFromCustomer(id);
            return remove;
        }


    }
}
