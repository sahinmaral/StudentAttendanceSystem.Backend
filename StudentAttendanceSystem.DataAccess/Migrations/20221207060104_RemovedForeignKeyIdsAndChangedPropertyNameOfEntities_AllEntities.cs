using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.DataAccess.Migrations
{
    public partial class RemovedForeignKeyIdsAndChangedPropertyNameOfEntities_AllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentsId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureLectureHour_LectureHours_LectureHoursId",
                table: "LectureLectureHour");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureLectureHour_Lectures_LecturesId",
                table: "LectureLectureHour");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Lectures_LectureId",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Users_TakenLectureId",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Users_StudentId",
                table: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "LectureInstructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LectureStudent",
                table: "LectureStudent");

            migrationBuilder.DropColumn(
                name: "TakenLectureId",
                table: "LectureStudent");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "UserSurname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "UserAddresses",
                newName: "UserAddressZipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "UserAddresses",
                newName: "UserAddressStreet");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "UserAddresses",
                newName: "UserAddressDistrict");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "UserAddresses",
                newName: "UserAddressCity");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentAttendances",
                newName: "StudentUserId");

            migrationBuilder.RenameColumn(
                name: "LectureEnteredDateTime",
                table: "StudentAttendances",
                newName: "StudentAttendanceLectureEnteredDateTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentAttendances",
                newName: "StudentAttendanceId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_StudentUserId");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "LectureStudent",
                newName: "StudentsUserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "LectureStudent",
                newName: "LecturesLectureId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureStudent_LectureId",
                table: "LectureStudent",
                newName: "IX_LectureStudent_StudentsUserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Lectures",
                newName: "LectureName");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Lectures",
                newName: "LectureLanguage");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Lectures",
                newName: "LectureCode");

            migrationBuilder.RenameColumn(
                name: "ClassCode",
                table: "Lectures",
                newName: "LectureClassCode");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lectures",
                newName: "LectureId");

            migrationBuilder.RenameColumn(
                name: "LecturesId",
                table: "LectureLectureHour",
                newName: "LecturesLectureId");

            migrationBuilder.RenameColumn(
                name: "LectureHoursId",
                table: "LectureLectureHour",
                newName: "LectureHoursLectureHourId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureLectureHour_LecturesId",
                table: "LectureLectureHour",
                newName: "IX_LectureLectureHour_LecturesLectureId");

            migrationBuilder.RenameColumn(
                name: "StartHour",
                table: "LectureHours",
                newName: "LectureHourStartHour");

            migrationBuilder.RenameColumn(
                name: "EndHour",
                table: "LectureHours",
                newName: "LectureHourEndHour");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LectureHours",
                newName: "LectureHourId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Faculties",
                newName: "FacultyName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Faculties",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "DepartmentName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "LecturesId",
                table: "DepartmentLecture",
                newName: "LecturesLectureId");

            migrationBuilder.RenameColumn(
                name: "DepartmentsId",
                table: "DepartmentLecture",
                newName: "DepartmentsDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_LecturesId",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_LecturesLectureId");

            migrationBuilder.AddColumn<string>(
                name: "StudentSchoolNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LectureStudent",
                table: "LectureStudent",
                columns: new[] { "LecturesLectureId", "StudentsUserId" });

            migrationBuilder.CreateTable(
                name: "InstructorLecture",
                columns: table => new
                {
                    InstructorsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturesLectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorLecture", x => new { x.InstructorsUserId, x.LecturesLectureId });
                    table.ForeignKey(
                        name: "FK_InstructorLecture_Lectures_LecturesLectureId",
                        column: x => x.LecturesLectureId,
                        principalTable: "Lectures",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorLecture_Users_InstructorsUserId",
                        column: x => x.InstructorsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLecture_LecturesLectureId",
                table: "InstructorLecture",
                column: "LecturesLectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentsDepartmentId",
                table: "DepartmentLecture",
                column: "DepartmentsDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesLectureId",
                table: "DepartmentLecture",
                column: "LecturesLectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureLectureHour_LectureHours_LectureHoursLectureHourId",
                table: "LectureLectureHour",
                column: "LectureHoursLectureHourId",
                principalTable: "LectureHours",
                principalColumn: "LectureHourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureLectureHour_Lectures_LecturesLectureId",
                table: "LectureLectureHour",
                column: "LecturesLectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesLectureId",
                table: "LectureStudent",
                column: "LecturesLectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentsDepartmentId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesLectureId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureLectureHour_LectureHours_LectureHoursLectureHourId",
                table: "LectureLectureHour");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureLectureHour_Lectures_LecturesLectureId",
                table: "LectureLectureHour");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesLectureId",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Users_StudentsUserId",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Users_StudentUserId",
                table: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "InstructorLecture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LectureStudent",
                table: "LectureStudent");

            migrationBuilder.DropColumn(
                name: "StudentSchoolNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserSurname",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserAddressZipCode",
                table: "UserAddresses",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "UserAddressStreet",
                table: "UserAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "UserAddressDistrict",
                table: "UserAddresses",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "UserAddressCity",
                table: "UserAddresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "StudentAttendances",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentAttendanceLectureEnteredDateTime",
                table: "StudentAttendances",
                newName: "LectureEnteredDateTime");

            migrationBuilder.RenameColumn(
                name: "StudentAttendanceId",
                table: "StudentAttendances",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_StudentUserId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentsUserId",
                table: "LectureStudent",
                newName: "LectureId");

            migrationBuilder.RenameColumn(
                name: "LecturesLectureId",
                table: "LectureStudent",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureStudent_StudentsUserId",
                table: "LectureStudent",
                newName: "IX_LectureStudent_LectureId");

            migrationBuilder.RenameColumn(
                name: "LectureName",
                table: "Lectures",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LectureLanguage",
                table: "Lectures",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "LectureCode",
                table: "Lectures",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "LectureClassCode",
                table: "Lectures",
                newName: "ClassCode");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Lectures",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LecturesLectureId",
                table: "LectureLectureHour",
                newName: "LecturesId");

            migrationBuilder.RenameColumn(
                name: "LectureHoursLectureHourId",
                table: "LectureLectureHour",
                newName: "LectureHoursId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureLectureHour_LecturesLectureId",
                table: "LectureLectureHour",
                newName: "IX_LectureLectureHour_LecturesId");

            migrationBuilder.RenameColumn(
                name: "LectureHourStartHour",
                table: "LectureHours",
                newName: "StartHour");

            migrationBuilder.RenameColumn(
                name: "LectureHourEndHour",
                table: "LectureHours",
                newName: "EndHour");

            migrationBuilder.RenameColumn(
                name: "LectureHourId",
                table: "LectureHours",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FacultyName",
                table: "Faculties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Faculties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Departments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Departments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LecturesLectureId",
                table: "DepartmentLecture",
                newName: "LecturesId");

            migrationBuilder.RenameColumn(
                name: "DepartmentsDepartmentId",
                table: "DepartmentLecture",
                newName: "DepartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_LecturesLectureId",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_LecturesId");

            migrationBuilder.AddColumn<Guid>(
                name: "TakenLectureId",
                table: "LectureStudent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LectureStudent",
                table: "LectureStudent",
                columns: new[] { "TakenLectureId", "StudentId" });

            migrationBuilder.CreateTable(
                name: "LectureInstructor",
                columns: table => new
                {
                    GivenLectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureInstructor", x => new { x.GivenLectureId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_LectureInstructor_Lectures_GivenLectureId",
                        column: x => x.GivenLectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureInstructor_Users_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureInstructor_InstructorId",
                table: "LectureInstructor",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentsId",
                table: "DepartmentLecture",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureLectureHour_LectureHours_LectureHoursId",
                table: "LectureLectureHour",
                column: "LectureHoursId",
                principalTable: "LectureHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureLectureHour_Lectures_LecturesId",
                table: "LectureLectureHour",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Lectures_LectureId",
                table: "LectureStudent",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Users_TakenLectureId",
                table: "LectureStudent",
                column: "TakenLectureId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Users_StudentId",
                table: "StudentAttendances",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
