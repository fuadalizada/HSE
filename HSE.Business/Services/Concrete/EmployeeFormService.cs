using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class EmployeeFormService:BaseService<EmployeeFormDto,EmployeeForm,IEmployeeFormRepository>,IEmployeeFormService
    {
        private readonly IEmployeeFormRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeFormService(IEmployeeFormRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public new async Task<EmployeeFormDto> Add(EmployeeFormDto dto)
        {
            var request = _mapper.Map<EmployeeForm>(dto);
            var response = await _repository.Add(request);
            var result = _mapper.Map<EmployeeFormDto>(response);
            return result;
        }

        public async Task<IQueryable<EmployeeFormDto>> GetEmployeesByFormId(int id)
        {
            var response = await _repository.GetEmployeesByFormId(id);
            var result = _mapper.ProjectTo<EmployeeFormDto>(response);
            return result;
        }

        public async Task<EmployeeFormDto> Update(EmployeeFormDto dto)
        {
            var request = _mapper.Map<EmployeeForm>(dto);
            var response = await _repository.Update(request);
            var result = _mapper.Map<EmployeeFormDto>(response);
            return result;
        }
    }
}
