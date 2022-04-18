using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.DataDB
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid productId { get; set; }
        [Required]
        [MaxLength(100)]
        public string productName { get; set; }
        public string description { get; set; }
        [Range(0, double.MaxValue)]
        public double price { get; set; }
        public byte sale { get; set; }

        //foreignkey
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category category { get; set; }

        public ICollection<OrderDetail> listOrderDetail { get; set; }
        public Product()
        {
            listOrderDetail = new HashSet<OrderDetail>();
        }
    }
}
