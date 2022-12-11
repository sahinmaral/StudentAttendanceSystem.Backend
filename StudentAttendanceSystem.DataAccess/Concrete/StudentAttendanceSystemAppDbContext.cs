using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete
{
    public class StudentAttendanceSystemAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=StudentAttendanceSystemDb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSchoolCard>().HasKey(x => x.StudentSchoolCardId);
            modelBuilder.Entity<StudentSchoolCard>().HasIndex(x =>x.StudentSchoolCardPhysicalUID).IsUnique();

            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<LectureHour> LectureHours { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<StudentSchoolCard> StudentSchoolCards { get; set; }


    }
}
