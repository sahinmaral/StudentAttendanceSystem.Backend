using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.DataAccess.Migrations
{
    public partial class UpdatedEnumPropertyName_StudentAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudenAttendanceType",
                table: "StudentAttendances",
                newName: "StudentAttendanceType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentAttendanceType",
                table: "StudentAttendances",
                newName: "StudenAttendanceType");
        }
    }
}
