using System;
using System.Collections.Generic;

namespace HSE.Domain.Entities
{
    public class InstructionForm : BaseEntity
    {
        public int InstructorUserId { get; set; }
        public int InstructorOrganizationId { get; set; }
        public string InstructorFullName { get; set; }
        public string InstructorPosition { get; set; }
        public string InstructionShortContent { get; set; }
        public DateTime InstructionDate { get; set; }
        public int InstructionTypeId { get; set; }
        public string InstructionTypeName { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<EmployeeForm> EmployeeForms { get; set; }
    }
}
