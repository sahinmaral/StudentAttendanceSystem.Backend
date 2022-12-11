using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, StudentAttendanceSystemAppDbContext>, IStudentDal
    {
        public List<Student> GetByDetail()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.Students
                    .Include(x => x.Lectures)
                        .ThenInclude(x => x.LectureHours)
                    .Include(x => x.User)
                    .Include(x => x.StudentSchoolCard)
                    .ToList();
            }
        }

        public async Task<List<Student>> GetByDetailAsync()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.Students
                    .Include(x => x.Lectures)
                        .ThenInclude(x=>x.LectureHours)
                    .Include(x => x.User)
                    .Include(x => x.StudentSchoolCard)
                    .ToListAsync();
            }
        }

        public Student GetByIdDetail(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.Students
                    .Include(x => x.Lectures)
                        .ThenInclude(x => x.LectureHours)
                    .Include(x => x.User)
                    .Include(x => x.StudentSchoolCard)
                    .SingleOrDefault(x=>x.StudentId == id);
            }
        }

        public async Task<Student> GetByIdDetailAsync(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.Students
                    .Include(x => x.Lectures)
                        .ThenInclude(x => x.LectureHours)
                    .Include(x => x.User)
                    .Include(x => x.StudentSchoolCard)
                    .SingleOrDefaultAsync(x => x.StudentId == id);
            }
        }
    }
}
