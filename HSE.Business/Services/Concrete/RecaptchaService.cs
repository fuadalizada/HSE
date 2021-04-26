using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class RecaptchaService:BaseService<GoogleRespondDto,GoogleRespond,IRecaptchaRepository>,IRecaptchaService
    {
        private readonly IRecaptchaRepository _repository;
        private readonly IMapper _mapper;
        public RecaptchaService(IRecaptchaRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GoogleRespondDto> Verification(string token, string action = "")
        {
            var response = await _repository.Verification(token, action);
            var result = _mapper.Map<GoogleRespondDto>(response);
            return result;
        }
    }
}
