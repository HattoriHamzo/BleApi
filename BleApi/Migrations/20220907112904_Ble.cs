using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BleApi.Migrations
{
    public partial class Ble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    order_name = table.Column<string>(type: "TEXT", nullable: false),
                    order_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    order_image = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    procuct_name = table.Column<string>(type: "TEXT", nullable: false),
                    product_price = table.Column<double>(type: "REAL", nullable: false),
                    product_stock = table.Column<int>(type: "INTEGER", nullable: false),
                    product_image = table.Column<byte[]>(type: "BLOB", nullable: true),
                    provider_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    provider_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    provider_name = table.Column<string>(type: "TEXT", nullable: true),
                    provider_mail = table.Column<string>(type: "TEXT", nullable: true),
                    provider_phone = table.Column<string>(type: "TEXT", nullable: true),
                    order_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.provider_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
