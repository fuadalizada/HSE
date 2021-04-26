using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class EmployeeService:BaseService<EmployeeDto,Employee,IEmployeeRepository>,IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> GetOrganizationIdByFincode(string fincode)
        {
            var result = await _repository.GetOrganizationIdByFincode(fincode);
            return result;
        }
    }
}
