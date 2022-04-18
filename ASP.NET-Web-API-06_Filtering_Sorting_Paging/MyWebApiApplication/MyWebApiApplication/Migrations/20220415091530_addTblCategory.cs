using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApplication.Migrations
{
    public partial class addTblCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Product_categoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Product");
        }
    }
}
