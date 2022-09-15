using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BleApi.Orders.Migrations
{
    public partial class OrdersMigrations : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
