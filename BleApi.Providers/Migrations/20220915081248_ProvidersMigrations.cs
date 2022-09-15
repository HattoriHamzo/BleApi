using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BleApi.Providers.Migrations
{
    public partial class ProvidersMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Providers");
        }
    }
}
