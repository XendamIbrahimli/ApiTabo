using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedWords_Words_WordId",
                table: "BannedWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
