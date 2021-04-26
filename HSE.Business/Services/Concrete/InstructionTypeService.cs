using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HSE.Business.Services.Concrete
{
    public class InstructionTypeService : BaseService<InstructionTypeDto, InstructionType, IInstructionTypeRepository>, IInstructionTypeService
    {
        private readonly IInstructionTypeRepository _repository;
        private readonly IMapper _mapper;
        public InstructionTypeService(IInstructionTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IQueryable<InstructionTypeDto>> GetActiveTypes()
        {
            var response = await _repository.GetActiveTypes();
            var result = _mapper.ProjectTo<InstructionTypeDto>(response);
            return result;
        }
    }
}
