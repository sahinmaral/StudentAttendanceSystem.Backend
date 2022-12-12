using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.DataAccess.Migrations
{
    public partial class AddedAttendanceTypeAsEnumAndUpdatedDatetimePropertyName_StudentAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentAttendanceLectureEnteredDateTime",
                table: "StudentAttendances");

            migrationBuilder.AddColumn<int>(
                name: "StudenAttendanceType",
                table: "StudentAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StudentAttendanceEnteredDateTime",
                table: "StudentAttendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudenAttendanceType",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "StudentAttendanceEnteredDateTime",
                table: "StudentAttendances");

            migrationBuilder.AddColumn<DateTime>(
                name: "StudentAttendanceLectureEnteredDateTime",
                table: "StudentAttendances",
                type: "datetime2",
                nullable: true);
        }
    }
}
