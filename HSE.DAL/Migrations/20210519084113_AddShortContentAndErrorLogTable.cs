using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddShortContentAndErrorLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ERROR_LOG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: true),
                    INSTRUCTION_FORM_ID = table.Column<int>(type: "int", nullable: true),
                    ACTION_NAME = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ERROR_MESSAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ERROR_LOG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_FORM_SHORT_CONTENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_FORM_SHORT_CONTENT", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ERROR_LOG");

            migrationBuilder.DropTable(
                name: "TBL_FORM_SHORT_CONTENT");
        }
    }
}
