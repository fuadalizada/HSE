using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Concrete
{
    public class LoginLogRepository:BaseRepository<LoginLog>,ILoginLogRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public LoginLogRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LoginLog> AddLog(LoginLog entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
