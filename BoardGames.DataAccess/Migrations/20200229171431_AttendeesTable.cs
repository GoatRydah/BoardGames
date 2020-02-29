using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.DataAccess.Migrations
{
    public partial class AttendeesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameNightAttendees",
                columns: table => new
                {
                    AttendeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameNightAttendees", x => x.AttendeeId);
                    table.ForeignKey(
                        name: "FK_GameNightAttendees_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameNightAttendees_Id",
                table: "GameNightAttendees",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameNightAttendees");
        }
    }
}
