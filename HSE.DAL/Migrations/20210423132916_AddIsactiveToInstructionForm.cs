using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddIsactiveToInstructionForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "TBL_INSTRUCTION_FORM",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "TBL_EMPLOYEE_FORM",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "TBL_INSTRUCTION_FORM");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "TBL_EMPLOYEE_FORM",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");
        }
    }
}
