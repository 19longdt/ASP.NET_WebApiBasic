using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApplication.Migrations
{
    public partial class addColumnTblProdut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "Product");
        }
    }
}
