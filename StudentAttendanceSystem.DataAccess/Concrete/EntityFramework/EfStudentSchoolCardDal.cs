using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfStudentSchoolCardDal : EfEntityRepositoryBase<StudentSchoolCard, StudentAttendanceSystemAppDbContext>, IStudentSchoolCardDal
    {
        public List<StudentSchoolCard> GetByDetail()
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentSchoolCard>> GetByDetailAsync()
        {
            throw new NotImplementedException();
        }

        public StudentSchoolCard GetByIdDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentSchoolCard> GetByIdDetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
