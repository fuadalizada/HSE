using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class FormShortContentRepository:BaseRepository<FormShortContent>,IFormShortContentRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public FormShortContentRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<FormShortContent>> GetShortContentNames()
        {
            var result = await _context.Set<FormShortContent>().ToListAsync();
            return result.AsQueryable();
        }
    }
}
