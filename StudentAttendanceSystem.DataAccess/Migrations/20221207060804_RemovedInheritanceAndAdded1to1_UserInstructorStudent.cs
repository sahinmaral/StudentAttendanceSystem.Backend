using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.DataAccess.Migrations
{
    public partial class RemovedInheritanceAndAdded1to1_UserInstructorStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorLecture_Users_InstructorsUserId",
                table: "InstructorLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Users_StudentsUserId",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Users_StudentUserId",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentSchoolNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "StudentAttendances",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_StudentUserId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentsUserId",
                table: "LectureStudent",
                newName: "StudentsStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureStudent_StudentsUserId",
                table: "LectureStudent",
                newName: "IX_LectureStudent_StudentsStudentId");

            migrationBuilder.RenameColumn(
                name: "InstructorsUserId",
                table: "InstructorLecture",
                newName: "InstructorsInstructorId");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_Instructors_Users_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentSchoolNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorLecture_Instructors_InstructorsInstructorId",
                table: "InstructorLecture",
                column: "InstructorsInstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Students_StudentsStudentId",
                table: "LectureStudent",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Students_StudentId",
                table: "StudentAttendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorLecture_Instructors_InstructorsInstructorId",
                table: "InstructorLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Students_StudentsStudentId",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Students_StudentId",
                table: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentAttendances",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_StudentUserId");

            migrationBuilder.RenameColumn(
                name: "StudentsStudentId",
                table: "LectureStudent",
                newName: "StudentsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureStudent_StudentsStudentId",
                table: "LectureStudent",
                newName: "IX_LectureStudent_StudentsUserId");

            migrationBuilder.RenameColumn(
                name: "InstructorsInstructorId",
                table: "InstructorLecture",
                newName: "InstructorsUserId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentSchoolNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorLecture_Users_InstructorsUserId",
                table: "InstructorLecture",
                column: "InstructorsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Users_StudentsUserId",
                table: "LectureStudent",
                column: "StudentsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Users_StudentUserId",
                table: "StudentAttendances",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
