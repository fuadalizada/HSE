using System.Collections.Generic;
using System.Threading.Tasks;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User> GetUserInfoByUserId(int userId);
        Task<int> GetUserIdByFincode(string fincode);
        Task<List<WorkerInformationViewModel>> GetWorkerInformations(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<int> GetWorkerInformationsTotalCount();
        Task<int> GetWorkerInformationsFilteredCount(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters);
        Task<bool> CheckFincodeAndEmpUserId(string fincode, int employeeUserId);
    }
}
