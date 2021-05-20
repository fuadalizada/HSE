namespace HSE.Domain.Entities
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
