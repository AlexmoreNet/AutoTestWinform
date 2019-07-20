using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Data.Migrations
{
    public partial class info3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Genres_ContextId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_ContextId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ContextId",
                table: "Musics");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Musics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_GenreId",
                table: "Musics",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Genres_GenreId",
                table: "Musics",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Genres_GenreId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_GenreId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Musics");

            migrationBuilder.AddColumn<int>(
                name: "ContextId",
                table: "Musics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ContextId",
                table: "Musics",
                column: "ContextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Genres_ContextId",
                table: "Musics",
                column: "ContextId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
