using Microsoft.EntityFrameworkCore.Migrations;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class AddPhoneColumnToCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PHONE",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PHONE",
                table: "Customer");
        }
    }
}
