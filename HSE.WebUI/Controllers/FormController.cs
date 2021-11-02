using System;
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
    [Route("[controller]")]
    public class FormController : Controller
    {
        private readonly IInstructionTypeService _instructionTypeService;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly IFormShortContentService _formShortContentService;
        private readonly FormServiceFacade _formServiceFacade;
        public InstructionFormDto InstructionFormResult;
        private readonly IErrorLogsService _errorLogsService;

        public FormController(IInstructionTypeService instructionTypeService, IUserService userService, IEmployeeService employeeService, IFormShortContentService formShortContentService,
            FormServiceFacade formServiceFacade, IErrorLogsService errorLogsService)
        {
            _instructionTypeService = instructionTypeService;
            _userService = userService;
            _employeeService = employeeService;
            _formServiceFacade = formServiceFacade;
            _formShortContentService = formShortContentService;
            _errorLogsService = errorLogsService;
        }

        [HttpGet("CreateForm")]
        public async Task<IActionResult> CreateForm()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
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
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = null,
                    UserId = userId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return NotFound();
            }

        }

        [HttpPost("GetFormContentListByInstructionType")]
        public async Task<List<FormShortContentDto>> GetFormContentListByInstructionType()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var formShortContentList = await _formShortContentService.GetShortContentNames();

                return formShortContentList.ToList();
            }
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = null,
                    UserId = userId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return null;
            }


        }

        [HttpPost("WorkerInformation")]
        public async Task<JsonResult> WorkerInformation(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
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
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = null,
                    UserId = userId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return null;
            }
        }

        [HttpPost("AddForms")]
        public async Task<int> AddForms(InstructionFormViewModel instructionFormViewModel)
        {
            var instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var employeInfos = JsonConvert.DeserializeObject<List<EmployeInfo>>(instructionFormViewModel.EmployeInfoListJsonString);
                var fincode = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                var organizationId = await _employeeService.GetOrganizationIdByFincode(fincode);
                var organizationName = await _employeeService.GetOrganizationFullNameByFincode(fincode);
                InstructionFormResult = await _formServiceFacade.AddToInstructionForm(instructionFormViewModel, organizationId,organizationName, instructorUserId);
                await _formServiceFacade.AddToEmployeeForm(employeInfos);

                return InstructionFormResult.Id;
            }
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = null,
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return 0;
            }
        }

        [HttpGet("RetrieveFormResult")]
        public async Task<IActionResult> RetrieveFormResult(int instructionFormId)
        {
            var instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
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
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = instructionFormId,
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return NotFound();
            }
            
        }

        [HttpPost("CheckIfFincodeAndEmpUserIdIsTrue")]
        public async Task<bool> CheckIfFincodeAndEmpUserIdIsTrue(string fincode, int employeeUserId)
        {
            var result = await _userService.CheckFincodeAndEmpUserId(fincode, employeeUserId);
#if DEBUG
            result = true;
#endif
            return result;
        }

        [HttpPost("UpdateEmployeeForm")]
        public async Task UpdateEmployeeForm(int instructionFormId, int employeeUserId)
        {
            var instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var dto = new EmployeeFormDto
                {
                    InstructionFormId = instructionFormId,
                    EmployeeUserId = employeeUserId
                };

                var result = await _formServiceFacade.UpdateIsActiveOfEmployee(dto);
            }
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = instructionFormId,
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
            }
           
        }

        [HttpPost("GetPhotoDate")]
        public async Task<string> GetPhotoDate(int instructionFormId, int employeeUserId)
        {
            var instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                string result = "";
                if (instructionFormId != 0 && employeeUserId != 0)
                {
                    result = await _formServiceFacade.GetPhotoDate(instructionFormId, employeeUserId);
                }

                if (result != null)
                {
                    return result;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = instructionFormId,
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return "";
            }
            
        }
    }
}
