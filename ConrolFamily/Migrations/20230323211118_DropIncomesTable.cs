using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConrolFamily.Migrations
{
    /// <inheritdoc />
    public partial class DropIncomesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Incomes");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
