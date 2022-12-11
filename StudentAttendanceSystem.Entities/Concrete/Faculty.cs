using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class Faculty : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<Department> Departments { get; set; }
    }
}