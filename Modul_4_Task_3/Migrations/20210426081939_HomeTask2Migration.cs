using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Modul_4_Task_3.Migrations
{
    public partial class HomeTask2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Name", "Country", "Email", "Description" },
                values: new object[,]
                {
                    { 1, "Roga&Kopyta", "Ukraine", "1@gmai.com", "adgasdgasdf" },
                    { 2, "RMC", "Ukraine", "2@gmail.com", "afasfafasf" },
                    { 3, "3", "USA", "3@gmail.com", null },
                    { 4, "4", "USA", "4@gmail.com", "12345" },
                    { 5, "5", "USA", "5@gmail.com", "098765" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Name", "Budget", "StartedDate", "ClientId" },
                values: new object[,]
                {
                    { "Roga&Kopyta_Project", 1230000, new DateTime(2020, 8, 3, 0, 0, 0, 0), 1 },
                    { "RMC_Project", 200000, new DateTime(2020, 12, 22, 0, 0, 0, 0), 2 },
                    { "3_Project", 45000, new DateTime(2021, 8, 15, 0, 0, 0, 0), 3 },
                    { "4_Project", 10000, new DateTime(2021, 9, 3, 0, 0, 0, 0), 4 },
                    { "5_Project", 9000000, new DateTime(2023, 8, 3, 0, 0, 0, 0), 5 }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "SysAdmin" },
                    { "DevOps" },
                    { "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "Title", "Location" },
                values: new object[,]
                {
                    { "City24", "Kharkiv" },
                    { "Boombastic", "Kharkiv" },
                    { "Paladium", "Kharkiv" }
                });

            migrationBuilder.Sql(@$"INSERT INTO Employee(FirstName, LastName, HiredDate, DateOfBirth, OfficeId, TitleId) 
                                    VALUES('Mark','Zobel', '{new DateTime(2020, 8, 3, 0, 0, 0, 0).ToString("s")}', null, 
                                    (SELECT TitleId FROM Title WHERE Name = 'SysAdmin'),
                                    (SELECT OfficeId FROM Office WHERE Title = 'Paladium'))");

            migrationBuilder.Sql(@$"INSERT INTO EmployeeProject(Rate, StartedDate, EmployeeId, ProjectId) 
                                    VALUES({100000}, '{new DateTime(2021, 8, 15, 0, 0, 0, 0).ToString("s")}', 
                                    (SELECT EmployeeId FROM Employee WHERE FirstName = 'Mark' and LastName = 'Zobel'),
                                    (SELECT ProjectId FROM Project WHERE Name = 'Roga&Kopyta_Project'))");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumns: new[] { "Name", "Budget", "StartedDate" },
                keyValues: new object[,]
                {
                    { "Roga&Kopyta_Project", 1230000, new DateTime(2020, 8, 3, 0, 0, 0, 0) },
                    { "RMC_Project", 200000, new DateTime(2020, 12, 22, 0, 0, 0, 0) },
                    { "3_Project", 45000, new DateTime(2021, 8, 15, 0, 0, 0, 0) },
                    { "4_Project", 10000, new DateTime(2021, 9, 3, 0, 0, 0, 0) },
                    { "5_Project", 9000000, new DateTime(2023, 8, 3, 0, 0, 0, 0) }
                });

            migrationBuilder.DeleteData(
                table: "Title",
                keyColumns: new[] { "Name" },
                keyValues: new object[,]
                {
                    { "SysAdmin" },
                    { "DevOps" },
                    { "Manager" }
                });

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumns: new[] { "Title", "Location" },
                keyValues: new object[,]
                {
                    { "City24", "Kharkiv" },
                    { "Boombastic", "Kharkiv" },
                    { "Paladium", "Kharkiv" }
                });

            migrationBuilder.Sql(@$"DELETE FROM Employee WHERE FirstName='Mark' and
                                    LastName='Zobel' and HiredDate = '{new DateTime(2020, 8, 3, 0, 0, 0, 0)}' and
                                    DateOfBirth = null and TitleId = (SELECT TitleId FROM Title WHERE Name = 'SysAdmin') and
                                    OfficeId = (SELECT OfficeId FROM Office WHERE Title = 'Paladium'))");

            migrationBuilder.Sql(@$"DELETE FROM EmployeeProject WHERE Rate = {100000} and StartedDate = '{new DateTime(2021, 8, 15, 0, 0, 0, 0)}' and 
                                    EmployeeId = (SELECT EmployeeId FROM Employee WHERE FirstName = 'Mark' and LastName = 'Zobel') and
                                    ProjectId = (SELECT ProjectId FROM Project WHERE Name = 'Roga&Kopyta_Project'))");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
