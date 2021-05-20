namespace HSE.Domain.Entities
{
    public class FormShortContent : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
