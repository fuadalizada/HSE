using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.ViewModels;
using HSE.WebUI.Models;
using HSE.WebUI.ServiceFacade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DataTableParamsModel = HSE.DAL.ViewModels.DataTableParamsModel;

namespace HSE.WebUI.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        private readonly IInstructionTypeService _instructionTypeService;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly FormServiceFacade _formServiceFacade;
        public InstructionFormDto InstructionFormResult;

        public FormController(IInstructionTypeService instructionTypeService, IUserService userService, IEmployeeService employeeService, FormServiceFacade formServiceFacade)
        {
            _instructionTypeService = instructionTypeService;
            _userService = userService;
            _employeeService = employeeService;
            _formServiceFacade = formServiceFacade;
        }

        [HttpGet]
        public async Task<IActionResult> CreateForm()
        {
            var firstName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var lastName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
            var instructorPosition = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)?.Value;
            
            var instructionTypeList = await _instructionTypeService.GetActiveTypes();
            var createFormViewModel = new CreateFormViewModel
            {
                InstructorFullName = $"{firstName} {lastName}",
                InstructorPosition = instructorPosition,
                InstructionFormDtos = instructionTypeList.ToList()
            };
            return View(createFormViewModel);
        }

        [HttpPost]
        public JsonResult WorkerInformation(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            int recordsFiltered = 0, recordsTotal = 0;

            List<WorkerInformationViewModel> data = new List<WorkerInformationViewModel>();

            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 3
            };

            Parallel.Invoke(parallelOptions, () =>
                 {
                     Task.Run(async () =>
                     {
                         data.AddRange(await _userService.GetWorkerInformations(jqueryDataTablesParameters));
                     }).Wait();
                 },
                    () =>
                    {
                        Task.Run(async () =>
                        {
                            recordsTotal = await _userService.GetWorkerInformationsTotalCount();
                        }).Wait();
                    },
                    () =>
                    {
                        Task.Run(async () =>
                        {
                            recordsFiltered =
                                await _userService.GetWorkerInformationsFilteredCount(jqueryDataTablesParameters);
                        }).Wait();
                    }
            );
            return new JsonResult(new DataTableParamsModel.JqueryDataTablesResult<WorkerInformationViewModel>
            {
                Draw = jqueryDataTablesParameters.Draw,
                Data = data,
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            });
        }

        [HttpPost]
        public async Task<int> AddForms(InstructionFormViewModel instructionFormViewModel)
        {
            var employeInfos = JsonConvert.DeserializeObject<List<EmployeInfo>>(instructionFormViewModel.EmployeInfoListJsonString);
            var fincode = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var instructorUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value;
            
            var organizationId = await _employeeService.GetOrganizationIdByFincode(fincode);
            
            InstructionFormResult = await _formServiceFacade.AddToInstructionForm(instructionFormViewModel, organizationId, instructorUserId);
            await _formServiceFacade.AddToEmployeeForm(employeInfos);

            return InstructionFormResult.Id;
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveFormResult(int instructionFormId)
        {
            var instructionFormData = await _formServiceFacade.GetInstructionFormInfo(instructionFormId);
            var employeeFormData = await _formServiceFacade.GetEmployeeFormInfo(instructionFormId);
            
            var retrieveFormResultViewModel = new RetrieveFormResultViewModel
            {
                InstructionFormDto = instructionFormData,
                EmployeeFormDtos = employeeFormData.ToList()
            };
            return View(retrieveFormResultViewModel);
        }

        [HttpPost]
        public async Task<bool> CheckIfFincodeAndEmpUserIdIsTrue(string fincode,int employeeUserId)
        {
            var result = await _userService.CheckFincodeAndEmpUserId(fincode, employeeUserId);
#if DEBUG
            result = true;
#endif
            return result;
        }

        [HttpPost]
        public async Task UpdateEmployeeForm(int instructionFormId,int employeeUserId)
        {
            var dto = new EmployeeFormDto
            {
                InstructionFormId = instructionFormId,
                EmployeeUserId = employeeUserId
            };

            var result = await _formServiceFacade.UpdateIsActiveOfEmployee(dto);
        }
    }
}
