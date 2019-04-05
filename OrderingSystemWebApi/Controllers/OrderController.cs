using OrderingSystemWebApi.Models;
using OrderingSystemWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderingSystemWebApi.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderRepository<Order> _orderRepository;
        private ISearchOrder _searchOrder;

        public OrderController(IOrderRepository<Order> orderRepository, ISearchOrder searchOrder)
        {
            _orderRepository = orderRepository;
            _searchOrder = searchOrder;
        }

        [HttpGet]
        public IHttpActionResult GetAllOrder()
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, _orderRepository.GetAllOrder()));
            }
            catch (Exception e)
            {
               // _log.Error(e.ToString());
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetOrder(int id)
        {
                //var ReturnofOrderRepository = _orderRepository.Add(order);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, _searchOrder.GetOrder(id)));            
        }
        [HttpPost]
        public IHttpActionResult Add(Order order)
        {
            var NameOfItem = order.NameOfItem;
            var Quantity = order.Quantity;

            if (NameOfItem.Equals(null) || Quantity.Equals(null))
            {
                return NotFound();
            }
            else
            {
                //var ReturnofOrderRepository = _orderRepository.Add(order);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, _orderRepository.Add(order)));
            }
        }

        [HttpPost]
        public IHttpActionResult Update(Order order)
        {
            var NameOfItem = order.NameOfItem;
            var Quantity = order.Quantity;

            if (NameOfItem.Equals(null) || Quantity.Equals(null))
            {
                return NotFound();
            }
            else
            {
                //var ReturnofOrderRepository = _orderRepository.Add(order);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, _orderRepository.Update(order)));
            }
        }

        [HttpDelete]
        public IHttpActionResult Cancle(Order order)
        {
            var NameOfItem = order.NameOfItem;
            var Quantity = order.Quantity;

            if (NameOfItem.Equals(null) || Quantity.Equals(null))
            {
                return NotFound();
            }
            else
            {
                //var ReturnofOrderRepository = _orderRepository.Add(order);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, _orderRepository.Cancle(order)));
            }
        }

    }
}
