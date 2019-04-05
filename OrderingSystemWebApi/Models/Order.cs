using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderingSystemWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string NameOfItem { get; set; }
        public int Quantity { get; set; }
    }
}