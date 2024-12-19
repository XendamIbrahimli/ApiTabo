using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabo.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatasForLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "Icon", "Name" },
                values: new object[] { "az", "https://cdn-icons-png.flaticon.com/512/330/330544.png", "Azerbaijan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "az");
        }
    }
}
