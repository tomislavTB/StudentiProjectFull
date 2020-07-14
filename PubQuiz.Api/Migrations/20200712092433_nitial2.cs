using Microsoft.EntityFrameworkCore.Migrations;

namespace PubQuiz.Migrations
{
    public partial class nitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthUserId",
                table: "Champion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthUserId",
                table: "Champion");
        }
    }
}
