using System;

namespace HSE.Domain.Entities
{
    public class EmployeeForm : BaseEntity
    {
        public int EmployeeUserId { get; set; }
        public int InstructionFormId { get; set; }
        public string InstructorComment { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeePosition { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? PhotoTakingDate { get; set; }
        public InstructionForm InstructionForm { get; set; }
    }
}
