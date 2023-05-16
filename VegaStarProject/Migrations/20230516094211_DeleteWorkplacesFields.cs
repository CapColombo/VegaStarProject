using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegaStarProject.Migrations
{
    /// <inheritdoc />
    public partial class DeleteWorkplacesFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaces_Employees_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.AddColumn<string>(
                name: "WorkPlaceId",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkPlaceId",
                table: "Employees",
                column: "WorkPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkPlaces_WorkPlaceId",
                table: "Employees",
                column: "WorkPlaceId",
                principalTable: "WorkPlaces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkPlaces_WorkPlaceId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WorkPlaceId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkPlaceId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "WorkPlaces",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaces_Employees_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
