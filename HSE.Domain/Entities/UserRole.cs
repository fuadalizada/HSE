using System;

namespace HSE.Domain.Entities
{
    public class UserRole:BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
