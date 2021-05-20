namespace HSE.Business.DTOs
{
    public class RoleDto :BaseDto
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
