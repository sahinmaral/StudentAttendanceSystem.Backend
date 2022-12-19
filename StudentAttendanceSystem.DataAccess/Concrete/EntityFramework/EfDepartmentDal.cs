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
        public override void Add(Department entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.Entry(entity.Faculty).State = EntityState.Unchanged;

                context.SaveChanges();
            }
        }
        public async override Task AddAsync(Department entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.Entry(entity.Faculty).State = EntityState.Unchanged;

                await context.SaveChangesAsync();
            }
        }
        public override void Update(Department entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                var updatedEntity = GetByIdDetail(entity.DepartmentId);
                context.Entry(updatedEntity).State = EntityState.Modified;

                updatedEntity.DepartmentName = entity.DepartmentName;

                #region Lectures Navigation Property Update

                updatedEntity.Lectures.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityDepartmentDictionary = updatedEntity.Lectures.ToDictionary(x => x.LectureId);
                var entityDepartmentDictionary = entity.Lectures.ToDictionary(x => x.LectureId);

                foreach (var key in updatedEntityDepartmentDictionary.Keys)
                {
                    if (!entityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Lectures.Remove(context.Lectures.Single(x => x.LectureId == key));
                    }
                }


                foreach (var key in entityDepartmentDictionary.Keys)
                {
                    if (!updatedEntityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Lectures.Add(context.Lectures.Single(x => x.LectureId == key));
                    }
                }

                #endregion

                #region Faculty Navigation Property Update

                if (entity.Faculty.FacultyId != updatedEntity.Faculty.FacultyId)
                    updatedEntity.Faculty = context.Faculties.Single(x=>x.FacultyId == entity.Faculty.FacultyId);

                #endregion

                context.SaveChanges();
            }
      
        }
        public override async Task UpdateAsync(Department entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                var updatedEntity = GetByIdDetail(entity.DepartmentId);
                context.Entry(updatedEntity).State = EntityState.Modified;

                updatedEntity.DepartmentName = entity.DepartmentName;

                #region Lectures Navigation Property Update

                updatedEntity.Lectures.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityDepartmentDictionary = updatedEntity.Lectures.ToDictionary(x => x.LectureId);
                var entityDepartmentDictionary = entity.Lectures.ToDictionary(x => x.LectureId);

                foreach (var key in updatedEntityDepartmentDictionary.Keys)
                {
                    if (!entityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Lectures.Remove(context.Lectures.Single(x => x.LectureId == key));
                    }
                }


                foreach (var key in entityDepartmentDictionary.Keys)
                {
                    if (!updatedEntityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Lectures.Add(context.Lectures.Single(x => x.LectureId == key));
                    }
                }

                #endregion

                #region Faculty Navigation Property Update

                if (entity.Faculty.FacultyId != updatedEntity.Faculty.FacultyId)
                    updatedEntity.Faculty = context.Faculties.Single(x => x.FacultyId == entity.Faculty.FacultyId);

                #endregion

                await context.SaveChangesAsync();
            }
        }
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
