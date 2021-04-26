using System;

namespace HSE.Business.DTOs
{
    public class InstructionTypeDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
