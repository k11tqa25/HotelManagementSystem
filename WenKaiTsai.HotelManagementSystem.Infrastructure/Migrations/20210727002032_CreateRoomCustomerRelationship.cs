using Microsoft.EntityFrameworkCore.Migrations;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class CreateRoomCustomerRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_ROOMNO",
                table: "Customer",
                column: "ROOMNO");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Room_ROOMNO",
                table: "Customer",
                column: "ROOMNO",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Room_ROOMNO",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ROOMNO",
                table: "Customer");
        }
    }
}
