using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Utilities.Business;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;
using StudentAttendanceSystem.Entities.Enums;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class StudentAttendanceManager : IStudentAttendanceService
    {
        private readonly IStudentAttendanceDal _studentAttendanceDal;
        private readonly ILectureService _lectureService;
        private readonly IStudentSchoolCardService _studentSchoolCardService;
        private readonly IStudentService _studentService;
        public StudentAttendanceManager(IStudentAttendanceDal studentAttendanceDal, IStudentSchoolCardService studentSchoolCardService, ILectureService lectureService, IStudentService studentService)
        {
            _studentAttendanceDal = studentAttendanceDal;
            _studentSchoolCardService = studentSchoolCardService;
            _lectureService = lectureService;
            _studentService = studentService;
        }
        public IResult AddByStudent(StudentAttendanceAddByStudentDto dto)
        {
            IResult result = BusinessRules.Run(CheckIfStudentCardIsValid(dto.StudentCardUID), CheckIfStudentAlreadyPresentByCardUID(dto.StudentCardUID));
            if (result != null) return result;

            Student student = _studentService.GetSingle(x => x.StudentSchoolCard.StudentSchoolCardPhysicalUID == dto.StudentCardUID).Data;

            DayOfWeek currentDayOfWeek = dto.StudentAttendanceLectureEnteredDateTime.DayOfWeek;
            IEnumerable<Lecture> lectures = student.Lectures.Where(x => (int)x.LectureDay == (int)currentDayOfWeek);

            TimeSpan currentTimeSpan = dto.StudentAttendanceLectureEnteredDateTime.TimeOfDay;

            bool isLectureFound = false;
            Lecture currentLecture = null;

            foreach (Lecture lecture in lectures)
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
                StudentAttendanceEnteredDateTime = DateTime.Now,
                StudentAttendanceType = StudentAttendanceType.Present
            };

            _studentAttendanceDal.Add(studentAttendance);

            return new SuccessResult("Derste var olarak kaydedildiniz");
        }

        public async Task<IResult> AddByStudentAsync(StudentAttendanceAddByStudentDto dto)
        {
            IResult result = BusinessRules.Run(CheckIfStudentCardIsValid(dto.StudentCardUID), CheckIfStudentAlreadyPresentByCardUID(dto.StudentCardUID));
            if (result != null) return result;

            Student student = _studentService.GetWhere(x => x.StudentSchoolCard.StudentSchoolCardPhysicalUID == dto.StudentCardUID).Data.First(); ;

            DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
            IEnumerable<Lecture> lectures = student.Lectures.Where(x => (int)x.LectureDay == (int)currentDayOfWeek);

            TimeSpan currentTimeSpan = DateTime.Now.TimeOfDay;

            bool isLectureFound = false;
            Lecture currentLecture = null;

            foreach (Lecture lecture in lectures)
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

                        if (currentTimeSpan < compareLectureEndHour)
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
                StudentAttendanceEnteredDateTime = DateTime.Now,
            };

            await _studentAttendanceDal.AddAsync(studentAttendance);

            return new SuccessResult("Derste var olarak kaydedildiniz");
        }

        public IResult AddByInstructor(StudentAttendanceAddByInstructorDto dto)
        {
            IResult result = BusinessRules.Run(
                CheckIfStudentExisted(dto.StudentId),
                CheckIfStudentAlreadyPresentByStudentId(dto.StudentId),
                CheckIfLectureExisted(dto.LectureId));
            if (result != null) return result;

            StudentAttendance studentAttendance = new StudentAttendance()
            {
                StudentAttendanceEnteredDateTime = dto.StudentAttendanceEnteredDateTime,
                Student = _studentService.GetById(dto.StudentId).Data,
                Lecture = _lectureService.GetById(dto.LectureId).Data,
            };
            
            

            return new SuccessResult("Secilen ogrenci var olarak kaydedildi");
        }

        public Task<IResult> AddByInstructorAsync(StudentAttendanceAddByInstructorDto dto)
        {
            throw new NotImplementedException();
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

        public IDataResult<StudentAttendance> GetById(Guid id)
        {
            return new SuccessDataResult<StudentAttendance>(_studentAttendanceDal.GetById(id));
        }

        public async Task<IDataResult<StudentAttendance>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<StudentAttendance>(await _studentAttendanceDal.GetByIdAsync(id));
        }

        private IResult CheckIfStudentAlreadyPresentByCardUID(string studentCardUID)
        {
            var card = _studentSchoolCardService.GetSingle(x => x.StudentSchoolCardPhysicalUID == studentCardUID).Data;
            var student = _studentService.GetWhere(x => x.StudentSchoolCard.StudentSchoolCardPhysicalUID == studentCardUID).Data.First();

            var result = _studentAttendanceDal
                    .GetByDetail()
                    .Where(x => x.Student.StudentId == student.StudentId &&
                    DateTime.Now.TimeOfDay.Days - x.StudentAttendanceEnteredDateTime.Day == 0);

            if (result.Any()) return new ErrorResult("Zaten suanki ders icin kartinizi okutmussunuz");
            return new SuccessResult();
        }

        private IResult CheckIfStudentAlreadyPresentByStudentId(Guid studentId)
        {
            Student student = _studentService.GetById(studentId).Data;

            var result = GetWhere
                    (x => x.Student.StudentId == student.StudentId &&
                    DateTime.Now.TimeOfDay.Hours - x.StudentAttendanceEnteredDateTime.Day == 0).Data;

            if (result.Any()) return new ErrorResult("Secilen ogrenci zaten belirtilen tarihte var yazilmistir");
            return new SuccessResult();
        }

        private IResult CheckIfStudentCardIsValid(string studentCardUID)
        {
            var card = _studentSchoolCardService.GetSingle(x => x.StudentSchoolCardPhysicalUID == studentCardUID);
            if (card == null) return new ErrorResult("Okutulan kart gecersizdir");
            return new SuccessResult();
        }

        private IResult CheckIfStudentAttendanceExisted(Guid id)
        {
            var studentAttendance = GetById(id);
            if (studentAttendance == null) return new ErrorResult("Boyle bir yoklama saati yok");
            return new SuccessResult();
        }

        private IResult CheckIfStudentExisted(Guid id)
        {
            Student student = _studentService.GetById(id).Data;
            if (student == null) return new ErrorResult("Boyle bir ogrenci yok");
            return new SuccessResult();
        }

        private IResult CheckIfLectureExisted(Guid id)
        {
            Lecture lecture = _lectureService.GetById(id).Data;
            if (lecture == null) return new ErrorResult("Boyle bir ders yok");
            return new SuccessResult();
        }

        public IResult Add(StudentAttendance entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddAsync(StudentAttendance entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(StudentAttendance entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(StudentAttendance entity)
        {
            throw new NotImplementedException();
        }
    }
}
