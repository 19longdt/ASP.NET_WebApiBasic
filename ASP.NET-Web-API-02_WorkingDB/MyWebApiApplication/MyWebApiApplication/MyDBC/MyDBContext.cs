using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApiApplication.DataDB;

namespace MyWebApiApplication.MyDBC
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region DBSet
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categoies { get; set; }
        #endregion
    }
}
