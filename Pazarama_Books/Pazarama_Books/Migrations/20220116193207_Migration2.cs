using Microsoft.EntityFrameworkCore.Migrations;

namespace Pazarama_Books.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Books_MoviesBookId",
                table: "BookGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre");

            migrationBuilder.DropIndex(
                name: "IX_BookGenre_MoviesBookId",
                table: "BookGenre");

            migrationBuilder.RenameColumn(
                name: "MoviesBookId",
                table: "BookGenre",
                newName: "BooksBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre",
                columns: new[] { "BooksBookId", "GenresGenreId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresGenreId",
                table: "BookGenre",
                column: "GenresGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Books_BooksBookId",
                table: "BookGenre",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Books_BooksBookId",
                table: "BookGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre");

            migrationBuilder.DropIndex(
                name: "IX_BookGenre_GenresGenreId",
                table: "BookGenre");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "BookGenre",
                newName: "MoviesBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre",
                columns: new[] { "GenresGenreId", "MoviesBookId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_MoviesBookId",
                table: "BookGenre",
                column: "MoviesBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Books_MoviesBookId",
                table: "BookGenre",
                column: "MoviesBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
