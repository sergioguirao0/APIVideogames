using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVideogames.Migrations
{
    /// <inheritdoc />
    public partial class VideogamePlatformTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videogames_Platforms_PlatformId",
                table: "Videogames");

            migrationBuilder.DropIndex(
                name: "IX_Videogames_PlatformId",
                table: "Videogames");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Videogames");

            migrationBuilder.CreateTable(
                name: "VideogamePlatforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "integer", nullable: false),
                    VideogameId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogamePlatforms", x => new { x.PlatformId, x.VideogameId });
                    table.ForeignKey(
                        name: "FK_VideogamePlatforms_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideogamePlatforms_Videogames_VideogameId",
                        column: x => x.VideogameId,
                        principalTable: "Videogames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideogamePlatforms_VideogameId",
                table: "VideogamePlatforms",
                column: "VideogameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideogamePlatforms");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Videogames",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_PlatformId",
                table: "Videogames",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videogames_Platforms_PlatformId",
                table: "Videogames",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
