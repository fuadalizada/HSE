using System.Linq;
using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IOrganizationBasePermitionMapRepository:IBaseRepository<OrganizationBasePermitionMap>
    {
        Task<IQueryable<OrganizationBasePermitionMap>> GetOrganizationIdsByUserId(int employeeUserId);
    }
}
