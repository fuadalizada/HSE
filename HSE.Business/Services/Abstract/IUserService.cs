using System.Collections.Generic;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.DAL.ViewModels;

namespace HSE.Business.Services.Abstract
{
    public interface IUserService : IBaseService<UserDto>
    {
        Task<UserDto> GetUserInfoByUserId(int userId);
        Task<int> GetUserIdByFincode(string fincode);
        Task<List<WorkerInformationViewModel>> GetWorkerInformations(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetWorkerInformationsTotalCount();
        Task<int> GetWorkerInformationsFilteredCount(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<bool> CheckFincodeAndEmpUserId(string fincode, int employeeUserId);
    }
}
