using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class AddStructureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_STRUCTURE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARENT_ORGANIZATION_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_ORGANIZATION_FULL_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    PARENT_ORGANIZATION_SHORT_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    PARENT_ORG_IS_EMPLOYER_FLAG = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    LEVEL_DIFFERENCE = table.Column<int>(type: "int", nullable: true),
                    CHILD_ORGANIZATION_ID = table.Column<int>(type: "int", nullable: true),
                    CHILD_ORGANIZATION_FULL_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    CHILD_ORGANIZATION_SHORT_NAME = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    CHILD_ORG_IS_EMPLOYER_FLAG = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    PARENT_ORG_MGR_POSITION_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_IND_ORG_MGR_POSITION_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_IND_ORG_MGR_POS_ORG_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_IND_ORG_MGR_POS_LEVEL = table.Column<int>(type: "int", nullable: true),
                    PARENT_IND_FIRST_INC_PERSON_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_L3_PARENT_ORG_ID = table.Column<int>(type: "int", nullable: true),
                    CHILD_ORG_MGR_POSITION_ID = table.Column<int>(type: "int", nullable: true),
                    CHILD_IND_ORG_MGR_POSITION_ID = table.Column<int>(type: "int", nullable: true),
                    CHILD_IND_ORG_MGR_POS_ORG_ID = table.Column<int>(type: "int", nullable: true),
                    CHILD_IND_ORG_MGR_POS_LEVEL = table.Column<int>(type: "int", nullable: true),
                    CHILD_IND_FIRST_INC_PERSON_ID = table.Column<int>(type: "int", nullable: true),
                    CHILD_L3_PARENT_ORG_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_STRUCTURE", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_STRUCTURE");
        }
    }
}
