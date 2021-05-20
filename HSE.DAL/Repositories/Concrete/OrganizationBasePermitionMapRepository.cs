using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class OrganizationBasePermitionMapRepository:BaseRepository<OrganizationBasePermitionMap>,IOrganizationBasePermitionMapRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public OrganizationBasePermitionMapRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<OrganizationBasePermitionMap>> GetOrganizationIdsByUserId(int employeeUserId)
        {
            var result = await _context.Set<OrganizationBasePermitionMap>().Where(x => x.UserId == employeeUserId).ToListAsync();
            return result.AsQueryable();
        }
    }
}
