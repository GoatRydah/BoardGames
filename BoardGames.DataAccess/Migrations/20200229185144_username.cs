using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.DataAccess.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "GameNightAttendees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "GameNightAttendees");
        }
    }
}
