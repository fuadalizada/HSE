using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddInstructorUserGuidIdToInstructionFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "INSTRUCTOR_USER_GUID_ID",
                table: "TBL_INSTRUCTION_FORM",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INSTRUCTOR_USER_GUID_ID",
                table: "TBL_INSTRUCTION_FORM");
        }
    }
}
