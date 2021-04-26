using System.Collections.Generic;
using System.Threading.Tasks;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IInstructionFormRepository : IBaseRepository<InstructionForm>
    {
        Task<InstructionForm> GetInstructionFormData(int id);
        Task<List<ActiveFormsViewModel>> GetActiveForms(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetActiveFormsTotalCount(int instructorUserId);
        Task<int> GetActiveFormsFilteredCount(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<List<AllFormsForHistoryViewModel>> GetAllFormsForHistory(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetAllFormsForHistoryTotalCount(int instructorUserId);
        Task<int> GetAllFormsForHistoryFilteredCount(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<InstructionForm> UpdateIsActiveByInstructionFormId(int instructionFormId);
    }
}
