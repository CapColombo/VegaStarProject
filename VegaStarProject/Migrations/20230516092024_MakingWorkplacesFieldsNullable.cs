using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegaStarProject.Migrations
{
    /// <inheritdoc />
    public partial class MakingWorkplacesFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaces_Employees_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "WorkPlaces",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ComputerNumber",
                table: "WorkPlaces",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaces_Employees_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaces_Employees_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "WorkPlaces",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComputerNumber",
                table: "WorkPlaces",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaces_Employees_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
