using Microsoft.EntityFrameworkCore.Migrations;

namespace PubQuiz.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NoticeBoards_AuthUserId",
                table: "NoticeBoards",
                column: "AuthUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeBoards_AspNetUsers_AuthUserId",
                table: "NoticeBoards",
                column: "AuthUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeBoards_AspNetUsers_AuthUserId",
                table: "NoticeBoards");

            migrationBuilder.DropIndex(
                name: "IX_NoticeBoards_AuthUserId",
                table: "NoticeBoards");
        }
    }
}
