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
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(o =>
            {
                o.ToTable("Order");     // Tùy chọn tên của bảng là Order (mặc định Order)
                o.HasKey(order => order.orderID);       // Thiết lập order.orderID là Pk
                o.Property(order => order.dateFrom).HasDefaultValueSql("getutcdate()");
                o.Property(order => order.receiver).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<OrderDetail>(o =>
            {
                o.ToTable("OrderDetail");       

                o.HasKey(order => new {order.orderID, order.productID });

                o.HasOne(order => order.product)
                .WithMany(product => product.listOrderDetail)       
                .HasForeignKey(order => order.productID)
                .HasConstraintName("FR_OrderDetail_Product");

                o.HasOne(order => order.product)
                .WithMany(order => order.listOrderDetail)
                .HasForeignKey(order => order.orderID)
                .HasConstraintName("FR_OrderDetail_Order");
            });

        }
    }
}
