using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.DataAccess.Migrations
{
    public partial class gamenights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameNight",
                columns: table => new
                {
                    GameNightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameNightDate = table.Column<DateTime>(nullable: false),
                    GameNightType = table.Column<string>(nullable: true),
                    Attendees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameNight", x => x.GameNightId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameNight");
        }
    }
}
