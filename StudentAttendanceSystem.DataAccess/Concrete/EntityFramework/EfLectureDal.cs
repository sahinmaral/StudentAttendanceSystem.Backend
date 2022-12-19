using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Data.Common;

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

                await context.SaveChangesAsync();

            }
        }

        public override void Update(Lecture entity)
        {
            using (StudentAttendanceSystemAppDbContext context = new StudentAttendanceSystemAppDbContext())
            {

                var updatedEntity = GetByIdDetail(entity.LectureId);
                context.Entry(updatedEntity).State = EntityState.Modified;

                updatedEntity.LectureName = entity.LectureName;
                updatedEntity.LectureLanguage = entity.LectureLanguage;
                updatedEntity.LectureCode = entity.LectureCode;

                #region Department Navigation Property Update 

                updatedEntity.Departments.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityDepartmentDictionary = updatedEntity.Departments.ToDictionary(x => x.DepartmentId);
                var entityDepartmentDictionary = entity.Departments.ToDictionary(x => x.DepartmentId);

                foreach (var key in updatedEntityDepartmentDictionary.Keys)
                {
                    if (!entityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Departments.Remove(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }


                foreach (var key in entityDepartmentDictionary.Keys)
                {
                    if (!updatedEntityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Departments.Add(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }

                #endregion

                #region Instructor Navigation Property Update

                updatedEntity.Instructors.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityInstructorDictionary = updatedEntity.Instructors.ToDictionary(x => x.InstructorId);
                var entityInstructorDictionary = entity.Instructors.ToDictionary(x => x.InstructorId);

                foreach (var key in updatedEntityInstructorDictionary.Keys)
                {
                    if (!entityInstructorDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Instructors.Remove(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }

                foreach (var key in entityInstructorDictionary.Keys)
                {
                    if (!updatedEntityInstructorDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Instructors.Add(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }
                #endregion

                #region LectureHour Navigation Property Update

                updatedEntity.LectureHours.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityLectureHourDictionary = updatedEntity.LectureHours.ToDictionary(x => x.LectureHourId);
                var entityLectureHourDictionary = entity.LectureHours.ToDictionary(x => x.LectureHourId);

                foreach (var key in updatedEntityLectureHourDictionary.Keys)
                {
                    if (!entityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.LectureHours.Remove(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }

                foreach (var key in entityLectureHourDictionary.Keys)
                {
                    if (!updatedEntityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.LectureHours.Add(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }
                #endregion

                #region Student Navigation Property Update

                updatedEntity.Students.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityStudentDictionary = updatedEntity.Students.ToDictionary(x => x.StudentId);
                var entityStudentDictionary = entity.Students.ToDictionary(x => x.StudentId);

                foreach (var key in updatedEntityStudentDictionary.Keys)
                {
                    if (!entityStudentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Students.Remove(context.Students.Single(x => x.User.UserId == key));
                    }
                }

                foreach (var key in entityStudentDictionary.Keys)
                {
                    if (!updatedEntityStudentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Students.Add(context.Students.Single(x => x.User.UserId == key));
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
                var updatedEntity = GetByIdDetail(entity.LectureId);
                context.Entry(updatedEntity).State = EntityState.Modified;

                updatedEntity.LectureName = entity.LectureName;
                updatedEntity.LectureLanguage = entity.LectureLanguage;
                updatedEntity.LectureCode = entity.LectureCode;

                #region Department Navigation Property Update 

                updatedEntity.Departments.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityDepartmentDictionary = updatedEntity.Departments.ToDictionary(x => x.DepartmentId);
                var entityDepartmentDictionary = entity.Departments.ToDictionary(x => x.DepartmentId);

                foreach (var key in updatedEntityDepartmentDictionary.Keys)
                {
                    if (!entityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Departments.Remove(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }


                foreach (var key in entityDepartmentDictionary.Keys)
                {
                    if (!updatedEntityDepartmentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Departments.Add(context.Departments.Single(x => x.DepartmentId == key));
                    }
                }

                #endregion

                #region Instructor Navigation Property Update

                updatedEntity.Instructors.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityInstructorDictionary = updatedEntity.Instructors.ToDictionary(x => x.InstructorId);
                var entityInstructorDictionary = entity.Instructors.ToDictionary(x => x.InstructorId);

                foreach (var key in updatedEntityInstructorDictionary.Keys)
                {
                    if (!entityInstructorDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Instructors.Remove(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }

                foreach (var key in entityInstructorDictionary.Keys)
                {
                    if (!updatedEntityInstructorDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Instructors.Add(context.Instructors.Single(x => x.InstructorId == key));
                    }
                }
                #endregion

                #region LectureHour Navigation Property Update

                updatedEntity.LectureHours.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityLectureHourDictionary = updatedEntity.LectureHours.ToDictionary(x => x.LectureHourId);
                var entityLectureHourDictionary = entity.LectureHours.ToDictionary(x => x.LectureHourId);

                foreach (var key in updatedEntityLectureHourDictionary.Keys)
                {
                    if (!entityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.LectureHours.Remove(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }

                foreach (var key in entityLectureHourDictionary.Keys)
                {
                    if (!updatedEntityLectureHourDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.LectureHours.Add(context.LectureHours.Single(x => x.LectureHourId == key));
                    }
                }
                #endregion

                #region Student Navigation Property Update

                updatedEntity.Students.ForEach((x) =>
                {
                    context.Entry(x).State = EntityState.Unchanged;
                });

                var updatedEntityStudentDictionary = updatedEntity.Students.ToDictionary(x => x.StudentId);
                var entityStudentDictionary = entity.Students.ToDictionary(x => x.StudentId);

                foreach (var key in updatedEntityStudentDictionary.Keys)
                {
                    if (!entityStudentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Students.Remove(context.Students.Single(x => x.User.UserId == key));
                    }
                }

                foreach (var key in entityStudentDictionary.Keys)
                {
                    if (!updatedEntityStudentDictionary.TryGetValue(key, out _))
                    {
                        updatedEntity.Students.Add(context.Students.Single(x => x.User.UserId == key));
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
