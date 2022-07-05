using Microsoft.EntityFrameworkCore.Migrations;

namespace Faculty_Information_System_Application.Migrations
{
    public partial class degu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleLookups_RoleLookupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleLookupId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleLookupId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "RoleLookupId1",
                table: "Users",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleLookupId1",
                table: "Users",
                column: "RoleLookupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleLookups_RoleLookupId1",
                table: "Users",
                column: "RoleLookupId1",
                principalTable: "RoleLookups",
                principalColumn: "RoleLookupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleLookups_RoleLookupId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleLookupId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleLookupId1",
                table: "Users");

            migrationBuilder.AlterColumn<short>(
                name: "RoleLookupId",
                table: "Users",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleLookupId",
                table: "Users",
                column: "RoleLookupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleLookups_RoleLookupId",
                table: "Users",
                column: "RoleLookupId",
                principalTable: "RoleLookups",
                principalColumn: "RoleLookupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
