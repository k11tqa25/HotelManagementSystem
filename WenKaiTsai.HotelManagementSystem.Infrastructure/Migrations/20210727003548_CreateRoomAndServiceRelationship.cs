using Microsoft.EntityFrameworkCore.Migrations;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class CreateRoomAndServiceRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Service_ROOMNO",
                table: "Service",
                column: "ROOMNO");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Room_ROOMNO",
                table: "Service",
                column: "ROOMNO",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Room_ROOMNO",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ROOMNO",
                table: "Service");
        }
    }
}
