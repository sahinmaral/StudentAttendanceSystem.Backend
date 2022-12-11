using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class UserAddress:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public User User { get; set; }
        public string UserAddressCity { get; set; }
        public string UserAddressDistrict { get; set; }
        public string UserAddressStreet { get; set; }
        public short UserAddressZipCode { get; set; }
    }
}
