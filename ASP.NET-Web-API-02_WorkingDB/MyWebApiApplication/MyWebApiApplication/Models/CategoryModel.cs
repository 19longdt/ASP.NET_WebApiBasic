﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Models
{
    public class CategoryModel
    {
        [Required]
        [MaxLength(50)]
        public string categoryName { get; set; }
    }
}
