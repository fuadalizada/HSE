namespace HSE.Business.DTOs
{
    public class UserDto : BaseDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fincode { get; set; }
        public string Structure { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public bool Active { get; set; }
        public string LayoutOptionsJson { get; set; }
    }
}
