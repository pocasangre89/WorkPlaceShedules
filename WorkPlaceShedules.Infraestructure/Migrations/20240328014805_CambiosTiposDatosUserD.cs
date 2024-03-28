using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPlaceShedules.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CambiosTiposDatosUserD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Schedule",
                table: "WorkPlaceShedules",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "WorkPlaceShedules",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "WorkPlaces",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "WorkGroups",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Users",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Schedule",
                table: "WorkPlaceShedules",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "WorkPlaceShedules",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "WorkPlaces",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "WorkGroups",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Users",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
