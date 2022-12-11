﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentAttendanceSystem.DataAccess.Concrete;

#nullable disable

namespace StudentAttendanceSystem.DataAccess.Migrations
{
    [DbContext(typeof(StudentAttendanceSystemAppDbContext))]
    [Migration("20221208101101_AddedStudentSchoolCardAndJoinedWithStudentOneByOne_StudentSchoolNumber")]
    partial class AddedStudentSchoolCardAndJoinedWithStudentOneByOne_StudentSchoolNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.Property<Guid>("DepartmentsDepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LecturesLectureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentsDepartmentId", "LecturesLectureId");

                    b.HasIndex("LecturesLectureId");

                    b.ToTable("DepartmentLecture");
                });

            modelBuilder.Entity("InstructorLecture", b =>
                {
                    b.Property<Guid>("InstructorsInstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LecturesLectureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InstructorsInstructorId", "LecturesLectureId");

                    b.HasIndex("LecturesLectureId");

                    b.ToTable("InstructorLecture");
                });

            modelBuilder.Entity("LectureLectureHour", b =>
                {
                    b.Property<Guid>("LectureHoursLectureHourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LecturesLectureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LectureHoursLectureHourId", "LecturesLectureId");

                    b.HasIndex("LecturesLectureId");

                    b.ToTable("LectureLectureHour");
                });

            modelBuilder.Entity("LectureStudent", b =>
                {
                    b.Property<Guid>("LecturesLectureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsStudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LecturesLectureId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("LectureStudent");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Faculty", b =>
                {
                    b.Property<Guid>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Instructor", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Lecture", b =>
                {
                    b.Property<Guid>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LectureClassCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LectureCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LectureLanguage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LectureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LectureId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.LectureHour", b =>
                {
                    b.Property<Guid>("LectureHourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LectureHourEndHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LectureHourStartHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LectureHourId");

                    b.ToTable("LectureHours");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentSchoolNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.StudentAttendance", b =>
                {
                    b.Property<Guid>("StudentAttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LectureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StudentAttendanceLectureEnteredDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentAttendanceId");

                    b.HasIndex("LectureId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAttendances");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.StudentSchoolCard", b =>
                {
                    b.Property<string>("CardUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CardUID");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentSchoolCards");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserAddressCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAddressDistrict")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAddressStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("UserAddressZipCode")
                        .HasColumnType("smallint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesLectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstructorLecture", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsInstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesLectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LectureLectureHour", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.LectureHour", null)
                        .WithMany()
                        .HasForeignKey("LectureHoursLectureHourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesLectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LectureStudent", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesLectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Department", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Instructor", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.User", "User")
                        .WithOne("Instructor")
                        .HasForeignKey("StudentAttendanceSystem.Entities.Concrete.Instructor", "InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Student", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("StudentAttendanceSystem.Entities.Concrete.Student", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.StudentAttendance", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.StudentSchoolCard", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.Student", "Student")
                        .WithOne("StudentSchoolCard")
                        .HasForeignKey("StudentAttendanceSystem.Entities.Concrete.StudentSchoolCard", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.UserAddress", b =>
                {
                    b.HasOne("StudentAttendanceSystem.Entities.Concrete.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Faculty", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.Student", b =>
                {
                    b.Navigation("StudentSchoolCard")
                        .IsRequired();
                });

            modelBuilder.Entity("StudentAttendanceSystem.Entities.Concrete.User", b =>
                {
                    b.Navigation("Instructor")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();

                    b.Navigation("UserAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}
