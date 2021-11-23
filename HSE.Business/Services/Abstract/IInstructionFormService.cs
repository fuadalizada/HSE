using System.Collections.Generic;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.DAL.ViewModels;

namespace HSE.Business.Services.Abstract
{
    public interface IInstructionFormService :IBaseService<InstructionFormDto>
    {
        Task<InstructionFormDto> GetInstructionFormData(int id);
        Task<List<ActiveFormsViewModel>> GetActiveForms(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetActiveFormsTotalCount(int instructorUserId, int userRoleId, string organizationIds);
        Task<int> GetActiveFormsFilteredCount(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<List<AllFormsForHistoryViewModel>> GetAllFormsForHistory(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetAllFormsForHistoryTotalCount(int instructorUserId, int userRoleId, string organizationIds);
        Task<int> GetAllFormsForHistoryFilteredCount(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<List<FormsReportViewModel>> GetFormsReport(int instructorUserId, string dateRange, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetFormsReportTotalCount(int instructorUserId, string dateRange, int userRoleId, string organizationIds);
        Task<int> GetFormsReportFilteredCount(int instructorUserId, string dateRange, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetInstructionFormIdByFormGuidId(string formGuidId);
    }
}
