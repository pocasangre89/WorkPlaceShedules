using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPlaceShedules.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "WorkPlaceShedules",
                newName: "UserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkPlaceShedules",
                newName: "userId");
        }
    }
}
