using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soqia.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToTank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tanks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tanks");
        }
    }
}
