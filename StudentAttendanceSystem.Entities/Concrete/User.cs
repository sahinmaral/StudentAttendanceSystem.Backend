

using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class User:IEntity
    {
        public User()
        {
            UserId = Guid.NewGuid();
        }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }

        public Student Student { get; set; }
        public Instructor Instructor { get; set; }

    }
}
