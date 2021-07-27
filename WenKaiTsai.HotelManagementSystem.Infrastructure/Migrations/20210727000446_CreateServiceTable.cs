using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class CreateServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROOMNO = table.Column<int>(type: "int", nullable: true),
                    SDESC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "money", nullable: true),
                    SERVICEDATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
