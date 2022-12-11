using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.DataAccess.Migrations
{
    public partial class UpdatedPropertiesAndChangedPrimaryKeyAndAddedUniqueKey_StudentSchoolNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSchoolCards",
                table: "StudentSchoolCards");

            migrationBuilder.RenameColumn(
                name: "CardUID",
                table: "StudentSchoolCards",
                newName: "StudentSchoolCardPhysicalUID");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentSchoolCardId",
                table: "StudentSchoolCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSchoolCards",
                table: "StudentSchoolCards",
                column: "StudentSchoolCardId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchoolCards_StudentSchoolCardPhysicalUID",
                table: "StudentSchoolCards",
                column: "StudentSchoolCardPhysicalUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSchoolCards",
                table: "StudentSchoolCards");

            migrationBuilder.DropIndex(
                name: "IX_StudentSchoolCards_StudentSchoolCardPhysicalUID",
                table: "StudentSchoolCards");

            migrationBuilder.DropColumn(
                name: "StudentSchoolCardId",
                table: "StudentSchoolCards");

            migrationBuilder.RenameColumn(
                name: "StudentSchoolCardPhysicalUID",
                table: "StudentSchoolCards",
                newName: "CardUID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSchoolCards",
                table: "StudentSchoolCards",
                column: "CardUID");
        }
    }
}
