using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_HeadDepartmentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartment_Departments_DepartmentId",
                table: "EmployeeDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartment_Employees_EmployeeId",
                table: "EmployeeDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HeadDepartmentId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartment",
                table: "EmployeeDepartment");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "EmployeeDepartment",
                newName: "EmployeeDepartments");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDepartment_EmployeeId",
                table: "EmployeeDepartments",
                newName: "IX_EmployeeDepartments_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDepartment_DepartmentId",
                table: "EmployeeDepartments",
                newName: "IX_EmployeeDepartments_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartments",
                table: "EmployeeDepartments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HeadDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    HeadDepartmentId = table.Column<int>(type: "integer", nullable: true),
                    ManagerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadDepartments_Departments_HeadDepartmentId",
                        column: x => x.HeadDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadDepartments_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeadDepartments_DepartmentId",
                table: "HeadDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadDepartments_HeadDepartmentId",
                table: "HeadDepartments",
                column: "HeadDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadDepartments_ManagerId",
                table: "HeadDepartments",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Departments_DepartmentId",
                table: "EmployeeDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Employees_EmployeeId",
                table: "EmployeeDepartments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Departments_DepartmentId",
                table: "EmployeeDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Employees_EmployeeId",
                table: "EmployeeDepartments");

            migrationBuilder.DropTable(
                name: "HeadDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartments",
                table: "EmployeeDepartments");

            migrationBuilder.RenameTable(
                name: "EmployeeDepartments",
                newName: "EmployeeDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDepartments_EmployeeId",
                table: "EmployeeDepartment",
                newName: "IX_EmployeeDepartment_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDepartments_DepartmentId",
                table: "EmployeeDepartment",
                newName: "IX_EmployeeDepartment_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentId",
                table: "Departments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Departments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartment",
                table: "EmployeeDepartment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadDepartmentId",
                table: "Departments",
                column: "HeadDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_HeadDepartmentId",
                table: "Departments",
                column: "HeadDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartment_Departments_DepartmentId",
                table: "EmployeeDepartment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartment_Employees_EmployeeId",
                table: "EmployeeDepartment",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
