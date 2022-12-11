using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Utilities.Business;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class StudentAttendanceManager : IStudentAttendanceService
    {
        private readonly IStudentAttendanceDal _studentAttendanceDal;
        private readonly IStudentDal _studentDal;
        private readonly ILectureDal _lectureDal;
        private readonly IStudentSchoolCardDal _studentSchoolCardDal;
        public StudentAttendanceManager(IStudentAttendanceDal studentAttendanceDal, IStudentDal studentDal, ILectureDal lectureDal, IStudentSchoolCardDal studentSchoolCardDal)
        {
            _studentAttendanceDal = studentAttendanceDal;
            _studentDal = studentDal;
            _lectureDal = lectureDal;
            _studentSchoolCardDal = studentSchoolCardDal;
        }
        public IResult AddByStudent(StudentAttendanceAddByStudentDto dto)
        {
            IResult result = BusinessRules.Run(CheckIfStudentCardIsValid(dto.StudentCardUID), CheckIfStudentAlreadyPresent(dto.StudentCardUID));
            if (result != null) return result;

            Student student = _studentDal.GetByDetail().Single(x => x.StudentSchoolCard.StudentSchoolCardPhysicalUID == dto.StudentCardUID);

            DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
            IEnumerable<Lecture> lectures = student.Lectures.Where(x => (int)x.LectureDay == (int)currentDayOfWeek);

            TimeSpan currentTimeSpan = DateTime.Now.TimeOfDay;

            bool isLectureFound = false;
            Lecture currentLecture = null;

            foreach (var lecture in lectures)
            {
                if (isLectureFound) break;

                foreach (LectureHour lectureHour in lecture.LectureHours)
                {
                    if (currentTimeSpan > lectureHour.LectureHourStartHour)
                    {
                        TimeSpan compareLectureEndHour = new TimeSpan();

                        if (lectureHour.LectureHourEndHour == new TimeSpan(0, 0, 0))
                            compareLectureEndHour = new TimeSpan(23, 59, 59);
                        else
                            compareLectureEndHour = lectureHour.LectureHourEndHour;

                        if(currentTimeSpan < compareLectureEndHour)
                        {
                            isLectureFound = true;
                            currentLecture = lecture;
                            break;
                        }
                        
                    }
                }
            }

            if (currentLecture == null)
                return new ErrorResult("Su anda bir dersin yok");

            StudentAttendance studentAttendance = new StudentAttendance()
            {
                Lecture = currentLecture,
                Student = student,
                StudentAttendanceLectureEnteredDateTime = DateTime.Now,
            };

            _studentAttendanceDal.Add(studentAttendance);

            return new SuccessResult("Derste var olarak kaydedildiniz");
        }

        public async Task<IResult> AddByStudentAsync(StudentAttendanceAddByStudentDto dto)
        {
            var result = BusinessRules.Run(CheckIfStudentCardIsValid(dto.StudentCardUID),CheckIfStudentAlreadyPresent(dto.StudentCardUID));
            if (result != null) return result;

            var students = await _studentDal.GetByDetailAsync();
            Student student = students.Single(x => x.StudentSchoolCard.StudentSchoolCardId == new Guid(dto.StudentCardUID));

            DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
            var lectures = student.Lectures.Where(x => (int)x.LectureDay == (int)currentDayOfWeek);

            TimeSpan currentTimeSpan = DateTime.Now.TimeOfDay;

            bool isLectureFound = false;
            Lecture currentLecture = null;

            foreach (var lecture in lectures)
            {
                if (isLectureFound) break;

                foreach (var lectureHour in lecture.LectureHours)
                {
                    if (currentTimeSpan > lectureHour.LectureHourStartHour && currentTimeSpan < lectureHour.LectureHourEndHour)
                    {
                        isLectureFound = true;
                        currentLecture = lecture;
                        break;
                    }
                }
            }

            if (currentLecture == null)
                return new ErrorResult("Su anda bir dersin yok");

            StudentAttendance studentAttendance = new StudentAttendance()
            {
                Lecture = currentLecture,
                Student = student,
                StudentAttendanceLectureEnteredDateTime = DateTime.Now,
            };

            await _studentAttendanceDal.AddAsync(studentAttendance);

            return new SuccessResult("Derste var olarak kaydedildiniz");
        }

        private IResult CheckIfStudentAlreadyPresent(string studentCardUID)
        {
            var card = _studentSchoolCardDal.GetSingle(x => x.StudentSchoolCardPhysicalUID == studentCardUID);
            var student = _studentDal.GetByDetail().Single(x => x.StudentSchoolCard.StudentSchoolCardPhysicalUID == studentCardUID);

            var result = _studentAttendanceDal
                    .GetByDetail()
                    .Where(x => x.Student.StudentId == student.StudentId &&
                    Math.Abs(DateTime.Now.TimeOfDay.Hours - x.StudentAttendanceLectureEnteredDateTime.Value.Hour) > 24);

            if (result.Any()) return new ErrorResult("Zaten suanki ders icin kartinizi okutmussunuz");
            return new SuccessResult();
        }

        private IResult CheckIfStudentCardIsValid(string studentCardUID)
        {
            var card = _studentSchoolCardDal.GetSingle(x => x.StudentSchoolCardPhysicalUID == studentCardUID);
            if (card == null) return new ErrorResult("Okutulan kart gecersizdir");
            return new SuccessResult();
        }

        public IResult Delete(Guid id)
        {
            var result = BusinessRules.Run(CheckIfStudentAttendanceExisted(id));

            if (result != null) return result;

            _studentAttendanceDal.Delete(new StudentAttendance()
            {
                StudentAttendanceId = id
            });

            return new SuccessResult("Ogrencinin secilen yoklama saati silindi");
        }

        private IResult CheckIfStudentAttendanceExisted(Guid id)
        {
            var studentAttendance = _studentAttendanceDal.GetById(id);
            if (studentAttendance == null) return new ErrorResult("Boyle bir yoklama saati yok");
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = BusinessRules.Run(CheckIfStudentAttendanceExisted(id));

            if (result != null) return result;

            await _studentAttendanceDal.DeleteAsync(new StudentAttendance()
            {
                StudentAttendanceId = id
            });

            return new SuccessResult("Ogrencinin secilen yoklama saati silindi");
        }

        public IDataResult<List<StudentAttendance>> Get()
        {
            return new SuccessDataResult<List<StudentAttendance>>(_studentAttendanceDal.Get());
        }

        public async Task<IDataResult<List<StudentAttendance>>> GetAsync()
        {
            return new SuccessDataResult<List<StudentAttendance>>(await _studentAttendanceDal.GetAsync());
        }

        //public IDataResult<List<StudentAttendance>> GetByDetail()
        //{
        //    return new SuccessDataResult<List<StudentAttendance>>(_studentAttendanceDal.GetByDetail());
        //}

        //public async Task<IDataResult<List<StudentAttendance>>> GetByDetailAsync()
        //{
        //    return new SuccessDataResult<List<StudentAttendance>>(await _studentAttendanceDal.GetByDetailAsync());
        //}

        //public IDataResult<StudentAttendance> GetById(Guid id)
        //{
        //    return new SuccessDataResult<StudentAttendance>(_studentAttendanceDal.GetById(id));
        //}

        //public async Task<IDataResult<StudentAttendance>> GetByIdAsync(Guid id)
        //{
        //    return new SuccessDataResult<StudentAttendance>(await _studentAttendanceDal.GetByIdAsync(id));
        //}

        //public IDataResult<StudentAttendance> GetByIdDetail(Guid id)
        //{
        //    return new SuccessDataResult<StudentAttendance>(_studentAttendanceDal.GetByIdDetail(id));
        //}

        //public async Task<IDataResult<StudentAttendance>> GetByIdDetailAsync(Guid id)
        //{
        //    return new SuccessDataResult<StudentAttendance>(await _studentAttendanceDal.GetByIdDetailAsync(id));
        //}

        public IDataResult<StudentAttendance> GetSingle(Expression<Func<StudentAttendance, bool>> predicate)
        {
            return new SuccessDataResult<StudentAttendance>(_studentAttendanceDal.GetSingle(predicate));
        }

        public async Task<IDataResult<StudentAttendance>> GetSingleAsync(Expression<Func<StudentAttendance, bool>> predicate)
        {
            return new SuccessDataResult<StudentAttendance>(await _studentAttendanceDal.GetSingleAsync(predicate));
        }

        public IDataResult<List<StudentAttendance>> GetWhere(Expression<Func<StudentAttendance, bool>> predicate)
        {
            return new SuccessDataResult<List<StudentAttendance>>(_studentAttendanceDal.GetWhere(predicate));
        }

        public async Task<IDataResult<List<StudentAttendance>>> GetWhereAsync(Expression<Func<StudentAttendance, bool>> predicate)
        {
            return new SuccessDataResult<List<StudentAttendance>>(await _studentAttendanceDal.GetWhereAsync(predicate));
        }

        private IResult CheckIfStudentIsExisted(Guid studentId)
        {
            var student = _studentDal.GetById(studentId);
            if (student == null) return new ErrorResult("Boyle bir ogrenci yok");
            return new SuccessResult();
        }

        private IResult CheckIfLectureIsExisted(Guid studentId)
        {
            var lecture = _lectureDal.GetById(studentId);
            if (lecture == null) return new ErrorResult("Boyle bir ders yok");
            return new SuccessResult();
        }

        public IDataResult<StudentAttendance> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<StudentAttendance>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
