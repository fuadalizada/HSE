using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class FormShortContentService:BaseService<FormShortContentDto,FormShortContent,IFormShortContentRepository>,IFormShortContentService
    {
        private readonly IFormShortContentRepository _formShortContentRepository;
        private readonly IMapper _mapper;
        public FormShortContentService(IFormShortContentRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _formShortContentRepository = repository;
            _mapper = mapper;
        }

        public async Task<IQueryable<FormShortContentDto>> GetShortContentNames()
        {
            var request = await _formShortContentRepository.GetShortContentNames();
            var response = _mapper.ProjectTo<FormShortContentDto>(request);
            return response;
        }
    }
}
