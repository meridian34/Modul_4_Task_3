using Microsoft.EntityFrameworkCore.Migrations;

namespace Modul_4_Task_3.Migrations
{
    public partial class FixRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Office_OfficeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Title_TitleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Employee_EmployeeId",
                table: "EmployeeProject");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Project_ProjectId",
                table: "EmployeeProject");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Office_OfficeId",
                table: "Employee",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Title_TitleId",
                table: "Employee",
                column: "TitleId",
                principalTable: "Title",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Employee_EmployeeId",
                table: "EmployeeProject",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Project_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Office_OfficeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Title_TitleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Employee_EmployeeId",
                table: "EmployeeProject");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Project_ProjectId",
                table: "EmployeeProject");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Office_OfficeId",
                table: "Employee",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Title_TitleId",
                table: "Employee",
                column: "TitleId",
                principalTable: "Title",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Employee_EmployeeId",
                table: "EmployeeProject",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Project_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
