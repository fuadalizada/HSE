using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;

namespace HSE.Business.Services.Concrete
{
    public class BaseService<TDto, TEntity, TRepository> : IBaseService<TDto>
        where TDto : class, new()
        where TEntity : class, new()
        where TRepository : IBaseRepository<TEntity>
    {

        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public BaseService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IQueryable<TDto>> GetAll()
        {
            var response = await _repository.GetAll();
            var result = _mapper.ProjectTo<TDto>(response);
            return result;
        }

        public async Task<TDto> Add(TDto dto)
        {
            var request = _mapper.Map<TEntity>(dto);
            var response = await _repository.Add(request);
            var result = _mapper.Map<TDto>(response);
            return result;
        }
    }
}
