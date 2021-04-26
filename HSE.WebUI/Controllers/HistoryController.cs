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

namespace HSE.WebUI.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IInstructionFormService _instructionFormService;
        private readonly FormServiceFacade _formServiceFacade;
        public HistoryController(IInstructionFormService instructionFormService, FormServiceFacade formServiceFacade)
        {
            _instructionFormService = instructionFormService;
            _formServiceFacade = formServiceFacade;
        }

        [HttpGet]
        public IActionResult AllFormsHistory()
        {
            return View();
        } 
        
        [HttpPost]
        public JsonResult AllFormsHistory(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            int recordsFiltered = 0, recordsTotal = 0;

            var data = new List<AllFormsForHistoryViewModel>();

            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 3
            };

            Parallel.Invoke(parallelOptions, () =>
                {
                    Task.Run(async () =>
                    {
                        data.AddRange(await _instructionFormService.GetAllFormsForHistory(instructorUserId, jqueryDataTablesParameters));
                    }).Wait();
                },
                () =>
                {
                    Task.Run(async () =>
                    {
                        recordsTotal = await _instructionFormService.GetAllFormsForHistoryTotalCount(instructorUserId);
                    }).Wait();
                },
                () =>
                {
                    Task.Run(async () =>
                    {
                        recordsFiltered =
                            await _instructionFormService.GetAllFormsForHistoryFilteredCount(instructorUserId, jqueryDataTablesParameters);
                    }).Wait();
                }
            );
            return new JsonResult(new DataTableParamsModel.JqueryDataTablesResult<AllFormsForHistoryViewModel>
            {
                Draw = jqueryDataTablesParameters.Draw,
                Data = data,
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            });
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveHistoryResult(int instructionFormId)
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
    }
}
