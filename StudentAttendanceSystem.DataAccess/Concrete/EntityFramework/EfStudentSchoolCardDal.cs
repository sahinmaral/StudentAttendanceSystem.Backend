using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfStudentSchoolCardDal:EfEntityRepositoryBase<StudentSchoolCard,StudentAttendanceSystemAppDbContext>,IStudentSchoolCardDal
    {

    }
}
