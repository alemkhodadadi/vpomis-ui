using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLte3.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerEmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Department_Employee_ManagerEmployeeID",
                        column: x => x.ManagerEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    TodoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(maxLength: 100, nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TodoType = table.Column<int>(nullable: true),
                    IsUrgent = table.Column<bool>(nullable: false),
                    TodoStatus = table.Column<int>(nullable: false),
                    HasReminder = table.Column<bool>(nullable: false),
                    ReminderTime = table.Column<DateTime>(nullable: false),
                    Teamwork = table.Column<bool>(nullable: false),
                    HasExplanation = table.Column<bool>(nullable: false),
                    Explanation = table.Column<string>(nullable: true),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.TodoID);
                    table.ForeignKey(
                        name: "FK_Todo_Department_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Department",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TodoEmployee",
                columns: table => new
                {
                    TodoID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoEmployee", x => new { x.TodoID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_TodoEmployee_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoEmployee_Todo_TodoID",
                        column: x => x.TodoID,
                        principalTable: "Todo",
                        principalColumn: "TodoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_ManagerEmployeeID",
                table: "Department",
                column: "ManagerEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TeamID",
                table: "Employee",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_TeamID",
                table: "Todo",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoEmployee_EmployeeID",
                table: "TodoEmployee",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_TeamID",
                table: "Employee",
                column: "TeamID",
                principalTable: "Department",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_ManagerEmployeeID",
                table: "Department");

            migrationBuilder.DropTable(
                name: "TodoEmployee");

            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
