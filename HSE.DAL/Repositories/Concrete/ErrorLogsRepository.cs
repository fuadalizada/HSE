using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Concrete
{
    public class ErrorLogsRepository:BaseRepository<ErrorLog>,IErrorLogsRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public ErrorLogsRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddErrorLog(ErrorLog entity)
        {
            await _context.Set<ErrorLog>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
