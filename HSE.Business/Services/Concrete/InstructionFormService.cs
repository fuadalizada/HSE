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
    public class InstructionFormService :BaseService<InstructionFormDto,InstructionForm,IInstructionFormRepository>,IInstructionFormService
    {
        private readonly IInstructionFormRepository _repository;
        private readonly IMapper _mapper;
        public InstructionFormService(IInstructionFormRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public new async Task<InstructionFormDto> Add(InstructionFormDto dto)
        {
            var request = _mapper.Map<InstructionForm>(dto);
            var response = await _repository.Add(request);
            var result = _mapper.Map<InstructionFormDto>(response);
            return result;
        }

        public async Task<InstructionFormDto> GetInstructionFormData(int id)
        {
            var response = await _repository.GetInstructionFormData(id);
            var result = _mapper.Map<InstructionFormDto>(response);
            return result;
        }

        public async Task<List<ActiveFormsViewModel>> GetActiveForms(int instructorUserId,int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetActiveForms(instructorUserId ,userRoleId, organizationIds, jqueryDataTablesParameters);
            return result;
        }

        public async Task<int> GetActiveFormsTotalCount(int instructorUserId, int userRoleId, string organizationIds)
        {
            var result = await _repository.GetActiveFormsTotalCount(instructorUserId, userRoleId, organizationIds);
            return result;
        }

        public async Task<int> GetActiveFormsFilteredCount(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetActiveFormsFilteredCount(instructorUserId, userRoleId, organizationIds, jqueryDataTablesParameters);
            return result;
        }

        public async Task<List<AllFormsForHistoryViewModel>> GetAllFormsForHistory(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetAllFormsForHistory(instructorUserId, userRoleId, organizationIds, jqueryDataTablesParameters);
            return result;
        }

        public async Task<int> GetAllFormsForHistoryTotalCount(int instructorUserId, int userRoleId, string organizationIds)
        {
            var result = await _repository.GetAllFormsForHistoryTotalCount(instructorUserId, userRoleId, organizationIds);
            return result;
        }

        public async Task<int> GetAllFormsForHistoryFilteredCount(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetAllFormsForHistoryFilteredCount(instructorUserId , userRoleId, organizationIds, jqueryDataTablesParameters);
            return result;
        }

        public async Task<List<FormsReportViewModel>> GetFormsReport(int instructorUserId, string dateRange, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetFormsReport(instructorUserId, dateRange, userRoleId, organizationIds, jqueryDataTablesParameters);
            return result;
        }

        public async Task<int> GetFormsReportTotalCount(int instructorUserId, string dateRange, int userRoleId, string organizationIds)
        {
            var result = await _repository.GetFormsReportTotalCount(instructorUserId, dateRange, userRoleId, organizationIds);
            return result;
        }

        public async Task<int> GetFormsReportFilteredCount(int instructorUserId, string dateRange, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetFormsReportFilteredCount(instructorUserId, dateRange, userRoleId, organizationIds, jqueryDataTablesParameters);
            return result;
        }

        public async Task<int> GetInstructionFormIdByFormGuidId(string formGuidId)
        {
            var result = await _repository.GetInstructionFormIdByFormGuidId(formGuidId);
            return result;
        }
    }
}
