using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddOrganizationBasePermitionMapTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ORGANIZATION_BASE_PERMITION_MAP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    ROLE = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ORGANIZATION_ID = table.Column<int>(type: "int", nullable: false),
                    ORGANIZATION_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ORGANIZATION_BASE_PERMITION_MAP", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ORGANIZATION_BASE_PERMITION_MAP");
        }
    }
}
