using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApplication.Migrations
{
    public partial class addtblOrderOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateFrom = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    dateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    statuss = table.Column<int>(type: "int", nullable: false),
                    receiver = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    sale = table.Column<byte>(type: "tinyint", nullable: false),
                    orderID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.orderID, x.productID });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_orderID1",
                        column: x => x.orderID1,
                        principalTable: "Order",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FR_OrderDetail_Order",
                        column: x => x.orderID,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_orderID1",
                table: "OrderDetail",
                column: "orderID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
