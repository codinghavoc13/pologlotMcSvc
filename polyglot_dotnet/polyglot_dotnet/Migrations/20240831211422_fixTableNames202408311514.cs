using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace polyglot_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class fixTableNames202408311514 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "author");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "book");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "author",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "book",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "book",
                newName: "IX_book_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_author",
                table: "author",
                column: "AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_author",
                table: "author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.RenameTable(
                name: "author",
                newName: "Author");

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Author",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_book_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
