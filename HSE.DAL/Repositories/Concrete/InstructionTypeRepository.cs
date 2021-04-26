using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class InstructionTypeRepository : BaseRepository<InstructionType>, IInstructionTypeRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public InstructionTypeRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<InstructionType>> GetActiveTypes()
        {
            var result = await _context.Set<InstructionType>().Where(x => x.IsActive == true).ToListAsync();
            return result.AsQueryable();
        }


    }
}
