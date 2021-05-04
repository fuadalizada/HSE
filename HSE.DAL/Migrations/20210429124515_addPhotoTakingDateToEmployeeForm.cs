using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSE.DAL.Migrations
{
    public partial class addPhotoTakingDateToEmployeeForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PHOTO_TAKING_DATE",
                table: "TBL_EMPLOYEE_FORM",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PHOTO_TAKING_DATE",
                table: "TBL_EMPLOYEE_FORM");
        }
    }
}
