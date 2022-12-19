using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete
{
    public class StudentAttendanceSystemAppDbContext : DbContext
    {
        public StudentAttendanceSystemAppDbContext(DbContextOptions<StudentAttendanceSystemAppDbContext> options) : base(options)
        {
        }
        public StudentAttendanceSystemAppDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=StudentAttendanceSystemDb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSchoolCard>().HasIndex(x =>x.StudentSchoolCardPhysicalUID).IsUnique();

            modelBuilder.Entity<User>().HasOne(x => x.Student).WithOne(x => x.User).HasForeignKey<Student>(x => x.StudentId);
            modelBuilder.Entity<User>().HasOne(x => x.Instructor).WithOne(x => x.User).HasForeignKey<Instructor>(x => x.InstructorId);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LectureHour> LectureHours { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<StudentSchoolCard> StudentSchoolCards { get; set; }


    }
}
