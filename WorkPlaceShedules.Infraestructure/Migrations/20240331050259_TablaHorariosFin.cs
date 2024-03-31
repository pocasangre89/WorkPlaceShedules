using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPlaceShedules.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class TablaHorariosFin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropColumn(
                name: "WorkPlaceId",
                table: "WorkPlaceShedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "WorkPlaceShedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkPlaceId",
                table: "WorkPlaceShedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
