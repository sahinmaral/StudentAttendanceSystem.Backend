using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal:EfEntityRepositoryBase<Department, StudentAttendanceSystemAppDbContext>, IDepartmentDal
    {
        public List<Department> GetByDetail()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.Departments
                    .Include(x => x.Lectures)
                    .Include(x => x.Faculty)
                    .ToList();
            }
        }

        public async Task<List<Department>> GetByDetailAsync()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.Departments
                    .Include(x => x.Lectures)
                    .Include(x => x.Faculty)
                    .ToListAsync();
            }
        }

        public Department GetByIdDetail(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.Departments
                    .Include(x => x.Lectures)
                    .Include(x => x.Faculty)
                    .SingleOrDefault(x => x.DepartmentId == id);
            }
        }

        public async Task<Department> GetByIdDetailAsync(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.Departments
                    .Include(x => x.Lectures)
                    .Include(x => x.Faculty)
                    .SingleOrDefaultAsync(x => x.DepartmentId == id);
            }
        }
    }
}
