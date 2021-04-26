using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ACCESS_DENIED_LOG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: true),
                    REMOTE_IP_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BROWSER_INFO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERER_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ACCESS_DENIED_LOG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_EMPLOYEE",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    CURRENT_EMPLOYEE_FLAG = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    NATIONAL_IDENTIFIER = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EMAIL_ADDRESS = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    FULL_NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    PATRONYMIC = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    GENDER = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    POSITION_ID = table.Column<int>(type: "int", nullable: true),
                    ORGANIZATION_ID = table.Column<int>(type: "int", nullable: true),
                    ORGANIZATION_FULL_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    ORGANIZATION_SHORT_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    JOB_ID = table.Column<int>(type: "int", nullable: true),
                    JOB_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    MOBILE_PHONE_NUMBER = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    JOB_CATEGORY_CODE = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    JOB_CATEGORY_NAME = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    JOB_SUBCATEGORY_CODE = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    JOB_SUBCATEGORY_NAME = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    CHILD_ORG_IND_MGR_POS_PER_ID = table.Column<int>(type: "int", nullable: true),
                    ORG_CURATOR_PERSON_ID = table.Column<int>(type: "int", nullable: true),
                    ORG_STR_DEDUCTED_MGR_PERSON_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_ORG_IND_MGR_POS_PER_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_ORG_IND_MGR_POSITION_ID = table.Column<int>(type: "int", nullable: true),
                    PERSON_IS_CURATOR_FLAG = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    PERSON_IS_ENTERPRISE_MGR_FLAG = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    ENTERPRISE_MANAGER_PERSON_ID = table.Column<int>(type: "int", nullable: true),
                    ENTERPRISE_MANAGER_POSITION_ID = table.Column<int>(type: "int", nullable: true),
                    POS_ORG_MGR_POSITION_FLAG = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    L3_PARENT_ORGANIZATION_ID = table.Column<int>(type: "int", nullable: true),
                    WORK_PHONE_NUMBER = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TBL_INSTRUCTION_FORM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSTRUCTOR_USER_ID = table.Column<int>(type: "int", nullable: false),
                    INSTRUCTOR_ORGANIZATION_ID = table.Column<int>(type: "int", nullable: false),
                    INSTRUCTOR_FULL_NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    INSTRUCTOR_POSITION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INSTRUCTOR_SHORT_CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    INSTRUCTION_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_INSTRUCTION_FORM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_INSTRUCTION_TYPE",
                columns: table => new
                {
                    NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CREATE_DATE = table.Column<DateTime>(type: "DateTime", nullable: true, defaultValueSql: "GetDate()"),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TBL_LOGIN_LOG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMOTE_IP_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BROWSER_INFO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUCCESS = table.Column<bool>(type: "bit", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LOGIN_LOG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NATIONAL_IDENTIFIER = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ORGANIZATION_FULL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    GENDER = table.Column<bool>(type: "bit", nullable: false),
                    LAYOUT_OPTIONS_JSON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOUR_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_EMPLOYEE_FORM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_USER_ID = table.Column<int>(type: "int", nullable: false),
                    INSTRUCTION_FORM_ID = table.Column<int>(type: "int", nullable: false),
                    INSTRUCTOR_COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_EMPLOYEE_FORM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_EMPLOYEE_FORM_TBL_INSTRUCTION_FORM_INSTRUCTION_FORM_ID",
                        column: x => x.INSTRUCTION_FORM_ID,
                        principalTable: "TBL_INSTRUCTION_FORM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_EMPLOYEE_FORM_INSTRUCTION_FORM_ID",
                table: "TBL_EMPLOYEE_FORM",
                column: "INSTRUCTION_FORM_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ACCESS_DENIED_LOG");

            migrationBuilder.DropTable(
                name: "TBL_EMPLOYEE");

            migrationBuilder.DropTable(
                name: "TBL_EMPLOYEE_FORM");

            migrationBuilder.DropTable(
                name: "TBL_INSTRUCTION_TYPE");

            migrationBuilder.DropTable(
                name: "TBL_LOGIN_LOG");

            migrationBuilder.DropTable(
                name: "TBL_USER");

            migrationBuilder.DropTable(
                name: "TBL_INSTRUCTION_FORM");
        }
    }
}
