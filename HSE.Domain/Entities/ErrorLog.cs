using System;

namespace HSE.Domain.Entities
{
    public class ErrorLog : BaseEntity
    {
        public int? UserId { get; set; }
        public int? InstructionFormId { get; set; }
        public string ActionName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
