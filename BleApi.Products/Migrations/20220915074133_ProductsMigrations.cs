using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BleApi.Products.Migrations
{
    public partial class ProductsMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    product_category = table.Column<int>(type: "INTEGER", nullable: false),
                    product_name = table.Column<string>(type: "TEXT", nullable: false),
                    product_price = table.Column<double>(type: "REAL", nullable: false),
                    product_stock = table.Column<int>(type: "INTEGER", nullable: false),
                    product_image = table.Column<byte[]>(type: "BLOB", nullable: true),
                    provider_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
