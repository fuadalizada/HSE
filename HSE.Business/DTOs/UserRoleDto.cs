using System;

namespace HSE.Business.DTOs
{
    public class UserRoleDto:BaseDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
