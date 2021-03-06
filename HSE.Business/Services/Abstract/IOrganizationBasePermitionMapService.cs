using System.Linq;
using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IOrganizationBasePermitionMapService:IBaseService<OrganizationBasePermitionMapDto>
    {
        Task<IQueryable<OrganizationBasePermitionMapDto>> GetOrganizationIdsByUserId(int employeeUserId);
    }
}
