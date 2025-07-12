using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVideogames.Migrations
{
    /// <inheritdoc />
    public partial class ErrorCorrectionGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Videogames",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_GenreId",
                table: "Videogames",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videogames_Genres_GenreId",
                table: "Videogames",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videogames_Genres_GenreId",
                table: "Videogames");

            migrationBuilder.DropIndex(
                name: "IX_Videogames_GenreId",
                table: "Videogames");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Videogames");
        }
    }
}
