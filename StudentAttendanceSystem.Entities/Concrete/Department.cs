using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class Department:IEntity
    {
        public Department()
        {
            DepartmentId = Guid.NewGuid();
        }

        
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Faculty Faculty { get; set; }
        public List<Lecture> Lectures { get; set; }
    }
}
