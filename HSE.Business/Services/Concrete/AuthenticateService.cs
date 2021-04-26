using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class AuthenticateService : BaseService<AuthenticateDto, Authenticate, IAuthenticateRepository>, IAuthenticateService
    {
        private readonly IAuthenticateRepository _repository;
        private readonly IMapper _mapper;
        public AuthenticateService(IAuthenticateRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthenticateDto> Authenticate(LoginViewModel model, string remoteIpAddress)
        {
            var response = await _repository.Authenticate(model, remoteIpAddress);
            var result = _mapper.Map<AuthenticateDto>(response);
            return result;
        }
    }
}
