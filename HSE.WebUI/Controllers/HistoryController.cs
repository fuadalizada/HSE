using System;
using HSE.Business.Services.Abstract;
using HSE.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HSE.WebUI.Models;
using HSE.WebUI.ServiceFacade;
using DataTableParamsModel = HSE.DAL.ViewModels.DataTableParamsModel;
using System.Linq;
using System.Security.Claims;
using HSE.Business.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace HSE.WebUI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HistoryController : Controller
    {
        private readonly IInstructionFormService _instructionFormService;
        private readonly FormServiceFacade _formServiceFacade;
        private readonly UserRoleServiceFacade _userRoleServiceFacade;
        private readonly IErrorLogsService _errorLogsService;
        public HistoryController(IInstructionFormService instructionFormService, FormServiceFacade formServiceFacade, UserRoleServiceFacade userRoleServiceFacade, IErrorLogsService errorLogsService)
        {
            _instructionFormService = instructionFormService;
            _formServiceFacade = formServiceFacade;
            _userRoleServiceFacade = userRoleServiceFacade;
            _errorLogsService = errorLogsService;
        }

        [HttpGet("AllFormsHistory")]
        public IActionResult AllFormsHistory()
        {
            return View();
        } 
        
        [HttpPost("AllFormsHistory")]
        public async Task<JsonResult> AllFormsHistory(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                int recordsFiltered = 0, recordsTotal = 0;

                var data = new List<AllFormsForHistoryViewModel>();

                var parallelOptions = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 3
                };

                if (User.IsInRole("WorkFlowBase"))
                {
                    Parallel.Invoke(parallelOptions, () =>
                    {
                        Task.Run(async () =>
                        {
                            data.AddRange(await _instructionFormService.GetAllFormsForHistory(instructorUserId, 3, string.Empty, jqueryDataTablesParameters));
                        }).Wait();
                    },
                        () =>
                        {
                            Task.Run(async () =>
                            {
                                recordsTotal = await _instructionFormService.GetAllFormsForHistoryTotalCount(instructorUserId, 3, string.Empty);
                            }).Wait();
                        },
                        () =>
                        {
                            Task.Run(async () =>
                            {
                                recordsFiltered =
                                    await _instructionFormService.GetAllFormsForHistoryFilteredCount(instructorUserId, 3, string.Empty, jqueryDataTablesParameters);
                            }).Wait();
                        }
                    );
                }
                else if (User.IsInRole("OrganizationBase"))
                {
                    List<string> organizationIdList = new List<string>();
                    var organizationIds = _userRoleServiceFacade.GetOrganizationIdsByUserId(instructorUserId);
                    if (organizationIds.Result.Any())
                    {
                        organizationIdList = _userRoleServiceFacade.GetOrganizationIdList(organizationIds);
                        var joinListAsString = string.Join(',', organizationIdList);
                        Parallel.Invoke(parallelOptions, () =>
                        {
                            Task.Run(async () =>
                            {
                                data.AddRange(await _instructionFormService.GetAllFormsForHistory(instructorUserId, 4, joinListAsString, jqueryDataTablesParameters));
                            }).Wait();
                        },
                            () =>
                            {
                                Task.Run(async () =>
                                {
                                    recordsTotal = await _instructionFormService.GetAllFormsForHistoryTotalCount(instructorUserId, 4, joinListAsString);
                                }).Wait();
                            },
                            () =>
                            {
                                Task.Run(async () =>
                                {
                                    recordsFiltered =
                                        await _instructionFormService.GetAllFormsForHistoryFilteredCount(instructorUserId, 4, joinListAsString, jqueryDataTablesParameters);
                                }).Wait();
                            }
                        );
                    }
                }
                else
                {
                    Parallel.Invoke(parallelOptions, () =>
                    {
                        Task.Run(async () =>
                        {
                            data.AddRange(await _instructionFormService.GetAllFormsForHistory(instructorUserId, 5, string.Empty, jqueryDataTablesParameters));
                        }).Wait();
                    },
                        () =>
                        {
                            Task.Run(async () =>
                            {
                                recordsTotal = await _instructionFormService.GetAllFormsForHistoryTotalCount(instructorUserId, 5, string.Empty);
                            }).Wait();
                        },
                        () =>
                        {
                            Task.Run(async () =>
                            {
                                recordsFiltered =
                                    await _instructionFormService.GetAllFormsForHistoryFilteredCount(instructorUserId, 5, string.Empty, jqueryDataTablesParameters);
                            }).Wait();
                        }
                    );
                }

                return new JsonResult(new DataTableParamsModel.JqueryDataTablesResult<AllFormsForHistoryViewModel>
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
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return null;
            }
        }

        [HttpPost("CheckIfInstructionFormIdExist")]
        public async Task<bool> CheckIfInstructionFormIdExist(int instructionFormId)
        {
            var result = await _formServiceFacade.CheckIfInstructionFormIdExist(instructionFormId);
            return result;
        }

        [HttpGet("RetrieveHistoryResult")]
        public async Task<IActionResult> RetrieveHistoryResult(int instructionFormId)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
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
    }
}
