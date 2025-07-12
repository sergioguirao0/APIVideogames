using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVideogames.Migrations
{
    /// <inheritdoc />
    public partial class FoundationYearCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Developers",
                newName: "FoundationYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoundationYear",
                table: "Developers",
                newName: "ReleaseYear");
        }
    }
}
