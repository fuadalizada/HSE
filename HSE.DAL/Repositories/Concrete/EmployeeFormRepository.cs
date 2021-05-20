using System;
using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class EmployeeFormRepository :BaseRepository<EmployeeForm>,IEmployeeFormRepository
    {
        private readonly IInstructionFormRepository _instructionFormRepository;
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public EmployeeFormRepository(HseDbContext context, IInstructionFormRepository instructionFormRepository) : base(context)
        {
            _context = context;
            _instructionFormRepository = instructionFormRepository;
        }

        public new async Task<EmployeeForm> Add(EmployeeForm enEmployeeForm)
        {
            var result = await _context.AddAsync(enEmployeeForm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IQueryable<EmployeeForm>> GetEmployeesByFormId(int id)
        {
            var result = await _context.Set<EmployeeForm>().Where(x => x.InstructionFormId == id).ToListAsync();
            return result.AsQueryable();
        }

        public async Task<EmployeeForm> Update(EmployeeForm entity)
        {
            var result = await _context.Set<EmployeeForm>().Where(x => x.InstructionFormId == entity.InstructionFormId & x.EmployeeUserId == entity.EmployeeUserId & x.IsActive==true).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false;
                result.PhotoTakingDate = DateTime.Now;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }

            var isFormClosed = await CheckIfAllEmpFormsClosed(entity.InstructionFormId);
            if (isFormClosed)
            {
               await _instructionFormRepository.UpdateIsActiveByInstructionFormId(entity.InstructionFormId);
            }
            return entity;
        }

        public async Task<bool> CheckIfAllEmpFormsClosed(int instructionFormId)
        {
            var result = await _context.Set<EmployeeForm>().Where(x => x.InstructionFormId == instructionFormId).ToListAsync();
            foreach (var item in result)
            {
                if (item.IsActive == true)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<DateTime?> GetPhotoDateByInstructionFormId(int instructionFormId, int employeeUserId)
        {
            var result = await _context.Set<EmployeeForm>()
                .Where(x => x.InstructionFormId == instructionFormId & x.EmployeeUserId == employeeUserId & x.IsActive == false)
                .FirstOrDefaultAsync();
            return result.PhotoTakingDate;
        }

        public async Task<bool> CheckIfInstructionFormIdExist(int instructionFormId)
        {
            var result = await _context.Set<EmployeeForm>().Where(x => x.InstructionFormId == instructionFormId)
                .FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
