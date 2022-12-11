using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfStudentAttendanceDal : EfEntityRepositoryBase<StudentAttendance, StudentAttendanceSystemAppDbContext>, IStudentAttendanceDal
    {
        public List<StudentAttendance> GetByDetail()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.StudentAttendances
                    .Include(x => x.Lecture)
                    .Include(x => x.Student)
                    .ToList();
            }
        }

        public async Task<List<StudentAttendance>> GetByDetailAsync()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.StudentAttendances
                .Include(x => x.Lecture)
                .Include(x => x.Student)
                .ToListAsync();
            }
        }

        public StudentAttendance GetByIdDetail(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.StudentAttendances
                    .Include(x => x.Lecture)
                    .Include(x => x.Student)
                    .SingleOrDefault(x => x.StudentAttendanceId == id);
            }
        }

        public async Task<StudentAttendance> GetByIdDetailAsync(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.StudentAttendances
                .Include(x => x.Lecture)
                .Include(x => x.Student)
                .SingleOrDefaultAsync(x=>x.StudentAttendanceId == id);
            }
        }
    }
}
