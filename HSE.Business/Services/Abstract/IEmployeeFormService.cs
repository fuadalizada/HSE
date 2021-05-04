using System;
using System.Linq;
using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IEmployeeFormService:IBaseService<EmployeeFormDto>
    {
        Task<IQueryable<EmployeeFormDto>> GetEmployeesByFormId(int id);
        Task<EmployeeFormDto> Update(EmployeeFormDto dto);
        Task<DateTime?> GetPhotoDateByInstructionFormId(int instructionFormId, int employeeUserId);
    }
}
