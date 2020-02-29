using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.DataAccess.Migrations
{
    public partial class CapacityForGameNights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "GameNight",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "GameNight");
        }
    }
}
