using System.Collections.Generic;
using HSE.Business.DTOs;

namespace HSE.WebUI.Models
{
    public class RetrieveFormResultViewModel
    {
        public InstructionFormDto InstructionFormDto { get; set; }
        public List<EmployeeFormDto> EmployeeFormDtos { get; set; }
    }
}
