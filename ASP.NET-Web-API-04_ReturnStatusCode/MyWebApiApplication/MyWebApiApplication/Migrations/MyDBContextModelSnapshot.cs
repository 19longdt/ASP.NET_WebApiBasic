﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebApiApplication.MyDBC;

namespace MyWebApiApplication.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebApiApplication.DataDB.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("categoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.Order", b =>
                {
                    b.Property<Guid>("orderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateFrom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("dateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("receiver")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("statuss")
                        .HasColumnType("int");

                    b.HasKey("orderID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.OrderDetail", b =>
                {
                    b.Property<Guid>("orderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<Guid>("orderID1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<byte>("sale")
                        .HasColumnType("tinyint");

                    b.HasKey("orderID", "productID");

                    b.HasIndex("orderID1");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.Product", b =>
                {
                    b.Property<Guid>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("sale")
                        .HasColumnType("tinyint");

                    b.HasKey("productId");

                    b.HasIndex("categoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.OrderDetail", b =>
                {
                    b.HasOne("MyWebApiApplication.DataDB.Product", "product")
                        .WithMany("listOrderDetail")
                        .HasForeignKey("orderID")
                        .HasConstraintName("FR_OrderDetail_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiApplication.DataDB.Order", "order")
                        .WithMany("listOrderDetail")
                        .HasForeignKey("orderID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.Product", b =>
                {
                    b.HasOne("MyWebApiApplication.DataDB.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.Order", b =>
                {
                    b.Navigation("listOrderDetail");
                });

            modelBuilder.Entity("MyWebApiApplication.DataDB.Product", b =>
                {
                    b.Navigation("listOrderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
