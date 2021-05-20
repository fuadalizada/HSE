using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class OrganizationBasePermitionMapService:BaseService<OrganizationBasePermitionMapDto,OrganizationBasePermitionMap,IOrganizationBasePermitionMapRepository>,IOrganizationBasePermitionMapService
    {
        private readonly IOrganizationBasePermitionMapRepository _repository;
        private readonly IMapper _mapper;
        public OrganizationBasePermitionMapService(IOrganizationBasePermitionMapRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IQueryable<OrganizationBasePermitionMapDto>> GetOrganizationIdsByUserId(int employeeUserId)
        {
            var response = await _repository.GetOrganizationIdsByUserId(employeeUserId);
            var result = _mapper.ProjectTo<OrganizationBasePermitionMapDto>(response);
            return result;
        }
    }
}
