using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace ConrolFamily.Migrations
{
    /// <inheritdoc />
    public partial class InitialIncomesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    IdIncome = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountIncome = table.Column<double>(type: "float", nullable: false),
                    DateIncome = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.IdIncome);
                });
          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
