using System;
using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public EmployeeRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetOrganizationIdByFincode(string fincode)
        {
            var result = await _context.Set<Employee>().Where(x => x.NationalIdentifier == fincode)
                .FirstOrDefaultAsync();
            return Convert.ToInt32(result.OrganizationId);
        }

        public async Task<string> GetOrganizationFullNameByFincode(string fincode)
        {
            var result = await _context.Set<Employee>().Where(x => x.NationalIdentifier == fincode)
                .FirstOrDefaultAsync();
            return result.OrganizationFullname;
        }

        public async Task<byte[]> GetUserPhotoByFincode(string fincode)
        {
            var result = await _context.Set<Employee>().Where(x => x.NationalIdentifier == fincode)
                .FirstOrDefaultAsync();
            return result.PhotoBinary;
        }
    }
}
