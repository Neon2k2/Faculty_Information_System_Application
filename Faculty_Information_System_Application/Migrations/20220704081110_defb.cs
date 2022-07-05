using Microsoft.EntityFrameworkCore.Migrations;

namespace Faculty_Information_System_Application.Migrations
{
    public partial class defb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "CourseCredits",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<short>(
                name: "CourseCredits",
                table: "Courses",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
