using System.Collections.Generic;
using HSE.Business.DTOs;

namespace HSE.WebUI.Models
{
    public class CreateFormViewModel
    {
        public string InstructorFullName { get; set; }
        public string InstructorPosition { get; set; }
        public List<InstructionTypeDto> InstructionFormDtos { get; set; }
        public List<FormShortContentDto>  FormShortContentDtos { get; set; }
    }
}
