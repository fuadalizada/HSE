using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddInstructiondateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstructionDate",
                table: "TBL_INSTRUCTION_FORM",
                newName: "INSTRUCTION_DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "INSTRUCTION_DATE",
                table: "TBL_INSTRUCTION_FORM",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "INSTRUCTION_DATE",
                table: "TBL_INSTRUCTION_FORM",
                newName: "InstructionDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InstructionDate",
                table: "TBL_INSTRUCTION_FORM",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
