using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.Repositories.Abstract;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;

namespace HSE.Business.Services.Concrete
{
    public class UserService:BaseService<UserDto,User,IUserRepository>,IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserInfoByUserId(int userId)
        {
            var response = await _repository.GetUserInfoByUserId(userId);
            var result = _mapper.Map<UserDto>(response);
            return result;
        }

        public async Task<int> GetUserIdByFincode(string fincode)
        {
            var result = await _repository.GetUserIdByFincode(fincode);
            return result;
        }

        public async Task<List<WorkerInformationViewModel>> GetWorkerInformations(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetWorkerInformations(jqueryDataTablesParameters);
            return result;
        }

        public async Task<int> GetWorkerInformationsTotalCount()
        {
            var result = await _repository.GetWorkerInformationsTotalCount();
            return result;
        }

        public async Task<int> GetWorkerInformationsFilteredCount(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetWorkerInformationsFilteredCount(jqueryDataTablesParameters);
            return result;
        }

        public async Task<bool> CheckFincodeAndEmpUserId(string fincode,int employeeUserId)
        {
            var result = await _repository.CheckFincodeAndEmpUserId(fincode,employeeUserId);
            return result;
        }
    }
}
