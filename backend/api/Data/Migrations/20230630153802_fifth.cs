using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roleTypeId",
                table: "userPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userPermissions_roleTypeId",
                table: "userPermissions",
                column: "roleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_userPermissions_roleTypes_roleTypeId",
                table: "userPermissions",
                column: "roleTypeId",
                principalTable: "roleTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userPermissions_roleTypes_roleTypeId",
                table: "userPermissions");

            migrationBuilder.DropIndex(
                name: "IX_userPermissions_roleTypeId",
                table: "userPermissions");

            migrationBuilder.DropColumn(
                name: "roleTypeId",
                table: "userPermissions");
        }
    }
}
