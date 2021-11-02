using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.ViewModels;

namespace HSE.WebUI.ServiceFacade
{
    public class FormServiceFacade
    {
        private readonly IInstructionFormService _instructionFormService;
        private readonly IEmployeeFormService _employeeFormService;
        public InstructionFormDto InstructionFormResult;
        public FormServiceFacade(IInstructionFormService instructionFormService, IEmployeeFormService employeeFormService)
        {
            _instructionFormService = instructionFormService;
            _employeeFormService = employeeFormService;
        }

        public async Task<InstructionFormDto> AddToInstructionForm(InstructionFormViewModel instructionFormViewModel,int organizationId,string organizationName,int instructorUserId)
        {
            instructionFormViewModel.InstructorOrganizationId = organizationId;
            instructionFormViewModel.InstructorOrganizationFullName = organizationName;
            instructionFormViewModel.InstructorUserId = instructorUserId;
            var instructionFormDto = new InstructionFormDto
            {
                InstructionDate = DateTime.ParseExact(instructionFormViewModel.FormCreateDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                InstructionShortContent = instructionFormViewModel.InstructionShortContent,
                InstructorFullName = instructionFormViewModel.InstructorFullName,
                InstructorOrganizationId = organizationId,
                InstructorOrganizationFullName = organizationName,
                InstructorPosition = instructionFormViewModel.InstructorPosition,
                InstructorUserId = instructorUserId,
                InstructionTypeId = Convert.ToInt32(instructionFormViewModel.InstructionType),
                InstructionTypeName = instructionFormViewModel.InstructionTypeName
            };

            InstructionFormResult = await _instructionFormService.Add(instructionFormDto);
            return InstructionFormResult;
        }

        public async Task AddToEmployeeForm(List<EmployeInfo> employeInfos)
        {
            EmployeeFormDto employeeFormDto = new EmployeeFormDto();
            foreach (var item in employeInfos)
            {
                employeeFormDto.EmployeeUserId = item.EmployeUserId;
                employeeFormDto.EmployeeFullName = item.EmployeFullName;
                employeeFormDto.EmployeePosition = item.EmployeePosition;
                employeeFormDto.InstructorComment = item.Note;
                employeeFormDto.InstructionFormId = InstructionFormResult.Id;
                var employeeFormResult = await _employeeFormService.Add(employeeFormDto);
            }
        }

        public async Task<InstructionFormDto> GetInstructionFormInfo(int id)
        {
            var result = await _instructionFormService.GetInstructionFormData(id);
            return result;
        }

        public async Task<IQueryable<EmployeeFormDto>> GetEmployeeFormInfo(int id)
        {
            var result = await _employeeFormService.GetEmployeesByFormId(id);
            return result;
        }

        public async Task<EmployeeFormDto> UpdateIsActiveOfEmployee(EmployeeFormDto dto)
        {
            var result = await _employeeFormService.Update(dto);
            return result;
        }

        public async Task<string> GetPhotoDate(int instructionFormId, int employeeUserId)
        {
            var result = await _employeeFormService.GetPhotoDateByInstructionFormId(instructionFormId, employeeUserId);
            if (result != null)
            {
                return result.Value.ToString("dd/MM/yyyy HH:mm");
            }

            return result.ToString();
        }

        public async Task<bool> CheckIfInstructionFormIdExist(int instructionFormId)
        {
            var result = await _employeeFormService.CheckIfInstructionFormIdExist(instructionFormId);
            return result;
        }
    }
}
