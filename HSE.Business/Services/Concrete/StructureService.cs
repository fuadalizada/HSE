using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class StructureService:BaseService<StructureDto,Structure,IStructureRepository>,IStructureService
    {
        private readonly IStructureRepository _repository;
        private readonly IMapper _mapper;
        public StructureService(IStructureRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IQueryable<StructureDto>> GetChildOrganizationIdsByParentOrgId(int organizationId)
        {
            var response = await _repository.GetChildOrganizationIdsByParentOrgId(organizationId);
            var result = _mapper.ProjectTo<StructureDto>(response);
            return result;
        }

        public async Task<StructureDto> GetOrganizationItself(int organizationId)
        {
            var response = await _repository.GetOrganizationItself(organizationId);
            var result = _mapper.Map<StructureDto>(response);
            return result;
        }
    }
}
