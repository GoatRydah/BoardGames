using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.DataAccess.Migrations
{
    public partial class GameNightId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameNightId",
                table: "GameNightAttendees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameNightAttendees_GameNightId",
                table: "GameNightAttendees",
                column: "GameNightId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameNightAttendees_GameNight_GameNightId",
                table: "GameNightAttendees",
                column: "GameNightId",
                principalTable: "GameNight",
                principalColumn: "GameNightId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameNightAttendees_GameNight_GameNightId",
                table: "GameNightAttendees");

            migrationBuilder.DropIndex(
                name: "IX_GameNightAttendees_GameNightId",
                table: "GameNightAttendees");

            migrationBuilder.DropColumn(
                name: "GameNightId",
                table: "GameNightAttendees");
        }
    }
}
