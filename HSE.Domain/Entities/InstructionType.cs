using System;

namespace HSE.Domain.Entities
{
    public class InstructionType : BaseEntity
    {
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
