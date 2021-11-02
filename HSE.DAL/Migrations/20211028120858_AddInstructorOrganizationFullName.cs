using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddInstructorOrganizationFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "INSTRUCTOR_ORGANIZATION_FULL_NAME",
                table: "TBL_INSTRUCTION_FORM",
                type: "nvarchar(240)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INSTRUCTOR_ORGANIZATION_FULL_NAME",
                table: "TBL_INSTRUCTION_FORM");
        }
    }
}
