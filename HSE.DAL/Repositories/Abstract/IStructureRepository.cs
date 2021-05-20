using System.Linq;
using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IStructureRepository:IBaseRepository<Structure>
    {
        Task<IQueryable<Structure>> GetChildOrganizationIdsByParentOrgId(int organizationId);
        Task<Structure> GetOrganizationItself(int organizationId);
    }
}
