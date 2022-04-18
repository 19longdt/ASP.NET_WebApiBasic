using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.DataDB
{
    public class OrderDetail
    {
        public Guid productID { get; set; }
        public Guid orderID { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public byte sale { get; set; }

        //relationship
        public Product product { get; set; }
        public Order order { get; set; }
    }
}
