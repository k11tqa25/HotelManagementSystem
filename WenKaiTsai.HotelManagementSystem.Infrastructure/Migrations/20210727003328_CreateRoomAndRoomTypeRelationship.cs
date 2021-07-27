using Microsoft.EntityFrameworkCore.Migrations;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class CreateRoomAndRoomTypeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Room_RTCODE",
                table: "Room",
                column: "RTCODE");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RTCODE",
                table: "Room",
                column: "RTCODE",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RTCODE",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RTCODE",
                table: "Room");
        }
    }
}
