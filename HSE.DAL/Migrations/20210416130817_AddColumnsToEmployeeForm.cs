using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddColumnsToEmployeeForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMPLOYEE_FULL_NAME",
                table: "TBL_EMPLOYEE_FORM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMPLOYEE_POSITION",
                table: "TBL_EMPLOYEE_FORM",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMPLOYEE_FULL_NAME",
                table: "TBL_EMPLOYEE_FORM");

            migrationBuilder.DropColumn(
                name: "EMPLOYEE_POSITION",
                table: "TBL_EMPLOYEE_FORM");
        }
    }
}
