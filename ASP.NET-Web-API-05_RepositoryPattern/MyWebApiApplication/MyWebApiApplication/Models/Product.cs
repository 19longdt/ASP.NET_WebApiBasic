using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Models
{
    public class ProductVM
    {
        public string productName { get; set; }
        public double price { get; set; }

    }
    public class Product : ProductVM
    {
        public Guid productID { get; set; }

    }
}
