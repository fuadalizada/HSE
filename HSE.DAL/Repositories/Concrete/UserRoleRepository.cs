using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class UserRoleRepository:BaseRepository<UserRole>,IUserRoleRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public UserRoleRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetUserRoleByUserId(int userId)
        {
            var result = await _context.Set<UserRole>().Where(x => x.UserId == userId & x.IsActive == true).FirstOrDefaultAsync();
            return result.Role;
        }
    }
}
