namespace HSE.DAL.ViewModels
{
    public class InstructionFormViewModel
    {
        public int InstructorUserId { get; set; }
        public string FormCreateDate { get; set; }
        public string InstructorFullName { get; set; }
        public string InstructorPosition { get; set; }
        public string InstructionType { get; set; }
        public string InstructionTypeName { get; set; }
        public string InstructionShortContent { get; set; }
        public int InstructorOrganizationId { get; set; }
        public string InstructorOrganizationFullName { get; set; }
        public string EmployeInfoListJsonString { get; set; }
    }

    public class EmployeInfo
    {
        public int EmployeUserId { get; set; }
        public string EmployeFullName { get; set; }
        public string EmployeePosition { get; set; }
        public string Note { get; set; }
    }
}
