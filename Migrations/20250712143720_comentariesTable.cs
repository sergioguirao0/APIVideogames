using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVideogames.Migrations
{
    /// <inheritdoc />
    public partial class comentariesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ComentaryBody = table.Column<string>(type: "text", nullable: false),
                    PublicationData = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VideogameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentaries_Videogames_VideogameId",
                        column: x => x.VideogameId,
                        principalTable: "Videogames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentaries_VideogameId",
                table: "Comentaries",
                column: "VideogameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentaries");
        }
    }
}
