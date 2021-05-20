using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class StructureRepository:BaseRepository<Structure>,IStructureRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public StructureRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Structure>> GetChildOrganizationIdsByParentOrgId(int organizationId)
        {
            var result = await _context.Set<Structure>().Where(x => x.ParentOrganizationId == organizationId)
                .ToListAsync();
            return result.AsQueryable();
        }

        public async Task<Structure> GetOrganizationItself(int organizationId)
        {
            var result = await _context.Set<Structure>().Where(x => x.ChildOrganizationId == organizationId & x.LevelDifference==1).FirstOrDefaultAsync();
            return result;
        }
    }
}
