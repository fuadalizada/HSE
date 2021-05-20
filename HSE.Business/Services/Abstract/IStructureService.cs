using System.Linq;
using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IStructureService:IBaseService<StructureDto>
    {
        Task<IQueryable<StructureDto>> GetChildOrganizationIdsByParentOrgId(int organizationId);
        Task<StructureDto> GetOrganizationItself(int organizationId);
    }
}
