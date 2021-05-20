using System;

namespace HSE.Business.DTOs
{
    public class ErrorLogDto : BaseDto
    {
        public int? UserId { get; set; }
        public int? InstructionFormId { get; set; }
        public string ActionName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
