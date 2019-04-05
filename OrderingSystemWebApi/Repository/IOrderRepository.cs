using OrderingSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderingSystemWebApi.Repository
{
    public interface IOrderRepository<T> where T : class
    {
        IEnumerable<Order> GetAllOrder();
        
        bool Add(T t);
        bool Update(T t);
        bool Cancle(T t);
    }

    public interface ISearchOrder
    {
        IEnumerable<Order> GetOrder(int Id);
    }

}