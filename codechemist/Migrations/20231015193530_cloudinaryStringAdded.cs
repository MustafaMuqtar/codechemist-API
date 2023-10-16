using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codechemist.Migrations
{
    /// <inheritdoc />
    public partial class cloudinaryStringAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Technologys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Technologys");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Lessons");
        }
    }
}
