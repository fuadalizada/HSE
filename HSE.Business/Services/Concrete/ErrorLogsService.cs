using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class ErrorLogsService:BaseService<ErrorLogDto,ErrorLog,IErrorLogsRepository>,IErrorLogsService
    {
        private readonly IErrorLogsRepository _errorLogsRepository;
        private readonly IMapper _mapper;
        public ErrorLogsService(IErrorLogsRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _errorLogsRepository = repository;
            _mapper = mapper;
        }

        public async Task AddErrorLog(ErrorLogDto dto)
        {
            var request = _mapper.Map<ErrorLog>(dto);
            await _errorLogsRepository.AddErrorLog(request);
        }
    }
}
