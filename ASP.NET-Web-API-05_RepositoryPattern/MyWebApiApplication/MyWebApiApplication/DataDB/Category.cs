using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.DataDB
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string categoryName { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
