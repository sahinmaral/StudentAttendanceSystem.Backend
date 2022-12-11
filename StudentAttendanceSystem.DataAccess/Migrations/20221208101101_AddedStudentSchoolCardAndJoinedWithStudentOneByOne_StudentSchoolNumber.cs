using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.DataAccess.Migrations
{
    public partial class AddedStudentSchoolCardAndJoinedWithStudentOneByOne_StudentSchoolNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentSchoolCards",
                columns: table => new
                {
                    CardUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSchoolCards", x => x.CardUID);
                    table.ForeignKey(
                        name: "FK_StudentSchoolCards_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchoolCards_StudentId",
                table: "StudentSchoolCards",
                column: "StudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSchoolCards");
        }
    }
}
