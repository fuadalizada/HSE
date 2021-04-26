using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddInstructionTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "INSTRUCTION_TYPE_NAME",
                table: "TBL_INSTRUCTION_FORM",
                type: "nvarchar(150)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INSTRUCTION_TYPE_NAME",
                table: "TBL_INSTRUCTION_FORM");
        }
    }
}
