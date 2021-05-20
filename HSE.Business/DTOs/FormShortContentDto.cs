namespace HSE.Business.DTOs
{
    public class FormShortContentDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
