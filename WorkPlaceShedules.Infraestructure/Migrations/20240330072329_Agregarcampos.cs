using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPlaceShedules.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregarcampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceShedules_Users_UsersEntityPUserId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceShedules_WorkGroups_WorkGroupPGroupId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceShedules_WorkPlaces_WorkPlacesPWorkPlaceId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropIndex(
                name: "IX_WorkPlaceShedules_UsersEntityPUserId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropIndex(
                name: "IX_WorkPlaceShedules_WorkGroupPGroupId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropIndex(
                name: "IX_WorkPlaceShedules_WorkPlacesPWorkPlaceId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropColumn(
                name: "UsersEntityPUserId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropColumn(
                name: "WorkGroupPGroupId",
                table: "WorkPlaceShedules");

            migrationBuilder.DropColumn(
                name: "WorkPlacesPWorkPlaceId",
                table: "WorkPlaceShedules");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UsersEntityPUserId",
                table: "WorkPlaceShedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkGroupPGroupId",
                table: "WorkPlaceShedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkPlacesPWorkPlaceId",
                table: "WorkPlaceShedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaceShedules_UsersEntityPUserId",
                table: "WorkPlaceShedules",
                column: "UsersEntityPUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaceShedules_WorkGroupPGroupId",
                table: "WorkPlaceShedules",
                column: "WorkGroupPGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaceShedules_WorkPlacesPWorkPlaceId",
                table: "WorkPlaceShedules",
                column: "WorkPlacesPWorkPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceShedules_Users_UsersEntityPUserId",
                table: "WorkPlaceShedules",
                column: "UsersEntityPUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceShedules_WorkGroups_WorkGroupPGroupId",
                table: "WorkPlaceShedules",
                column: "WorkGroupPGroupId",
                principalTable: "WorkGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceShedules_WorkPlaces_WorkPlacesPWorkPlaceId",
                table: "WorkPlaceShedules",
                column: "WorkPlacesPWorkPlaceId",
                principalTable: "WorkPlaces",
                principalColumn: "WorkPlaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
