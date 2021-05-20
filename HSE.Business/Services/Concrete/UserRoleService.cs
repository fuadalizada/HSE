using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class UserRoleService:BaseService<UserRoleDto,UserRole,IUserRoleRepository>,IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IMapper _mapper;
        public UserRoleService(IUserRoleRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> GetUserRoleByUserId(int userId)
        {
            var result = await _repository.GetUserRoleByUserId(userId);
            return result;
        }
    }
}
