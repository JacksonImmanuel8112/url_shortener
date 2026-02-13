using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace urlshortner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatesd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_url",
                table: "url");

            migrationBuilder.RenameTable(
                name: "url",
                newName: "Urls");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Urls",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.RenameTable(
                name: "Urls",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "url",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_url",
                table: "url",
                column: "id");
        }
    }
}
