using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConrolFamily.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Expenses");
        }
    }
}
