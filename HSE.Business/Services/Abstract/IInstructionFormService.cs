using System.Collections.Generic;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.DAL.ViewModels;

namespace HSE.Business.Services.Abstract
{
    public interface IInstructionFormService :IBaseService<InstructionFormDto>
    {
        Task<InstructionFormDto> GetInstructionFormData(int id);
        Task<List<ActiveFormsViewModel>> GetActiveForms(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetActiveFormsTotalCount(int instructorUserId);
        Task<int> GetActiveFormsFilteredCount(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<List<AllFormsForHistoryViewModel>> GetAllFormsForHistory(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetAllFormsForHistoryTotalCount(int instructorUserId);
        Task<int> GetAllFormsForHistoryFilteredCount(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
    }
}
