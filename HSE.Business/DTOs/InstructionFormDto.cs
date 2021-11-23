using System;

namespace HSE.Business.DTOs
{
    public class InstructionFormDto : BaseDto
    {
        public int InstructorUserId { get; set; }
        public string InstructionFormGuidId { get; set; }
        public int InstructorOrganizationId { get; set; }
        public string InstructorOrganizationFullName { get; set; }
        public string InstructorFullName { get; set; }
        public string InstructorPosition { get; set; }
        public string InstructionShortContent { get; set; }
        public DateTime InstructionDate { get; set; }
        public int InstructionTypeId { get; set; }
        public string InstructionTypeName { get; set; }
        public bool? IsActive { get; set; }
    }
}
