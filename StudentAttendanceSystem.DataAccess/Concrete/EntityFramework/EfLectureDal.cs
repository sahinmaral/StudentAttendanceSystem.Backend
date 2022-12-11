using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using StudentAttendanceSystem.Core.Entities.Abstract;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfLectureDal : EfEntityRepositoryBase<Lecture, StudentAttendanceSystemAppDbContext>, ILectureDal
    {

        public override void Add(Lecture entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                context.Entry(entity).State = EntityState.Added;

                entity.LectureHours.ForEach(x =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                entity.Departments.ForEach(x =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                entity.Instructors.ForEach(x =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                context.SaveChanges();

            }
        }

        public override async Task AddAsync(Lecture entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {

                entity.LectureHours.ForEach(x =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                entity.Departments.ForEach(x =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                entity.Instructors.ForEach(x =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                await base.AddAsync(entity);

            }
        }

        public override void Update(Lecture entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {

                var unchangedEntity = GetByIdDetail(entity.LectureId);
                context.Entry(unchangedEntity).State = EntityState.Unchanged;

                #region Department Navigation Property Update 

                unchangedEntity.Departments.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityDepartmentDictionary = unchangedEntity.Departments.ToDictionary(x => x.DepartmentId);
                var entityDepartmentDictionary = entity.Departments.ToDictionary(x => x.DepartmentId);

                foreach (var key in unchangedEntityDepartmentDictionary.Keys)
                {
                    if (!entityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Departments.Remove(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }


                foreach (var key in entityDepartmentDictionary.Keys)
                {
                    if (!unchangedEntityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Departments.Add(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }

                #endregion

                #region Instructor Navigation Property Update

                unchangedEntity.Instructors.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityInstructorDictionary = unchangedEntity.Instructors.ToDictionary(x => x.InstructorId);
                var entityInstructorDictionary = entity.Instructors.ToDictionary(x => x.InstructorId);

                foreach (var key in unchangedEntityInstructorDictionary.Keys)
                {
                    if (!entityInstructorDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Instructors.Remove(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }

                foreach (var key in entityInstructorDictionary.Keys)
                {
                    if (!unchangedEntityInstructorDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Instructors.Add(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }
                #endregion

                #region LectureHour Navigation Property Update

                unchangedEntity.LectureHours.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityLectureHourDictionary = unchangedEntity.LectureHours.ToDictionary(x => x.LectureHourId);
                var entityLectureHourDictionary = entity.LectureHours.ToDictionary(x => x.LectureHourId);

                foreach (var key in unchangedEntityLectureHourDictionary.Keys)
                {
                    if (!entityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.LectureHours.Remove(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }

                foreach (var key in entityLectureHourDictionary.Keys)
                {
                    if (!unchangedEntityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.LectureHours.Add(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }
                #endregion

                #region Student Navigation Property Update

                unchangedEntity.Students.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityStudentDictionary = unchangedEntity.Students.ToDictionary(x => x.StudentId);
                var entityStudentDictionary = entity.Students.ToDictionary(x => x.StudentId);

                foreach (var key in unchangedEntityStudentDictionary.Keys)
                {
                    if (!entityStudentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Students.Remove(context.Students.Single(x => x.User.UserId == key));
                    }
                }

                foreach (var key in entityStudentDictionary.Keys)
                {
                    if (!unchangedEntityStudentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Students.Add(context.Students.Single(x => x.User.UserId == key));
                    }
                }
                #endregion

                context.SaveChanges();

            }
        }

        public override async Task UpdateAsync(Lecture entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                var unchangedEntity = GetByIdDetail(entity.LectureId);
                context.Entry(unchangedEntity).State = EntityState.Unchanged;

                #region Department Navigation Property Update 

                unchangedEntity.Departments.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityDepartmentDictionary = unchangedEntity.Departments.ToDictionary(x => x.DepartmentId);
                var entityDepartmentDictionary = entity.Departments.ToDictionary(x => x.DepartmentId);

                foreach (var key in unchangedEntityDepartmentDictionary.Keys)
                {
                    if (!entityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Departments.Remove(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }


                foreach (var key in entityDepartmentDictionary.Keys)
                {
                    if (!unchangedEntityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Departments.Add(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }

                #endregion

                #region Instructor Navigation Property Update

                unchangedEntity.Instructors.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityInstructorDictionary = unchangedEntity.Instructors.ToDictionary(x => x.InstructorId);
                var entityInstructorDictionary = entity.Instructors.ToDictionary(x => x.InstructorId);

                foreach (var key in unchangedEntityInstructorDictionary.Keys)
                {
                    if (!entityInstructorDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Instructors.Remove(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }

                foreach (var key in entityInstructorDictionary.Keys)
                {
                    if (!unchangedEntityInstructorDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Instructors.Add(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }
                #endregion

                #region LectureHour Navigation Property Update

                unchangedEntity.LectureHours.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityLectureHourDictionary = unchangedEntity.LectureHours.ToDictionary(x => x.LectureHourId);
                var entityLectureHourDictionary = entity.LectureHours.ToDictionary(x => x.LectureHourId);

                foreach (var key in unchangedEntityLectureHourDictionary.Keys)
                {
                    if (!entityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.LectureHours.Remove(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }

                foreach (var key in entityLectureHourDictionary.Keys)
                {
                    if (!unchangedEntityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.LectureHours.Add(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }
                #endregion

                #region Student Navigation Property Update

                unchangedEntity.Students.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var unchangedEntityStudentDictionary = unchangedEntity.Students.ToDictionary(x => x.StudentId);
                var entityStudentDictionary = entity.Students.ToDictionary(x => x.StudentId);

                foreach (var key in unchangedEntityStudentDictionary.Keys)
                {
                    if (!entityStudentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Students.Remove(context.Students.Single(x => x.User.UserId == key));
                    }
                }

                foreach (var key in entityStudentDictionary.Keys)
                {
                    if (!unchangedEntityStudentDictionary.TryGetValue(key, out _))
                    {
                        unchangedEntity.Students.Add(context.Students.Single(x => x.User.UserId == key));
                    }
                }
                #endregion

                await context.SaveChangesAsync();

            }
            
        }

        public List<Lecture> GetByDetail()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.Lectures
                    .Include(x => x.LectureHours)
                    .Include(x => x.Students)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Instructors)
                        .ThenInclude(x=>x.User)
                    .Include(x => x.Departments)
                    .ToList();
            }
        }

        public async Task<List<Lecture>> GetByDetailAsync()
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.Lectures
                    .Include(x => x.LectureHours)
                    .Include(x => x.LectureHours)
                    .Include(x => x.Students)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Instructors)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Departments)
                    .ToListAsync();
            }
        }

        public Lecture GetByIdDetail(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return context.Lectures
                    .Include(x => x.LectureHours)
                    .Include(x => x.LectureHours)
                    .Include(x => x.Students)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Instructors)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Departments)
                    .SingleOrDefault(x => x.LectureId == id);
            }
        }

        public async Task<Lecture> GetByIdDetailAsync(Guid id)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {
                return await context.Lectures
                    .Include(x => x.LectureHours)
                    .Include(x => x.Students)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Instructors)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Departments)
                    .SingleOrDefaultAsync(x => x.LectureId == id);
            }
        }
    }
}
