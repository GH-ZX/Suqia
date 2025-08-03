using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soqia.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToTank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Tanks",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tanks");
        }
    }
}
