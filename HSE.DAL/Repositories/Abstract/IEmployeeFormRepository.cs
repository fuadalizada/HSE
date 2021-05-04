using System;
using System.Linq;
using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IEmployeeFormRepository : IBaseRepository<EmployeeForm>
    {
        Task<IQueryable<EmployeeForm>> GetEmployeesByFormId(int id);
        Task<EmployeeForm> Update(EmployeeForm entity);
        Task<bool> CheckIfAllEmpFormsClosed(int instructionFormId);
        Task<DateTime?> GetPhotoDateByInstructionFormId(int instructionFormId,int employeeUserId);
    }
}
