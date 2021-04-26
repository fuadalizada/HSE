namespace HSE.Business.DTOs
{
    public class EmployeeFormDto :BaseDto
    {
        public int EmployeeUserId { get; set; }
        public int InstructionFormId { get; set; }
        public string InstructorComment { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeePosition { get; set; }
        public bool? IsActive { get; set; }
    }
}
