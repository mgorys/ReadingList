using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImgUrl", "Name" },
                values: new object[] { "https://bookishloom.files.wordpress.com/2020/04/513wb5gwt9l.jpg?w=256", "The Da Vinci Code" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImgUrl", "Name" },
                values: new object[] { "https://m.media-amazon.com/images/I/51jyI6lYi1L._AC_SY780_.jpg", "Harry Potter And the Deathly Hallows" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImgUrl", "Name" },
                values: new object[] { "http://bookcoverarchive.com/wp-content/uploads/amazon/the_girl_with_the_dragon_tattoo.jpg", "The Girl with the Dragon Tattoo" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImgUrl", "Name" },
                values: new object[] { "https://ecsmedia.pl/c/a-short-history-of-nearly-everything-w-iext121467176.jpg", "A Short History of Nearly Everything" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImgUrl", "Name" },
                values: new object[] { null, "The Girl Who Kicked the Hornets' Nest" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "First");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Second");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Third");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Fourth");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Fifth");
        }
    }
}
