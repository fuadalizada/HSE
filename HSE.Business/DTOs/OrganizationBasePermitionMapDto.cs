using System;

namespace HSE.Business.DTOs
{
    public class OrganizationBasePermitionMapDto:BaseDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
