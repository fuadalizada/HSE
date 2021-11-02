using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<int> GetOrganizationIdByFincode(string fincode);
        Task<string> GetOrganizationFullNameByFincode(string fincode);
        Task<byte[]> GetUserPhotoByFincode(string fincode);
    }
}
