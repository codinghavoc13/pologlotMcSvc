using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace polyglot_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class fixColumnNames202408311518 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "book",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "book",
                newName: "author_id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "book",
                newName: "book_id");

            migrationBuilder.RenameIndex(
                name: "IX_book_AuthorId",
                table: "book",
                newName: "IX_book_author_id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "author",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "author",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "author",
                newName: "author_id");

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_author_id",
                table: "book",
                column: "author_id",
                principalTable: "author",
                principalColumn: "author_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_author_id",
                table: "book");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "book",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "book",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "book",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_book_author_id",
                table: "book",
                newName: "IX_book_AuthorId");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "author",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "author",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "author",
                newName: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
