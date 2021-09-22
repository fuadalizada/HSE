using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HSE.Business.Services.Abstract;
using HSE.DAL.ViewModels;
using HSE.WebUI.ServiceFacade;
using Microsoft.AspNetCore.Mvc;

namespace HSE.WebUI.Controllers
{
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IInstructionFormService _instructionFormService;
        private readonly UserRoleServiceFacade _userRoleServiceFacade;

        public ReportController(IInstructionFormService instructionFormService, UserRoleServiceFacade userRoleServiceFacade)
        {
            _instructionFormService = instructionFormService;
            _userRoleServiceFacade = userRoleServiceFacade;
        }

        [HttpGet("ReportIndex")]
        public IActionResult ReportIndex()
        {
            return View();
        }

        [HttpPost("ReportIndex")]
        public JsonResult ReportIndex(string dateRange,DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            int recordsFiltered = 0, recordsTotal = 0;

            if (string.IsNullOrEmpty(dateRange))
            {
                dateRange = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy") + "-" + DateTime.Now.ToString("dd/MM/yyyy");
            }
            else if (dateRange.Contains("Invalid date - Invalid date") || dateRange.Contains("Hamısı"))
            {
                dateRange = SqlDateTime.MinValue.Value.ToString("dd/MM/yyyy") + "-" + DateTime.Now.ToString("dd/MM/yyyy");
            }

            var data = new List<FormsReportViewModel>();

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
                        data.AddRange(await _instructionFormService.GetFormsReport(instructorUserId,dateRange, 3, string.Empty, jqueryDataTablesParameters));
                    }).Wait();
                },
                    () =>
                    {
                        Task.Run(async () =>
                        {
                            recordsTotal = await _instructionFormService.GetFormsReportTotalCount(instructorUserId, dateRange, 3, string.Empty);
                        }).Wait();
                    },
                    () =>
                    {
                        Task.Run(async () =>
                        {
                            recordsFiltered =
                                await _instructionFormService.GetFormsReportFilteredCount(instructorUserId, dateRange, 3, string.Empty, jqueryDataTablesParameters);
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
                            data.AddRange(await _instructionFormService.GetFormsReport(instructorUserId, dateRange, 4, joinListAsString, jqueryDataTablesParameters));
                        }).Wait();
                    },
                        () =>
                        {
                            Task.Run(async () =>
                            {
                                recordsTotal = await _instructionFormService.GetFormsReportTotalCount(instructorUserId, dateRange, 4, joinListAsString);
                            }).Wait();
                        },
                        () =>
                        {
                            Task.Run(async () =>
                            {
                                recordsFiltered =
                                    await _instructionFormService.GetFormsReportFilteredCount(instructorUserId, dateRange, 4, joinListAsString, jqueryDataTablesParameters);
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
                        data.AddRange(await _instructionFormService.GetFormsReport(instructorUserId, dateRange, 5, string.Empty, jqueryDataTablesParameters));
                    }).Wait();
                },
                    () =>
                    {
                        Task.Run(async () =>
                        {
                            recordsTotal = await _instructionFormService.GetFormsReportTotalCount(instructorUserId, dateRange, 5, string.Empty);
                        }).Wait();
                    },
                    () =>
                    {
                        Task.Run(async () =>
                        {
                            recordsFiltered =
                                await _instructionFormService.GetFormsReportFilteredCount(instructorUserId, dateRange, 5, string.Empty, jqueryDataTablesParameters);
                        }).Wait();
                    }
                );
            }

            return new JsonResult(new DataTableParamsModel.JqueryDataTablesResult<FormsReportViewModel>
            {
                Draw = jqueryDataTablesParameters.Draw,
                Data = data,
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            });
        }
    }
}
