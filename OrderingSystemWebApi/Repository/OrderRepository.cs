using OrderingSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderingSystemWebApi.Repository
{
    public class OrderRepository : IOrderRepository<Order>, ISearchOrder
    {
        public static List<Order> orderList = new List<Order>();

        public bool Add(Order order)
        {
            orderList.Add(order);
            return true;
        }

        public bool Cancle(Order order)
        {
           // return orderList.Remove(e => e.Id == Id);
            orderList.Remove(order);
            return true;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return orderList;
        }
        public bool Update(Order order)
        {
            Order O = orderList.First(e => e.Id == order.Id);
            O.NameOfItem = order.NameOfItem;
            O.Quantity = order.Quantity;
            return true;

        }

        public IEnumerable<Order> GetOrder(int Id)
        {
            yield return orderList.FirstOrDefault(e => e.Id == Id);
        }
    }
}