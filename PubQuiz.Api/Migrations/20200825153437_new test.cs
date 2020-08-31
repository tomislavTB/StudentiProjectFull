using Microsoft.EntityFrameworkCore.Migrations;

namespace PubQuiz.Migrations
{
    public partial class newtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthUserId",
                table: "Champion");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Champion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Champion");

            migrationBuilder.AddColumn<int>(
                name: "AuthUserId",
                table: "Champion",
                nullable: false,
                defaultValue: 0);
        }
    }
}
