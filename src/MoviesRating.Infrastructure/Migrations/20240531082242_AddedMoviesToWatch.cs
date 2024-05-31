using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoviesToWatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieToWatch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieToWatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieToWatch_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieToWatch_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieToWatch_MovieId",
                table: "MovieToWatch",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieToWatch_UserId",
                table: "MovieToWatch",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieToWatch");
        }
    }
}
