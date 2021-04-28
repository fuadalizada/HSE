using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HSE.Business.Services.Abstract;
using HSE.DAL.ViewModels;
using HSE.WebUI.Models;
using HSE.WebUI.ServiceFacade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTableParamsModel = HSE.DAL.ViewModels.DataTableParamsModel;

namespace HSE.WebUI.Controllers
{
    [Authorize]
    public class IncomingController : Controller
    {
        private readonly IInstructionFormService _instructionFormService;
        private readonly FormServiceFacade _formServiceFacade;
        public IncomingController(IInstructionFormService instructionFormService, FormServiceFacade formServiceFacade)
        {
            _instructionFormService = instructionFormService;
            _formServiceFacade = formServiceFacade;
        }
        [HttpGet]
        public IActionResult Income()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Income(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            int recordsFiltered = 0, recordsTotal = 0;

            List<ActiveFormsViewModel> data = new List<ActiveFormsViewModel>();

            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 3
            };

            Parallel.Invoke(parallelOptions, () =>
                {
                    Task.Run(async () =>
                    {
                        data.AddRange(await _instructionFormService.GetActiveForms(instructorUserId, jqueryDataTablesParameters));
                    }).Wait();
                },
                () =>
                {
                    Task.Run(async () =>
                    {
                        recordsTotal = await _instructionFormService.GetActiveFormsTotalCount(instructorUserId);
                    }).Wait();
                },
                () =>
                {
                    Task.Run(async () =>
                    {
                        recordsFiltered =
                            await _instructionFormService.GetActiveFormsFilteredCount(instructorUserId,jqueryDataTablesParameters);
                    }).Wait();
                }
            );
            return new JsonResult(new DataTableParamsModel.JqueryDataTablesResult<ActiveFormsViewModel>
            {
                Draw = jqueryDataTablesParameters.Draw,
                Data = data,
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            });
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveIncomingResult(int instructionFormId)
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
