using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class InitialMigrationCreateCustomersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROOMNO = table.Column<int>(type: "int", nullable: true),
                    CNAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CHECKIN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TOTALPERSONS = table.Column<int>(type: "int", nullable: true),
                    BOOKINGDAYS = table.Column<int>(type: "int", nullable: true),
                    ADVANCE = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
