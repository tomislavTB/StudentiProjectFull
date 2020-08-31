using Microsoft.EntityFrameworkCore.Migrations;

namespace PubQuiz.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeBoards_Countries_CoutryId",
                table: "NoticeBoards");

            migrationBuilder.RenameColumn(
                name: "CoutryId",
                table: "NoticeBoards",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_NoticeBoards_CoutryId",
                table: "NoticeBoards",
                newName: "IX_NoticeBoards_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeBoards_Countries_CountryId",
                table: "NoticeBoards",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeBoards_Countries_CountryId",
                table: "NoticeBoards");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "NoticeBoards",
                newName: "CoutryId");

            migrationBuilder.RenameIndex(
                name: "IX_NoticeBoards_CountryId",
                table: "NoticeBoards",
                newName: "IX_NoticeBoards_CoutryId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeBoards_Countries_CoutryId",
                table: "NoticeBoards",
                column: "CoutryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
