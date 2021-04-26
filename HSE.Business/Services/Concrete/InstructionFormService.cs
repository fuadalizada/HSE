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

        public async Task<List<ActiveFormsViewModel>> GetActiveForms(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetActiveForms(instructorUserId ,jqueryDataTablesParameters);
            return result;
        }

        public async Task<int> GetActiveFormsTotalCount(int instructorUserId)
        {
            var result = await _repository.GetActiveFormsTotalCount(instructorUserId);
            return result;
        }

        public async Task<int> GetActiveFormsFilteredCount(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetActiveFormsFilteredCount(instructorUserId,jqueryDataTablesParameters);
            return result;
        }

        public async Task<List<AllFormsForHistoryViewModel>> GetAllFormsForHistory(int instructorUserId, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetAllFormsForHistory(instructorUserId,jqueryDataTablesParameters);
            return result;
        }

        public async Task<int> GetAllFormsForHistoryTotalCount(int instructorUserId)
        {
            var result = await _repository.GetAllFormsForHistoryTotalCount(instructorUserId);
            return result;
        }

        public async Task<int> GetAllFormsForHistoryFilteredCount(int instructorUserId,DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var result = await _repository.GetAllFormsForHistoryFilteredCount(instructorUserId ,jqueryDataTablesParameters);
            return result;
        }
    }
}
