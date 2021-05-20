using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;

namespace HSE.WebUI.ServiceFacade
{
    public class UserRoleServiceFacade
    {
        private readonly IOrganizationBasePermitionMapService _organizationBasePermitionMapService;
        private readonly IStructureService _structureService;
        public UserRoleServiceFacade(IStructureService structureService, IOrganizationBasePermitionMapService organizationBasePermitionMapService)
        {
            _structureService = structureService;
            _organizationBasePermitionMapService = organizationBasePermitionMapService;
        }

        public async Task<IQueryable<OrganizationBasePermitionMapDto>> GetOrganizationIdsByUserId(int employeeUserId)
        {
            var response = await _organizationBasePermitionMapService.GetOrganizationIdsByUserId(employeeUserId);
            return response;
        }

        public async Task<IQueryable<StructureDto>> GetChildOrganizationIdsByParentOrgId(int organizationId)
        {
            var response = await _structureService.GetChildOrganizationIdsByParentOrgId(organizationId);
            return response;
        }

        public async Task<StructureDto> GetOrganizationItself(int organizationId)
        {
            var response = await _structureService.GetOrganizationItself(organizationId);
            return response;
        }

        public List<string> GetOrganizationIdList(Task<IQueryable<OrganizationBasePermitionMapDto>> organizationIds)
        {
            List<string> organizationList = new List<string>();
            foreach (var item in organizationIds.Result)
            {
                var result = GetChildOrganizationIdsByParentOrgId(item.OrganizationId);
                if (!result.Result.Any())
                {
                    var childOrganizationItself = GetOrganizationItself(item.OrganizationId);
                    if (childOrganizationItself.Result.ChildOrganizationId != null)
                        organizationList.Add(childOrganizationItself.Result.ChildOrganizationId.Value.ToString());
                }
                else
                {
                    foreach (var itm in result.Result)
                    {
                        if (itm.ChildOrganizationId != null)
                            organizationList.Add(itm.ChildOrganizationId.Value.ToString());
                    }
                }
            }

            return organizationList;
        }
    }
}
