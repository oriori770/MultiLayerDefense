using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multi_Layer_Defense.Migrations
{
    /// <inheritdoc />
    public partial class Regions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "regions",
                table: "Threat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "regions",
                table: "Threat");
        }
    }
}
