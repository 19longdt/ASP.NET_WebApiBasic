using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.DataDB
{
    public class Order
    {
        public enum status
        {
            New = 0, Payment = 1, Completed = 2, Cancel = -1
        }
        public Guid orderID { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
        public status statuss { get; set; }
        public string receiver { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public ICollection<OrderDetail> listOrderDetail { get; set; }
        public Order()
        {
            listOrderDetail = new List<OrderDetail>();
        }
    }
}
