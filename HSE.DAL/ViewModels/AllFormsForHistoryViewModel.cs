namespace HSE.DAL.ViewModels
{
    public class AllFormsForHistoryViewModel
    {
        public int FormId { get; set; }
        public string FormGuidId { get; set; }
        public string InstructionDate { get; set; }
        public string InstructorFullName { get; set; }
        public string InstructorOrganizationFullName { get; set; }
        public string InstructorPosition { get; set; }
        public string InstructorTypeName { get; set; }
        public string InstructionShortContent { get; set; }
        public string IsActive { get; set; }
    }
}
