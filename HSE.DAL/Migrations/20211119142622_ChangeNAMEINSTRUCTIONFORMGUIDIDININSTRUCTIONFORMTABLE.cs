using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class ChangeNAMEINSTRUCTIONFORMGUIDIDININSTRUCTIONFORMTABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "INSTRUCTOR_USER_GUID_ID",
                table: "TBL_INSTRUCTION_FORM",
                newName: "INSTRUCTION_FORM_GUID_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "INSTRUCTION_FORM_GUID_ID",
                table: "TBL_INSTRUCTION_FORM",
                newName: "INSTRUCTOR_USER_GUID_ID");
        }
    }
}
