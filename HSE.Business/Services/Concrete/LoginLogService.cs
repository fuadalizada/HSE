using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class LoginLogService:BaseService<LoginLogDto,LoginLog,ILoginLogRepository>,ILoginLogService
    {
        private readonly ILoginLogRepository _repository;
        private readonly IMapper _mapper;
        public LoginLogService(ILoginLogRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoginLogDto> AddLog(LoginLogDto dto)
        {
            var entity = _mapper.Map<LoginLog>(dto);
            var response = await _repository.AddLog(entity);
            var result = _mapper.Map<LoginLogDto>(response);
            return result;
        }
    }
}
